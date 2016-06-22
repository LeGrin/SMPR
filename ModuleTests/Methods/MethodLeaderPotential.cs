using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Tests.Methods
{
    class MethodLeaderPotential : Method
    {
        Conclusion[] conclMass = new Conclusion[3];
        public MethodLeaderPotential()
        {
            conclMass[0] = new Conclusion(0, 70, @"Ви — дисциплінований працівник, але не упевнені в собі, тому не проявляєте ініціативу і навряд чи поведете за собою колектив");
            conclMass[1] = new Conclusion(75, 100, @"Ви володієте виключно цінною якістю - вмінням приймати роль ведучого або відомого залежно від обставин. Пошана до авторитету не заважає вам мати власну точку зору. Для вас знайдеться місце в будь-якому колективі. Залишається тільки вибрати таке місце, яке б вас влаштовувало");
            conclMass[2] = new Conclusion(100, 150, @"Вам не позичати ініціативи і впевненості в собі. Схоже, сама природа підготувала вам роль ватажка, забезпечивши для цього необхідними якостями — сміливістю, цілеспрямованістю, твердою волею. Проте у цих достоїнств буває і зворотна сторона — завищена самооцінка, безцеремонність, невміння зважати на чужі інтереси. Ви зумієте добитися чималих успіхів, якщо пам'ятатимете: люди охоче йдуть за лідерами, але неполюбляють диктаторів");
            numberOfQuestions = 15;
        }
        public override string Name
        {
            get { return "Потенаціал лідера"; }
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
            //conclMass[0].a = 6;
            //conclMass[0].b = 9;
            //conclMass[0].textOfConclusion = @"Схоже, життя вас не раз випробувало, і ви вже не чекаєте від нього нічого доброго. Невдачі вважаєте неминучими, радощі - випадковими. Жалість до себе і недовіра до людей заважають вам радіти життю. Щоб підбадьоритися, навчіться цінувати ті маленькі радощі, які випадають кожному з нас. Не забувайте: життя ніколи не є настільки поганим, щоб його не можна було змінити нашим ставленням до нього.";
            //conclMass[1].a = 10;
            //conclMass[1].b = 14;
            //conclMass[1].textOfConclusion = @"Ви розсудлива людина, що знає ціну собі і людям. Ви вмієте ставити перед собою реальну мету і добиватися її. Ясно бачите тіньові сторони життя, але не схильні їх смакувати. Для своїх друзів і близьких ви — надійна опора, тому що вмієте і втішити в горі, і остудити надмірне захоплення.";
            //conclMass[2].a = 15;
            //conclMass[2].b = 18;
            //conclMass[2].textOfConclusion = @"Ваш оптимізм просто б'є через край. Неприємності для вас немов і не існують, і ви від них просто відмахуєетесь і поспішаєте назустріч новим радощам. Проте задумайтеся: чи не дуже легковажна ваша позиція? Не виключено, що недооцінка серйозних проблем одного разу примусить вас зіткнутися з несподіваними засмученнями.";    
            questions[0] = new Question("Якщо якась авторитетна особа публічно виказує думку, яку я вважаю неправильною, я постараюся, щоб присутні вислухали і мою точку зору", false, 3, new variant("завжди", 10), new variant("не впевнений, сумніваюся", 5), new variant("не згоден", 0));
            questions[1] = new Question("У дитинстві мене частенько називали неслухняною дитиною", false, 3, new variant("завжди", 10), new variant("не впевнений, сумніваюся", 5), new variant("не згоден", 0));
            questions[2] = new Question("Переконаний, що навколишній світ може бути краще", false, 3, new variant("завжди", 10), new variant("не впевнений, сумніваюся", 5), new variant("не згоден", 0));
            questions[3] = new Question("Не люблю, коли друзі і рідні намагаються мене опікати, набридають порадами", false, 3, new variant("завжди", 10), new variant("не впевнений, сумніваюся", 5), new variant("не згоден", 0));
            questions[4] = new Question("В ситуаціях, що вимагають серйозного рішення, я не схильний до довгих коливань", false, 3, new variant("завжди", 10), new variant("не впевнений, сумніваюся", 5), new variant("не згоден", 0));
            questions[5] = new Question("Здається, більшість суспільно-політичних проблем виникає через недостатню твердість відповідальних керівників", false, 3, new variant("завжди", 10), new variant("не впевнений, сумніваюся", 5), new variant("не згоден", 0));
            questions[6] = new Question("Я не збентежуюся, якщо мені доводиться комусь дорікати", false, 3, new variant("завжди", 10), new variant("не впевнений, сумніваюся", 5), new variant("не згоден", 0));
            questions[7] = new Question("Якщо з якоюсь справою неможливо справитися самотужки, то для її виконання мені потрібні помічники, а не порадники", false, 3, new variant("завжди", 10), new variant("не впевнений, сумніваюся", 5), new variant("не згоден", 0));
            questions[8] = new Question("В суперечках завжди прагну залишити за собою останнє слово", false, 3, new variant("завжди", 10), new variant("не впевнений, сумніваюся", 5), new variant("не згоден", 0));
            questions[9] = new Question("Вважаю, що ніякий прогрес немислимий без прагнення людей до переваги над іншими", false, 3, new variant("завжди", 10), new variant("не впевнений, сумніваюся", 5), new variant("не згоден", 0));
            questions[10] = new Question("Часто мені доводиться брати на себе відповідальність, тому що інші недостатньо рішучі", false, 3, new variant("завжди", 10), new variant("не впевнений, сумніваюся", 5), new variant("не згоден", 0));
            questions[11] = new Question("Не вірю в абсолютну рівноправність в подружніх відносинах, в своїй сім'ї вважаю за краще бути главою", false, 3, new variant("завжди", 10), new variant("не впевнений, сумніваюся", 5), new variant("не згоден", 0));
            questions[12] = new Question("Коли в гостях ніхто не наважується взяти з блюда останній шматок торта, я спокійно можу це зробити", false, 3, new variant("завжди", 10), new variant("не впевнений, сумніваюся", 5), new variant("не згоден", 0));
            questions[13] = new Question("Люблю бути в центрі уваги", false, 3, new variant("завжди", 10), new variant("не впевнений, сумніваюся", 5), new variant("не згоден", 0));
            questions[14] = new Question("В своїй кар'єрі готовий змиритися з роллю підлеглого тільки як з тимчасовою", false, 3, new variant("завжди", 10), new variant("не впевнений, сумніваюся", 5), new variant("не згоден", 0));

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

