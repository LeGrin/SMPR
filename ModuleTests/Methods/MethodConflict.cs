using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Modules.Tests.Methods
{
    class MethodConflict : Method
    {
        Conclusion[] conclMass = new Conclusion[3];
        public MethodConflict()
        {
            
            numberOfQuestions = 6;
        }
        public override string Name
        {
            get { return Properties.Resources.ConflictMethodName; }
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
                    questions[0] = new Question(@"Якщо ваша друга половина заборонить 
вам носити дуже короткі спідниці...", false, 3,
                                        new variant(@"ви погодитеся,
щоб не псувати з ним відношення", 2),
                                        new variant(@"спробуєте переконати його
в тому, що він не має рації", 1),
                                        new variant(@"розлучитеся з ним, якщо
переконати його не вдасться", 3));

                    questions[1] = new Question(@"Якщо дві ваші приятельки почнуть при вас лаятися...", false, 3,
                                        new variant("ви постараєтеся зрозуміти і помирити обох", 2),
                                        new variant("покинете приміщення", 3),
                                        new variant(" викажете свою незадоволеність ситуацією", 1));

                    questions[2] = new Question(@"Якщо батьки постійно втручаються у ваші справи...", false, 3,
                                        new variant("ви стримуєте себе", 3),
                                        new variant("намагатиметеся домовитися", 1),
                                        new variant(@"зажадаєте, щоб вони більше 
ніколи не робили цього", 2));

                    questions[3] = new Question("Якщо вас хтось образить...", false, 3,
                                        new variant("Якщо вас хтось образить...", 2),
                                        new variant("спробуєте приховати образу", 3),
                                        new variant("відповісте кривднику тим же", 1));

                    questions[4] = new Question(@"Якщо близька подруга посвариться з вами...", false, 3,
                                        new variant("ви спробуєте зрозуміти, що трапилося", 1),
                                        new variant("не станете звертати увагу", 3),
                                        new variant("розваритеся з нею вщент", 2));

                    questions[5] = new Question(@"Якщо під час дискусії вам не дають висловитися...", false, 3,
                                        new variant("ви припините розмову ", 3),
                                        new variant("наполягатимете, щоб вас вислухали", 1),
                                        new variant("будете кричати", 2));
                    break;
                case "ru-RU":
                    questions[0] = new Question(@"Если ваша вторая половина запретит
вам носить очень короткие юбки...", false, 3,
                                new variant(@"ви согласитесь,
чтобы не портить с ним отношения", 2),
                                new variant(@"попробуете убедить его
в том, что он не прав", 1),
                                new variant(@"расстанетесь с ним, если
убедить его не удастся", 3));

                    questions[1] = new Question(@"Если две ваши приятельницы начнут при вас ругаться...", false, 3,
                                        new variant("вы постараетесь понять і примирить обоих", 2),
                                        new variant("вы вийдете из помещения", 3),
                                        new variant("вы выскажете своё негодование ситуацией", 1));

                    questions[2] = new Question(@"Если родители постоянно вмешиваются в Ваши дела...", false, 3,
                                        new variant("вы сдержите тебя", 3),
                                        new variant("попробуете договориться", 1),
                                        new variant(@"потребуете, чтобы они больше этого не делали", 2));

                    questions[3] = new Question("Если Вас кто-то обидит...", false, 3,
                                        new variant("вы постараетесь сохранить своё достоинство", 2),
                                        new variant("вы попробуете скрыть обиду", 3),
                                        new variant("вы ответите тем же", 1));

                    questions[4] = new Question(@"Если близкая подруга посорится с Вами...", false, 3,
                                        new variant("вы попробуете выяснить в чём дело", 1),
                                        new variant("вы не станете обращать внимание", 3),
                                        new variant("розругаетесь вдребезги", 2));

                    questions[5] = new Question(@"Если во время дискусии Вам не дают высказаться...", false, 3,
                                        new variant("вы прекратите разговор", 3),
                                        new variant("настоите, чтобы Вас выслушали", 1),
                                        new variant("начнёте кричать", 2));
                    break;
                case "en-US":
                    questions[0] = new Question(@"If your partner will forbid 
you to wear very short skirts ...", false, 3,
                                new variant(@"you'll agree not to affect your relationship", 2),
                                new variant(@"you'll try to convince him
that he's not right", 1),
                                new variant(@"you'll split up, if you 
won't succeed to convince him", 3));

                    questions[1] = new Question(@"If two of your friends start a fight...", false, 3,
                                        new variant("you'll try to understand both and reconcile them", 2),
                                        new variant("leave the room", 3),
                                        new variant("show your indignation, caused by this situation", 1));

                    questions[2] = new Question(@"If your parents always interfere your business...", false, 3,
                                        new variant("you try to keep calm", 3),
                                        new variant("you try to get compromise", 1),
                                        new variant(@"demand them not to do that any more", 2));

                    questions[3] = new Question("If someone offends you...", false, 3,
                                        new variant("try to save your dignity by, for example, making a joke of it...", 2),
                                        new variant("try to hide your abuse", 3),
                                        new variant("react by doing the same", 1));

                    questions[4] = new Question(@"If a good friend of yours will fight with you...", false, 3,
                                        new variant("you'll try to find out the cause", 1),
                                        new variant("you won't react at all", 3),
                                        new variant("you'll reply in the same way and fight to end", 2));

                    questions[5] = new Question(@"If someone interrupts you all the time, you'll...", false, 3,
                                        new variant("stop talking", 3),
                                        new variant("insist on their finally hear you out", 1),
                                        new variant("start screaming", 2));
                    break;

                default:
                    questions[0] = new Question(@"If your partner will forbid 
you to wear very short skirts ...", false, 3,
                                new variant(@"you'll agree not to affect your relationship", 2),
                                new variant(@"you'll try to convince him
that he's not right", 1),
                                new variant(@"you'll split up, if you 
won't succeed to convince him", 3));

                    questions[1] = new Question(@"If two of your friends start a fight...", false, 3,
                                        new variant("you'll try to understand both and reconcile them", 2),
                                        new variant("leave the room", 3),
                                        new variant("show your indignation, caused by this situation", 1));

                    questions[2] = new Question(@"If your parents always interfere your business...", false, 3,
                                        new variant("you try to keep calm", 3),
                                        new variant("you try to get compromise", 1),
                                        new variant(@"demand them not to do that any more", 2));

                    questions[3] = new Question("If someone offends you...", false, 3,
                                        new variant("try to save your dignity by, for example, making a joke of it...", 2),
                                        new variant("try to hide your abuse", 3),
                                        new variant("react by doing the same", 1));

                    questions[4] = new Question(@"If a good friend of yours will fight with you...", false, 3,
                                        new variant("you'll try to find out the cause", 1),
                                        new variant("you won't react at all", 3),
                                        new variant("you'll reply in the same way and fight to end", 2));

                    questions[5] = new Question(@"If someone interrupts you all the time, you'll...", false, 3,
                                        new variant("stop talking", 3),
                                        new variant("insist on their finally hear you out", 1),
                                        new variant("start screaming", 2));
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
                    conclMass[0] = new Conclusion(6, 9, @"Вам зрозуміло, що сварка не виникає на порожньому місці.
Оскільки ви завжди прагнете зрозуміти опонента,
то зазвичай вам вдається знайти компроміс,
що влаштовує обидві сторони.");

                    conclMass[1] = new Conclusion(10, 14, @"На напружену ситуацію ви часто реагуєте за принципом
«напад — кращий спосіб захисту».
З одного боку, добре, що ви не приховуєте свою точку зору,
але з іншої - цим ви часто дуже сильно дратуєте суперника");

                    conclMass[2] = new Conclusion(15, 18, @"Ви тримаєтеся осторонь конфліктних ситуацій і
уникаєте з'ясування відносин,
не знаходячи при цьому конструктивного рішення проблем. 
Спробуйте навчитися визначати і відстоювати свою позицію.");
                    break;
                case "ru-RU":
                    conclMass[0] = new Conclusion(6, 9, @"Вам понятно, что ссора не возникает на пустом месте. 
Поскольку вы всегда стремитесь понять оппонента, 
то обычно вам удается найти компромисс, 
устраивающий обе стороны.");

                    conclMass[1] = new Conclusion(10, 14, @"В напряженной ситуации вы часто реагируете по принципу 
«Нападение - лучший способ защиты». 
С одной стороны, хорошо, что вы не скрываете свою точку зрения, 
но с другой - этим вы часто очень сильно раздражаете соперника");

                    conclMass[2] = new Conclusion(15, 18, @"Вы держитесь в стороне конфликтных ситуаций и 
избегаете выяснения отношений, 
не находя при этом конструктивного решения проблем. 
Попробуйте научиться определять и отстаивать свою позицию.");
                    break;
                case "en-US":
                    conclMass[0] = new Conclusion(6, 9, @"You understand that there is no fight made up of nothing. 
As you always want to understand the opponent, 
you usually find a compromise 
acceptable to both parties.");

                    conclMass[1] = new Conclusion(10, 14, @"In a tense situation you often use the principle 
«Attack - the best way to protect.» 
On the one hand, that's good, when you do not hide your views, 
but on the other - you often annoy opponent with this");

                    conclMass[2] = new Conclusion(15, 18, @"You keep aside of conflicts and 
avoid showdowns, 
not finding constructive solutions to problems. 
Try to learn how to define and defend your position.");
                    break;

                default:
                    conclMass[0] = new Conclusion(6, 9, @"You understand that there is no fight made up of nothing. 
As you always want to understand the opponent, 
you usually find a compromise 
acceptable to both parties.");

                    conclMass[1] = new Conclusion(10, 14, @"In a tense situation you often use the principle 
«Attack - the best way to protect.» 
On the one hand, that's good, when you do not hide your views, 
but on the other - you often annoy opponent with this");

                    conclMass[2] = new Conclusion(15, 18, @"You keep aside of conflicts and 
avoid showdowns, 
not finding constructive solutions to problems. 
Try to learn how to define and defend your position.");
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

