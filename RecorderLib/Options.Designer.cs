namespace RecorderLib
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GB_Templates = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_FileTemplate = new System.Windows.Forms.TextBox();
            this.TB_FolderTemplate = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.B_OK = new System.Windows.Forms.Button();
            this.BG_Format = new System.Windows.Forms.GroupBox();
            this.RB_WAV = new System.Windows.Forms.RadioButton();
            this.RB_MP3 = new System.Windows.Forms.RadioButton();
            this.CB_Freq = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_Mode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CB_BitSample = new System.Windows.Forms.ComboBox();
            this.GB_Templates.SuspendLayout();
            this.BG_Format.SuspendLayout();
            this.SuspendLayout();
            // 
            // GB_Templates
            // 
            this.GB_Templates.Controls.Add(this.button1);
            this.GB_Templates.Controls.Add(this.label2);
            this.GB_Templates.Controls.Add(this.label1);
            this.GB_Templates.Controls.Add(this.TB_FileTemplate);
            this.GB_Templates.Controls.Add(this.TB_FolderTemplate);
            this.GB_Templates.Location = new System.Drawing.Point(13, 13);
            this.GB_Templates.Name = "GB_Templates";
            this.GB_Templates.Size = new System.Drawing.Size(424, 79);
            this.GB_Templates.TabIndex = 0;
            this.GB_Templates.TabStop = false;
            this.GB_Templates.Text = "Шаблоны папки и файла";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(393, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Файл";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Папка";
            // 
            // TB_FileTemplate
            // 
            this.TB_FileTemplate.Location = new System.Drawing.Point(52, 48);
            this.TB_FileTemplate.Name = "TB_FileTemplate";
            this.TB_FileTemplate.Size = new System.Drawing.Size(366, 20);
            this.TB_FileTemplate.TabIndex = 1;
            // 
            // TB_FolderTemplate
            // 
            this.TB_FolderTemplate.Location = new System.Drawing.Point(52, 22);
            this.TB_FolderTemplate.Name = "TB_FolderTemplate";
            this.TB_FolderTemplate.Size = new System.Drawing.Size(335, 20);
            this.TB_FolderTemplate.TabIndex = 0;
            // 
            // B_OK
            // 
            this.B_OK.Location = new System.Drawing.Point(362, 302);
            this.B_OK.Name = "B_OK";
            this.B_OK.Size = new System.Drawing.Size(75, 23);
            this.B_OK.TabIndex = 1;
            this.B_OK.Text = "OK";
            this.B_OK.UseVisualStyleBackColor = true;
            this.B_OK.Click += new System.EventHandler(this.B_OK_Click);
            // 
            // BG_Format
            // 
            this.BG_Format.Controls.Add(this.CB_BitSample);
            this.BG_Format.Controls.Add(this.label5);
            this.BG_Format.Controls.Add(this.CB_Mode);
            this.BG_Format.Controls.Add(this.label4);
            this.BG_Format.Controls.Add(this.label3);
            this.BG_Format.Controls.Add(this.CB_Freq);
            this.BG_Format.Controls.Add(this.RB_WAV);
            this.BG_Format.Controls.Add(this.RB_MP3);
            this.BG_Format.Location = new System.Drawing.Point(12, 98);
            this.BG_Format.Name = "BG_Format";
            this.BG_Format.Size = new System.Drawing.Size(425, 110);
            this.BG_Format.TabIndex = 2;
            this.BG_Format.TabStop = false;
            this.BG_Format.Text = "Формат";
            // 
            // RB_WAV
            // 
            this.RB_WAV.AutoSize = true;
            this.RB_WAV.Location = new System.Drawing.Point(7, 73);
            this.RB_WAV.Name = "RB_WAV";
            this.RB_WAV.Size = new System.Drawing.Size(50, 17);
            this.RB_WAV.TabIndex = 1;
            this.RB_WAV.Text = "WAV";
            this.RB_WAV.UseVisualStyleBackColor = true;
            // 
            // RB_MP3
            // 
            this.RB_MP3.AutoSize = true;
            this.RB_MP3.Checked = true;
            this.RB_MP3.Location = new System.Drawing.Point(7, 20);
            this.RB_MP3.Name = "RB_MP3";
            this.RB_MP3.Size = new System.Drawing.Size(47, 17);
            this.RB_MP3.TabIndex = 0;
            this.RB_MP3.TabStop = true;
            this.RB_MP3.Text = "MP3";
            this.RB_MP3.UseVisualStyleBackColor = true;
            // 
            // CB_Freq
            // 
            this.CB_Freq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Freq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CB_Freq.FormattingEnabled = true;
            this.CB_Freq.Items.AddRange(new object[] {
            "5000",
            "8000",
            "11025",
            "22050",
            "44100",
            "48000",
            "88200",
            "96000",
            "192000"});
            this.CB_Freq.Location = new System.Drawing.Point(298, 20);
            this.CB_Freq.Name = "CB_Freq";
            this.CB_Freq.Size = new System.Drawing.Size(121, 21);
            this.CB_Freq.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Частота дискретизации";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Режим";
            // 
            // CB_Mode
            // 
            this.CB_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Mode.FormattingEnabled = true;
            this.CB_Mode.Items.AddRange(new object[] {
            "Моно",
            "Стерео"});
            this.CB_Mode.Location = new System.Drawing.Point(298, 47);
            this.CB_Mode.Name = "CB_Mode";
            this.CB_Mode.Size = new System.Drawing.Size(121, 21);
            this.CB_Mode.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Бит/сэмпл";
            // 
            // CB_BitSample
            // 
            this.CB_BitSample.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_BitSample.FormattingEnabled = true;
            this.CB_BitSample.Items.AddRange(new object[] {
            "8",
            "16"});
            this.CB_BitSample.Location = new System.Drawing.Point(298, 74);
            this.CB_BitSample.Name = "CB_BitSample";
            this.CB_BitSample.Size = new System.Drawing.Size(121, 21);
            this.CB_BitSample.TabIndex = 7;
            // 
            // Options
            // 
            this.AcceptButton = this.B_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 337);
            this.Controls.Add(this.BG_Format);
            this.Controls.Add(this.B_OK);
            this.Controls.Add(this.GB_Templates);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.GB_Templates.ResumeLayout(false);
            this.GB_Templates.PerformLayout();
            this.BG_Format.ResumeLayout(false);
            this.BG_Format.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_Templates;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_FileTemplate;
        private System.Windows.Forms.TextBox TB_FolderTemplate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button B_OK;
        private System.Windows.Forms.GroupBox BG_Format;
        private System.Windows.Forms.RadioButton RB_WAV;
        private System.Windows.Forms.RadioButton RB_MP3;
        private System.Windows.Forms.ComboBox CB_Mode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_Freq;
        private System.Windows.Forms.ComboBox CB_BitSample;
        private System.Windows.Forms.Label label5;
    }
}