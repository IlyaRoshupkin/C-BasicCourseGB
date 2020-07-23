using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//2. Создайте простую форму на котором свяжите свойство Text элемента TextBox со свойством
//Value элемента NumericUpDown
//Рощупкин
namespace hw8task2
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void numUpDown_ValueChanged(object sender, EventArgs e)
        {
            textBox.Text = numUpDown.Value.ToString();
        }
    }
}
