using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//1. а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
//б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число
//должен получить игрок.Игрок должен получить это число за минимальное количество ходов.
//в) * Добавить кнопку «Отменить», которая отменяет последние ходы.Используйте
// обобщенный класс Stack.
// Вся логика игры должна быть реализована в классе с удвоителем.
//    Рощупкин
namespace homework7
{
    public partial class formMain : Form
    {
        FormEvent formEvent = new FormEvent(); 

        public formMain()
        {
            InitializeComponent();
        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            formEvent.PlusOne();
            UpdateForm();
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            formEvent.TimesTwo();
            UpdateForm();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            formEvent.Refresh();
            UpdateForm();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            EnableButtons();
            formEvent.StartGame();
            
            lblStepsRest.Text = formEvent.stepsRest.ToString();
            lblTask.Text = formEvent.task.ToString();
        }

        private void EnableButtons()
        {
            if(!btnCommand1.Enabled)
            {
                btnCommand1.Enabled = true;
                btnCommand2.Enabled = true;
                btnReset.Enabled = true;
                btnCansel.Enabled = true;
                btnPlay.Enabled = false;
            }
            else
            {
                btnCommand1.Enabled = false;
                btnCommand2.Enabled = false;
                btnReset.Enabled = false;
                btnCansel.Enabled = false;
                btnPlay.Enabled = true;
            }
        }

        private void RefreshFields()
        {
            formEvent.GetStartValues();
            UpdateForm();
        }

        public void UpdateForm()
        {
            labelNumber.Text = formEvent.currentNum.ToString();
            lblCounter.Text = formEvent.stepsMade.ToString();
            lblStepsRest.Text = formEvent.stepsRest.ToString();
            lblTask.Text = formEvent.task.ToString();
            if(formEvent.IsTheEndOfGame())
            {
                RefreshFields();
                EnableButtons();
            }
               
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            formEvent.Cansel();
            UpdateForm();
        }
    }

    public class FormEvent
    {
        public int currentNum = 1;
        public int stepsMade = 0;
        public int stepsRest = 0;
        public int task = 0;
        Stack<FormEvent> events = new Stack<FormEvent>();
        Random rnd = new Random();

        public void PlusOne()
        {
            events.Push(new FormEvent() { currentNum = currentNum + 1,stepsMade=stepsMade+1 });
            currentNum++;
            stepsMade++;
            stepsRest--;
        }
        public void TimesTwo()
        {
            events.Push(new FormEvent() { currentNum = currentNum * 2, stepsMade = stepsMade + 1 });
            currentNum *= 2;
            stepsMade++;
            stepsRest--;
        }
        public void Refresh()
        {
            events.Push(new FormEvent() { currentNum = 0, stepsMade = stepsMade + 1 });
            currentNum = 1;
            stepsMade++;
            stepsRest--;
        }
        public void Cansel()
        {
            if (events.Count > 0)
            {
                int tempNum = currentNum;
                currentNum = events.Pop().currentNum;
                if (currentNum == 2)
                {
                    currentNum = 1;
                    stepsRest += stepsMade-1;
                    stepsMade = 1;
                }
                    
                else if (tempNum == currentNum)
                    currentNum = events.Pop().currentNum;
                stepsMade--;
                stepsRest++;
            }
            else
                return;
        }

        internal void StartGame()
        {
            task = rnd.Next(2,100);
            stepsRest = (int)Math.Sqrt((double)task) + task %
                ((int)Math.Sqrt((double)task) * (int)Math.Sqrt((double)task)) ;
            MessageBox.Show($"Получите число: {task} за {stepsRest} ходов.");
            events.Clear();
        }

        internal void GetStartValues()
        {
            stepsRest = 0;
            stepsMade = 0;
            task = 0;
            currentNum = 1;
        }

        internal bool IsTheEndOfGame()
        {
            if (stepsRest == 0 && currentNum != task && stepsMade != 0)
            {
                MessageBox.Show("Потрачены все ходы!");

                return true;
            }
            else if (currentNum == task && task != 0)
            {
                MessageBox.Show("Вы выиграли!");
                return true;
            }
            else
                return false;
        }
    }
}
