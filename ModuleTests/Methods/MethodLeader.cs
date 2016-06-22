using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Modules.Tests.Methods
{
    class MethodLeader : Method
    {
        Conclusion[] conclMass = new Conclusion[3];
        public MethodLeader()
        {
            conclMass[0] = new Conclusion(0, 91, @"Ваша роль - в добросовісному виконанні чужих ініціатив.
Ви звикли підтримувати чужу думку і слідувати генеральній лінії,
прокладеній іншими. Легко і приємно знати,
що за тебе вже всі вирішили і відповідальність
лежить не на тобі.");

            conclMass[1] = new Conclusion(92, 150, @"Тому людству і вдалося добитися таких успіхів,
що кожний з нас готовий у будь-який момент
стати провідним або відомим, лідером або підлеглим.
Вам обидві ці ролі властиві приблизно в рівному степені,
тому для вас знайдеться місце в будь-якому колективі.
Залишається сподіватися, що це місце вас влаштовує.");

            conclMass[2] = new Conclusion(151, 250, @"Ініціатива у вас незламна.
Ви у будь-який момент готові зайняти лідируючу позицію
в будь-якому колективі, роздавати доручення, 
указувати як краще і пояснювати як правильно.
Ви можете вказати шлях і повести за собою і на 
вас чекає велике майбутнє - за однієї умові:
якщо при цьому за вами йдуть.");

            numberOfQuestions = 24;
        }
        public override string Name
        {
            get { return Properties.Resources.LeaderMethodName; }
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
                    questions[0] = new Question(@"Як часто ви намагаєтеся досягти того,
щоб люди слідували за вами як за лідером?", false, 5,
                                        new variant("дуже часто", 5),
                                        new variant("часто", 4),
                                        new variant("коли як", 3),
                                        new variant("рідко", 2),
                                        new variant("дуже рідко", 1));

                    questions[1] = new Question("Як часто ви прагнете домінувати над людьми?", false, 5,
                                        new variant("дуже часто", 5),
                                        new variant("часто", 4),
                                        new variant("коли як", 3),
                                        new variant("рідко", 2),
                                        new variant("дуже рідко", 1));

                    questions[2] = new Question(@"Як часто ви дозволяєте людям
контролювати свою поведінку?", false, 5,
                                        new variant("дуже часто", 5),
                                        new variant("часто", 4),
                                        new variant("коли як", 3),
                                        new variant("рідко", 2),
                                        new variant("дуже рідко", 1));

                    questions[3] = new Question(@"Чи багато людей можуть легко впливати на вас?", false, 5,
                                        new variant("всі", 5),
                                        new variant("більшість", 4),
                                        new variant("близько половини", 3),
                                        new variant("кілька", 2),
                                        new variant("практично ніхто", 1));

                    questions[4] = new Question(@"Як часто Вам трапляються люди, яким ви дозволяєте
контролювати важливу для вас ситуацію?", false, 5,
                                        new variant("дуже часто", 5),
                                        new variant("часто", 4),
                                        new variant("коли як", 3),
                                        new variant("рідко", 2),
                                        new variant("дуже рідко", 1));

                    questions[5] = new Question(@"Як часто ви прагнете захопити
лідируючу позицію у стосунках?", false, 5,
                                        new variant("дуже часто", 5),
                                        new variant("часто", 4),
                                        new variant("коли як", 3),
                                        new variant("рідко", 2),
                                        new variant("дуже рідко", 1));

                    questions[6] = new Question(@"Як часто ви прагнете впливати на людей,
щоб вони наслідували приклад ваших дій?", false, 5,
                                        new variant("дуже часто", 5),
                                        new variant("часто", 4),
                                        new variant("коли як", 3),
                                        new variant("рідко", 2),
                                        new variant("дуже рідко", 1));

                    questions[7] = new Question(@"Як часто ви дозволяєте іншим ухвалювати
рішення, що стосуються вас?", false, 5,
                                        new variant("дуже часто", 5),
                                        new variant("часто", 4),
                                        new variant("коли як", 3),
                                        new variant("рідко", 2),
                                        new variant("дуже рідко", 1));

                    questions[8] = new Question(@"Як часто ви берете на себе відповідальність
за ситуації, що стосуються інших людей?", false, 5,
                                        new variant("дуже часто", 5),
                                        new variant("часто", 4),
                                        new variant("коли як", 3),
                                        new variant("рідко", 2),
                                        new variant("дуже рідко", 1));

                    // from leaderPotential

                    questions[9] = new Question(@"Якщо якась авторитетна особа публічно
виказує думку, яку я вважаю неправильною, 
я постараюся, щоб присутні вислухали і
мою точку зору", false, 3,
                                        new variant("завжди", 10),
                                        new variant("не впевнений, сумніваюся", 5),
                                        new variant("не згоден", 0));

                    questions[10] = new Question(@"У дитинстві мене частенько
називали неслухняною дитиною", false, 3,
                                        new variant("завжди", 10),
                                        new variant("не впевнений, сумніваюся", 5),
                                        new variant("не згоден", 0));

                    questions[11] = new Question(@"Переконаний, що навколишній світ може бути краще", false, 3,
                                        new variant("завжди", 10),
                                        new variant("не впевнений, сумніваюся", 5),
                                        new variant("не згоден", 0));

                    questions[12] = new Question(@"Не люблю, коли друзі і рідні намагаються
мене опікати, набридають порадами", false, 3,
                                        new variant("завжди", 10),
                                        new variant("не впевнений, сумніваюся", 5),
                                        new variant("не згоден", 0));
                    questions[13] = new Question(@"В ситуаціях, що вимагають серйозного рішення,
я не схильний до довгих коливань", false, 3,
                                        new variant("завжди", 10),
                                        new variant("не впевнений, сумніваюся", 5),
                                        new variant("не згоден", 0));

                    questions[14] = new Question(@"Здається, більшість суспільно-політичних
проблем виникає через недостатню твердість
відповідальних керівників", false, 3,
                                        new variant("завжди", 10),
                                        new variant("не впевнений, сумніваюся", 5),
                                        new variant("не згоден", 0));

                    questions[15] = new Question(@"Я не збентежуюся, якщо мені
доводиться комусь дорікати", false, 3,
                                        new variant("завжди", 10),
                                        new variant("не впевнений, сумніваюся", 5),
                                        new variant("не згоден", 0));

                    questions[16] = new Question(@"Якщо з якоюсь справою неможливо 
справитися самотужки, то для її виконання 
мені потрібні помічники, а не порадники", false, 3,
                                        new variant("завжди", 10),
                                        new variant("не впевнений, сумніваюся", 5),
                                        new variant("не згоден", 0));

                    questions[17] = new Question(@"В суперечках завжди прагну залишити
за собою останнє слово", false, 3,
                                        new variant("завжди", 10),
                                        new variant("не впевнений, сумніваюся", 5),
                                        new variant("не згоден", 0));

                    questions[18] = new Question(@"Вважаю, що ніякий прогрес немислимий
без прагнення людей до переваги над іншими", false, 3,
                                        new variant("завжди", 10),
                                        new variant("не впевнений, сумніваюся", 5),
                                        new variant("не згоден", 0));
                    questions[19] = new Question(@"Часто мені доводиться брати на
себе відповідальність, тому що інші
недостатньо рішучі", false, 3,
                                        new variant("завжди", 10),
                                        new variant("не впевнений, сумніваюся", 5),
                                        new variant("не згоден", 0));

                    questions[20] = new Question(@"Не вірю в абсолютну рівноправність
в подружніх відносинах, в своїй сім'ї
вважаю за краще бути главою", false, 3,
                                        new variant("завжди", 10),
                                        new variant("не впевнений, сумніваюся", 5),
                                        new variant("не згоден", 0));

                    questions[21] = new Question(@"Коли в гостях ніхто не наважується взяти
з блюда останній шматок торта,
я спокійно можу це зробити", false, 3,
                                        new variant("завжди", 10),
                                        new variant("не впевнений, сумніваюся", 5),
                                        new variant("не згоден", 0));

                    questions[22] = new Question(@"Люблю бути в центрі уваги", false, 3,
                                        new variant("завжди", 10),
                                        new variant("не впевнений, сумніваюся", 5),
                                        new variant("не згоден", 0));

                    questions[23] = new Question(@"В своїй кар'єрі готовий змиритися з
роллю підлеглого тільки як з тимчасовою", false, 3,
                                        new variant("завжди", 10),
                                        new variant("не впевнений, сумніваюся", 5),
                                        new variant("не згоден", 0));
                    break;
                case "ru-RU":
                    questions[0] = new Question(@"Как часто вы пытаетесь достичь того, чтобы 
люди следовали за вами как за лидером? ", false, 5,
                                        new variant("очень часто", 5),
                                        new variant("часто", 4),
                                        new variant("когда как", 3),
                                        new variant("редко", 2),
                                        new variant("очень редко", 1));

                    questions[1] = new Question("Как часто вы хотите доминировать над людьми?", false, 5,
                                        new variant("очень часто", 5),
                                        new variant("часто", 4),
                                        new variant("когда как", 3),
                                        new variant("редко", 2),
                                        new variant("очень редко", 1));

                    questions[2] = new Question(@"Как часто вы позволяете другим людям 
контролировать ваше поведение?", false, 5,
                                        new variant("очень часто", 5),
                                        new variant("часто", 4),
                                        new variant("когда как", 3),
                                        new variant("редко", 2),
                                        new variant("очень редко", 1));

                    questions[3] = new Question(@"Много ли людей могут влиять на вас?", false, 5,
                                        new variant("все", 5),
                                        new variant("большинство", 4),
                                        new variant("прмерно половина", 3),
                                        new variant("несколько", 2),
                                        new variant("практически никто", 1));

                    questions[4] = new Question(@"Как часто Вам попадаются люди, которым вы 
позволяете контролировать важную для вас ситуацию?", false, 5,
                                       new variant("очень часто", 5),
                                        new variant("часто", 4),
                                        new variant("когда как", 3),
                                        new variant("редко", 2),
                                        new variant("очень редко", 1));

                    questions[5] = new Question(@"Как часто вы пытаетесь быть лидером в отношениях?", false, 5,
                                        new variant("очень часто", 5),
                                        new variant("часто", 4),
                                        new variant("когда как", 3),
                                        new variant("редко", 2),
                                        new variant("очень редко", 1));

                    questions[6] = new Question(@" Как часто вы хотите влиять на других людей, 
что бы они брали пример с ваших действий?", false, 5,
                                       new variant("очень часто", 5),
                                        new variant("часто", 4),
                                        new variant("когда как", 3),
                                        new variant("редко", 2),
                                        new variant("очень редко", 1));

                    questions[7] = new Question(@"Как часто вы позволяете другим принимать 
решения, которые касаются Вас?", false, 5,
                                       new variant("очень часто", 5),
                                        new variant("часто", 4),
                                        new variant("когда как", 3),
                                        new variant("редко", 2),
                                        new variant("очень редко", 1));

                    questions[8] = new Question(@"Как часто вы берете на себя ответственность за ситуацим, 
которые касаются других людей?", false, 5,
                                       new variant("очень часто", 5),
                                        new variant("часто", 4),
                                        new variant("когда как", 3),
                                        new variant("редко", 2),
                                        new variant("очень редко", 1));

                    // from leaderPotential

                    questions[9] = new Question(@"Если какoe-то авторитетное лицо публично
высказывает мысль, которую я считаю неправильной,
я постараюсь, чтобы присутствующие выслушали и
мою точку зрения.", false, 3,
                                        new variant("всегда", 10),
                                        new variant("не уверен, сомневаюсь", 5),
                                        new variant("не согласен", 0));

                    questions[10] = new Question(@"В детстве меня часто
называли непослушным ребенком", false, 3,

                                        new variant("всегда", 10),
                                        new variant("не уверен, сомневаюсь", 5),
                                        new variant("не согласен", 0));

                    questions[11] = new Question(@"Я уверен, что окружающий мир может быть лучше", false, 3,

                                        new variant("всегда", 10),
                                        new variant("не уверен, сомневаюсь", 5),
                                        new variant("не согласен", 0));

                    questions[12] = new Question(@"Не люблю, когда друзья и родные пытаются
меня опекать, надоедают советами", false, 3,

                                        new variant("всегда", 10),
                                        new variant("не уверен, сомневаюсь", 5),
                                        new variant("не согласен", 0));

                    questions[13] = new Question(@"В ситуациях, требующих серьезного решения,
я не подвержен долгим колебаниям", false, 3,

                                        new variant("всегда", 10),
                                        new variant("не уверен, сомневаюсь", 5),
                                        new variant("не согласен", 0));

                    questions[14] = new Question(@"Кажется, большинство общественно-политических
проблем возникает из-за недостаточной жесткости
ответственных руководителей", false, 3,

                                        new variant("всегда", 10),
                                        new variant("не уверен, сомневаюсь", 5),
                                        new variant("не согласен", 0));

                    questions[15] = new Question(@"Меня не волнует, если мне
приходится кого-то упрекать", false, 3,

                                        new variant("всегда", 10),
                                        new variant("не уверен, сомневаюсь", 5),
                                        new variant("не согласен", 0));

                    questions[16] = new Question(@"Если с каким-то делом невозможно
справиться самостоятельно, то для ее выполнения
мне нужны помощники, а не советчики", false, 3,

                                        new variant("всегда", 10),
                                        new variant("не уверен, сомневаюсь", 5),
                                        new variant("не согласен", 0));

                    questions[17] = new Question(@"В спорах всегда стараюсь оставить
за собой последнее слово", false, 3,

                                        new variant("всегда", 10),
                                        new variant("не уверен, сомневаюсь", 5),
                                        new variant("не согласен", 0));

                    questions[18] = new Question(@"Считаю, что никакой прогресс немыслим
без стремления людей к превосходству над другими", false, 3,

                                        new variant("всегда", 10),
                                        new variant("не уверен, сомневаюсь", 5),
                                        new variant("не согласен", 0));
                    questions[19] = new Question(@"Часто мне приходится брать на
себя ответственность, потому что другие
недостаточно решительные", false, 3,

                                        new variant("всегда", 10),
                                        new variant("не уверен, сомневаюсь", 5),
                                        new variant("не согласен", 0));

                    questions[20] = new Question(@"Не верю в абсолютное равноправие
в супружеских отношениях, в своей семье
предпочитаю быть главой", false, 3,

                                        new variant("всегда", 10),
                                        new variant("не уверен, сомневаюсь", 5),
                                        new variant("не согласен", 0));

                    questions[21] = new Question(@"Когда в гостях никто не решается взять
с блюда последний кусок торта,
я спокойно могу это сделать", false, 3,

                                        new variant("всегда", 10),
                                        new variant("не уверен, сомневаюсь", 5),
                                        new variant("не согласен", 0));

                    questions[22] = new Question(@"Люблю быть в центре внимания", false, 3,

                                        new variant("всегда", 10),
                                        new variant("не уверен, сомневаюсь", 5),
                                        new variant("не согласен", 0));

                    questions[23] = new Question(@"В своей карьере готов смириться с
ролью подчиненного только как с временной", false, 3,

                                        new variant("всегда", 10),
                                        new variant("не уверен, сомневаюсь", 5),
                                        new variant("не согласен", 0));
                    break;
                default:
                    questions[0] = new Question(@"How often do you try to make 
people to follow you as the leader? ", false, 5,
                                        new variant("very often", 5),
                                        new variant("often", 4),
                                        new variant("sometimes", 3),
                                        new variant("rare", 2),
                                        new variant("very rare", 1));

                    questions[1] = new Question("How often do you want to dominate people?", false, 5,
                                      new variant("very often", 5),
                                        new variant("often", 4),
                                        new variant("sometimes", 3),
                                        new variant("rare", 2),
                                        new variant("very rare", 1));

                    questions[2] = new Question(@"How often do you let other people
to control your behavior?", false, 5,
                                         new variant("very often", 5),
                                        new variant("often", 4),
                                        new variant("sometimes", 3),
                                        new variant("rare", 2),
                                        new variant("very rare", 1));

                    questions[3] = new Question(@"How many people can affect you?", false, 5,
                                       new variant("all", 5),
                                        new variant("most of people", 4),
                                        new variant("almost a half", 3),
                                        new variant("few", 2),
                                        new variant("nobody", 1));

                    questions[4] = new Question(@"How often do you come across people who you
allow to control the situation that is important for you?", false, 5,
                                         new variant("very often", 5),
                                        new variant("often", 4),
                                        new variant("sometimes", 3),
                                        new variant("rare", 2),
                                        new variant("very rare", 1));

                    questions[5] = new Question(@"How often do you try to be a leader in a relationship?", false, 5,
                                          new variant("very often", 5),
                                        new variant("often", 4),
                                        new variant("sometimes", 3),
                                        new variant("rare", 2),
                                        new variant("very rare", 1));

                    questions[6] = new Question(@"How often do you want to influence others,
that they would take an example with your actions?", false, 5,
                                       new variant("very often", 5),
                                        new variant("often", 4),
                                        new variant("sometimes", 3),
                                        new variant("rare", 2),
                                        new variant("very rare", 1));

                    questions[7] = new Question(@"How often do you allow others to take
decisions that affect you?", false, 5,
                                         new variant("very often", 5),
                                        new variant("often", 4),
                                        new variant("sometimes", 3),
                                        new variant("rare", 2),
                                        new variant("very rare", 1));

                    questions[8] = new Question(@"How often do you take responsibility for the situation,
which relate to other people?", false, 5,
                                         new variant("very often", 5),
                                        new variant("often", 4),
                                        new variant("sometimes", 3),
                                        new variant("rare", 2),
                                        new variant("very rare", 1));

                    // from leaderPotential

                    questions[9] = new Question(@"If authoritative person publicly
expresses the idea, which I think is wrong,
I will try to present and listened
my point of view.", false, 3,
                                        new variant("always", 10),
                                        new variant("not sure, doubt", 5),
                                        new variant("disagree", 0));

                    questions[10] = new Question(@"As a child, I was often
called a naughty child", false, 3,

                                       new variant("always", 10),
                                        new variant("not sure, doubt", 5),
                                        new variant("disagree", 0));
                    questions[11] = new Question(@"I am sure that the world can be better", false, 3,

                                      new variant("always", 10),
                                        new variant("not sure, doubt", 5),
                                        new variant("disagree", 0));

                    questions[12] = new Question(@"I do not like when friends and relatives try to
patronize me, boring me with tips", false, 3,

                                       new variant("always", 10),
                                        new variant("not sure, doubt", 5),
                                        new variant("disagree", 0));

                    questions[13] = new Question(@"In situations that require serious solutions,
I'm not prone to long fluctuations", false, 3,

                                       new variant("always", 10),
                                        new variant("not sure, doubt", 5),
                                        new variant("disagree", 0));

                    questions[14] = new Question(@"It seems that most of the socio-political
problems arise due to lack of rigidity of
decision makers", false, 3,

                                        new variant("always", 10),
                                        new variant("not sure, doubt", 5),
                                        new variant("disagree", 0));

                    questions[15] = new Question(@"I do not care if I
have to blame someone", false, 3,

                                        new variant("always", 10),
                                        new variant("not sure, doubt", 5),
                                        new variant("disagree", 0));

                    questions[16] = new Question(@"If I am not possible to
handle situation with myself, then for its implementation
I need assistants, not advisers", false, 3,

                                       new variant("always", 10),
                                        new variant("not sure, doubt", 5),
                                        new variant("disagree", 0));

                    questions[17] = new Question(@"In disputes I always try to leave
the last word", false, 3,

                                      new variant("always", 10),
                                        new variant("not sure, doubt", 5),
                                        new variant("disagree", 0));

                    questions[18] = new Question(@"I believe that no progress is inconceivable
without the people's aspirations for superiority over others", false, 3,

                                        new variant("always", 10),
                                        new variant("not sure, doubt", 5),
                                        new variant("disagree", 0));
                    questions[19] = new Question(@"Often I have to take on responsibility,
because other insufficiently resolute", false, 3,

                                       new variant("always", 10),
                                        new variant("not sure, doubt", 5),
                                        new variant("disagree", 0));

                    questions[20] = new Question(@"I do not believe in absolute equality
in the marital relationship, in my family
I prefer to be the head", false, 3,
                                        new variant("always", 10),
                                        new variant("not sure, doubt", 5),
                                        new variant("disagree", 0));

                    questions[21] = new Question(@"When at a party no one dares to take
dishes with the last piece of cake,
I can do it quietly", false, 3,

                                        new variant("always", 10),
                                        new variant("not sure, doubt", 5),
                                        new variant("disagree", 0));

                    questions[22] = new Question(@"I like to be in the spotlight", false, 3,

                                        new variant("always", 10),
                                        new variant("not sure, doubt", 5),
                                        new variant("disagree", 0));

                    questions[23] = new Question(@"In my career, I am ready to accept
subordinate role only as a temporary", false, 3,

                                        new variant("always", 10),
                                        new variant("not sure, doubt", 5),
                                        new variant("disagree", 0));
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

