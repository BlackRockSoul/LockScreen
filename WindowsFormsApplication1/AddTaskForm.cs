using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace LockScreen
{
    public partial class AddTaskForm : MetroForm
    {
        public AddTaskForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            TaskComboBox.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = ("Через " + MinutesUpDown.Value.ToString() + " минут выполнить " ); //+ TaskComboBox.SelectedValue.ToString()
        }
    }
}
