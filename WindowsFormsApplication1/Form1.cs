using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LockScreen.Properties;
using System.Threading;
using AutoUpdaterDotNET;
using System.IO;
using System.Net;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {


        public const int MOD_ALT = 0x12;
        public const int MOD_SHIFT = 0x10;
        public const int MOD_F9 = 0x78;

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern short GetAsyncKeyState(int vkey);


        bool Locked, fi;
        bool[] CB = new bool[Screen.AllScreens.Length];
        bool[] Showed = new bool[Screen.AllScreens.Length];
        Form[] forms;
        int CursX1, CursX2, CursY1, CursY2;
        int time;
        Screen[] sc = Screen.AllScreens;


        public Form1()
        {
            InitializeComponent();

            if (!(File.Exists("AutoUpdater.NET.dll")))
            {
                using (var client = new WebClient())
                {
                    client.Headers.Add("user-agent", "Anything");
                    client.DownloadFile( 
                        "https://raw.githubusercontent.com/BlackRockSoul/LockScreen/master/WindowsFormsApplication1/bin/Release/AutoUpdater.NET",
                        "AutoUpdater.NET");
                    File.Move("AutoUpdater.NET", "AutoUpdater.NET" + ".dll");//само переименование
                }
            }
        }


        private void WaitKey()
        {


            while (this.IsHandleCreated)
            {
                Thread.Sleep(100);

                short res1 = GetAsyncKeyState(MOD_SHIFT);

                if (res1 != 0)
                {
                    Thread.Sleep(100);
                    short res2 = GetAsyncKeyState(MOD_ALT);
                    short res3 = GetAsyncKeyState(MOD_F9);
                    if (res2 != 0 && res3 != 0)
                    {
                        button1.Invoke(new MethodInvoker(delegate ()
                        {
                            button1.PerformClick();
                        }));
                    }
                }
            }
        }

        public void HideScreen()
        {
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                Locked = true;

                forms = new Form[Screen.AllScreens.Length];
                for (int i = 0; i < Screen.AllScreens.Length; i++)
                {
                    if (!CB[i] & checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                    {
                        forms[i] = new Form();
                        Showed[i] = true;
                        forms[i].BackColor = System.Drawing.Color.Black;
                        forms[i].FormBorderStyle = FormBorderStyle.None;
                        forms[i].Show();
                        forms[i].Location = sc[i].Bounds.Location;
                        forms[i].Width = sc[i].Bounds.Width;
                        forms[i].Height = sc[i].Bounds.Height;
                        forms[i].TopMost = true;
                        forms[i].FormClosing += Form1_FormClosing;
                        forms[i].BringToFront();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Locked)
            {
                HideScreen();
                time = 0;
            }
            else
            {
                Locked = false;
                for (int i = 0; i <= Screen.AllScreens.Length - 1; i++)
                {
                    if (Showed[i])
                    {
                        Showed[i] = false;
                        forms[i].Close();
                        BringToFront();
                    }
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Settings.Default.Checkboxes = "";
            for (int i = 1; i <= Screen.AllScreens.Length; i++)
            {
                if (checkedListBox1.GetItemChecked(i - 1))
                {

                    Settings.Default.Checkboxes += "1";
                }
                else
                    Settings.Default.Checkboxes += "0";
            }
            Settings.Default.Save();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveBtn.PerformClick();
        }


        private void Form1_Load(object sender, EventArgs e)
        {



            AutoUpdater.Start("https://raw.githubusercontent.com/BlackRockSoul/LockScreen/master/WindowsFormsApplication1/Update.xml");
            
            checkedListBox1.Items.Clear();
            for (int i = 1; i <= Screen.AllScreens.Length; i++)
            {
                Showed[i - 1] = false;
                checkedListBox1.Items.Add("Монитор " + i);
            }
            for (int i = 1; i <= Screen.AllScreens.Length; i++)
            {
                string sub = Settings.Default.Checkboxes.Substring(i - 1, 1);
                if (sub == "1")
                {
                    checkedListBox1.SetItemChecked(i - 1, true);
                }
            }


            MethodInvoker mi = new MethodInvoker(WaitKey);
            mi.BeginInvoke(null, null);


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Locked)
            {
                base.OnClosing(e);
                e.Cancel = true;
            }
            else
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!Locked)
            {
                time++;
                if (!fi)
                {
                    fi = true;
                    CursX1 = Cursor.Position.X;
                    CursY1 = Cursor.Position.Y;
                }
                else
                {
                    fi = false;
                    CursX2 = Cursor.Position.X;
                    CursY2 = Cursor.Position.Y;
                    if (CursX1 == CursX2)
                    {
                        if (time == 10 && checkBox1.Checked != true)
                        {
                            button1.PerformClick();
                            checkBox1.Checked = true;
                        }
                        else if (time >= 3 && checkBox1.Checked)
                        {
                            button1.PerformClick();
                            time = 0;
                        }
                    }
                }
            }
        }
    }
}
