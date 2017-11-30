using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture8HomeWork
{
    public partial class Settings : Form
    {
        ListOfQuestions liQ;
        public Settings(ListOfQuestions liQ)
        {
            this.liQ = liQ;
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            try
            {
                PathSettingsFileTextBox.Text = System.IO.File.ReadAllText(@"C:\Users\" + System.Environment.UserName + @"\Documents\SettingsGameTrueFalse.txt");
            }
            catch
            {
                MessageBox.Show("Отсутствует файл с настроуками игры. Укажите к нему путь или создайте его", "Упс...");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PathSettingsFileTextBox.Text = ofd.FileName;
                System.IO.File.WriteAllText(@"C:\Users\" + System.Environment.UserName + @"\Documents\SettingsGameTrueFalse.txt", ofd.FileName);
            }
        }

        private void AddQuestionButton_Click(object sender, EventArgs e)
        {
            if (QuestionRichTextBox.Text != string.Empty && (TrueRadioButton.Checked || FalseRadioButton.Checked))
            {
                if (TrueRadioButton.Checked)
                {
                    liQ.Add(QuestionRichTextBox.Text, true);
                }
                if (FalseRadioButton.Checked)
                {
                    liQ.Add(QuestionRichTextBox.Text, false);
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
