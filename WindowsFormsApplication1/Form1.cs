using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LockScreen.Properties;
using System.Threading;
using AutoUpdaterDotNET;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        // Объявление Горячих клавиш. Добавить выбор
        public const int MOD_ALT = 0x12;
        public const int MOD_SHIFT = 0x10;
        public const int MOD_F9 = 0x78;

        //База для горячих клавиш
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern short GetAsyncKeyState(int vkey);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr window, int index, int value);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr window, int index);

        //Описания переменных. Привести в порядок//
        bool Locked, fi;
        bool[] CB = new bool[Screen.AllScreens.Length];
        bool[] Showed = new bool[Screen.AllScreens.Length];
        Form[] forms;
        int CursX1, CursX2, CursY1, CursY2;
        int time;
        Screen[] sc = Screen.AllScreens;
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TOOLWINDOW = 0x00000080;
        const string filePath = "settings.txt";
        string[] Setting_file = new string[100];    //File.ReadAllLines(filePath, Encoding.UTF8);

        Random rand = new Random();
        //Описания переменных. Привести в порядок//

        public Form1()
        {
            InitializeComponent();

            //Подгрузка DLL'ки для автообновления//
            if (!(File.Exists("AutoUpdater.NET.dll")))
            {
                using (var client = new WebClient())
                {
                    client.Headers.Add("user-agent", "Anything");
                    client.DownloadFile(
                        "https://raw.githubusercontent.com/BlackRockSoul/LockScreen/master/WindowsFormsApplication1/bin/Release/AutoUpdater.NET",
                        "AutoUpdater.NET"); //пофиксить кривое скачивание
                    File.Move("AutoUpdater.NET", "AutoUpdater.NET" + ".dll");//переименование
                }
            }
            //Подгрузка DLL'ки для автообновления//
        }

        //Процедура регистрации горячих клавиш//
        private void WaitKey()
        {
            while (this.IsHandleCreated)
            {
                Thread.Sleep(100); //Оптимизация пожирания CPU

                short res1 = GetAsyncKeyState(MOD_SHIFT);

                if (res1 != 0) //Проверка на нажатие кнопки SHIFT
                {
                    Thread.Sleep(100); //Оптимизация пожирания CPU
                    short res2 = GetAsyncKeyState(MOD_ALT);
                    short res3 = GetAsyncKeyState(MOD_F9);
                    if (res2 != 0 && res3 != 0)
                    {
                        LockBtn.Invoke(new MethodInvoker(delegate ()
                        {
                            LockBtn.PerformClick(); //Имитация нажатия на копку "Заблокировать"
                        }));
                    }
                }
            }
        }
        //Процедура регистрации горячих клавиш//


        //Процедура блокирования экрана. Сделать как-нибудь менее криво...//
        public void HideScreen()
        {
            if (MonitorList.CheckedItems.Count != 0) //Проверка на выбор хотя бы одного пункта из меню
            {
                Locked = true;

                forms = new Form[Screen.AllScreens.Length]; //Объявления массива с формами
                for (int i = 0; i < Screen.AllScreens.Length; i++) //Генерация форм. Пофиксить, блять! Нахуй тут формы?!
                {
                    if (!CB[i] & MonitorList.GetItemCheckState(i) == CheckState.Checked)
                    {                                               //Создание и настройка формы
                        forms[i] = new Form();
                        Showed[i] = true;
                        forms[i].BackColor = System.Drawing.Color.Black;
                        forms[i].FormBorderStyle = FormBorderStyle.None;
                        forms[i].ShowInTaskbar = false;
                        forms[i].Show();
                        forms[i].Location = sc[i].Bounds.Location; //Иногда глючит. Хуй знает почему
                        forms[i].Width = sc[i].Bounds.Width;
                        forms[i].Height = sc[i].Bounds.Height;
                        forms[i].TopMost = true;
                        forms[i].FormClosing += Form1_FormClosing;
                        forms[i].BringToFront();
                        HideFromAltTab(forms[i].Handle);
                        forms[i].Location = sc[i].Bounds.Location; //На всякий случай. 
                                                                   //Потом понять что работает, а что нет и выпилить лишнее
                    }
                }
            }
        }
        //Процедура блокирования экрана. Сделать как-нибудь менее криво...//

        public static void HideFromAltTab(IntPtr Handle)
        {
            SetWindowLong(Handle, GWL_EXSTYLE, GetWindowLong(Handle,
                GWL_EXSTYLE) | WS_EX_TOOLWINDOW);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Locked)
            {
                HideScreen();
                time = 0; //Сброс времени для timer1
            }
            else
            {
                Locked = false;
                for (int i = 0; i <= Screen.AllScreens.Length - 1; i++) //Закрытие всех форм
                {
                    if (Showed[i])
                    {
                        Showed[i] = false;
                        forms[i].Close();
                        BringToFront(); //Не уверен что это нужно
                    }
                }

            }
        }

        private void AddTask_Click(object sender, EventArgs e)
        {
            TaskList.Items.Add("Task" + rand.Next(1, 100));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string Checkboxes = string.Empty;
            string str = string.Empty;

            for (int i = 1; i <= Screen.AllScreens.Length; i++)
            {
                if (MonitorList.GetItemChecked(i - 1))
                {

                    Checkboxes += "1";
                }
                else
                    Checkboxes += "0";
            }

            using (System.IO.StreamReader reader = System.IO.File.OpenText(filePath))
            {
                str = reader.ReadToEnd();
            }
            if (Checkboxes != Setting_file[0])
            {
                str = str.Remove(0, Setting_file[0].Length).Insert(0, Checkboxes);
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath))
            {
                file.Write(str);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            AutoUpdater.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");
            AutoUpdater.Start("https://raw.githubusercontent.com/BlackRockSoul/LockScreen/master/WindowsFormsApplication1/Update.xml");

            VersionLabel.Text = "Версия " + ProductVersion.ToString();

            MonitorList.Items.Clear();
            for (int i = 1; i <= Screen.AllScreens.Length; i++) //Подгрузка мониторов в список
            {
                Showed[i - 1] = false;
                MonitorList.Items.Add("Монитор " + i);
            }

            if (!(File.Exists(filePath)))
            {
                using (StreamWriter WriteFile = new StreamWriter(filePath))
                {
                    string cur = "";
                    for (int i = 1; i <= Screen.AllScreens.Length; i++)
                    {
                        cur += "0";
                    }
                    WriteFile.Write(cur);
                    TaskList.Items.Clear();
                }
            }

                FileInfo file = new FileInfo(filePath);
            using (StreamReader ReadFile = File.OpenText(filePath))
            {
                Setting_file = File.ReadAllLines(filePath, Encoding.UTF8);
            }
            if (file.Length > 1)
            {
                for (int i = 1; i <= Screen.AllScreens.Length; i++) //Добавление для них чекбоксов из настроек
                {
                    string sub = Setting_file[0].Substring(i - 1, 1);
                    if (sub == "1")
                    {
                        MonitorList.SetItemChecked(i - 1, true);
                    }
                }
                TaskList.Items.Clear();
                for (int i = 2; i < Setting_file.Length; i++)
                {
                    TaskList.Items.Add(Setting_file[i]);
                }
            }


            MethodInvoker mi = new MethodInvoker(WaitKey); //Включение регистрации горячих клавиш
            mi.BeginInvoke(null, null);                    //Включение регистрации горячих клавиш


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Locked) //Если блокировка включена, хер ты вырубишь её просто так
            {
                base.OnClosing(e);
                e.Cancel = true;
            }
            else
            {
                //Я что-то сюда хотел добавить? Разве?
            }
        }


        //Самая ущербная часть проекта. Таймер и проверка на движение мыши//
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!Locked)
            {
                time++;
                if (!fi) //Сохранение первых позиций мыши
                {
                    fi = true; //Эта переменная меняется каждый цикл
                    CursX1 = Cursor.Position.X;
                    CursY1 = Cursor.Position.Y;
                }
                else //Сохранение вторых позиций мыши
                {
                    fi = false; //Эта переменная меняется каждый цикл
                    CursX2 = Cursor.Position.X;
                    CursY2 = Cursor.Position.Y;
                    if (CursX1 == CursX2) //Если мышь не двигалась, то либо ждем дальше, либо.. 
                    {
                        if (time == 10 && AutoLock.Checked != true) //..после 10 минут простоя самостоятельно врубаем блокировку..
                        {
                            AutoLock.Checked = true;
                            LockBtn.PerformClick();                  //..иии самостоятельно всё нахуй блокируем..                            
                            time = 0;
                        }
                        else if (time >= 3 && AutoLock.Checked)     //..Есть ещё один вариант. Галка стоит, мы просто..
                        {                                            //..блокируем и сбрасываем таймер
                            LockBtn.PerformClick();
                            time = 0;
                        }
                    }
                }
            }
        }
        //Самая ущербная часть проекта. Таймер и проверка на движение мыши//

    }
}
