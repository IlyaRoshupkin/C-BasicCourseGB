using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw8task4
{
    public partial class FormMain : Form
    {
        WordsAndTranslations wordsBase;
        public FormMain()
        {
            InitializeComponent();
            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            if(wordsBase != null)
            {
                textBoxEng.Text = wordsBase[(int)nud.Value - 1].Word;
                textBoxRus.Text = wordsBase[(int)nud.Value - 1].Translation;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (wordsBase == null)
            {
                MessageBox.Show("Создайте новую базу данных слов", "Сообщение");
                return;
            }
            wordsBase.Add((wordsBase.Count + 1).ToString(), "");
            nud.Maximum = wordsBase.Count;
            nud.Value = wordsBase.Count;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (nud.Maximum == 1 || wordsBase == null) return;
            wordsBase.Remove((int)nud.Value);
            nud.Maximum--;
            if (nud.Value > 1) nud.Value = nud.Value;
        }

        private void btnSaveWord_Click(object sender, EventArgs e)
        {
            if (wordsBase == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            if (String.IsNullOrWhiteSpace(textBoxEng.Text) || String.IsNullOrWhiteSpace(textBoxRus.Text))
                MessageBox.Show("Ничего не введено!");
            else
            {
                wordsBase[(int)nud.Value - 1].Word = textBoxEng.Text;
                wordsBase[(int)nud.Value - 1].Translation = textBoxRus.Text;
            }
        }

        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                wordsBase = new WordsAndTranslations(sfd.FileName);
                wordsBase.Save();
                wordsBase.Add("Введите слово", "Его перевод");
                nud.Minimum = 1;
                nud.Maximum = 1;
                nud.Value = 1;
            };
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                wordsBase = new WordsAndTranslations(ofd.FileName);
                wordsBase.Load();
                nud.Minimum = 1;
                nud.Maximum = wordsBase.Count;
                nud.Value = 1;
            }
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            if (wordsBase != null) wordsBase.Save();
            else MessageBox.Show("База данных не создана");
        }

        private void miSaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            try
            {
                string filename = saveFileDialog.FileName;
                File.WriteAllText(filename, File.ReadAllText(wordsBase.FileName));
                MessageBox.Show("Файл сохранен");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка при сохранении файла");
            }
        }
    }
}
