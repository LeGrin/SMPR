using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Tests.Methods
{
    class MethodOptimist2 : Method
    {
        Conclusion[] conclMass = new Conclusion[3];
        public MethodOptimist2()
        {
            conclMass[0] = new Conclusion(7, 100, @"У вас явно склалося негативне світосприйняття. Швидше за все, причина тому - ваші минулі невдачі. Звичайно, важко повірити, що завтра у вас буде все добре якщо сьогодні, так само, як і вчора, життя схоже на кошмарний сон. Тому радимо почитати біографії відомих людей. Після цього прочитання власні кошмари здаватимуться вам навіть забавними. Якщо конкретно, то в першу чергу починайте переорієнтувати свій настрій на позитивний полюс. Марно що-небудь робити для зміни ситуації, якщо наперед узята негативна установка");
            conclMass[1] = new Conclusion(3, 7, @"Це добре, що ви прагнете мислити позитивними категоріями, але, на жаль, це не завжди виходить. Річ у тім, що у вас сформувалося похмуре світовідчування. А результат? Похмурість в оцінках породжує тільки песимізм. Втім, не все втрачено. Насамперед припиніть озиратися на минуле або «повертайтеся в нього» тільки за добрим. Коли ви перестанете у всіх своїх починах відштовхуватися від негативу, візьметеся як би почати все з чистого листа, вам здаватиметься, що все йде добрие (або непогано) і є певні шанси на успіх. Відчуття і думки можна коректувати, в усякому разі, це простіше, ніж впливати на ситуацію. Настроюйтеся на позитивну хвилю і — вперед по життю!");
            conclMass[2] = new Conclusion(0, 3, @"Ви дивитеся на життя ясно і радісно. Люди вашого типу зазвичай мають шалений успіх у представників протилежної статі. Нічого дивного - з вами легко, весело і завжди можна зарядитись позитивною енергією. Наперекір труднощам життя ви вірите, що важливо залишатися оптимістом, навіть якщо доля буває не цілком справедливою до вас. Така позиція рятує не тільки від сьогодніщніх проблем та зневір, але є і заставою майбутнього процвітання. Постарайтеся не угра-тить цієї «легкості» в сприйнятті життя.");
            numberOfQuestions = 15;
        }
        public override string Name
        {
            get { return "Чи ви оптиміст?"; }
        }

        public int GetNum()
        {
            return numberOfQuestions;
        }
        /// <summary>
        /// рахується бал за поточние питання.
        /// </summary>
        /// <param name="answerForCurrentQuestion"></param>
        /// <returns>Num of radioButton.</returns>
        override public int CountResultOfCurrentQuestion(int answerForCurrentQuestion)
        {
            return currentQuestion.masMark[answerForCurrentQuestion - 1].ball;
        }
        /// <summary>
        /// Set Texts of questions.
        /// </summary>
        override public void InitAttributesOfQuestions()
        {
            questions[0] = new Question(@"Ви такий же щасливий, як і ваші знайомі?", false, 2, new variant("так", 0), new variant("ні", 1));
            questions[1] = new Question(@"Чи доводилося вам коли-небудь прокидатися з відчуттям, що ви можете все?", false, 2, new variant("так", 0), new variant("ні", 1));
            questions[2] = new Question(@"Ви гадаєте, що везе тільки іншим?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[3] = new Question(@"Ви вважаєте, що вашим родитеоям повезло, раз вони знайшли один одного?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[4] = new Question(@"Чи траплялося вам відчувати себе нещасною людиною без особливої причини?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[5] = new Question(@"Вам знайомо відчуття безнадійності?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[6] = new Question(@"Чи не здається вам, що життя взагалі безцільне?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[7] = new Question(@"Чи думаєте ви, що світ гідний жалю?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[8] = new Question(@"Чи сильно вас дратує шум?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[9] = new Question(@"Чи вважаєте ви, що доля несправедлива до вас? ", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[10] = new Question(@"Ви усміхаєтеся так само часто, як і люди, яких ви знаєте?", false, 2, new variant("так", 0), new variant("ні", 1));
            questions[11] = new Question(@"Ви вважаєте, вашому другу з вами дійсно повезло?", false, 2, new variant("так", 0), new variant("ні", 1));
            questions[12] = new Question(@"Чи можете ви перебувати в стані апатії тижнями?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[13] = new Question(@"Чи вважаєте ви, що ваше життя зіпсовано, головним чином, іншими людьми?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[14] = new Question(@"Чи сильно вас травмують невдачі?", false, 2, new variant("так", 1), new variant("ні", 0));
        }
        /// <summary>
        /// нормування (с)Ертонг
        /// </summary>
        override public void CountFinalResult()
        {

            // Setup FinalResult and FinalConclusion.
            // It will be setup value of FinalResult ( [0,1] ).
        }
        protected string GetConclusion()
        {
            for (int i = 0; i < conclMass.Length; i++)
                if (summResult <= conclMass[i].b && summResult >= conclMass[i].a)
                    return conclMass[i].textOfConclusion;
            return "";
        }
        override protected void InitConclusions()
        {
            FinalConclusion = GetConclusion();
        }
    }
}
