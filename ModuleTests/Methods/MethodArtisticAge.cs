using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;



namespace Modules.Tests.Methods
{
    class MethodArtisticAge : Method
    {
        Conclusion[] conclMass = new Conclusion[2];
        public MethodArtisticAge()
        {
            numberOfQuestions = 10;
        }
        public override string Name
        {
            get { return Properties.Resources.ArtisticAgeMethodName; }
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
            switch (Thread.CurrentThread.CurrentUICulture.Name)
            {
                case "uk-UA":
                    questions[0] = new Question(@"Ви спізнюєтеся і знаходитеся недалеко
від автобусної зупинки. Підходить автобус.
Що ви зробите?", false, 5,
                                        new variant("побіжу, щоб встигнути", 0),
                                        new variant("йтиму якомога швидше", 2),
                                        new variant("буду йти трохи швидше, ніж звичайно", 6),
                                        new variant("йтиму, як йшов", 8),
                                        new variant(@"подивлюся, чи не йде наступний автобус, 
а потім вирішу, що робити", 4));

                    questions[1] = new Question("Ваше ставлення до моди", false, 5,
                                        new variant("визнаю і дію, щоб відповідати їй", 0),
                                        new variant("визнаю те, що мені підходить", 2),
                                        new variant("не визнаю сучасної моди взагалі", 6),
                                        new variant("не визнаю сучасні екстравагантні моделі", 8),
                                        new variant("визнаю і відкидаю, дивлячись по настрою", 4));

                    questions[2] = new Question("У вільний час ви охочіше за все", false, 5,
                                        new variant("проводите час із приятелями", 0),
                                        new variant("дивиться телевізор", 2),
                                        new variant("читаєте художню літературу", 6),
                                        new variant("розгадуєте кросворди", 8),
                                        new variant("займаєтеся чим завгодно", 4));

                    questions[3] = new Question(@"На ваших очах скоюється явна несправедливість.
Ваші дії",
                        false, 5,
                                        new variant(@"відразу постараюся відновити справедливість
всіма доступними засобами", 0),
                                        new variant(@"встати на сторону потерпілого і
постаратися йому допомогти", 2),
                                        new variant(@"постаратися відновити справедливість
в рамках закону", 6),
                                        new variant(@"засудити про себе чергову 
несправедливість і продовжити свої справи", 8),
                                        new variant(@"втрутитися в обговорення,
не виказуючи своєї думки", 4));

                    questions[4] = new Question("Коли ви слухаєте сучасну молодіжну музику, то", false, 5,
                                        new variant("приходите у захват", 0),
                                        new variant("думаєте, що і ви цим повинні перехворіти", 6),
                                        new variant("не визнаєте цей шум і гуркіт", 8),
                                        new variant("почуваєте задоволення", 2),
                                        new variant("вважаєте, що на смак і колір товаришів немає", 4));

                    questions[5] = new Question(@"Ви знаходитеся в дружній компанії.
Для вас важливо", false, 4,
                                        new variant("можливість продемонструвати свої здібності", 0),
                                        new variant(@"зробити так, щоб люди не забували,
з ким мають справи", 6),
                                        new variant("дотримуватися правил гарної поведінки", 8),
                                        new variant("поводитися відповідно до норм цієї компанії", 4));

                    questions[6] = new Question("Яка робота вам подобається?", false, 5,
                                        new variant("що містить елементи несподіванки і ризику", 0),
                                        new variant("не монотонна", 2),
                                        new variant(@"така, де можна використовувати
свій досвід і знання", 6),
                                        new variant("неважка", 8),
                                        new variant("дивлячись по настрою", 4));

                    questions[7] = new Question("Наскільки ви передбачливі?", false, 5,
                                        new variant(@"схильний прийматися за справи
не роздумуючи", 0),
                                        new variant(@"вважаю за краще спочатку діяти,
а вже потім міркувати", 2),
                                        new variant(@"вважаю за краще не брати участь
в справах, поки не з'ясовані основні їх наслідки", 6),
                                        new variant(@"вважаю за краще брати участь тільки
в таких справах, де успіх гарантований", 8),
                                        new variant(@"відношуся до справ залежно від ситуації", 4));

                    questions[8] = new Question("Чи довірливі ви", false, 5,
                                        new variant("довіряю деяким людям", 0),
                                        new variant("довіряю багатьом людям", 2),
                                        new variant("не довіряю багато кому", 6),
                                        new variant("не довіряю нікому", 8),
                                        new variant(@"все залежить від того,
з ким маю справу", 4));

                    questions[9] = new Question("Ваш настрій", false, 5,
                                        new variant("переважає оптимістичний", 0),
                                        new variant("часто оптимістичний", 2),
                                        new variant("часто песимістичний", 6),
                                        new variant("переважає песимістичний", 8),
                                        new variant("в залежності від обставин", 4));
                    break;
                case "ru-RU":
                    questions[0] = new Question(@"Вы опаздываете и находитесь неподалеку 
от автобусной остановки. Подходит автобус. 
Что вы сделаете?", false, 5,
                                    new variant("побегу, чтобы успеть", 0),
                                    new variant("буду идти как можно быстрее", 2),
                                    new variant("буду идти немного быстрее", 6),
                                    new variant("не изменю скорость", 8),
                                    new variant(@"посмотрю, не идёт ли следующий автобус, 
а потом решу, что делать", 4));

                    questions[1] = new Question("Ваше отношение к моде", false, 5,
                                        new variant("признаю и стараюсь соответствовать", 0),
                                        new variant("признаю то, что подходит мне", 2),
                                        new variant("не признаю современную моду", 6),
                                        new variant("не признаю современные экстравагантные модели", 8),
                                        new variant("признаю или отвергаю, смотря по настроению", 4));

                    questions[2] = new Question("В Ваше свободное время Вы скорее всего", false, 5,
                                        new variant("проведёте время с приятелями", 0),
                                        new variant("посмотрите телевизор", 2),
                                        new variant("почитаете художественную литературу", 6),
                                        new variant("порешаете кросворды", 8),
                                        new variant("займётесь чем угодно", 4));

                    questions[3] = new Question(@"На ваших глазах совершается явная несправедливость. 
Ваши действия",
                        false, 5,
                                        new variant(@"сразу постараюсь восстановить справедливость 
всеми доступными средствами", 0),
                                        new variant(@"встать на сторону потерпевшего и 
постараться ему помочь", 2),
                                        new variant(@"постараться восстановить справедливость 
в рамках закона", 6),
                                        new variant(@"осудить в тихую очередную 
несправедливость и продолжить свои дела", 8),
                                        new variant(@"вмешаться в обсуждение, 
не выражая своего мнения", 4));

                    questions[4] = new Question(@"Когда вы слушаете современную молодежную 
музыку,то", false, 5,
                                        new variant("приходите в восторг", 0),
                                        new variant("думаете, что и вы этим должны переболеть", 6),
                                        new variant("не признаете этот шум и грохот", 8),
                                        new variant("чувствуете удовольствие", 2),
                                        new variant("считаете, что на вкус и цвет товарищей нет", 4));

                    questions[5] = new Question(@"Вы находитесь в дружеской компании. 
Для вас важно", false, 4,
                                        new variant(@"возможность продемонстрировать 
свои способности", 0),
                                        new variant(@"сделать так, чтобы люди не забывали, 
с кем имеют дела", 6),
                                        new variant("соблюдать правила хорошего поведения", 8),
                                        new variant(@"вести себя в соответствии с нормами
этой компании", 4));

                    questions[6] = new Question("Какая работа вам нравится?", false, 5,
                                        new variant("содержащую элементы неожиданности и риска", 0),
                                        new variant("не монотонная", 2),
                                        new variant(@"такая, где можно использовать 
свой опыт и знания", 6),
                                        new variant("не тяжолая", 8),
                                        new variant("смотря по настроении", 4));

                    questions[7] = new Question("Насколько вы предусмотрительны?", false, 5,
                                        new variant(@"склонен приниматься за дела 
не раздумывая", 0),
                                        new variant(@"предпочитаю сначала действовать, 
а уже потом рассуждать", 2),
                                        new variant(@"предпочитаю не участвовать 
в делах, пока не выяснены основные
их последствия", 6),
                                        new variant(@"предпочитаю участвовать только 
в таких делах, где успех гарантирован", 8),
                                        new variant(@"отношусь к делам в зависимости от ситуации", 4));

                    questions[8] = new Question("Доверливы ли Вы", false, 5,
                                        new variant("доверяю некоторым людям", 0),
                                        new variant("доверяю многим людям", 2),
                                        new variant("не доверяю много кому", 6),
                                        new variant("не доверяю никому", 8),
                                        new variant(@"все зависит от того, 
с кем имею дело", 4));

                    questions[9] = new Question("Ваше настроение", false, 5,
                                        new variant("преимущественно оптимистичное", 0),
                                        new variant("часто оптимистичное", 2),
                                        new variant("часто песимистичное", 6),
                                        new variant("преимущественно песимистичное", 8),
                                        new variant("в зависимости от обстоятельств", 4));
                    break;
                case "en-US":
                    questions[0] = new Question(@"You're running late and are close 
to the bus stop. The bus is coming.
What will you do?", false, 5,
                                    new variant("I will run to catch it", 0),
                                    new variant("I'll walk as fast as I can", 2),
                                    new variant("I'll walk a little bit faster than usual", 6),
                                    new variant("I won't change my speed", 8),
                                    new variant(@"I'll look if next bus is arriving and then decide.", 4));

                    questions[1] = new Question("Your attitude to fashion", false, 5,
                                        new variant("admit it and try to be up-to-date", 0),
                                        new variant("admit things that fit me", 2),
                                        new variant("do not admit it at all", 6),
                                        new variant("do not admit modern extravagant models", 8),
                                        new variant("admint or reject, depending on mood", 4));

                    questions[2] = new Question("On your free time you'll prefer", false, 5,
                                        new variant("meet with friends", 0),
                                        new variant("watch TV", 2),
                                        new variant("read literature", 6),
                                        new variant("solve puzzles", 8),
                                        new variant("do whatever you want", 4));

                    questions[3] = new Question(@"You observe someone committing manifest injustice. 
Your actions",
                        false, 5,
                                        new variant(@"immideately try to restore justice by all means", 0),
                                        new variant(@"side with the victim and 
try to help him", 2),
                                        new variant(@"try to restore justice by the means of law", 6),
                                        new variant(@"silently sentence another injustice and keep doing your business", 8),
                                        new variant(@"interfere the discussion with not revealing you point of view", 4));

                    questions[4] = new Question("When you listen to modern youth music, you", false, 5,
                                        new variant("become excited", 0),
                                        new variant("think you also must go though it", 6),
                                        new variant("do not admit that noise and roar", 8),
                                        new variant("feeling pleasure", 2),
                                        new variant("believe that anyone can choose himself, what he likes", 4));

                    questions[5] = new Question(@"You are in friendly company. 
Important to you is", false, 4,
                                        new variant("opportunity to demonstrate your skills", 0),
                                        new variant(@"act in the way the people won't forget, whom they are dealing with", 6),
                                        new variant("stay in good manners", 8),
                                        new variant("act respectively to the company's norms", 4));

                    questions[6] = new Question("What job do you like?", false, 5,
                                        new variant("that contains elements of surprizes and risks", 0),
                                        new variant("not monotonic", 2),
                                        new variant(@"the one, where you can use your experience and skills", 6),
                                        new variant("not hard", 8),
                                        new variant("depending on mood", 4));

                    questions[7] = new Question("How prudent you are?", false, 5,
                                        new variant(@"inclined to start the action 
without hesitating", 0),
                                        new variant(@"I think it is best to act 
and then think", 2),
                                        new variant(@"Prefer not to participate 
in business without clarifying their main effects", 6),
                                        new variant(@"prefer to participate only 
in such cases, where success is guaranteed", 8),
                                        new variant(@"I behave according to the situation", 4));

                    questions[8] = new Question("Are you trustful", false, 5,
                                        new variant("I trust some people", 0),
                                        new variant("I trust many people", 2),
                                        new variant("I don't trust most of people", 6),
                                        new variant("I don't trust anyone", 8),
                                        new variant(@"depends on, whom I deal with", 4));

                    questions[9] = new Question("Your mood", false, 5,
                                        new variant("mostly optimistic", 0),
                                        new variant("often optimistic", 2),
                                        new variant("often pesimistic", 6),
                                        new variant("mostly pesimistic", 8),
                                        new variant("depending on circumstances", 4));
                    break;

                default:
                    questions[0] = new Question(@"You're running late and are close 
to the bus stop. The bus is coming.
What will you do?", false, 5,
                                    new variant("I will run to catch it", 0),
                                    new variant("I'll walk as fast as I can", 2),
                                    new variant("I'll walk a little bit faster than usual", 6),
                                    new variant("I won't change my speed", 8),
                                    new variant(@"I'll look if next bus is arriving and then decide.", 4));

                    questions[1] = new Question("Your attitude to fashion", false, 5,
                                        new variant("admit it and try to be up-to-date", 0),
                                        new variant("admit things that fit me", 2),
                                        new variant("do not admit it at all", 6),
                                        new variant("do not admit modern extravagant models", 8),
                                        new variant("admint or reject, depending on mood", 4));

                    questions[2] = new Question("On your free time you'll prefer", false, 5,
                                        new variant("meet with friends", 0),
                                        new variant("watch TV", 2),
                                        new variant("read literature", 6),
                                        new variant("solve puzzles", 8),
                                        new variant("do whatever you want", 4));

                    questions[3] = new Question(@"You observe someone committing manifest injustice. 
Your actions",
                        false, 5,
                                        new variant(@"immideately try to restore justice by all means", 0),
                                        new variant(@"side with the victim and 
try to help him", 2),
                                        new variant(@"try to restore justice by the means of law", 6),
                                        new variant(@"silently sentence another injustice and keep doing your business", 8),
                                        new variant(@"interfere the discussion with not revealing you point of view", 4));

                    questions[4] = new Question("When you listen to modern youth music, you", false, 5,
                                        new variant("become excited", 0),
                                        new variant("think you also must go though it", 6),
                                        new variant("do not admit that noise and roar", 8),
                                        new variant("feeling pleasure", 2),
                                        new variant("believe that anyone can choose himself, what he likes", 4));

                    questions[5] = new Question(@"You are in friendly company. 
Important to you is", false, 4,
                                        new variant("opportunity to demonstrate your skills", 0),
                                        new variant(@"act in the way the people won't forget, whom they are dealing with", 6),
                                        new variant("stay in good manners", 8),
                                        new variant("act respectively to the company's norms", 4));

                    questions[6] = new Question("What job do you like?", false, 5,
                                        new variant("that contains elements of surprizes and risks", 0),
                                        new variant("not monotonic", 2),
                                        new variant(@"the one, where you can use your experience and skills", 6),
                                        new variant("not hard", 8),
                                        new variant("depending on mood", 4));

                    questions[7] = new Question("How prudent you are?", false, 5,
                                        new variant(@"inclined to start the action 
without hesitating", 0),
                                        new variant(@"I think it is best to act 
and then think", 2),
                                        new variant(@"Prefer not to participate 
in business without clarifying their main effects", 6),
                                        new variant(@"prefer to participate only 
in such cases, where success is guaranteed", 8),
                                        new variant(@"I behave according to the situation", 4));

                    questions[8] = new Question("Are you trustful", false, 5,
                                        new variant("I trust some people", 0),
                                        new variant("I trust many people", 2),
                                        new variant("I don't trust most of people", 6),
                                        new variant("I don't trust anyone", 8),
                                        new variant(@"depends on, whom I deal with", 4));

                    questions[9] = new Question("Your mood", false, 5,
                                        new variant("mostly optimistic", 0),
                                        new variant("often optimistic", 2),
                                        new variant("often pesimistic", 6),
                                        new variant("mostly pesimistic", 8),
                                        new variant("depending on circumstances", 4));
                    break;
            }
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
            switch (Thread.CurrentThread.CurrentUICulture.Name)
            {
                case "uk-UA":
                    {
                        conclMass[0] = new Conclusion(0, 100, @"Якщо кількість балів співпадає з вашим віком,все гаразд.
Для тих, хто схильний до творчої діяльності, бажано,
щоб психологічний вік не випереджав паспортний.
А якщо після 30 років він відстає, то це означає,
що ви у гарній формі, вільні від стереотипів і ваші
можливості далеко не вичерпані. Коли ваш творчій вік
випереджає паспортний - це також непагано, ви без
проблем впорраєтеся із тандартними діями,
які потрбують чіткості та пунктуальності");

                         break;
                    }



                case "ru-RU":
                    conclMass[0] = new Conclusion(0, 100, @"Если количество баллов совпадает с вашим возрастом, все в порядке. 
Для тех, кто склонен к творческой деятельности, желательно, 
чтобы психологический возраст не опережал паспортный. 
А если после 30 лет он отстает, то это означает, что вы в хорошей форме, 
свободны от стереотипов и ваши возможности далеко не исчерпаны. 
Когда ваш творческой возраст опережает паспортный - это также неплохо, 
вы без проблем справитесь со стандартными действиями, которые требуют четкости и пунктуальности");

                    
                    break;

                case "en-US":
                    conclMass[0] = new Conclusion(0, 100, @"If the number of points equal to your age, it's okay. 
For those who are inclined to creative activity, it is desirable 
to psychological age is not ahead of the passport. 
And if after 30 years it falls short, it means that you are in good shape, 
free from stereotypes and your possibilities are far from exhausted. 
When your creative age ahead passport - it is also good, 
you will easily cope with standard actions that require precision and punctuality");
                    
                    break;

                default:
                    conclMass[0] = new Conclusion(0, 100, @"If the number of points equal to your age, it's okay. 
For those who are inclined to creative activity, it is desirable 
to psychological age is not ahead of the passport. 
And if after 30 years it falls short, it means that you are in good shape, 
free from stereotypes and your possibilities are far from exhausted. 
When your creative age ahead passport - it is also good, 
you will easily cope with standard actions that require precision and punctuality");

                    break;
            }
            for (int i = 0; i < conclMass.Length; i++)
                if (summResult <= conclMass[i].b && summResult >= conclMass[i].a)
                    switch (Thread.CurrentThread.CurrentUICulture.Name)
                    {
                        case "uk-UA":
                            return "Ваш результат - " + summResult.ToString() + " балів\n\n" + conclMass[i].textOfConclusion + Thread.CurrentThread.CurrentUICulture.Name+i;
                        case "ru-RU":
                            return "Ваш результат - " + summResult.ToString() + " балов\n\n" + conclMass[i].textOfConclusion + Thread.CurrentThread.CurrentUICulture.Name + i;
                        case "en-US":
                            return "Your result - " + summResult.ToString() + " points\n\n" + conclMass[i].textOfConclusion + Thread.CurrentThread.CurrentUICulture.Name + i;
                        default:
                            return "Your result - " + summResult.ToString() + " points\n\n" + conclMass[i].textOfConclusion + Thread.CurrentThread.CurrentUICulture.Name + i;
                    }
            return "";
        }
        override protected void InitConclusions()
        {
            FinalConclusion = GetConclusion();
        }
    }
}