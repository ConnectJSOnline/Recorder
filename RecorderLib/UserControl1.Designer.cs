namespace RecorderLib
{
    partial class mainPanel
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.L_Level_Left = new System.Windows.Forms.Label();
            this.L_Level_Right = new System.Windows.Forms.Label();
            this.PB_Left = new System.Windows.Forms.ProgressBar();
            this.PB_Right = new System.Windows.Forms.ProgressBar();
            this.GB_Level = new System.Windows.Forms.GroupBox();
            this.GB_Devices = new System.Windows.Forms.GroupBox();
            this.CB_Device = new System.Windows.Forms.ComboBox();
            this.B_Record = new System.Windows.Forms.Button();
            this.B_Options = new System.Windows.Forms.Button();
            this.TB_CurrentFileName = new System.Windows.Forms.TextBox();
            this.GB_Status = new System.Windows.Forms.GroupBox();
            this.L_Status = new System.Windows.Forms.Label();
            this.TB_ChanelName = new System.Windows.Forms.TextBox();
            this.L_FileName = new System.Windows.Forms.Label();
            this.L_ChanelName = new System.Windows.Forms.Label();
            this.B_Close = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TB_RecordTime = new System.Windows.Forms.TextBox();
            this.L_RecordTime = new System.Windows.Forms.Label();
            this.GB_Level.SuspendLayout();
            this.GB_Devices.SuspendLayout();
            this.GB_Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // L_Level_Left
            // 
            this.L_Level_Left.AutoSize = true;
            this.L_Level_Left.Location = new System.Drawing.Point(7, 27);
            this.L_Level_Left.Name = "L_Level_Left";
            this.L_Level_Left.Size = new System.Drawing.Size(41, 13);
            this.L_Level_Left.TabIndex = 0;
            this.L_Level_Left.Text = "Левый";
            // 
            // L_Level_Right
            // 
            this.L_Level_Right.AutoSize = true;
            this.L_Level_Right.Location = new System.Drawing.Point(7, 56);
            this.L_Level_Right.Name = "L_Level_Right";
            this.L_Level_Right.Size = new System.Drawing.Size(47, 13);
            this.L_Level_Right.TabIndex = 1;
            this.L_Level_Right.Text = "Правый";
            // 
            // PB_Left
            // 
            this.PB_Left.Location = new System.Drawing.Point(56, 17);
            this.PB_Left.Name = "PB_Left";
            this.PB_Left.Size = new System.Drawing.Size(250, 23);
            this.PB_Left.TabIndex = 2;
            // 
            // PB_Right
            // 
            this.PB_Right.Location = new System.Drawing.Point(56, 46);
            this.PB_Right.Name = "PB_Right";
            this.PB_Right.Size = new System.Drawing.Size(250, 23);
            this.PB_Right.TabIndex = 3;
            // 
            // GB_Level
            // 
            this.GB_Level.Controls.Add(this.PB_Left);
            this.GB_Level.Controls.Add(this.PB_Right);
            this.GB_Level.Controls.Add(this.L_Level_Left);
            this.GB_Level.Controls.Add(this.L_Level_Right);
            this.GB_Level.Location = new System.Drawing.Point(3, 3);
            this.GB_Level.Name = "GB_Level";
            this.GB_Level.Size = new System.Drawing.Size(315, 80);
            this.GB_Level.TabIndex = 4;
            this.GB_Level.TabStop = false;
            this.GB_Level.Text = "Уровень сигнала";
            // 
            // GB_Devices
            // 
            this.GB_Devices.Controls.Add(this.CB_Device);
            this.GB_Devices.Location = new System.Drawing.Point(325, 4);
            this.GB_Devices.Name = "GB_Devices";
            this.GB_Devices.Size = new System.Drawing.Size(245, 42);
            this.GB_Devices.TabIndex = 5;
            this.GB_Devices.TabStop = false;
            this.GB_Devices.Text = "Устройство записи";
            // 
            // CB_Device
            // 
            this.CB_Device.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Device.FormattingEnabled = true;
            this.CB_Device.Location = new System.Drawing.Point(6, 14);
            this.CB_Device.Name = "CB_Device";
            this.CB_Device.Size = new System.Drawing.Size(233, 21);
            this.CB_Device.TabIndex = 0;
            this.CB_Device.SelectedIndexChanged += new System.EventHandler(this.CB_Device_SelectedIndexChanged);
            // 
            // B_Record
            // 
            this.B_Record.Enabled = false;
            this.B_Record.Location = new System.Drawing.Point(576, 30);
            this.B_Record.Name = "B_Record";
            this.B_Record.Size = new System.Drawing.Size(75, 23);
            this.B_Record.TabIndex = 6;
            this.B_Record.Text = "Запись";
            this.B_Record.UseVisualStyleBackColor = true;
            this.B_Record.Click += new System.EventHandler(this.B_Record_Click);
            // 
            // B_Options
            // 
            this.B_Options.Enabled = false;
            this.B_Options.Location = new System.Drawing.Point(576, 59);
            this.B_Options.Name = "B_Options";
            this.B_Options.Size = new System.Drawing.Size(75, 23);
            this.B_Options.TabIndex = 8;
            this.B_Options.Text = "Настройки";
            this.B_Options.UseVisualStyleBackColor = true;
            this.B_Options.Click += new System.EventHandler(this.B_Options_Click);
            // 
            // TB_CurrentFileName
            // 
            this.TB_CurrentFileName.Location = new System.Drawing.Point(501, 88);
            this.TB_CurrentFileName.Name = "TB_CurrentFileName";
            this.TB_CurrentFileName.ReadOnly = true;
            this.TB_CurrentFileName.Size = new System.Drawing.Size(150, 20);
            this.TB_CurrentFileName.TabIndex = 9;
            this.toolTip1.SetToolTip(this.TB_CurrentFileName, "Двойной щелчок открывает папку с файлом");
            this.TB_CurrentFileName.DoubleClick += new System.EventHandler(this.TB_CurrentFileName_DoubleClick);
            // 
            // GB_Status
            // 
            this.GB_Status.Controls.Add(this.L_Status);
            this.GB_Status.Location = new System.Drawing.Point(325, 45);
            this.GB_Status.Name = "GB_Status";
            this.GB_Status.Size = new System.Drawing.Size(245, 38);
            this.GB_Status.TabIndex = 10;
            this.GB_Status.TabStop = false;
            this.GB_Status.Text = "Статус";
            // 
            // L_Status
            // 
            this.L_Status.AutoSize = true;
            this.L_Status.Location = new System.Drawing.Point(3, 16);
            this.L_Status.Name = "L_Status";
            this.L_Status.Size = new System.Drawing.Size(177, 13);
            this.L_Status.TabIndex = 0;
            this.L_Status.Text = "Запись остановлена. Тревог нет.";
            // 
            // TB_ChanelName
            // 
            this.TB_ChanelName.Location = new System.Drawing.Point(51, 88);
            this.TB_ChanelName.Name = "TB_ChanelName";
            this.TB_ChanelName.ReadOnly = true;
            this.TB_ChanelName.Size = new System.Drawing.Size(145, 20);
            this.TB_ChanelName.TabIndex = 11;
            // 
            // L_FileName
            // 
            this.L_FileName.AutoSize = true;
            this.L_FileName.Location = new System.Drawing.Point(414, 90);
            this.L_FileName.Name = "L_FileName";
            this.L_FileName.Size = new System.Drawing.Size(84, 13);
            this.L_FileName.TabIndex = 12;
            this.L_FileName.Text = "Текущий файл:";
            // 
            // L_ChanelName
            // 
            this.L_ChanelName.AutoSize = true;
            this.L_ChanelName.Location = new System.Drawing.Point(4, 90);
            this.L_ChanelName.Name = "L_ChanelName";
            this.L_ChanelName.Size = new System.Drawing.Size(41, 13);
            this.L_ChanelName.TabIndex = 13;
            this.L_ChanelName.Text = "Канал:";
            // 
            // B_Close
            // 
            this.B_Close.Location = new System.Drawing.Point(631, 3);
            this.B_Close.Name = "B_Close";
            this.B_Close.Size = new System.Drawing.Size(20, 20);
            this.B_Close.TabIndex = 14;
            this.B_Close.Text = "X";
            this.B_Close.UseVisualStyleBackColor = true;
            this.B_Close.Click += new System.EventHandler(this.B_Close_Click);
            // 
            // TB_RecordTime
            // 
            this.TB_RecordTime.Location = new System.Drawing.Point(288, 88);
            this.TB_RecordTime.Name = "TB_RecordTime";
            this.TB_RecordTime.ReadOnly = true;
            this.TB_RecordTime.Size = new System.Drawing.Size(120, 20);
            this.TB_RecordTime.TabIndex = 15;
            this.TB_RecordTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.TB_RecordTime, "Таймер записи текущего файла / Таймер записи текщего канала");
            // 
            // L_RecordTime
            // 
            this.L_RecordTime.AutoSize = true;
            this.L_RecordTime.Location = new System.Drawing.Point(202, 91);
            this.L_RecordTime.Name = "L_RecordTime";
            this.L_RecordTime.Size = new System.Drawing.Size(82, 13);
            this.L_RecordTime.TabIndex = 16;
            this.L_RecordTime.Text = "Время записи:";
            // 
            // mainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.L_RecordTime);
            this.Controls.Add(this.TB_RecordTime);
            this.Controls.Add(this.B_Close);
            this.Controls.Add(this.L_ChanelName);
            this.Controls.Add(this.L_FileName);
            this.Controls.Add(this.TB_ChanelName);
            this.Controls.Add(this.GB_Status);
            this.Controls.Add(this.TB_CurrentFileName);
            this.Controls.Add(this.B_Options);
            this.Controls.Add(this.B_Record);
            this.Controls.Add(this.GB_Devices);
            this.Controls.Add(this.GB_Level);
            this.Name = "mainPanel";
            this.Size = new System.Drawing.Size(660, 115);
            this.GB_Level.ResumeLayout(false);
            this.GB_Level.PerformLayout();
            this.GB_Devices.ResumeLayout(false);
            this.GB_Status.ResumeLayout(false);
            this.GB_Status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_Level_Left;
        private System.Windows.Forms.Label L_Level_Right;
        private System.Windows.Forms.ProgressBar PB_Left;
        private System.Windows.Forms.ProgressBar PB_Right;
        private System.Windows.Forms.GroupBox GB_Level;
        private System.Windows.Forms.GroupBox GB_Devices;
        private System.Windows.Forms.ComboBox CB_Device;
        private System.Windows.Forms.Button B_Record;
        private System.Windows.Forms.Button B_Options;
        private System.Windows.Forms.TextBox TB_CurrentFileName;
        private System.Windows.Forms.GroupBox GB_Status;
        private System.Windows.Forms.Label L_Status;
        private System.Windows.Forms.TextBox TB_ChanelName;
        private System.Windows.Forms.Label L_FileName;
        private System.Windows.Forms.Label L_ChanelName;
        private System.Windows.Forms.Button B_Close;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox TB_RecordTime;
        private System.Windows.Forms.Label L_RecordTime;
    }
}
