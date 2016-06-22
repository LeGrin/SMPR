using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Modules.Tests.Methods
{
    public class MethodArtistic : Method
    {
        Conclusion[] conclMass = new Conclusion[2];        
        public MethodArtistic()
        {
            numberOfQuestions = 10;            
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
            switch (Thread.CurrentThread.CurrentUICulture.Name)
            {
                case "uk-UA":
                    questions[0] = new Question("Ваші кращі думки про роботу приходять до вас:", false, 3,
                                                    new variant("удома в ліжку", 1),
                                                    new variant("безпосередньо на робочому місці", 0),
                                                    new variant("під час обговорення з колегами", 0));
                    questions[1] = new Question("Домашні обов'язки:", false, 3,
                                                    new variant(@"настільки утомливі, 
що ви починаєте їх ненавидіти", 1),
                                                    new variant("здаються вам нудними", 0),
                                                    new variant("радують вас", 0));
                    questions[2] = new Question("Без чого, по-вашому, не можна обійтися в житті?", false, 3,
                                                    new variant("без ящиків для сміття", 0),
                                                    new variant("без блідо-жовтих нарцисів", 1),
                                                    new variant("без креслярських дошок", 0));
                    questions[3] = new Question("Вам приємно коли вас вважають людиною", false, 3,
                                                    new variant("обдарованою", 1),
                                                    new variant("практичною", 0),
                                                    new variant("винахідливою", 0));
                    questions[4] = new Question("Ви вважаєте за краще:", false, 3,
                                                    new variant("керувати іншими", 0),
                                                    new variant("впливати на людей", 0),
                                                    new variant("доставляти людям радість і задоволення", 1));
                    questions[5] = new Question("Коли ви чуєте слово «море», то вам спадає на думку:", false, 3,
                                                    new variant("риба", 0),
                                                    new variant("подорож", 1), new variant("мореплавання", 0));
                    questions[6] = new Question("Чи дотримуєте ви розпорядок дня?", false, 3,
                                                    new variant("ні", 0),
                                                    new variant("так", 0),
                                                    new variant("тільки коли цього не можна уникнути", 1));
                    questions[7] = new Question(@"Коли вас питають котра година,
а годинник ви забули вдома, ви:", false, 3,
                                                    new variant(@"інстинктивно відчуваєте,
як швидко пролетів день", 0),
                                                    new variant("просто намагаєтесь вгадати час", 0),
                                                    new variant(@"запросто відповідаєте:
циферблат же у вас в голові", 1));
                    questions[8] = new Question(@"Коли ви чуєте слово «птах»,
про що думаєте перш за все:", false, 3,
                                                    new variant("про політ", 0),
                                                    new variant("про пір'їнки", 0),
                                                    new variant("про гніздо", 1));
                    questions[9] = new Question("Коли вас з кимось знайомлять, зазвичай ви:", false, 3,
                                                    new variant("без проблем запам'ятовуєте ім'я нового знайомого", 0),
                                                    new variant("відразу ж його забуваєте", 1),
                                                    new variant("з великими зусиллями пригадуєте його пізніше", 0));
                    break;
                case "ru-RU":
                    questions[0] = new Question("Лучшие мысли о работе посещают Вас, когда Вы:", false, 3,
                                                    new variant("дома в постели", 1),
                                                    new variant("непосредственно на рабочем месте", 0),
                                                    new variant("обсуждаете работу с коллегами", 0));
                    questions[1] = new Question("Домашние обязанности:", false, 3,
                                                    new variant(@"настолько изматывающие,
что Вы начинаете их ненавидеть", 1),
                                                    new variant("кажутся Вам скушными", 0),
                                                    new variant("радуют Вас", 0));
                    questions[2] = new Question("Без чего, с Вашей точки зрения, нельзя обойтьсь в жизни?", false, 3,
                                                    new variant("без мусорных ящиков", 0),
                                                    new variant("без бледно-жёлтых нарцисов", 1),
                                                    new variant("без чертёжных досок", 0));
                    questions[3] = new Question("Вам приятно, когда Вас считают ... человеком.", false, 3,
                                                    new variant("одарённым", 1),
                                                    new variant("практичным", 0),
                                                    new variant("изобретательным", 0));
                    questions[4] = new Question("Вы считаете лучшим:", false, 3,
                                                    new variant("управлять другими", 0),
                                                    new variant("влиять на людей", 0),
                                                    new variant("доставлять людям радость и удовольствие", 1));
                    questions[5] = new Question("Когда Вы слышите слово «море», Вам на ум первым приходит:", false, 3,
                                                    new variant("рыба", 0),
                                                    new variant("путишествие", 1), 
                                                    new variant("мореплавание", 0));
                    questions[6] = new Question("Придерживаетесь ли Вы распорядка дня?", false, 3,
                                                    new variant("нет", 0),
                                                    new variant("да", 0),
                                                    new variant("только когда этого нельзя избежать", 1));
                    questions[7] = new Question(@"Когда Вас спрашивают, который час, 
а у Вас нету часов Вы:", false, 3,
                                                    new variant(@"инстинктивно чувствуете, 
как быстро пролетело время", 0),
                                                    new variant("просто пытаетесь угадать", 0),
                                                    new variant(@"запросто отвечаете, 
цыферблат же у Вас в голове", 1));
                    questions[8] = new Question(@"Когда Вы слышите слово «птица»,
о чём Вы думаете предже всего?", false, 3,
                                                    new variant("о полёте", 0),
                                                    new variant("о перъях", 0),
                                                    new variant("о гнезде", 1));
                    questions[9] = new Question("Когда Вас кому-то представляют, Вы:", false, 3,
                                                    new variant("без проблем запоминаете имя нового знакомого", 0),
                                                    new variant("сразу его забываете", 1),
                                                    new variant("с большим усилием вспоминаете его потом", 0));
                    break;
                case "en-US":
                    questions[0] = new Question("The best thoughts about job comes to you mostly:", false, 3,
                                                    new variant("at home in the bed", 1),
                                                    new variant("at your workplace", 0),
                                                    new variant("during discussion with collegues", 0));
                    questions[1] = new Question("Home duties:", false, 3,
                                                    new variant("so annoying that you almost hate them", 1),
                                                    new variant("seem to be booring", 0),
                                                    new variant("bring you happiness", 0));
                    questions[2] = new Question("Without which thing, people wouldn't manage?", false, 3,
                                                    new variant("recycle bins", 0),
                                                    new variant("straw-colored narcissuses", 1),
                                                    new variant("panel boards", 0));
                    questions[3] = new Question("You find it most pleasurably, when one says you are:", false, 3,
                                                    new variant("gifted", 1),
                                                    new variant("practical", 0),
                                                    new variant("inventive", 0));
                    questions[4] = new Question("You would prefer to:", false, 3,
                                                    new variant("manipulate others", 0),
                                                    new variant("influence on others", 0),
                                                    new variant("bring happiness and pleasure to people", 1));
                    questions[5] = new Question("When you hear word «sea», your first thought is:", false, 3,
                                                    new variant("fish", 0),
                                                    new variant("journey", 1), 
                                                    new variant("sailing", 0));
                    questions[6] = new Question("Do you follow your daily routine?", false, 3,
                                                    new variant("no", 0),
                                                    new variant("yes", 0),
                                                    new variant("only when can't avoid it", 1));
                    questions[7] = new Question(@"When you're being asked the time
and you forgot your watch at home, you:", false, 3,
                                                    new variant(@"instinctively feel,
how fast the time passed", 0),
                                                    new variant("just try to guess", 0),
                                                    new variant(@"give answer easily:
there's a watch in your head", 1));
                    questions[8] = new Question(@"When you hear word «sea», 
your first thought is:", false, 3,
                                                    new variant("flight", 0),
                                                    new variant("feather", 0),
                                                    new variant("nest", 1));
                    questions[9] = new Question("When introduced to someone, you usually:", false, 3,
                                                    new variant("remember the name easily", 0),
                                                    new variant("forget the name at the same moment", 1),
                                                    new variant("remember the name with big effort", 0));
                    break;

                default:
                    questions[0] = new Question("The best thoughts about job comes to you mostly:", false, 3,
                                                    new variant("at home in the bed", 1),
                                                    new variant("at your workplace", 0),
                                                    new variant("during discussion with collegues", 0));
                    questions[1] = new Question("Home duties:", false, 3,
                                                    new variant("so annoying that you almost hate them", 1),
                                                    new variant("seem to be booring", 0),
                                                    new variant("bring you happiness", 0));
                    questions[2] = new Question("Without which thing, people wouldn't manage?", false, 3,
                                                    new variant("recycle bins", 0),
                                                    new variant("straw-colored narcissuses", 1),
                                                    new variant("panel boards", 0));
                    questions[3] = new Question("You find it most pleasurably, when one says you are:", false, 3,
                                                    new variant("gifted", 1),
                                                    new variant("practical", 0),
                                                    new variant("inventive", 0));
                    questions[4] = new Question("You would prefer to:", false, 3,
                                                    new variant("manipulate others", 0),
                                                    new variant("influence on others", 0),
                                                    new variant("bring happiness and pleasure to people", 1));
                    questions[5] = new Question("When you hear word «sea», your first thought is:", false, 3,
                                                    new variant("fish", 0),
                                                    new variant("journey", 1),
                                                    new variant("sailing", 0));
                    questions[6] = new Question("Do you follow your daily routine?", false, 3,
                                                    new variant("no", 0),
                                                    new variant("yes", 0),
                                                    new variant("only when can't avoid it", 1));
                    questions[7] = new Question(@"When you're being asked the time
and you forgot your watch at home, you:", false, 3,
                                                    new variant(@"instinctively feel,
how fast the time passed", 0),
                                                    new variant("just try to guess", 0),
                                                    new variant(@"give answer easily:
there's a watch in your head", 1));
                    questions[8] = new Question(@"When you hear word «sea», 
your first thought is:", false, 3,
                                                    new variant("flight", 0),
                                                    new variant("feather", 0),
                                                    new variant("nest", 1));
                    questions[9] = new Question("When introduced to someone, you usually:", false, 3,
                                                    new variant("remember the name easily", 0),
                                                    new variant("forget the name at the same moment", 1),
                                                    new variant("remember the name with big effort", 0));
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
                    conclMass[0] = new Conclusion(1, 5, @"На жаль, вас не можна назвати творчою особистістю");
                    conclMass[1] = new Conclusion(6, 10, @"Ви — повноцінна творча особистість!");
                    break;
                case "ru-RU":
                    conclMass[0] = new Conclusion(1, 5, @"К сожалению, Вас нельзя назвать творческой личностью");
                    conclMass[1] = new Conclusion(6, 10, @"Вы — полноценная творческая личность! ");
                    break;
                case "en-US":
                    conclMass[0] = new Conclusion(1, 5, @"Unfortunatelly, you don't seem to be artistic person.");
                    conclMass[1] = new Conclusion(6, 10, @"You are completely artistic person!");
                    break;

                default:
                    conclMass[0] = new Conclusion(1, 5, @"Unfortunatelly, you don't seem to be artistic person.");
                    conclMass[1] = new Conclusion(6, 10, @"You are completely artistic person!");
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
