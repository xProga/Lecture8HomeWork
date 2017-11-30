using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lecture8HomeWork
{
    public partial class MainForm : Form
    {
        ListOfQuestions liQ;
        List<bool> liCorrectAns = new List<bool>();
        int iQuestion = 0;

        public void EndGame()
        {
            if (iQuestion == liQ.liQuest.Count)
            {
                int i = 0;
                int countCorrectAns = 0;
                while (liCorrectAns.Count > i)
                {
                    if (liCorrectAns[i] == liQ.liQuest[i].AnswerTrueFalse)
                    {
                        countCorrectAns++;
                    }
                    i++;
                }
                MessageBox.Show("Количество верных ответов: "+ countCorrectAns , "Игра закончена!");
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            liQ = new ListOfQuestions();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GameStartButton_Click(object sender, EventArgs e)
        {
            MainPanel.Visible = true;

            string xmlFilePath = System.IO.File.ReadAllText(@"C:\Users\" + System.Environment.UserName + @"\Documents\SettingsGameTrueFalse.txt");

            liQ.Load(xmlFilePath);
            if (liQ.liQuest.Count > 0)
            {
                QuestionRichTextBox.Text = liQ.liQuest[iQuestion].QuestionText;
            }
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            liCorrectAns.Add(true);
            if (liQ.liQuest.Count > iQuestion)
            {
                iQuestion++;
                QuestionRichTextBox.Text = liQ.liQuest[iQuestion].QuestionText;
            }
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            liCorrectAns.Add(false);
            if (liQ.liQuest.Count > iQuestion)
            {
                iQuestion++;
                QuestionRichTextBox.Text = liQ.liQuest[iQuestion].QuestionText;
            }
        }

        private void начатьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings ss = new Settings(liQ);
            ss.ShowDialog();
        }
    }
}
