using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Tests.Methods
{
    class MethodOptimist:Method
    {
        Conclusion[] conclMass = new Conclusion[3];
        public MethodOptimist()
        {
            conclMass[0] = new Conclusion(0, 13, @"Схоже, життя вас не раз випробувало,
і ви вже не чекаєте від нього нічого доброго.
Невдачі вважаєте неминучими,
радощі - випадковими.
Жалість до себе і недовіра до людей заважають
вам радіти життю.
Щоб підбадьоритися, навчіться цінувати ті маленькі радощі,
які випадають кожному з нас. Не забувайте:
життя ніколи не є настільки поганим,
щоб його не можна було змінити нашим ставленням до нього.");
            conclMass[1] = new Conclusion(14, 23, @"Ви розсудлива людина, що знає ціну собі і людям.
Ви вмієте ставити перед собою реальну мету і добиватися її.
Ясно бачите тіньові сторони життя, але не схильні їх смакувати.
Для своїх друзів і близьких ви — надійна опора,
тому що вмієте і втішити в горі,
і остудити надмірне захоплення.");
            conclMass[2] = new Conclusion(24, 30, @"Ваш оптимізм просто б'є через край.
Неприємності для вас немов і не існують,
і ви від них просто відмахуєетесь і поспішаєте
назустріч новим радощам. Проте задумайтеся:
чи не дуже легковажна ваша позиція?
Не виключено, що недооцінка серйозних проблем одного
разу примусить вас зіткнутися з несподіваними засмученнями.");
            numberOfQuestions = 35;
        }
        public override string Name
        {
            get { return Properties.Resources.OptimistMethodName; }
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
            if (answerForCurrentQuestion == 0)
                return 0;
            return currentQuestion.masMark[answerForCurrentQuestion-1].ball;            
        }
        /// <summary>
        /// Set Texts of questions.
        /// </summary>
        override public void InitAttributesOfQuestions()
        {
            questions[0] = new Question(@"Ви любите подорожувати?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[1] = new Question(@"Хотілося б вам ще чомусь навчитися
крім того, що ви вже умієте?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[2] = new Question(@"Ви часто приймаєте снодійне,
заспокійливе?", false, 2, new variant("так", 0), new variant("ні", 1));
            questions[3] = new Question(@"Чи подобається вам ходити в гості
і приймати гостей?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[4] = new Question(@"Чи часто вам вдається передбачити
неприємності, що насуваються?", false, 2, new variant("так", 0), new variant("ні", 1));
            questions[5] = new Question(@"Чи не здається вам, що ваші товариші
зуміли добитися в житті більшого ніж ви?", false, 2, new variant("так", 0), new variant("ні", 1));
            questions[6] = new Question(@"Чи знаходиться у вашому житті місце
якимсь спортивним заняттям?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[7] = new Question(@"Чи вважаєте ви, що доля несправедлива до вас?", false, 2, new variant("так", 0), new variant("ні", 1));
            questions[8] = new Question(@"Чи турбує вас можлива екологічна катастрофа?", false, 2, new variant("так", 0), new variant("ні", 1));
            questions[9] = new Question(@"Чи згодні ви, що науковий прогрес створює
більше проблем, ніж вирішує? ", false, 2, new variant("так", 0), new variant("ні", 1));
            questions[10] = new Question(@"Чи вдало ви вибрали свою професію?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[11] = new Question(@"Ви застрахували своє майно?", false, 2, new variant("так", 0), new variant("ні", 1));
            questions[12] = new Question(@"Погодилися б ви на переїзд в інше місто,
якби там вам запропонували цікаву роботу?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[13] = new Question(@"Чи задоволені ви своєю зовнішністю?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[14] = new Question(@"Чи часто вас турбують нездужання?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[15] = new Question(@"Чи легко вам освоїтися в незнайомому оточенні, знайти своє місце в новому колективі?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[16] = new Question(@"Чи вважають вас оточуючі енергійною,
діяльною людиною?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[17] = new Question(@"Чи вірите ви в безкорисливу дружбу?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[18] = new Question(@"Чи існують для вас особисті добрі
прикмети - фартові числа, вдалі дні тижня?", false, 2, new variant("так", 1), new variant("ні", 0));
            questions[19] = new Question(@"Чи вірите ви в те,
що кожен - сам коваль свого щастя?", false, 2, new variant("так", 1), new variant("ні", 0));            
            
            //from optimist2

            questions[20] = new Question(@"Ви такий же щасливий, як і ваші знайомі?", false, 2,
                                new variant("так", 0),
                                new variant("ні", 1));

            questions[21] = new Question(@"Чи доводилося вам коли-небудь
прокидатися з відчуттям, що ви можете все?", false, 2,
                                new variant("так", 0),
                                new variant("ні", 1));

            questions[22] = new Question(@"Ви вважаєте, що щастить тільки іншим?", false, 2,
                                new variant("так", 1),
                                new variant("ні", 0));

            questions[23] = new Question(@"Чи вважаєте ви, що вашим батькам пощастило,
коли вони знайшли один одного?", false, 2,
                                new variant("так", 1),
                                new variant("ні", 0));

            questions[24] = new Question(@"Чи траплялося вам відчувати себе
нещасною людиною без особливої причини?", false, 2,
                                new variant("так", 1),
                                new variant("ні", 0));

            questions[25] = new Question(@"Вам знайомо відчуття безнадійності?", false, 2,
                                new variant("так", 1),
                                new variant("ні", 0));

            questions[26] = new Question(@"Чи не здається вам, що життя
взагалі безцільне?", false, 2,
                                new variant("так", 1),
                                new variant("ні", 0));

            questions[27] = new Question(@"Чи думаєте ви, що світ гідний жалю?", false, 2,
                                new variant("так", 1),
                                new variant("ні", 0));

            questions[28] = new Question(@"Чи сильно вас дратує шум?", false, 2,
                                new variant("так", 1),
                                new variant("ні", 0));

            questions[29] = new Question(@"Чи вважаєте ви, що доля
несправедлива до вас? ", false, 2,
                                new variant("так", 1),
                                new variant("ні", 0));

            questions[30] = new Question(@"Ви усміхаєтеся так само часто,
як і люди, яких ви знаєте?", false, 2,
                                new variant("так", 0),
                                new variant("ні", 1));

            questions[31] = new Question(@"Ви вважаєте, вашому другу з
вами дійсно пощастило?", false, 2,
                                new variant("так", 0),
                                new variant("ні", 1));

            questions[32] = new Question(@"Чи можете ви перебувати в
стані апатії тижнями?", false, 2,
                                new variant("так", 1),
                                new variant("ні", 0));

            questions[33] = new Question(@"Чи вважаєте ви, що ваше життя
зіпсовано, головним чином, іншими людьми?", false, 2,
                                new variant("так", 1),
                                new variant("ні", 0));

            questions[34] = new Question(@"Чи сильно вас травмують невдачі?", false, 2,
                                new variant("так", 1),
                                new variant("ні", 0));

        }
        /// <summary>
        /// нормування (с)Ертонг
        /// </summary>
        override public void CountFinalResult()
        {
            // Setup FinalResult and FinalConclusion.
            // It will be setup value of FinalResult ( [0,1] ).
            CountMaxBal();
            finRes = ((double)summResult) / MaxBal;
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
