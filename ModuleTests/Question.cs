using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Tests
{
    public class Question
    {
        public variant[] masMark = new variant[5];
        /// <summary>
        /// Here will be saved text of question.
        /// </summary>
        public string questionsText;
        /// <summary>
        /// Here will be simple flag that indicates state of question.
        /// Value: true if it was answered, false - otherwise.
        /// </summary>
        public bool questionFlag=false;
        /// <summary>
        /// Value that point how much variants of answers on the question exist.
        /// It should value be between 1 and 5.
        /// </summary>
        public int numberOfVariantOfAnswers;
        public Question()
        { }
        /// <summary>
        /// Constructor for Question with parameters.
        /// </summary>
        /// <param name="test">The value for initialization of questionText</param>
        /// <param name="flag">The value for initialization of questionFlag.</param>
        /// <param name="numOfVar">The value for initialization of numberOfVariantOfAnswers.</param></param>
        /// <param name="balls">Balls for each variant of answer for question.</param>
        public Question(string test, bool flag, int numOfVar, params variant[] variants)
        {
            questionsText = test;
            questionFlag = flag;
            numberOfVariantOfAnswers = numOfVar;
            for (var i = 0; i < variants.Length; i++)
                masMark[i] = variants[i];
        }        
    }
}
