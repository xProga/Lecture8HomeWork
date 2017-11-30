using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;

namespace Lecture8HomeWork
{
    public class Question
    {
        public string QuestionText { get; set; }
        public bool AnswerTrueFalse { get; set; }

        public Question()
        { }

        public Question(string text, bool trueFalse)
        {
            this.QuestionText = text;
            this.AnswerTrueFalse = trueFalse;
        }
    }

    public class ListOfQuestions
    {
        string saveFilePath = System.IO.File.ReadAllText(@"C:\Users\" + System.Environment.UserName + @"\Documents\SettingsGameTrueFalse.txt");
        public List<Question> liQuest;
        XElement mainEl = new XElement("Main");

        public void Add(Question qs)
        {
            liQuest.Add(qs);
        }

        public void Add(string questionText, bool answer)
        {
            liQuest.Add(new Question
            {
                QuestionText = questionText,
                AnswerTrueFalse = answer
            });
        }

        public void Save()
        {
            if (liQuest != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    foreach (var item in liQuest)
                    {
                        XElement question = new XElement("Question");
                        XElement questionText = new XElement("QuestionText");
                        questionText.Add(item.QuestionText);
                        XElement answerTrueFalse = new XElement("AnswerTrueFalse");
                        answerTrueFalse.Add(item.AnswerTrueFalse);

                        question.Add(questionText, answerTrueFalse);
                        mainEl.Add(question);
                    }
                    mainEl.Save(sfd.FileName);
                    saveFilePath = sfd.FileName;
                    System.IO.File.WriteAllText(@"C:\Users\" + System.Environment.UserName + @"\Documents\SettingsGameTrueFalse.txt", saveFilePath);
                }
            }
        }

        public List<Question> Load(string xmlFilePath)
        {
            string xmlContent = System.IO.File.ReadAllText(xmlFilePath);
            var xmlText = XDocument.Parse(xmlContent).
                Descendants("Main").
                Descendants("Question").
                ToList<XElement>();
            liQuest = null;

            foreach (var item in xmlText)
            {
                liQuest.Add(new Question
                {
                    QuestionText = item.Element("QuestionText").Value,
                    AnswerTrueFalse = Convert.ToBoolean(item.Element("AnswerTrueFalse").Value)
                });
            }

            return liQuest;
        }

        public 
    }
}
