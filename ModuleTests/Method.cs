using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common;

namespace Modules.Tests
{
    public abstract class Method : Common.MethodAbstract
    {
        protected Question[] questions;
        public int numberOfQuestions;
        public int indexOfCurrQuestion=0;
        public Question currentQuestion;
        public int summResult=0;
        public double finRes = 0;
        protected int MaxBal=0;

        //public float FinalResult;    //v buffer
        //protected int NumberOfConcliusions=0;
        public string FinalConclusion;
        
        /*virtual public Method()
        {}*/
        /*virtual public void InitNumberOfVariantOfQuestions()
        {}*/
        virtual public void InitAttributesOfQuestions()
        { }
        virtual  public void CountFinalResult()
        { }
        virtual protected void InitConclusions()
        { }
        virtual public int CountResultOfCurrentQuestion(int answerForCurrentQuestion)
        {
            return numberOfQuestions;
        }
        public void InitQuestions()
        {
            InitAttributesOfQuestions();                                
        }

        public void CountMaxBal()
        {
            for (int i = 0; i < questions.Length; i++)
            {
                int temp = 0;
                for (int j = 0; j < questions[i].numberOfVariantOfAnswers; j++)
                    if (questions[i].masMark[j].ball > temp)
                        temp = questions[i].masMark[j].ball;
                MaxBal += temp;
            }
        }

        public Question FindFirstNotAnsweredQuestionAfterCurrentAnswerQuestionAndYouWillFuckWithReadingThisFunctionNameDoYouLikeItPutQuestionSymbolHereWeaReCoolProgrammersYeah()
        {
            if (indexOfCurrQuestion == numberOfQuestions - 1)
            {    for (int i = 0; i < numberOfQuestions; i++)
                if (!questions[i].questionFlag)
                {
                    indexOfCurrQuestion = i;
                    return questions[i];
                }
            }
            else
                for (int i = indexOfCurrQuestion+1; i < numberOfQuestions; i++)
                    if (!questions[i].questionFlag)
                    {
                        indexOfCurrQuestion = i;
                        return questions[i];
                    }
            for (int i = 0; i < numberOfQuestions; i++)
                if (!questions[i].questionFlag)
                {
                    indexOfCurrQuestion = i;
                    return questions[i];
                }
            return null;
        }

        public bool ExistNotAnsweredQuestion()
        {
            for (int i = 0; i < numberOfQuestions; i++)
                if (!questions[i].questionFlag)
                    return true;
            return false;
        }
        
        public void ShowResults()
        {
            CountFinalResult();
            InitConclusions();

      
            




        }

        public void CountNewResult(int answerForCurrentQuestion)
        {
            summResult += CountResultOfCurrentQuestion(answerForCurrentQuestion);
        }        

        public void MarkAnsweredQuestion()
        {
            currentQuestion.questionFlag = true;
        }

        public bool CurrentQuestionAnswered()
        {
            return currentQuestion.questionFlag;            
        }

        public void InitMethod()
        {
            questions = new Question[numberOfQuestions];
            summResult = 0;
            InitQuestions();
            currentQuestion = questions[0];
            indexOfCurrQuestion = 0;
        }

        public void InitQuestionFlags()
        {
            for (int i = 0; i < numberOfQuestions; i++)
                questions[i].questionFlag = false;
        }        
    }
}
