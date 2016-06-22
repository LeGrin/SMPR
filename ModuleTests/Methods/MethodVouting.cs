using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Tests.Methods
{
    public class MethodVouting : Method
    {
        Conclusion[] conclMass = new Conclusion[5];
        public MethodVouting()
        {
            conclMass[0] = new Conclusion(0,5, @"На жаль, ваш рівень незадовільний");
            conclMass[1] = new Conclusion(6,7, @"ваш рівень задовільний, і не більше");
            conclMass[2] = new Conclusion(8, 9, @"ви добре впоралися із завданням");
            conclMass[3] = new Conclusion(9, 10, @"ви відмінно впоралися із завданнм");
            conclMass[4] = new Conclusion(11, 11, @"Ви дали правильні відповіді на всі поставлені запитання");


            numberOfQuestions = 12;
        }
        public override string Name
        {
            get { return Properties.Resources.ArtisticMethodName; }
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
            return currentQuestion.masMark[answerForCurrentQuestion - 1].ball;
        }
        /// <summary>
        /// Set Texts of questions.
        /// </summary>
        override public void InitAttributesOfQuestions()
        {
            questions[0] = new Question("Яке з правил голосування є немонотонним?", false, 4,
 new variant("Копленда", 0),
 new variant("Сімпсона", 0),
 new variant("узагальнене Борда", 0),
 new variant("відносної більшості з вибуванням", 1));
            questions[1] = new Question("Яка з аксіом не згадується у «Парадоксі Ерроу»?", false, 4,
             new variant("аксіома монотонності", 1),
             new variant("аксіома ефективності(одностайності)", 0),
             new variant("аксіома незалежності", 0),
             new variant("аксіома транзитивності.", 0));
            questions[2] = new Question(@"Кубкова система, що використовується у багатьох 
видах спорту є застосуванням правила", false, 4,
             new variant("Копленда", 0),
             new variant("Борда", 0),
             new variant("послідовного виключення", 0),
             new variant("паралельного виключення", 1));
            questions[3] = new Question(@"Відображення голосування базується на правилі 
підрахунку балів тоді й лише тоді, коли 
задовольняє наступним чотирьом аксіомам: 
анонімності, поповнення, 
неперервності та...", false, 4,
             new variant("нейтральності", 1),
             new variant("участі", 0),
             new variant("ефективності", 0),
             new variant("незалежності", 0));
            questions[4] = new Question("Виберіть правильне твердження:", false, 4,
             new variant(@"Правило Сімпсона відповідає 
егалітарному, а правило Копленда 
— утилітарному критерію вибору", 1),
             new variant(@"Правило Сімпсона відповідає 
утилітарному, а правило Копленда
— егалітарному критерію вибору", 0),
             new variant(@"Правила Копленда і Сімпсона 
відповідають утилітарному критерію вибору", 0),
             new variant(@"Правила Копленда і Сімпсона 
відповідають егалітарному 
критерію вибору", 0));
            questions[5] = new Question(@"Яке з наведених правил 
не гарантує наявності переможця?", false, 4,
             new variant("Сімпсона", 0),
             new variant("Кондорсе", 1),
             new variant("Борда", 0),
             new variant("всі наведені гарантують", 0));
            questions[6] = new Question(@"Переможець Кондорсе(якщо існує) 
завжди є також переможцем...", false, 4,
             new variant("Копленда і Сімпсона ", 1),
             new variant("Сімпсона і Борда", 0),
             new variant("Борда і відносної більшості", 0),
             new variant("відносної більшості і Копленда", 0));
            questions[7] = new Question("Виберіть невірне твердження:", false, 4,
             new variant(@"правило Сімпсона 
задовольняє аксіомі поповнення", 0),
             new variant(@"правило Борда 
задовольняє аксіомі монотонності", 0),
             new variant(@"правило Копленда 
не задовольняє аксіомі монотонності", 1),
             new variant(@"правило Кондорсе 
не задовольняє аксіомі поповнення", 0));
            questions[8] = new Question(@"Яке правило голосування задовольняє 
аксіомам ефективності, незалежності,
повноти, транзитивності та 
відсутності диктатора?", false, 4,
             new variant("відносної більшості", 0),
             new variant("Борда", 0),
             new variant("Кондорсе", 0),
             new variant("такого правила не існує", 1));
            questions[9] = new Question(@"Якщо при виборі переможця за 
правилом Кондорсе немає кандидата,
що перемагає усіх інших, то...", false, 4,
             new variant("переможця не існує ", 1),
             new variant(@"перемагає той, що має 
більше перемог у попарних порівняннях", 0),
             new variant("переможець вибирається “головою жюрі”", 0),
             new variant("переможець обирається випадковим чином", 0));
            questions[10] = new Question(@"У цьому правилі за останнє місце кандидата 
йому нараховується 0 балів (очок),
за передостаннє – 1, ..., за перше – (m41).
Перемагає кандидат з 
найбільшою сумою очок.", false, 4,
             new variant("правило Борда", 1),
             new variant("правило Кондорсе", 0),
             new variant("правило Сімпсона", 0),
             new variant("правило Копленда", 0));
            questions[11] = new Question("“Диктатором” називається виборець такий, що:", false, 4,
             new variant("примушує інших голосувати за свого кандидата", 0),
             new variant("його голос має більшу вагу ніж у інших", 0),
             new variant(@"встановлює переможця незалежно 
від думки інших виборців", 0),
             new variant(@"коллективний порядок 
співпадає з його індивідуальним порядком", 1));
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
