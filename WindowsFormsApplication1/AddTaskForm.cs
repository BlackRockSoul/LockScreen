using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace LockScreen
{
    public partial class AddTaskForm : Form
    {
        public AddTaskForm()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string text = ("Через " + MinutesUpDown.Value.ToString() + " минут выполнить " ); //+ TaskComboBox.SelectedValue.ToString()
            //MainForm.ChangeText(text);
        }
    }
}
