using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//2. Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от
//1 до 100, а человек пытается его угадать за минимальное число попыток.Компьютер говорит,
//больше или меньше загаданное число введенного.
//a) Для ввода данных от человека используется элемент TextBox;
//б) ** Реализовать отдельную форму c TextBox для ввода числа.
//    Рощупкин
namespace hw7task2
{
    public partial class mainForm : Form
    {
        Random rnd = new Random();
        public int num;
        public mainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            num = rnd.Next(1, 101);
            Form inputForm = new userInputForm(this);
            inputForm.ShowDialog();
        }
    }
}
