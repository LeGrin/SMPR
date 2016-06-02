using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Modules.Tests.Methods
{
    class MethodOptimist:Method
    {
        Conclusion[] conclMass = new Conclusion[3];
        public MethodOptimist()
        {
            
                    conclMass[0] = new Conclusion(0, 13, @"Схоже, життя вас не раз випробувало,
і ви вже не чекаєте від нього нічого доброго.
Невдачі вважаєте неминучими, а
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
            switch (Thread.CurrentThread.CurrentUICulture.Name)
            {
                case "uk-UA":
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
                    break;
                case "ru-RU": questions[0] = new Question(@"Любите ли вы путешествовать?", false, 2, new variant("да", 1), new variant("нет", 0));
                    questions[1] = new Question(@"Хотелось бы вам еще чему-то научиться
кроме того, что вы уже умеете?", false, 2, new variant("да", 1), new variant("нет", 0));
                    questions[2] = new Question(@"Вы часто принимаете снотворное,
успокоительное?", false, 2, new variant("да", 0), new variant("нет", 1));
                    questions[3] = new Question(@"Нравится ли вам ходить в гости
и принимать гостей?", false, 2, new variant("да", 1), new variant("нет", 0));
                    questions[4] = new Question(@"Часто ли вам удается предсказать
неприятности надвигающихся?", false, 2, new variant("да", 0), new variant("нет", 1));
                    questions[5] = new Question(@"Не кажется ли вам, что ваши товарищи
сумели добиться в жизни большего чем вы?", false, 2, new variant("да", 0), new variant("нет", 1));
                    questions[6] = new Question(@"Находится в вашей жизни место
каким либо спортивным занятиям?", false, 2, new variant("да", 1), new variant("нет", 0));
                    questions[7] = new Question(@"Считаете ли вы, что судьба несправедлива к вам?", false, 2, new variant("да", 0), new variant("нет", 1));
                    questions[8] = new Question(@"Беспокоит ли вас возможна экологическая катастрофа?", false, 2, new variant("да", 0), new variant("нет", 1));
                    questions[9] = new Question(@"Согласны ли вы, что научный прогресс 
создает больше проблем, чем решает? ", false, 2, new variant("да", 0), new variant("нет", 1));
                    questions[10] = new Question(@"Удачно вы выбрали свою профессию?", false, 2, new variant("да", 1), new variant("нет", 0));
                    questions[11] = new Question(@"Вы застраховали свое имущество?", false, 2, new variant("да", 0), new variant("нет", 1));
                    questions[12] = new Question(@"Согласились бы вы на переезд в другой город,
если бы там вам предложили интересную работу?", false, 2, new variant("да", 1), new variant("нет", 0));
                    questions[13] = new Question(@"Довольны ли вы своей внешностью?", false, 2, new variant("да", 1), new variant("нет", 0));
                    questions[14] = new Question(@"Часто ли вас беспокоят недомогание?", false, 2, new variant("да", 1), new variant("нет", 0));
                    questions[15] = new Question(@"Легко ли вам освоиться в незнакомом окружении,
найти свое место в новом коллективе?", false, 2, new variant("да", 1), new variant("нет", 0));
                    questions[16] = new Question(@"Считают вас окружающие энергичной,
деятельным человеком?", false, 2, new variant("да", 1), new variant("нет", 0));
                    questions[17] = new Question(@"Верите ли вы в бескорыстную дружбу?", false, 2, new variant("да", 1), new variant("нет", 0));
                    questions[18] = new Question(@"Существуют ли для вас личные добрые
приметы - фартовые числа, удачные дни недели?", false, 2, new variant("да", 1), new variant("нет", 0));
                    questions[19] = new Question(@"Верите ли вы в то,
что каждый - сам кузнец своего счастья?", false, 2, new variant("да", 1), new variant("нет", 0));

                    //from optimist2

                    questions[20] = new Question(@"Вы такой же счастливый, как и ваши знакомые?", false, 2,
                                        new variant("да", 0),
                                        new variant("нет", 1));

                    questions[21] = new Question(@"Приходилось ли вам когда-нибудь
просыпаться с ощущением, что вы можете все?", false, 2,
                                        new variant("да", 0),
                                        new variant("нет", 1));

                    questions[22] = new Question(@"Вы считаете, что везет только другим?", false, 2,
                                        new variant("да", 1),
                                        new variant("нет", 0));

                    questions[23] = new Question(@"Считаете ли вы, что вашим родителям повезло,
когда они нашли друг друга?", false, 2,
                                        new variant("да", 1),
                                        new variant("нет", 0));

                    questions[24] = new Question(@"Случалось ли вам чувствовать себя
несчастным человеком без особой причины?", false, 2,
                                        new variant("да", 1),
                                        new variant("нет", 0));

                    questions[25] = new Question(@"Вам знакомо чувство безнадежности?", false, 2,
                                        new variant("да", 1),
                                        new variant("нет", 0));

                    questions[26] = new Question(@"Не кажется ли вам, что жизнь
вообще бесцельна?", false, 2,
                                        new variant("да", 1),
                                        new variant("нет", 0));

                    questions[27] = new Question(@"Думаете ли вы, что мир достоин сожаления?", false, 2,
                                        new variant("да", 1),
                                        new variant("нет", 0));

                    questions[28] = new Question(@"Сильно вас раздражает шум?", false, 2,
                                        new variant("да", 1),
                                        new variant("нет", 0));

                    questions[29] = new Question(@"Считаете ли вы, что судьба
несправедлива к вам? ", false, 2,
                                        new variant("да", 1),
                                        new variant("нет", 0));

                    questions[30] = new Question(@"Вы улыбаетесь так же часто,
как и люди, которых вы знаете?", false, 2,
                                        new variant("да", 0),
                                        new variant("нет", 1));

                    questions[31] = new Question(@"Вы считаете, вашему другу с
вами действительно повезло?", false, 2,
                                        new variant("да", 0),
                                        new variant("нет", 1));

                    questions[32] = new Question(@"Можете ли вы находиться в
состоянии апатии недели?", false, 2,
                                        new variant("да", 1),
                                        new variant("нет", 0));

                    questions[33] = new Question(@"Считаете ли вы, что ваша жизнь
испорчен, главным образом, другими людьми?", false, 2,
                                        new variant("да", 1),
                                        new variant("нет", 0));

                    questions[34] = new Question(@"Сильно вас травмируют неудачи?", false, 2,
                                        new variant("да", 1),
                                        new variant("нет", 0));
                    break;
                case "en-US":
                    questions[0] = new Question(@"Do you like travelling?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[1] = new Question(@"Would you like to have something to learn
besides, you already know how?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[2] = new Question(@"Do you often take a sleeping pill,
sedative?", false, 2, new variant("yes", 0), new variant("no", 1));
                    questions[3] = new Question(@"Do you like host and visit your friends?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[4] = new Question(@"Can you manage to predict
trouble that is coming?", false, 2, new variant("yes", 0), new variant("no", 1));
                    questions[5] = new Question(@"Don't you think that your friends achieved
more in life than you?", false, 2, new variant("yes", 0), new variant("no", 1));
                    questions[6] = new Question(@"Have you time for sports activities", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[7] = new Question(@"Do you think that fate is unfair to you?", false, 2, new variant("yes", 0), new variant("no", 1));
                    questions[8] = new Question(@"Are you concerned about possible 
environmental disaster?", false, 2, new variant("yes", 0), new variant("no", 1));
                    questions[9] = new Question(@"Do you agree that scientific progress creates
more problems than it solves? ", false, 2, new variant("yes", 0), new variant("no", 1));
                    questions[10] = new Question(@"Have you successfully chose your profession?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[11] = new Question(@"Have you insured your property?", false, 2, new variant("yes", 0), new variant("no", 1));
                    questions[12] = new Question(@"Would you move to another city,
 if you were offered an interesting job there?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[13] = new Question(@"Are you satisfied with your appearance?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[14] = new Question(@"Do you often feel sick?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[15] = new Question(@"Is it easy for you to get comfortable in 
an unfamiliar environment, find their place in the new team?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[16] = new Question(@"Do you energetic,
active person?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[17] = new Question(@"Do you believe in selfless friendship?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[18] = new Question(@"Have you your own good
signs -  lucky days of the week?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[19] = new Question(@"Do you believe that
everyone is a blacksmith of his own happiness?", false, 2, new variant("yes", 1), new variant("no", 0));

                    //from optimist2

                    questions[20] = new Question(@"You are the same happy, as people you know?", false, 2,
                                        new variant("yes", 0),
                                        new variant("no", 1));

                    questions[21] = new Question(@"Have you ever
wake up with the feeling that you can all to do?", false, 2,
                                        new variant("yes", 0),
                                        new variant("no", 1));

                    questions[22] = new Question(@"Do you think that lucky all except you?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[23] = new Question(@"Do you feel that your parents were lucky
when they found each other?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[24] = new Question(@"Do you ever feel
unhappy person without particular reason?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[25] = new Question(@"Do you know the feeling of hopelessness?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[26] = new Question(@"Do not you think that life
is priceless?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[27] = new Question(@"Do you think the world is worthy of pity?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[28] = new Question(@"Are you annoying noise?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[29] = new Question(@"Do you think that the fate
unfair to you? ", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[30] = new Question(@"Do you smile as often
like people, you know?", false, 2,
                                        new variant("yes", 0),
                                        new variant("no", 1));

                    questions[31] = new Question(@"Do you think that your friend is lucky
with you?
", false, 2,
                                        new variant("yes", 0),
                                        new variant("no", 1));

                    questions[32] = new Question(@"Can you be in
a state of apathy weeks?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[33] = new Question(@"Do you feel that your life
spoiled, mainly, by other people?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[34] = new Question(@"Are you heavily injure failure?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));
                    break;
                default:
                    questions[0] = new Question(@"Do you like travelling?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[1] = new Question(@"Would you like to have 
something to learn besides, you already know how?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[2] = new Question(@"Do you often take a sleeping pill,
sedative?", false, 2, new variant("yes", 0), new variant("no", 1));
                    questions[3] = new Question(@"Do you like host and visit your friends?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[4] = new Question(@"Can you manage to predict
trouble that is coming?", false, 2, new variant("yes", 0), new variant("no", 1));
                    questions[5] = new Question(@"Don't you think that your friends
achieved more in life than you?", false, 2, new variant("yes", 0), new variant("no", 1));
                    questions[6] = new Question(@"Have you time for sports activities", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[7] = new Question(@"Do you think that fate is unfair to you?", false, 2, new variant("yes", 0), new variant("no", 1));
                    questions[8] = new Question(@"Are you concerned about possible
environmental disaster?", false, 2, new variant("yes", 0), new variant("no", 1));
                    questions[9] = new Question(@"Do you agree that scientific progress
creates more problems than it solves? ", false, 2, new variant("yes", 0), new variant("no", 1));
                    questions[10] = new Question(@"Have you successfully chose your profession?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[11] = new Question(@"Have you insured your property?", false, 2, new variant("yes", 0), new variant("no", 1));
                    questions[12] = new Question(@"Would you move to another city,
 if you were offered an interesting job there?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[13] = new Question(@"Are you satisfied with your appearance?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[14] = new Question(@"Do you often feel sick?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[15] = new Question(@"Is it easy for you to get comfortable in an
unfamiliar environment, find their place in the new team?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[16] = new Question(@"Do you energetic,
active person?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[17] = new Question(@"Do you believe in selfless friendship?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[18] = new Question(@"Have you your own good
signs -  lucky days of the week?", false, 2, new variant("yes", 1), new variant("no", 0));
                    questions[19] = new Question(@"Do you believe that
everyone is a blacksmith of his own happiness?", false, 2, new variant("yes", 1), new variant("no", 0));

                    //from optimist2

                    questions[20] = new Question(@"You are the same happy, as people you know?", false, 2,
                                        new variant("yes", 0),
                                        new variant("no", 1));

                    questions[21] = new Question(@"Have you ever
wake up with the feeling that you can all to do?", false, 2,
                                        new variant("yes", 0),
                                        new variant("no", 1));

                    questions[22] = new Question(@"Do you think that lucky all except you?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[23] = new Question(@"Do you feel that your parents were lucky
when they found each other?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[24] = new Question(@"Do you ever feel
unhappy person without particular reason?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[25] = new Question(@"Do you know the feeling of hopelessness?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[26] = new Question(@"Do not you think that life
is priceless?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[27] = new Question(@"Do you think the world is worthy of pity?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[28] = new Question(@"Are you annoying noise?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[29] = new Question(@"Do you think that the fate
unfair to you? ", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[30] = new Question(@"Do you smile as often
like people, you know?", false, 2,
                                        new variant("yes", 0),
                                        new variant("no", 1));

                    questions[31] = new Question(@"Do you think that your friend is lucky with you?
", false, 2,
                                        new variant("yes", 0),
                                        new variant("no", 1));

                    questions[32] = new Question(@"Can you be in
a state of apathy weeks?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[33] = new Question(@"Do you feel that your life
spoiled, mainly, by other people?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));

                    questions[34] = new Question(@"Are you heavily injure failure?", false, 2,
                                        new variant("yes", 1),
                                        new variant("no", 0));
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
