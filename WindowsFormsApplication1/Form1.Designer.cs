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
            this.LockBtn.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.LockBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LockBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            resources.ApplyResources(this.LockBtn, "LockBtn");
            this.LockBtn.Name = "LockBtn";
            this.LockBtn.TabStop = false;
            this.LockBtn.UseVisualStyleBackColor = true;
            this.LockBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // MonitorList
            // 
            this.MonitorList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MonitorList.CheckOnClick = true;
            this.MonitorList.FormattingEnabled = true;
            resources.ApplyResources(this.MonitorList, "MonitorList");
            this.MonitorList.Items.AddRange(new object[] {
            resources.GetString("MonitorList.Items"),
            resources.GetString("MonitorList.Items1"),
            resources.GetString("MonitorList.Items2")});
            this.MonitorList.Name = "MonitorList";
            // 
            // LockTimer
            // 
            this.LockTimer.Enabled = true;
            this.LockTimer.Interval = 60000;
            this.LockTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AutoLock
            // 
            resources.ApplyResources(this.AutoLock, "AutoLock");
            this.AutoLock.Checked = true;
            this.AutoLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoLock.Name = "AutoLock";
            this.AutoLock.UseVisualStyleBackColor = true;
            // 
            // VersionLabel
            // 
            resources.ApplyResources(this.VersionLabel, "VersionLabel");
            this.VersionLabel.Name = "VersionLabel";
            // 
            // SettingsBox
            // 
            this.SettingsBox.Controls.Add(this.TaskBox);
            this.SettingsBox.Controls.Add(this.LockBtn);
            this.SettingsBox.Controls.Add(this.MonitorList);
            this.SettingsBox.Controls.Add(this.AutoLock);
            this.SettingsBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(this.SettingsBox, "SettingsBox");
            this.SettingsBox.Name = "SettingsBox";
            this.SettingsBox.TabStop = false;
            // 
            // TaskBox
            // 
            this.TaskBox.Controls.Add(this.AddTask);
            this.TaskBox.Controls.Add(this.TaskList);
            this.TaskBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(this.TaskBox, "TaskBox");
            this.TaskBox.Name = "TaskBox";
            this.TaskBox.TabStop = false;
            // 
            // AddTask
            // 
            this.AddTask.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.AddTask.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AddTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            resources.ApplyResources(this.AddTask, "AddTask");
            this.AddTask.Name = "AddTask";
            this.AddTask.UseVisualStyleBackColor = true;
            this.AddTask.Click += new System.EventHandler(this.AddTask_Click);
            // 
            // TaskList
            // 
            this.TaskList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TaskList.Cursor = System.Windows.Forms.Cursors.Default;
            this.TaskList.FormattingEnabled = true;
            resources.ApplyResources(this.TaskList, "TaskList");
            this.TaskList.Name = "TaskList";
            this.TaskList.TabStop = false;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SettingsBox);
            this.Controls.Add(this.VersionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
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

