using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RecorderLib;

namespace Multi_Channel_Recorder
{
    public partial class MainForm : Form
    {
        private bool _reallyExit;
        private bool _controlLocked;

        private const int MaxChanel = 10;

        public MainForm()
        {
            InitializeComponent();
        }

     
        private void LockControl()
        {
            _controlLocked = true;
            блокировкаToolStripMenuItem.Text = "Разблокировать";
            каналToolStripMenuItem.Enabled = false;
            файлToolStripMenuItem.Enabled = false;
            panel1.Enabled = false;
        }
        private void UnlockControl()
        {
            _controlLocked = false;
            блокировкаToolStripMenuItem.Text = "Блокировать";
            каналToolStripMenuItem.Enabled = true;
            файлToolStripMenuItem.Enabled = true;
            panel1.Enabled = true;
        }
        private bool CheckUniqueName(string name)
        {
          for (int i = 0; i < panel1.Controls.OfType<mainPanel>().Count() ; i++)
            {
                if (panel1.Controls.OfType<mainPanel>().ElementAt(i).ChanelName  == name)
                {
                    return false;
                }
            }
            return true;
        }

        private void блокировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_controlLocked)
            {
                UnlockControl();
            }
            else
            {
                LockControl();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_reallyExit)
            {
                Hide();
                NI_MainForm.Visible = true;
                e.Cancel = true;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckRecordingInProgress())
            {
                MessageBox.Show("Для выхода из программы остановите запись на ВСЕХ каналах!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _reallyExit = true;
                Close();
            }
            
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripTextBox1.ForeColor = CheckUniqueName(toolStripTextBox1.Text) ? SystemColors.ControlText: Color.Red;
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && CheckUniqueName(toolStripTextBox1.Text) && toolStripTextBox1.Text !="")
            {
                var count = panel1.Controls.OfType<mainPanel>().Count();
                if ( count < MaxChanel )
                {

                    panel1.Controls.Add(new mainPanel(toolStripTextBox1.Text));
                    var element = panel1.Controls.OfType<mainPanel>().Where(el => el.ChanelName == toolStripTextBox1.Text).First( );
                    MaximumSize = new Size(MaximumSize.Width,(count >= 2)? (count + 1) * element.Height + mainMenu.Height * 2 + 15:300);
                    element.Location = new Point(0,count* element.Height);
                    element.ElementDisposing  += ElementDisposing;
                    toolStripComboBox1.Items.Add(toolStripTextBox1.Text);
                    toolStripTextBox1.Text = "";
                    
                }
                else
                {
                    MessageBox.Show("Достигнуто максимальное количество каналов");
                }
                
            }
        }

        private void mainMenu_MenuDeactivate(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "";
        }

        private void toolStripComboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text == "") return;
            var c = panel1.Controls.OfType<mainPanel>().Where(el => el.ChanelName == toolStripComboBox1.Text).First();
            if (c.Status   != "Recording")
            {
                ElementDisposing(toolStripComboBox1.Text, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Для удаления выбранного канала сначала остановите запись","Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }
        }

        private void UpdateMaxSize()
        {
            var el = panel1.Controls.OfType<mainPanel>();
            MaximumSize = new Size(MaximumSize.Width, (el.Count() >= 2) ? el.Count() * el.First().Height + mainMenu.Height * 2 + 15 : 300);
        }

        private void UpdateLayout()
        {
            var el = panel1.Controls.OfType<mainPanel>();
            блокировкаToolStripMenuItem.Enabled = (el.Count() > 0);
            for (var i = 0; i < el.Count(); i++)
            {
                el.ElementAt(i).Location = new Point(0, i * el.First().Height);
            }
        }

        private void ElementDisposing(string sender, EventArgs e)
        {
            if (panel1.Controls.OfType<mainPanel>().Where(el => el.ChanelName == sender).First().Status == "Recording")
            {
                MessageBox.Show("Для удаления данного канала сначала остановите запись.", "Внимание!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (
                    MessageBox.Show("Действительно желаете удалить канал " + sender + " ?", "Внимание!",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                toolStripComboBox1.Items.Remove(sender);
                panel1.Controls.OfType<mainPanel>().Where(el => el.ChanelName == sender).First().Dispose();
                
                UpdateLayout();
                UpdateMaxSize();

            }

            
            
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutBox1()).ShowDialog();
        }

        private bool CheckRecordingInProgress()
        {
            return (panel1.Controls.OfType<mainPanel>().Where(el => el.Status == "Recording").Count() > 0)
                ? true
                : false;
        }

        private void восстановитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NI_MainForm.Visible = false;
            Show();
        }

        private void panel1_ControlAdded(object sender, ControlEventArgs e)
        {
            var el = panel1.Controls.OfType<mainPanel>();
            блокировкаToolStripMenuItem.Enabled = (el.Count() > 0);
        }
    }
}
