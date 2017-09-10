using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using NAudio.Lame;


namespace RecorderLib
{
    internal class Recorder
    {
        //0-ручной режим
        //1- с нарезкой по таймеру
        //2- с нарезкой по таймеру и выравниванием по интервалу
        public byte RecordMode { get; set; } = 0;
        public long TotalRecordTime { get; private set; }
        public long CurrentPartRecordTime { get; private set; }

        public int CuttingInterval
        {
            get { return _cuttingInterval; }
            set
            {
                if (value <= 3600)
                {
                    _cuttingInterval = value;
                }
                else
                {
                    _cuttingInterval = 3600;
                }
            }
        }

        public int AligningInterval
        {
            get { return _aligningInterval; }
            set
            {
                if (value < 3600)
                {
                    _aligningInterval = value;
                }
                else
                {
                    _aligningInterval = 0;
                }
            }
        }

        public string RecorderName { get; set; }

        public string FolderTemplate
        {
            get { return _targetFolderTemplate; }
            set
            {
                if (!value.EndsWith("\\"))
                {
                    _targetFolderTemplate = value + "\\";
                }
                else
                {
                    _targetFolderTemplate = value;
                }
            }
        }

        public string FileNameTemplate { get; set; }

        public string Format
        {
            get { return _format; }
            set
            {
                if ((Status != "Recording") & (Status != "Error"))
                {
                    if ((value.ToLower() == "mp3") || (value.ToLower() == "wav"))
                    {
                        _format = value.ToLower();
                    }
                }

            }
        }

        public byte Channels
        {
            get { return _channels; }
            set { _channels = (byte) (value == 2 ? 2 : 1); }
        }

        public byte BitSample
        {
            get { return _bitsample; }
            set { _bitsample = (byte) (value == 16 ? 16 : 8); }
        }

        public int Freq
        {
            get { return _freq; }
            set
            {
                if (value == 5000 || value == 8000 || value == 11025 || value == 22050 || value == 44100 ||
                    value == 48000 || value == 88200 || value == 96000 || value == 192000)
                {
                    _freq = value;

                }
                else
                {
                    _freq = 44100;
                }
            }
        }

        public string FullFilename { get; private set; }
        public string Status { get; private set; }
        public string Description { get; private set; }
        public MMDeviceCollection Devices { get; private set; }
        public MMDevice DefaultDevice { get; private set; }

        private byte _channels = 2;
        private byte _bitsample = 16;
        private int _freq = 44100;
        private string _format = "mp3";
        private string _targetFolderTemplate;
        private MMDevice _device;
        private WasapiCapture waveIn;
        private object _writer;
        private Timer _totalRecordTimer, _cuttingTimer, _aligningTimer;
        private int _cuttingInterval = 3600;
        private int _aligningInterval = 0;
        private int _selectedDevice;
        private bool _monitoring = true;

        public delegate void StatusChangedEventHandler(object sender, EventArgs e);

        public event StatusChangedEventHandler StatusChanged;

        public delegate void LevelChangedEventHandler(object sender, LevelChangedEventArgs e);

        public event LevelChangedEventHandler LevelChanged;

        public delegate void RecordTimerTickEventHandler(object sender, EventArgs e);

        public event RecordTimerTickEventHandler RecordTimerTick;

        public Recorder()
        {


            var enumerator = new MMDeviceEnumerator();
            DefaultDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia);
            Devices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            if (Devices.Count == 0)
            {
                ChangeStatus("Error", "Не найдено ни одно устройства записи");
                return;
            }

            _totalRecordTimer = new Timer {Interval = 1000};
            _totalRecordTimer.Tick += _totalRecordTimer_Tick;
            ChangeStatus("Inited");

        }

        private void _totalRecordTimer_Tick(object sender, EventArgs e)
        {
            if (TotalRecordTime < long.MaxValue)
            {
                TotalRecordTime++;

            }
            else
            {
                TotalRecordTime = 0;
            }
            CurrentPartRecordTime --;
            RecordTimerTick?.Invoke(this, EventArgs.Empty);
        }

        private bool OpenFile()
        {
            var f = ResolveName(_targetFolderTemplate + FileNameTemplate);
            var fn = f + "." + _format;
            if (!File.Exists(fn))
            {
                FullFilename = fn;
            }
            else
            {
                var i = 1;
                while (File.Exists(f + "-" + i + "." + _format))
                {
                    i++;
                }
                FullFilename = f + "-" + i + "." + _format;
            }
            try
            {
                //Console.WriteLine(_device.AudioMeterInformation.MasterPeakValue );
                
                if (!Directory.Exists(ResolveName(_targetFolderTemplate)))
                {
                    Directory.CreateDirectory(ResolveName(_targetFolderTemplate));
                }
                switch (_format)
                {
                    case "mp3":
                        _writer = new LameMP3FileWriter(FullFilename, waveIn.WaveFormat, LAMEPreset.ABR_320);
                        break;
                    case "wav":
                        _writer = new WaveFileWriter(FullFilename, waveIn.WaveFormat);
                        break;
                }
                return true;
            }
            catch (Exception e)
            {
                ChangeStatus("Error", e.Message);
                return false;

            }


        }

        
        public void StartRecord(int devicenumber, bool mon = false)
        {
            _monitoring = mon;
            _selectedDevice = devicenumber;

            

            if (devicenumber == -1)
            {
                _device = DefaultDevice;
            }
            else if ((devicenumber >= 0) && (devicenumber < Devices.Count))
            {
                _device = Devices[devicenumber];

            }

            else
            {
                ChangeStatus("Error", "Выбрано некорректное устройство записи");
                return;
            }
            if (waveIn == null)
            {
                waveIn = new WasapiCapture(_device);
                //waveIn.ShareMode = AudioClientShareMode.Exclusive;
                waveIn.ShareMode = AudioClientShareMode.Shared;
                waveIn.DataAvailable += waveIn_DataAvailable;
                waveIn.RecordingStopped += waveIn_RecordingStopped;
                waveIn.WaveFormat = new WaveFormat(_freq, _bitsample, _channels);
            }
            
            
            if (!_monitoring)
            {
                if (!OpenFile())
                {
                    return;
                }
            }
            // не удалять! Не знаю почему, но без этого не работает.
            var magic = _device.AudioMeterInformation.MasterPeakValue;

            try
            {
                if (waveIn?.CaptureState != CaptureState.Capturing)
                {
                    waveIn.StartRecording();
                }
                
                if(!_monitoring)
                { 
                _totalRecordTimer.Start();
                ChangeStatus("Recording", "Запись в процессе");
                switch (RecordMode)
                {
                    case 1:
                    {
                        if (_cuttingTimer == null)
                        {
                            InitCuttingTimer();
                            _cuttingTimer.Start();
                        }
                        
                            break;
                    }
                    case 2:
                    {
                        if (_aligningTimer == null)
                        {
                            InitCuttingTimer();
                            InitAligningTimer();
                            _aligningTimer.Start();
                        }
                        break;
                    }

                }
                }
            }
            catch (Exception e)
            {
                StopRecord();
                ChangeStatus("Error", e.Message);

            }
        }

