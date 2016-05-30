using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Modules.Tests.Methods
{
    class MethodCherepaha : Method
    {
        Conclusion[] conclMass = new Conclusion[5];
        public MethodCherepaha()
        {
            conclMass[0] = new Conclusion(1, 63, @"«Черепаха» (уникнення) - стратегія 
відходу під панцир, тобто відмови від 
досягнення особистої мети, та участі 
у взаємостосунках з оточуючими.");
            conclMass[1] = new Conclusion(64, 91, @"«Акула» (конкуренція) - силова стратегія: 
мета дуже важлива, взаємовідношення немає.
Таким людям не важливо, чи люблять 
їх, вони вважають, що конфлікти розв'язуються 
виграшем однієї із сторін і поразкою другої.");
            conclMass[2] = new Conclusion(92, 119, @"«Ведмідь» (пристосування) — стратегія
обходу гострих кутів: взаємостосунки важливі, 
мети немає. Такі люди хочуть, 
щоб їх приймали і любили, ради чого жертвують
метою.");
            conclMass[3] = new Conclusion(120, 147, @"«Лисиця» - (стратегія компромісу: 
помірне відношення і до мети, і до 
взаємовідношень. Такі люди готові відмовитися 
від деякої мети, щоб зберегти взаємовідношення.");
            conclMass[4] = new Conclusion(148, 175, @"«Сова» - стратегія відкритої 
і чесної конфронтації і співпраці. 
Представники цього типу цінують і мету, 
і взаємостосунки. Відкрито визначають 
позиції і шукають виходу в сумісній 
роботі по досягненню мети, прагнуть 
знайти рішення, що задовольняють всіх.");
            numberOfQuestions = 35;
        }
        public override string Name
        {
            get { return Properties.Resources.CherepahaMethodName; }
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
            switch (Thread.CurrentThread.CurrentUICulture.Name)
            { 
                case "uk-UA":
            questions[0] = new Question(@"Поганий мир краще за добру сварку", false, 5, 
                new variant("точно ні", 1), 
                new variant("мабуть ні", 2), 
                new variant("щось середнє", 3), 
                new variant("мабуть так", 4), 
                new variant("точно так", 5));
            questions[1] = new Question(@"Якщо не можете іншого примусити думати так, 
як ви хочете, примусьте його робити так, 
як ви думаєте", false, 5, 
              new variant("точно ні", 1), 
              new variant("мабуть ні", 2), 
              new variant("щось середнє", 3), 
              new variant("мабуть так", 4), 
              new variant("точно так", 5));
            questions[2] = new Question(@"М'яко стелить, та жорстко спати", false, 5, 
                new variant("точно ні", 1), 
                new variant("мабуть ні", 2), 
                new variant("щось середнє", 3), 
                new variant("мабуть так", 4), 
                new variant("точно так", 5));
            questions[3] = new Question(@"Рука руку миє", false, 5, 
                new variant("точно ні", 1), 
                new variant("мабуть ні", 2), 
                new variant("щось середнє", 3), 
                new variant("мабуть так", 4), 
                new variant("точно так", 5));
            questions[4] = new Question(@"Розум - добре, а два - краще", false, 5, 
                new variant("точно ні", 1), 
                new variant("мабуть ні", 2), 
                new variant("щось середнє", 3), 
                new variant("мабуть так", 4), 
                new variant("точно так", 5));
            questions[5] = new Question(@"З двох сперечальників розумніше той, 
хто перший замовкне", false, 5, 
                    new variant("точно ні", 1), 
                    new variant("мабуть ні", 2), 
                    new variant("щось середнє", 3), 
                    new variant("мабуть так", 4), 
                    new variant("точно так", 5));
            questions[6] = new Question(@"Хто сильніший - той і правий", false, 5, 
                new variant("точно ні", 1), 
                new variant("мабуть ні", 2), 
                new variant("щось середнє", 3), 
                new variant("мабуть так", 4), 
                new variant("точно так", 5));
            questions[7] = new Question(@"Не підмажеш - не поїдеш", false, 5, 
                new variant("точно ні", 1), 
                new variant("мабуть ні", 2), 
                new variant("щось середнє", 3), 
                new variant("мабуть так", 4), 
                new variant("точно так", 5));
            questions[8] = new Question(@"З паршивої вівці — хоч шерсті жмут", false, 5, 
                new variant("точно ні", 1), 
                new variant("мабуть ні", 2), 
                new variant("щось середнє", 3), 
                new variant("мабуть так", 4), 
                new variant("точно так", 5));
            questions[9] = new Question(@"Правда те, що мудрий знає, 
а не те, про що всі базікають", false, 5, 
                              new variant("точно ні", 1), 
                              new variant("мабуть ні", 2), 
                              new variant("щось середнє", 3), 
                              new variant("мабуть так", 4), 
                              new variant("точно так", 5));
            questions[10] = new Question(@"Хто вдарить і втече, той 
зможе битися і наступного дня", false, 5, 
                              new variant("точно ні", 1), 
                              new variant("мабуть ні", 2), 
                              new variant("щось середнє", 3), 
                              new variant("мабуть так", 4), 
                              new variant("точно так", 5));
            questions[11] = new Question(@"Слово «перемога» чітко написано 
тільки на спинах ворогів", false, 5, 
                         new variant("точно ні", 1), 
                         new variant("мабуть ні", 2), 
                         new variant("щось середнє", 3), 
                         new variant("мабуть так", 4), 
                         new variant("точно так", 5));
            questions[12] = new Question(@"Вбивай ворогів своїх добротою", false, 5, 
                new variant("точно ні", 1), 
                new variant("мабуть ні", 2), 
                new variant("щось середнє", 3), 
                new variant("мабуть так", 4), 
                new variant("точно так", 5));
            questions[13] = new Question(@"Чесна операція не викличе сварки", false, 5, 
                new variant("точно ні", 1), 
                new variant("мабуть ні", 2), 
                new variant("щось середнє", 3), 
                new variant("мабуть так", 4), 
                new variant("точно так", 5));
            questions[14] = new Question(@"Ні у кого немає повної відповіді, 
але у кожного є що додати", false, 5, 
                          new variant("точно ні", 1), 
                          new variant("мабуть ні", 2), 
                          new variant("щось середнє", 3), 
                          new variant("мабуть так", 4), 
                          new variant("точно так", 5));
            questions[15] = new Question(@"Тримайся подалі від людей, які не згодні
з тобою", false, 5, new variant("точно ні", 1), 
        new variant("мабуть ні", 2), 
        new variant("щось середнє", 3), 
        new variant("мабуть так", 4), 
        new variant("точно так", 5));
            questions[16] = new Question(@"Битву виграє той, хто вірить в перемогу", false, 5, 
                new variant("точно ні", 1), 
                new variant("мабуть ні", 2), 
                new variant("щось середнє", 3), 
                new variant("мабуть так", 4), 
                new variant("точно так", 5));
            questions[17] = new Question(@"Добре слово не вимагає витрат, а коштує 
дорого", false, 5, 
       new variant("точно ні", 1), 
       new variant("мабуть ні", 2), 
       new variant("щось середнє", 3), 
       new variant("мабуть так", 4), 
       new variant("точно так", 5));
            questions[18] = new Question(@"Ти — мені, я — тобі", false, 5, 
                new variant("точно ні", 1), 
                new variant("мабуть ні", 2), 
                new variant("щось середнє", 3), 
                new variant("мабуть так", 4), 
                new variant("точно так", 5));
            questions[19] = new Question(@"Тільки той, хто відмовиться від своєї
монополії на істину, зможе отримати користь
з істин, якими володіють інші", false, 5, 
                              new variant("точно ні", 1), 
                              new variant("мабуть ні", 2), 
                              new variant("щось середнє", 3), 
                              new variant("мабуть так", 4), 
                              new variant("точно так", 5));
            questions[20] = new Question(@"Хто сперечається, той гроша не коштує", false, 5, 
                new variant("точно ні", 1), 
                new variant("мабуть ні", 2), 
                new variant("щось середнє", 3), 
                new variant("мабуть так", 4), 
                new variant("точно так", 5));
            questions[21] = new Question(@"Хто не відступає, той обертає у втечу", false, 5, new variant("точно ні", 1), new variant("мабуть ні", 2), new variant("щось середнє", 3), new variant("мабуть так", 4), new variant("точно так", 5));
            questions[22] = new Question(@"Ласкаве телятко двох маток смокче, 
а уперте — жодної", false, 5, 
                  new variant("точно ні", 1), 
                  new variant("мабуть ні", 2), 
                  new variant("щось середнє", 3), 
                  new variant("мабуть так", 4), 
                  new variant("точно так", 5));
            questions[23] = new Question(@"Хто дарує — друзів наживає", false, 5, 
                new variant("точно ні", 1), 
                new variant("мабуть ні", 2),
                new variant("щось середнє", 3), 
                new variant("мабуть так", 4), 
                new variant("точно так", 5));
            questions[24] = new Question(@"Винось турботи на світло і тримай з
іншими пораду", false, 5, 
              new variant("точно ні", 1), 
              new variant("мабуть ні", 2), 
              new variant("щось середнє", 3), 
              new variant("мабуть так", 4), 
              new variant("точно так", 5));
            questions[25] = new Question(@"Кращий спосіб вирішувати конфлікти — 
уникати їх", false, 5, 
           new variant("точно ні", 1), 
           new variant("мабуть ні", 2), 
           new variant("щось середнє", 3), 
           new variant("мабуть так", 4), 
           new variant("точно так", 5));
            questions[26] = new Question(@"Сім разів відміряй, один раз відріж", false, 5, 
                new variant("точно ні", 1), 
                new variant("мабуть ні", 2), 
                new variant("щось середнє", 3), 
                new variant("мабуть так", 4), 
                new variant("точно так", 5));
            questions[27] = new Question(@"Лагідність перемагає гнів", false, 5, 
                new variant("точно ні", 1), 
                new variant("мабуть ні", 2), 
                new variant("щось середнє", 3), 
                new variant("мабуть так", 4), 
                new variant("точно так", 5));
            questions[28] = new Question(@"Краще синиця в руках, ніж журавель 
в хмарах", false, 5, 
         new variant("точно ні", 1), 
         new variant("мабуть ні", 2), 
         new variant("щось середнє", 3), 
         new variant("мабуть так", 4), 
         new variant("точно так", 5));
            questions[29] = new Question(@"Щиросердя, чесність і довір'я двигають 
гори", false, 5, 
     new variant("точно ні", 1), 
     new variant("мабуть ні", 2), 
     new variant("щось середнє", 3), 
     new variant("мабуть так", 4), 
     new variant("точно так", 5));
            questions[30] = new Question(@"На світі немає нічого, що заслуговувало 
б суперечки", false, 5, 
            new variant("точно ні", 1), 
            new variant("мабуть ні", 2), 
            new variant("щось середнє", 3), 
            new variant("мабуть так", 4), 
            new variant("точно так", 5));
            questions[31] = new Question(@"В цьому світі є тільки два типи людей: 
переможці і переможені", false, 5, 
                       new variant("точно ні", 1), 
                       new variant("мабуть ні", 2), 
                       new variant("щось середнє", 3), 
                       new variant("мабуть так", 4), 
                       new variant("точно так", 5));
            questions[32] = new Question(@"Якщо в тебе жбурнули камінь, 
кидай у відповідь шматок вати", false, 5, 
                              new variant("точно ні", 1), 
                              new variant("мабуть ні", 2), 
                              new variant("щось середнє", 3), 
                              new variant("мабуть так", 4), 
                              new variant("точно так", 5));
            questions[33] = new Question(@"Взаємні уступки чудово вирішують справи", false, 5, new variant("точно ні", 1), new variant("мабуть ні", 2), new variant("щось середнє", 3), new variant("мабуть так", 4), new variant("точно так", 5));
            questions[34] = new Question(@"Копай і копай без втоми - 
докопаєшся до істини", false, 5, 
                     new variant("точно ні", 1), 
                     new variant("мабуть ні", 2), 
                     new variant("щось середнє", 3), 
                     new variant("мабуть так", 4), 
                     new variant("точно так", 5));
            break;

                case "ru-RU":

            questions[0] = new Question(@"Плохой мир лучше доброй ссоры", false, 5, 
                new variant("точно нет", 1), 
                new variant("наверное нет", 2), 
                new variant("что-то среднее", 3), 
                new variant("наверное да", 4), 
                new variant("точно да", 5));
            questions[1] = new Question(@"Если не можете другого заставить думать так, 
как вы хотите, заставьте его делать так, 
как вы думаете", false, 5,
              new variant("точно нет", 1),
              new variant("наверное нет", 2),
              new variant("что-то среднее", 3),
              new variant("наверное да", 4),
              new variant("точно да", 5));
            questions[2] = new Question(@"Мягко стелит, но жестко спать", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[3] = new Question(@"Рука руку моет", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[4] = new Question(@"Одна голова - хорошо, а две - лучше.", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[5] = new Question(@"Из двух спорящих умнее тот, 
кто первый замолчит", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[6] = new Question(@"Кто сильнее - тот и прав.", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[7] = new Question(@"Не подмажешь - не поедешь", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[8] = new Question(@"С паршивой овцы — хоть шерсти клок", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[9] = new Question(@"Правда то, что мудрый знает, 
а не то, о чем все говорят", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[10] = new Question(@"Кто ударит и убежит, тот 
сможет драться и завтра", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[11] = new Question(@"Слово «победа» четко написано 
только на спинах врагов", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[12] = new Question(@"Убивай врагов своих добротой", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[13] = new Question(@"Чесная операция не вызовет ссоры", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[14] = new Question(@"Ни у кого нет полного ответа, 
но у каждого есть что добавить", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[15] = new Question(@"Держись подальше от людей, которые не согласны
с тобой", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[16] = new Question(@"Битву выиграет тот, кто верит в победу", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[17] = new Question(@"Доброе слово не требует трат, а стоит 
дорого", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[18] = new Question(@"Ты — мне, я — тебе", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[19] = new Question(@"Только тот, кто откажется от своей
монополии на истину, сможет получить пользу
из истин, которыми владеют другие", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[20] = new Question(@"Кто спорит, тот гроша не стоит", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[21] = new Question(@"Кто отступает, тот обращается в бегство", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[22] = new Question(@"Ласковый теленок двух маток сосет, 
а упертый — ни одной", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[23] = new Question(@"Кто дарит — друзей наживает", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[24] = new Question(@"Выноси заботы на свет и держи с 
другими совет", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[25] = new Question(@"Лучший способ решать конфликты — 
избегать их", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[26] = new Question(@"Семь раз отмерь, один раз отрежь", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[27] = new Question(@"Ласка побеждает гнев", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[28] = new Question(@"Лучше синица в руках, чем журавль 
в небе", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[29] = new Question(@"Чистосердечность, честность и доверие 
двигают горы", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[30] = new Question(@"На свете нет ничего, что заслуживало бы 
спора", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[31] = new Question(@"В этом мире есть только два типа людей: 
победители и проигравшие", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[32] = new Question(@"Если в тебя бросили камень, 
бросай в ответ кусок ваты", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[33] = new Question(@"Взаимные уступки чудесно решают дела", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));
            questions[34] = new Question(@"Копай и копай без устанку - 
докопаешься до истины", false, 5,
                new variant("точно нет", 1),
                new variant("наверное нет", 2),
                new variant("что-то среднее", 3),
                new variant("наверное да", 4),
                new variant("точно да", 5));

            break;
                case "en-US":
            questions[0] = new Question(@"Bad peace is better than a good quarrel", false, 5, 
                new variant("no", 1), 
                new variant("maybe no", 2), 
                new variant("middle", 3), 
                new variant("maybe yes", 4), 
                new variant("yes", 5));
            questions[1] = new Question(@"If you can not make them think of another way,
the way you want, make it do so,
what you think", false, 5,
              new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[2] = new Question(@"Gently spreads but hard to sleep", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[3] = new Question(@"One hand washes the other", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[4] = new Question(@"One head it's good, but two better.", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[5] = new Question(@"Of the two disputing the smarter,
who was the first silent", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[6] = new Question(@"Who is stronger is right.", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[7] = new Question(@"You will achieve nothing if you do not bribe", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[8] = new Question(@"even a mangy sheep is good for a little wool", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[9] = new Question(@"It is true that the wise know,
rather than what they say about all", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[10] = new Question(@"Who hit and run, the
able to fight tomorrow", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[11] = new Question(@"The word victory is clearly written,
only on the backs of enemies", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[12] = new Question(@"Kill your enemies with kindness", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[13] = new Question(@"Honest operation does not cause strife", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[14] = new Question(@"No one has the full answer,
but everyone has something to add", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[15] = new Question(@"Stay away from people who do not agree
with you", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[16] = new Question(@"Battle winner is the one who believes in victory", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[17] = new Question(@"A kind word does not require costs, and costs
expensive", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[18] = new Question(@"Roll my log and I will roll yours", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[19] = new Question(@"Only those who give up their
a monopoly on the truth, could benefit
of the truths that are owned by others", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[20] = new Question(@"Who argues, the penny is not worth", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[21] = new Question(@"Might makes right", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[22] = new Question(@"Не who is demure and kind gets everybody's
help, protection and favo(u)r", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[23] = new Question(@"Who gives - is making friends", false, 5,
               new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[24] = new Question(@"Endure concern to light and to hold
other tips", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[25] = new Question(@"The best way to resolve conflicts -
avoid them", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[26] = new Question(@"Think well before you take a
decision, do not act rashly", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[27] = new Question(@"A mild reply can alleviate 
anger or hostility", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[28] = new Question(@"Bird in the hand is better than a crane
in the sky", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[29] = new Question(@"Pure-hearted, honesty and trust
move mountains", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[30] = new Question(@"There is not anything that 
would deserve argue", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[31] = new Question(@"In this world there are only
two types of people:winners and losers", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[32] = new Question(@"If you throw a stone,
Throw in response to a piece of cotton wool", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[33] = new Question(@"Mutual concessions miraculously
solve the case", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[34] = new Question(@"Dug and dug without ustanku -
find the truth", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
           
            break;
                default:
                      questions[0] = new Question(@"Bad peace is better than a good quarrel", false, 5, 
                new variant("no", 1), 
                new variant("maybe no", 2), 
                new variant("middle", 3), 
                new variant("maybe yes", 4), 
                new variant("yes", 5));
            questions[1] = new Question(@"If you can not make them think of another way,
the way you want, make it do so,
what you think", false, 5,
              new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[2] = new Question(@"Gently spreads but hard to sleep", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[3] = new Question(@"One hand washes the other", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[4] = new Question(@"One head it's good, but two better.", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[5] = new Question(@"Of the two disputing the smarter,
who was the first silent", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[6] = new Question(@"Who is stronger is right.", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[7] = new Question(@"You will achieve nothing if you do not bribe", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[8] = new Question(@"even a mangy sheep is good for a little wool", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[9] = new Question(@"It is true that the wise know,
rather than what they say about all", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[10] = new Question(@"Who hit and run, the
able to fight tomorrow", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[11] = new Question(@"The word victory is clearly written,
only on the backs of enemies", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[12] = new Question(@"Kill your enemies with kindness", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[13] = new Question(@"Honest operation does not cause strife", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[14] = new Question(@"No one has the full answer,
but everyone has something to add", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[15] = new Question(@"Stay away from people who do not agree
with you", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[16] = new Question(@"Battle winner is the one who believes in victory", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[17] = new Question(@"A kind word does not require costs, and costs
expensive", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[18] = new Question(@"Roll my log and I will roll yours", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[19] = new Question(@"Only those who give up their
a monopoly on the truth, could benefit
of the truths that are owned by others", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[20] = new Question(@"Who argues, the penny is not worth", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[21] = new Question(@"Might makes right", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[22] = new Question(@"Не who is demure and kind gets everybody's
help, protection and favo(u)r", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[23] = new Question(@"Who gives - is making friends", false, 5,
               new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[24] = new Question(@"Endure concern to light and to hold
other tips", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[25] = new Question(@"The best way to resolve conflicts -
avoid them", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[26] = new Question(@"Think well before you take a
decision, do not act rashly", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[27] = new Question(@"A mild reply can alleviate 
anger or hostility", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[28] = new Question(@"Bird in the hand is better than a crane
in the sky", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[29] = new Question(@"Pure-hearted, honesty and trust
move mountains", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[30] = new Question(@"There is not anything that 
would deserve argue", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[31] = new Question(@"In this world there are only
two types of people:winners and losers", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[32] = new Question(@"If you throw a stone,
Throw in response to a piece of cotton wool", false, 5,
                new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[33] = new Question(@"Mutual concessions miraculously
solve the case", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
            questions[34] = new Question(@"Dug and dug without ustanku -
find the truth", false, 5,
                 new variant("no", 1),
                new variant("maybe no", 2),
                new variant("middle", 3),
                new variant("maybe yes", 4),
                new variant("yes", 5));
           
            break;




            
        }
        }
        /// <summary>
        /// нормування (с)Ертонг
        /// </summary>
        override public void CountFinalResult()
        {
            finRes =(summResult % 5);
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

