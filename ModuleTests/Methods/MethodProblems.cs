using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Modules.Tests.Methods
{
    class MethodProblems : Method
    {
        Conclusion[] conclMass = new Conclusion[3];
        public MethodProblems()
        {
            
            numberOfQuestions = 8;
        }
        public override string Name
        {
            get { return Properties.Resources.ProblemsMethodName; }
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
                    questions[0] = new Question("Чи розповідаєте ви про свої проблеми, негаразди?", false, 3,
                                                new variant("ні, це мені не допомогло б", 1),
                                                new variant("так, якщо є відповідний співрозмовник", 1),
                                                new variant("не завжди, людям вистачає своїх турбот", 2));
                    questions[1] = new Question("Чи сильно ви переживаєте неприємності?", false, 3,
                                                new variant("завжди і дуже важко", 4),
                                                new variant("все залежить від обставин", 0),
                                                new variant(@"упокорююся, адже будь-якій неприємності
рано чи пізно приходить кінець", 2));
                    questions[2] = new Question("Ви чимось дуже засмучені. Що робите у такому разі?", false, 3,
                                                new variant("дозволяю собі задоволення, про яке довго мріяв", 0),
                                                new variant("йду до добрих друзів", 2),
                                                new variant("жалію себе, відсиджуючись удома", 4));
                    questions[3] = new Question("Близька людина образила вас. Як ви вчините?", false, 3,
                                                new variant("сховаюся в свою \"мушлю\"", 3),
                                                new variant("зажадаю пояснення", 0),
                                                new variant("розкажу будь-кому,хто готовий слухати", 1));
                    questions[4] = new Question("В хвилину щастя:", false, 3,
                                                new variant("не думаю про нещастя", 1),
                                                new variant("не покидає тривога, що щастя швидко піде", 3),
                                                new variant(@"не забуваю про те,
що і засмучень в житті немало", 5));
                    questions[5] = new Question("Як ви ставитеся до психіатрів?", false, 3,
                                                new variant("не хотів би стати їх пацієнтом", 4),
                                                new variant("багатьом людям вони могли б допомогти", 2),
                                                new variant("людина здатна допомогти собі сама", 3));
                    questions[6] = new Question("Доля, на вашу думку:", false, 3,
                                                new variant("постійно випробовує вас", 5),
                                                new variant("несправедлива до вас", 2),
                                                new variant("прихильна до вас", 1));
                    questions[7] = new Question(@"Про що ви думаєте після сварки з улюбленою
людиною, коли гнів проходить?", false, 3,
                                                new variant("про те добре, що було у нас у минулому", 1),
                                                new variant("мрію про таємну помсту", 2),
                                                new variant("про те, скільки витерпів(ла) від неї (нього)", 3));
                    break;
                case "ru-RU":
                    questions[0] = new Question("Рассказываете ли Вы о своих проблемах?", false, 3,
                                                new variant("нет, это мне не помогло бы", 1),
                                                new variant("да, если есть подходящий собеседник", 1),
                                                new variant("не всегда, людям хватает своих забот", 2));
                    questions[1] = new Question("Сильно ли Вы переживаете из-за неприятностей?", false, 3,
                                                new variant("сильно и всегда", 4),
                                                new variant("зависит от обстоятельств", 0),
                                                new variant(@"успакаиваюсь, так как любой неприятности 
приходит конец", 2));
                    questions[2] = new Question("Что Вы делаете, если расстроены?", false, 3,
                                                new variant("балую себя чем-то, о чём долго мечтал", 0),
                                                new variant("иду к хорошим друзьям", 2),
                                                new variant("жалею себя, отсиживаюсь дома", 4));
                    questions[3] = new Question("Близкий человек обидел Вас. Как Вы поступите?", false, 3,
                                                new variant("спрячусь  в своя \"ракушку\"", 3),
                                                new variant("потребую объяснений", 0),
                                                new variant("расскажу кому-небудь, кто не прочь выслушать", 1));
                    questions[4] = new Question("В минуту щастья:", false, 3,
                                                new variant("не думаю о несчастье", 1),
                                                new variant("не оставляет тревого, что щастье быстро уйдёт", 3),
                                                new variant(@"не забываю о том, что и
огорчений в жизни немало", 5));
                    questions[5] = new Question("Как Вы относитесь к психиатрам?", false, 3,
                                                new variant("не хотел бы стать их пациентом", 4),
                                                new variant("многим они могли бы помочь", 2),
                                                new variant("человек способен помочь себе сам", 3));
                    questions[6] = new Question("Судьба, по Вашему мнению:", false, 3,
                                                new variant("постоянно испытывает Вас", 5),
                                                new variant("несправедлива к Вам", 2),
                                                new variant("благосклонна к Вам", 1));
                    questions[7] = new Question(@"О чём Вы думаете после ссоры с любимым 
человеком, когда проходит гнев?", false, 3,
                                                new variant("о том хорошем, что было в прошлом", 1),
                                                new variant("мечтаю о тайной мести", 2),
                                                new variant(@"о том, сколько вытерпел(-а) 
от него (нее)", 3));
                    break;
                case "en-US":
                    questions[0] = new Question("Do you tell anyone about your troubles?", false, 3,
                                                new variant("no, as it wouldn't help me", 1),
                                                new variant("yes, if I have a pesron to share with", 1),
                                                new variant(@"not always - people have 
their own troubles", 2));
                    questions[1] = new Question("How badly you go through your troubles?", false, 3,
                                                new variant("always and badly", 4),
                                                new variant("depends on situation", 0),
                                                new variant(@"try to stay calm as every trouble
eventually comes to it's end", 2));
                    questions[2] = new Question("What do you do is you are very upset?", false, 3,
                                                new variant("afford myself something I dreamed of", 0),
                                                new variant("go out with best friends", 2),
                                                new variant("regret myself, staying home", 4));
                    questions[3] = new Question(@"A close person of yours offends you, 
what would you do?", false, 3,
                                                new variant("hide in my \"shell\"", 3),
                                                new variant("demand explanations", 0),
                                                new variant(@"tell about it anyone, 
who's ready to hear out", 1));
                    questions[4] = new Question("At moments of happiness I:", false, 3,
                                                new variant("don't think about troubles", 1),
                                                new variant("remind myself of troubles time to time", 3),
                                                new variant(@"don't forget about troubles, 
whatever happens", 5));
                    questions[5] = new Question("What is you attitude to psychiatrists?", false, 3,
                                                new variant("wouldn't want to became treir patient", 4),
                                                new variant("they could help many people", 2),
                                                new variant("one can help himself on his own", 3));
                    questions[6] = new Question("In your opinion, fate:", false, 3,
                                                new variant("always tests you", 5),
                                                new variant("is unfair to you", 2),
                                                new variant("is favorable to you", 1));
                    questions[7] = new Question(@"What do you think after fight with 
the person you love about?", false, 3,
                                                new variant("about good things that happened before", 1),
                                                new variant("secretly plan a revenge", 2),
                                                new variant("about how much I suffer from him (her)", 3));
                    break;

                default:
                    questions[0] = new Question("Do you tell anyone about your troubles?", false, 3,
                                                new variant("no, as it wouldn't help me", 1),
                                                new variant("yes, if I have a pesron to share with", 1),
                                                new variant(@"not always - people have 
their own troubles", 2));
                    questions[1] = new Question("How badly you go through your troubles?", false, 3,
                                                new variant("always and badly", 4),
                                                new variant("depends on situation", 0),
                                                new variant(@"try to stay calm as every trouble
eventually comes to it's end", 2));
                    questions[2] = new Question("What do you do is you are very upset?", false, 3,
                                                new variant("afford myself something I dreamed of", 0),
                                                new variant("go out with best friends", 2),
                                                new variant("regret myself, staying home", 4));
                    questions[3] = new Question(@"A close person of yours offends you, 
what would you do?", false, 3,
                                                new variant("hide in my \"shell\"", 3),
                                                new variant("demand explanations", 0),
                                                new variant(@"tell about it anyone, 
who's ready to hear out", 1));
                    questions[4] = new Question("At moments of happiness I:", false, 3,
                                                new variant("don't think about troubles", 1),
                                                new variant("remind myself of troubles time to time", 3),
                                                new variant(@"don't forget about troubles, 
whatever happens", 5));
                    questions[5] = new Question("What is you attitude to psychiatrists?", false, 3,
                                                new variant("wouldn't want to became treir patient", 4),
                                                new variant("they could help many people", 2),
                                                new variant("one can help himself on his own", 3));
                    questions[6] = new Question("In your opinion, fate:", false, 3,
                                                new variant("always tests you", 5),
                                                new variant("is unfair to you", 2),
                                                new variant("is favorable to you", 1));
                    questions[7] = new Question(@"What do you think after fight with 
the person you love about?", false, 3,
                                                new variant("about good things that happened before", 1),
                                                new variant("secretly plan a revenge", 2),
                                                new variant("about how much I suffer from him (her)", 3));
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
                    conclMass[0] = new Conclusion(7, 15, @"Ви легко миритеся з неприємностями,
навіть бідами, оскільки здатні правильно оцінити їх.
Цінно те, що ви не схильні жаліти себе
(слабкість, властива багатьом).
Ваша душевна рівновага гідна захоплення!");

                    conclMass[1] = new Conclusion(16, 26, @"Ви часто ремствуєте на свою долю.
Вважаєте за краще випліскувати проблеми і неприємності на інших.
Вам необхідне чиєсь співчуття.
Можливо, краще навчитися володіти собою?");

                    conclMass[2] = new Conclusion(27, 36, @"Ви ще не справляєтеся зі своїми бідами.
Можливо, саме тому вони так вам дошкуляють.
Ви замикаєтеся, нерідко жалієте себе.
Якби у вас був вольовий характер при добрих завдатках,
ви успішно справлялися б з проблемами і неприємними ситуаціями.
Вони підкараулюють в житті не тільки вас.");
                    break;
                case "ru-RU":
                    conclMass[0] = new Conclusion(7, 15, @"Вы легко миритесь с неприятностями, 
даже бедами, так как способны правильно оценить их. 
Ценно то, что вы не склонны жалеть себя 
(слабость, присущая многим). 
Ваша душевное равновесие достойно восхищения!");

                    conclMass[1] = new Conclusion(16, 26, @"Вы часто жалуетесь на свою судьбу. 
Предпочитаете выплеснуть проблемы и неприятности на других. 
Вам необходимо чье-то сочувствие. 
Возможно, лучше научиться владеть собой?");

                    conclMass[2] = new Conclusion(27, 36, @"Вы еще не справляетесь со своими бедами. 
Возможно, именно поэтому они так вас донимают. 
Вы замыкаетесь, нередко жалеете себя. 
Если бы у вас был волевой характер при хороших задатках, 
вы успешно справлялись бы с проблемами и неприятными ситуациями. 
Они подкарауливают в жизни не только вас.");
                    break;
                case "en-US":
                    conclMass[0] = new Conclusion(7, 15, @"You will easily cope with troubles, 
even big ones, because of your ability to properly assess them. 
Valuable is that you are not tend to feel sorry for yourself 
(weakness inherent to many). 
Your mental health is admirable!");

                    conclMass[1] = new Conclusion(16, 26, @"You often angry at your fate, 
prefer to overthrow the problems and troubles on others. 
You need someone's sympathy. 
Perhaps it would be better to learn to control yourself?");

                    conclMass[2] = new Conclusion(27, 36, @"You do not deal with your troubles yet. 
Perhaps this is why they are so exasperate for you. 
You often feel sorry for yourself. 
If you had willed character with good instincts, 
You would have successfully coped with problems and unpleasant situations. 
They lie in wait in not just your life.");
                    break;

                default:
                    conclMass[0] = new Conclusion(7, 15, @"You will easily cope with troubles, 
even big ones, because of your ability to properly assess them. 
Valuable is that you are not tend to feel sorry for yourself 
(weakness inherent to many). 
Your mental health is admirable!");

                    conclMass[1] = new Conclusion(16, 26, @"You often angry at your fate, 
prefer to overthrow the problems and troubles on others. 
You need someone's sympathy. 
Perhaps it would be better to learn to control yourself?");

                    conclMass[2] = new Conclusion(27, 36, @"You do not deal with your troubles yet. 
Perhaps this is why they are so exasperate for you. 
You often feel sorry for yourself. 
If you had willed character with good instincts, 
You would have successfully coped with problems and unpleasant situations. 
They lie in wait in not just your life.");
                    break;
            }
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

