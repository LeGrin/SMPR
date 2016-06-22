using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modules.Tests
{
    public partial class TestsForm : Form
    {
        public Method CurrentMethod;
        public TestsForm()
        {
            InitializeComponent();
        }
        public void LoadDataFromMethod()
        {
            label6.Text = CurrentMethod.currentQuestion.questionsText;
            if (CurrentMethod.currentQuestion.numberOfVariantOfAnswers == 2)
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                radioButton5.Visible = false;

                radioButton1.Text = CurrentMethod.currentQuestion.masMark[0].text;
                radioButton2.Text = CurrentMethod.currentQuestion.masMark[1].text;                
            }
            if (CurrentMethod.currentQuestion.numberOfVariantOfAnswers == 3)
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = false;
                radioButton5.Visible = false;

                radioButton1.Text = CurrentMethod.currentQuestion.masMark[0].text;
                radioButton2.Text = CurrentMethod.currentQuestion.masMark[1].text;
                radioButton3.Text = CurrentMethod.currentQuestion.masMark[2].text;                
            }
            if (CurrentMethod.currentQuestion.numberOfVariantOfAnswers == 4)
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                radioButton5.Visible = false;

                radioButton1.Text = CurrentMethod.currentQuestion.masMark[0].text;
                radioButton2.Text = CurrentMethod.currentQuestion.masMark[1].text;
                radioButton3.Text = CurrentMethod.currentQuestion.masMark[2].text;
                radioButton4.Text = CurrentMethod.currentQuestion.masMark[3].text;                
            }
            if (CurrentMethod.currentQuestion.numberOfVariantOfAnswers == 5)
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                radioButton5.Visible = true;

                radioButton1.Text = CurrentMethod.currentQuestion.masMark[0].text;
                radioButton2.Text = CurrentMethod.currentQuestion.masMark[1].text;
                radioButton3.Text = CurrentMethod.currentQuestion.masMark[2].text;
                radioButton4.Text = CurrentMethod.currentQuestion.masMark[3].text;
                radioButton5.Text = CurrentMethod.currentQuestion.masMark[4].text;
            }
            
            
            //Loading label and radiobuttons (from CurrentQuestion)...
            //Don't forget clear radiobuttons (how? - xz!.. )
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Answer();
            if(!CurrentMethod.ExistNotAnsweredQuestion())
            {
                CurrentMethod.ShowResults();
                MessageBox.Show(CurrentMethod.FinalConclusion);
                return;
            }
            CurrentMethod.currentQuestion = CurrentMethod.FindFirstNotAnsweredQuestionAfterCurrentAnswerQuestionAndYouWillFuckWithReadingThisFunctionNameDoYouLikeItPutQuestionSymbolHereWeaReCoolProgrammersYeah();            
            
            LoadDataFromMethod();
        }
        public void Answer()
        {
            // якщо юзер (лох) відповів на поточне запитання(клікнуло на RadioButton), а не пропустило його,
            // то рахуєтсья новий поточний результат тестування (просто додаєься бал).
            //if (CurrentMethod.CurrentQuestionAnswered())
            {
                CurrentMethod.MarkAnsweredQuestion();
                CurrentMethod.CountNewResult(LastAnswer());                
            }

            if (!CurrentMethod.ExistNotAnsweredQuestion())
            {
                button1.Enabled = false;                
                CurrentMethod.ShowResults();
                return;
            }
        }
        private int LastAnswer()
        {
            if (radioButton1.Checked)
                return 1;
            if (radioButton2.Checked)
                return 2;
            if (radioButton3.Checked)
                return 3;
            if (radioButton4.Checked)
                return 4;
            if (radioButton5.Checked)
                return 5;
            return 0;
        }
    }
}