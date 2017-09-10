using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RecorderLib
{
    public partial class Options : Form
    {
        public string Title
        {
            get {return Text;  }
            set { Text = value; }
        }
        public string FolderTemplate
        {
            set { TB_FolderTemplate.Text  = value;}
            get { return TB_FolderTemplate.Text;}
        }

        public string FileNameTemplate
        {
            get { return TB_FileTemplate.Text; }
            set { TB_FileTemplate.Text = value; }
        }

        public string Format
        {
            get { return (RB_MP3.Checked && !RB_WAV.Checked) ? "MP3" : "WAV"; }
            set {
                switch (value.ToUpper())
                {
                    case "MP3":
                    {
                        RB_MP3.Checked = true;
                        RB_WAV.Checked = false;
                        break;
                    }
                    case "WAV":
                    {
                        RB_MP3.Checked = false;
                        RB_WAV.Checked = true;
                        break;
                    }
                    default:
                    {
                        RB_MP3.Checked = true;
                        RB_WAV.Checked = false;
                        break;
                    }
                }
            }
        }

        public byte Channels
        {
            get { return byte.Parse(CB_Mode.SelectedIndex + 1.ToString()) ; }
            set { CB_Mode.SelectedIndex = value - 1; }
        }

        public byte BitSample
        {
            get { return byte.Parse((CB_BitSample.SelectedIndex == 0 ? 8 : 16).ToString()); }
            set { CB_BitSample.SelectedIndex = (value == 16 ? 1 : 0); }
        }

        public int Freq
        {
            get { return int.Parse(CB_Freq.SelectedIndex.ToString()); }
            set
            {
                for (int i = 0; i < CB_Freq.Items.Count -1; i++)
                {
                    if (value == int.Parse(CB_Freq.Items[i].ToString()))
                    {
                        CB_Freq.SelectedIndex = i;
                        break;
                        
                    }
                }
                if (CB_Freq.SelectedIndex < 0)
                {
                    CB_Freq.SelectedIndex = 4;
                }
            }
        }

        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler OKpressed;

        public Options()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TB_FolderTemplate.Text = folderBrowserDialog1.SelectedPath;
                
            }
        }

        private void B_OK_Click(object sender, EventArgs e)
        {
            OKpressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
