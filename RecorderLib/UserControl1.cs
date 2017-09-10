using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using NAudio.Wave;


namespace RecorderLib
{
    public partial class mainPanel: UserControl
    {
        private Options _options;
        private Recorder _recorder;
        public int BarLeft
        {
            get { return PB_Left.Value;}
            set { PB_Left.Value = value;}
        }
        public int BarRight
        {
            get { return PB_Right.Value; }
            set { PB_Right.Value = value; }
        }
        public string Status
        {
            get { return _recorder .Status ; }
            
        }
        public string ChanelName
        {
            get { return _recorder.RecorderName; }
            set { _recorder.RecorderName = value; }
        }

        public delegate void EventHandler(string sender, EventArgs e);
        public event EventHandler ElementDisposing;

        public mainPanel(string chanelname)
        {
            InitializeComponent();
            InitRecorder();
            ChanelName = chanelname;
            TB_ChanelName.Text = ChanelName;
            CB_Device.Items.AddRange(_recorder.Devices.ToArray());

        }

        private void B_Options_Click(object sender, EventArgs e)
        {
            _options = new Options
            {
                Title = "Настрока канала " + _recorder.RecorderName,
                FileNameTemplate = _recorder .FileNameTemplate,
                FolderTemplate = _recorder.FolderTemplate,
                Format = _recorder .Format,
                Channels = _recorder.Channels,
                BitSample = _recorder.BitSample,
                Freq = _recorder.Freq
            };
            _options.OKpressed += ChangeOptions;
            _options.Show();
        }

        private void InitRecorder()
        {
            _recorder = new Recorder()
            {
                FolderTemplate = Application.StartupPath + "\\%cn\\%YYYY\\%MM.%MMMM\\%DD\\",
                FileNameTemplate = "%hh-%mm",
                Format = "MP3"
            };
            _recorder.StatusChanged += RecorderStatusHandler;
            _recorder.LevelChanged += RecorderLevelChanged;
            _recorder.RecordTimerTick += _recorder_RecordTimerTick;
        }

        private void _recorder_RecordTimerTick(object sender, EventArgs e)
        {
            TB_RecordTime.Invoke(
                (ThreadStart) delegate()
                {
                    var trt = TimeSpan.FromSeconds(_recorder.TotalRecordTime);
                    var cprt = TimeSpan.FromSeconds(_recorder.CurrentPartRecordTime);
                    TB_RecordTime.Text = (cprt.Days > 0 ? cprt.Days + "д " : "") + $"{cprt.Hours:D2}" + ":" + $"{cprt.Minutes:D2}" + ":" + $"{cprt.Seconds:D2}" + "/" + (trt.Days > 0 ? trt.Days + "д " : "") + $"{trt.Hours:D2}" + ":" + $"{trt.Minutes:D2}" + ":" + $"{trt.Seconds:D2}";
                    //TB_RecordTime.Text = _recorder.TotalRecordTime.ToString();
                }
                );
        }

        private void RecorderLevelChanged(object sender, LevelChangedEventArgs e)
        {
            PB_Left.Invoke(
                (ThreadStart) delegate()
                { PB_Left.Value = e.LevelLeft; }
                );
            PB_Right.Invoke(
                (ThreadStart) delegate()
                { PB_Right.Value = e.LevelRight; }
                );
        }

        private void ChangeOptions(object sender, EventArgs e)
        {
            _recorder.FileNameTemplate = _options.FileNameTemplate;
            _recorder.FolderTemplate = _options.FolderTemplate;
            _recorder.Format = _options.Format;
            _recorder.Channels = _options.Channels;
            _recorder.BitSample = _options.BitSample;
            _recorder.Freq = _options.Freq;
            _options.Close();
        }

        private void RecorderStatusHandler(object sender, EventArgs e)
        {
            switch (_recorder.Status)
            {
                case "Inited":
                {
                    B_Record.Enabled = true;

                    break;
                }
                case "Recording":
                {
                        //L_Status.Text = _recorder.Description;
                        StartState();
                    break;
                }

                case "Error":
                {
                    //MessageBox.Show(_recorder.Description, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //L_Status.Text = "Ошибка: " + _recorder.Description;
                    StopState();
                    break;
                }
                case "Stop":
                    {
                        StopState();
                        break;
                    }
                default:
                {
                        //MessageBox.Show(_recorder.Description);
                        //L_Status.Text = "Ошибка: " + _recorder.Description;
                        StopState();
                        break;
                }
            }
            L_Status.Text = _recorder.Description;
        }

        private void StartState()
        {
            CB_Device.Enabled = false;
            B_Options.Enabled = false;
            B_Record.Text = "Стоп";
        }

        private void StopState()
        {
            CB_Device.Enabled = true;
            B_Options.Enabled = true;
            B_Record.Text = "Запись";
            PB_Left.Value = 0;
            PB_Right.Value = 0;
        }

        private void B_Close_Click(object sender, EventArgs e)
        {
            ElementDisposing?.Invoke(ChanelName, EventArgs.Empty);
        }

        private void B_Record_Click(object sender, EventArgs e)
        {
            if (_recorder.Status != "Recording")
            {
                _recorder.StartRecord(CB_Device.SelectedIndex, false);
                TB_CurrentFileName.Text = _recorder.FullFilename;
                TB_CurrentFileName.SelectionStart = TB_CurrentFileName.TextLength;
            }
            else
            {
                _recorder.StopRecord();
            }
        }

        private void CB_Device_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Device.SelectedIndex != -1)
            {
                B_Record.Enabled = true;
                B_Options.Enabled = true;
                _recorder.StartRecord(CB_Device.SelectedIndex, true);
            }
            //for (int i = 0; i < _recorder.Devices[CB_Device.SelectedIndex].Properties.Count -1; i++)
            //{
            //    Console.Write(_recorder.Devices[CB_Device.SelectedIndex].Properties[i].Key.propertyId.ToString() + "   ");
            //    Console.WriteLine(_recorder.Devices[CB_Device.SelectedIndex].Properties[i].Value.ToString());
            //}
        }

        private void TB_CurrentFileName_DoubleClick(object sender, EventArgs e)
        {
            var p = _recorder.ResolveName(_recorder.FolderTemplate);
            if (Directory.Exists(p))
            {
                System.Diagnostics.Process.Start(p);
            }
            
        }
    }
}
