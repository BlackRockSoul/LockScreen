namespace WindowsFormsApplication1
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LockBtn = new System.Windows.Forms.Button();
            this.MonitorList = new System.Windows.Forms.CheckedListBox();
            this.LockTimer = new System.Windows.Forms.Timer(this.components);
            this.AutoLock = new System.Windows.Forms.CheckBox();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.SettingsBox = new System.Windows.Forms.GroupBox();
            this.TaskBox = new System.Windows.Forms.GroupBox();
            this.AddTask = new System.Windows.Forms.Button();
            this.TaskList = new System.Windows.Forms.ListBox();
            this.SettingsBox.SuspendLayout();
            this.TaskBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LockBtn
            // 
            this.LockBtn.Location = new System.Drawing.Point(6, 19);
            this.LockBtn.Name = "LockBtn";
            this.LockBtn.Size = new System.Drawing.Size(110, 30);
            this.LockBtn.TabIndex = 150;
            this.LockBtn.TabStop = false;
            this.LockBtn.Text = "Заблокировать";
            this.LockBtn.UseVisualStyleBackColor = true;
            this.LockBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // MonitorList
            // 
            this.MonitorList.FormattingEnabled = true;
            this.MonitorList.HorizontalScrollbar = true;
            this.MonitorList.Items.AddRange(new object[] {
            "Монитор 1",
            "Монитор 2",
            "Монитор 3"});
            this.MonitorList.Location = new System.Drawing.Point(6, 78);
            this.MonitorList.Name = "MonitorList";
            this.MonitorList.Size = new System.Drawing.Size(110, 64);
            this.MonitorList.TabIndex = 1;
            // 
            // LockTimer
            // 
            this.LockTimer.Enabled = true;
            this.LockTimer.Interval = 60000;
            this.LockTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AutoLock
            // 
            this.AutoLock.AutoSize = true;
            this.AutoLock.Checked = true;
            this.AutoLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoLock.Location = new System.Drawing.Point(6, 55);
            this.AutoLock.Name = "AutoLock";
            this.AutoLock.Size = new System.Drawing.Size(110, 17);
            this.AutoLock.TabIndex = 2;
            this.AutoLock.Text = "Автоотключение";
            this.AutoLock.UseVisualStyleBackColor = true;
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VersionLabel.Location = new System.Drawing.Point(479, 278);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(54, 9);
            this.VersionLabel.TabIndex = 4;
            this.VersionLabel.Text = "Версия 0.0.0.0";
            // 
            // SettingsBox
            // 
            this.SettingsBox.Controls.Add(this.TaskBox);
            this.SettingsBox.Controls.Add(this.LockBtn);
            this.SettingsBox.Controls.Add(this.MonitorList);
            this.SettingsBox.Controls.Add(this.AutoLock);
            this.SettingsBox.Location = new System.Drawing.Point(12, 12);
            this.SettingsBox.Name = "SettingsBox";
            this.SettingsBox.Size = new System.Drawing.Size(548, 263);
            this.SettingsBox.TabIndex = 5;
            this.SettingsBox.TabStop = false;
            this.SettingsBox.Text = "Настройки";
            // 
            // TaskBox
            // 
            this.TaskBox.Controls.Add(this.AddTask);
            this.TaskBox.Controls.Add(this.TaskList);
            this.TaskBox.Location = new System.Drawing.Point(122, 19);
            this.TaskBox.Name = "TaskBox";
            this.TaskBox.Size = new System.Drawing.Size(420, 238);
            this.TaskBox.TabIndex = 5;
            this.TaskBox.TabStop = false;
            this.TaskBox.Text = "Задачи";
            // 
            // AddTask
            // 
            this.AddTask.Location = new System.Drawing.Point(347, 19);
            this.AddTask.Name = "AddTask";
            this.AddTask.Size = new System.Drawing.Size(67, 23);
            this.AddTask.TabIndex = 1;
            this.AddTask.Text = "Добавить";
            this.AddTask.UseVisualStyleBackColor = true;
            this.AddTask.Click += new System.EventHandler(this.AddTask_Click);
            // 
            // TaskList
            // 
            this.TaskList.Cursor = System.Windows.Forms.Cursors.Default;
            this.TaskList.FormattingEnabled = true;
            this.TaskList.HorizontalScrollbar = true;
            this.TaskList.Location = new System.Drawing.Point(6, 19);
            this.TaskList.Name = "TaskList";
            this.TaskList.Size = new System.Drawing.Size(335, 212);
            this.TaskList.TabIndex = 0;
            this.TaskList.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 293);
            this.Controls.Add(this.SettingsBox);
            this.Controls.Add(this.VersionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LockScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SettingsBox.ResumeLayout(false);
            this.SettingsBox.PerformLayout();
            this.TaskBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LockBtn;
        private System.Windows.Forms.CheckedListBox MonitorList;
        private System.Windows.Forms.Timer LockTimer;
        private System.Windows.Forms.CheckBox AutoLock;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.GroupBox SettingsBox;
        private System.Windows.Forms.GroupBox TaskBox;
        private System.Windows.Forms.Button AddTask;
        public System.Windows.Forms.ListBox TaskList;
    }
}

