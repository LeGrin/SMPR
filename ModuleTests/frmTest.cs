using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modules.Tests
{
    public partial class frmTest : Form
    {
        public Method CurrentMethod;
        public RadioButton[] rdButtonVar=null;
        public frmTest(Method CurrentMethod)
        {
            InitializeComponent();
            this.CurrentMethod = CurrentMethod;
            CurrentMethod.InitMethod();
            this.Text = this.CurrentMethod.Name;
            LoadDataFromMethod();
        }

        public void LoadDataFromMethod()
        {
            // Print number of current question 
            groupBox1.Text = "Запитання №" + (CurrentMethod.indexOfCurrQuestion+1).ToString() + " (з " + CurrentMethod.numberOfQuestions + ")";
            // 
            label6.Text = CurrentMethod.currentQuestion.questionsText;
            // Delete radiobuttons from form & dispose rdbuttons.
            if(rdButtonVar!=null)
                for (int i = 0; i < rdButtonVar.Length; i++)
                {
                    groupBox2.Controls.Remove(rdButtonVar[i]);
                    rdButtonVar[i].Dispose();
                }
            
            rdButtonVar = new RadioButton[CurrentMethod.currentQuestion.numberOfVariantOfAnswers];
            for (int i = 0; i < rdButtonVar.Length; i++)
            {
                rdButtonVar[i] = new RadioButton();
                rdButtonVar[i].AutoSize = true;
                rdButtonVar[i].Text = CurrentMethod.currentQuestion.masMark[i].text;
                rdButtonVar[i].Location = new Point(20, 18+i * 50);
                groupBox2.Controls.Add(rdButtonVar[i]);
                //Controls.Remove(rdButtonVar[i]);
            }
            // Set first variant as checked
            rdButtonVar[0].Checked = true;
            return;
            
            //Loading label and radiobuttons (from CurrentQuestion)...
            //Don't forget clear radiobuttons (how? - xz!.. )
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rdButtonVar.Length; i++)
                if (rdButtonVar[i].Checked)
                    CurrentMethod.MarkAnsweredQuestion();

            Answer();
            if (!CurrentMethod.ExistNotAnsweredQuestion())
            {
                button1.Enabled = false;
                CurrentMethod.ShowResults();
                MessageBox.Show(CurrentMethod.FinalConclusion);
                DialogResult result = MessageBox.Show("Бажаєте відкрити новий тест?", "Тест закінчено", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    Module mod = new Module();
                    mod.Show(null);
                }
                this.Close();
                return;
            }
            CurrentMethod.currentQuestion = CurrentMethod.FindFirstNotAnsweredQuestionAfterCurrentAnswerQuestionAndYouWillFuckWithReadingThisFunctionNameDoYouLikeItPutQuestionSymbolHereWeaReCoolProgrammersYeah();            
            
            LoadDataFromMethod();
            //radioButton1.Checked = true;
        }
        public void Answer()
        {
            // якщо юзер (лох) відповів на поточне запитання(клікнуло на RadioButton), а не пропустило його,
            // то рахуєтсья новий поточний результат тестування (просто додаєься бал).
            if (CurrentMethod.CurrentQuestionAnswered())
            {
                //CurrentMethod.MarkAnsweredQuestion();
                CurrentMethod.CountNewResult(LastAnswer());                
            }

            //if (!CurrentMethod.ExistNotAnsweredQuestion())
            //{
            //    button1.Enabled = false;                
            //    CurrentMethod.ShowResults();
            //    return;
            //}
        }
        private int LastAnswer()
        {
            for (int i = 0; i < rdButtonVar.Length; i++)
                if (rdButtonVar[i].Checked)
                    return i + 1;
            return 0;
        }

        private void frmTest_Load(object sender, EventArgs e)
        {

        }

        private void frmTest_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void frmTest_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmTest_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==8)
            {
                button1_Click(sender, e);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}