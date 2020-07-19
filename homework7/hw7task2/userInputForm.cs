using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw7task2
{
    public partial class userInputForm : Form
    {
        int attempts = 0;
        int num;
        public userInputForm(mainForm mainForm)
        {
            InitializeComponent();
            num = mainForm.num;
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            int userNum;
            bool temp = int.TryParse(tbInput.Text,out userNum);
            if (temp)
            {
                if (userNum == num)
                {
                    MessageBox.Show($"Вы угадали! Попыток: {attempts}");
                    attempts = 0;
                    tbInput.Clear();
                    this.Close();
                }
                else if(userNum > num)
                {
                    attempts++;
                    tbInput.Clear();
                    MessageBox.Show($"Слишком большое число. Попробуйте ещё раз. Попыток: {attempts}");
                }
                else if (userNum < num)
                {
                    attempts++;
                    tbInput.Clear();
                    MessageBox.Show($"Слишком маленькое число. Попробуйте ещё раз. Попыток: {attempts}");
                }
            }
            else
            {
                MessageBox.Show("Некорректный ввод!");
                tbInput.Clear();
            }
        }
    }
}