        private void InitCuttingTimer()
        {
            _cuttingTimer = new Timer { Interval = _cuttingInterval * 1000 };
            _cuttingTimer.Tick += _cuttingTimer_Tick;
        }

        private void InitAligningTimer()
        {
            var dt = DateTime.Now;
            CurrentPartRecordTime = (3600 - dt.Minute * 60 - dt.Second + _aligningInterval) % _cuttingInterval;
            _aligningTimer = new Timer { Interval = (int)CurrentPartRecordTime * 1000};
            _aligningTimer.Tick += _aligningTimer_Tick;
            
        }

        private void _aligningTimer_Tick(object sender, EventArgs e)
        {
            RestartRecord();
            _cuttingTimer.Start();
            _aligningTimer.Stop();
        }

        private void _cuttingTimer_Tick(object sender, EventArgs e)
        {
            RestartRecord();
            
        }

        public void StopRecord()
        {
            try
            {
                _totalRecordTimer?.Stop();
                _cuttingTimer?.Dispose();
                _aligningTimer?.Dispose();
                waveIn.StopRecording();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        private void RestartRecord()
        {
            waveIn.StopRecording();
            StartRecord(_selectedDevice,false);
            CurrentPartRecordTime = _cuttingInterval;
        }

        private void CloseWriter(object w)
        {
            
            switch (_format)
            {
                case "wav":
                {
                    ((WaveFileWriter)w).Close();
                    ((WaveFileWriter)w).Dispose();
                    break;
                }
                case "mp3":
                {
                    ((LameMP3FileWriter)w).Close();
                    ((LameMP3FileWriter)w).Dispose();
                    break;
                }
            
            }
        }

        private void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
          
                try
                {
                    if (!_monitoring)
                    {
                    switch (_format)
                    {
                        case "mp3":
                            ((LameMP3FileWriter)_writer).Write(e.Buffer, 0, e.BytesRecorded);
                            break;
                        case "wav":
                            ((WaveFileWriter)_writer).Write(e.Buffer, 0, e.BytesRecorded);
                            break;
                    }
                    }

                
                
                //Console.WriteLine(_device.AudioMeterInformation .MasterPeakValue);
                if (waveIn.WaveFormat.Channels == 2)
                {
                   LevelChanged?.Invoke(this, new LevelChangedEventArgs((int)(Math.Round(_device.AudioMeterInformation.PeakValues[0] * 100)), (int)(Math.Round(_device.AudioMeterInformation.PeakValues[1] * 100))));
                }
                else
                {
                   LevelChanged?.Invoke(this, new LevelChangedEventArgs((int)(Math.Round(_device.AudioMeterInformation.PeakValues[0] * 100)), (int)(Math.Round(_device.AudioMeterInformation.PeakValues[0] * 100))));
                }
            }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    StopRecord();
                    ChangeStatus("Error", ex.Message);
                
                }
            }

        private void waveIn_RecordingStopped(object sender, EventArgs e)
        {
            
            waveIn.Dispose();
            //waveIn = null;
            if (_writer != null)
            {
                CloseWriter(_writer);
                
            }
            ChangeStatus("Stop", "Запись остановлена");
        }

        private void ChangeStatus(string status, string description = "")
        {
            Status = status;
            Description = description;
            StatusChanged?.Invoke(this, EventArgs.Empty);
        }

        public string ResolveName(string nametemplate)
        {
            var n = DateTime.Now;
            return nametemplate
                .Replace("%YYYY", $"{n:yyyy}")
                .Replace("%YY", $"{n:yy}")
                .Replace("%MMMM", $"{n:MMMM}")
                .Replace("%MM", $"{n:MM}")
                .Replace("%DD", $"{n:dd}")
                .Replace("%hh", $"{n:HH}")
                .Replace("%mm", $"{n:mm}")
                .Replace("%ss", $"{n:ss}")
                .Replace("%dow", $"{n:dddd}")
                .Replace("%cn", RecorderName);

        }


    }

    public class LevelChangedEventArgs : System.EventArgs
    {
        //public LevelChangedEventArgs(bool cancel, int level_left, int level_right)
        public LevelChangedEventArgs(int level_left, int level_right)
        //: base(cancel)
        {
            LevelLeft = level_left;
            LevelRight = level_right;
        }

        public int  LevelLeft { get; set; }
        public int LevelRight { get; set; }
    }

}
