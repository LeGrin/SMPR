using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Modules.Tests.Methods
{
    class MethodRisk : Method
    {
        Conclusion[] conclMass = new Conclusion[3];
        public MethodRisk()
        {
            numberOfQuestions = 25;
        }
        public override string Name
        {
            get { return Properties.Resources.RiskMethodName; }
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
                    questions[0] = new Question(@"Чи перевищили б Ви встановлену швидкість, 
щоб швидше надати необхідну медичну 
допомогу тяжкохворій людині?", false, 5, 
                             new variant("точно ні", -2), 
                             new variant("мабуть ні", -1), 
                             new variant("щось середнє", 0), 
                             new variant("мабуть так", 1), 
                             new variant("точно так", 2));
                    questions[1] = new Question(@"Чи погодилися б Ви заради гарного заробітку
взяти участь у небезпечній і
тривалій експедиції?", false, 5,
                             new variant("точно ні", -2),
                             new variant("мабуть ні", -1),
                             new variant("щось середнє", 0),
                             new variant("мабуть так", 1),
                             new variant("точно так", 2));
                    questions[2] = new Question(@"Чи стали б Ви на шляху небезпечного злодія, що тікає?", false, 5,
                        new variant("точно ні", -2),
                        new variant("мабуть ні", -1),
                        new variant("щось середнє", 0),
                        new variant("мабуть так", 1),
                        new variant("точно так", 2));
                    questions[3] = new Question(@"Чи могли б Ви їхати на підніжці товарного вагону
при швидкості більше ніж 100 км/год?", false, 5,
                                             new variant("точно ні", -2),
                                             new variant("мабуть ні", -1),
                                             new variant("щось середнє", 0),
                                             new variant("мабуть так", 1),
                                             new variant("точно так", 2));
                    questions[4] = new Question(@"Чи можете Ви на наступний день після безсонної ночі
нормально працювати?", false, 5,
                             new variant("точно ні", -2),
                             new variant("мабуть ні", -1),
                             new variant("щось середнє", 0),
                             new variant("мабуть так", 1),
                             new variant("точно так", 2));
                    questions[5] = new Question(@"Чи перейшли би Ви першим дуже холодну річку?", false, 5,
                        new variant("точно ні", -2),
                        new variant("мабуть ні", -1),
                        new variant("щось середнє", 0),
                        new variant("мабуть так", 1),
                        new variant("точно так", 2));
                    questions[6] = new Question(@"Чи позичили б Ви другові велику суму грошей,
будучи не зовсім упевненим,
що він зможе Вам повернути ці гроші?", false, 5,
                                             new variant("точно ні", -2),
                                             new variant("мабуть ні", -1),
                                             new variant("щось середнє", 0),
                                             new variant("мабуть так", 1),
                                             new variant("точно так", 2));
                    questions[7] = new Question(@"Чи увійшли б Ви разом з приборкувачем в клітку з
левами при його завіренні, що це безпечно?", false, 5,
                                                   new variant("точно ні", -2),
                                                   new variant("мабуть ні", -1),
                                                   new variant("щось середнє", 0),
                                                   new variant("мабуть так", 1),
                                                   new variant("точно так", 2));
                    questions[8] = new Question(@"Чи могли б Ви під керівництвом ззовні залізти
на високу фабричну трубу?", false, 5,
                                  new variant("точно ні", -2),
                                  new variant("мабуть ні", -1),
                                  new variant("щось середнє", 0),
                                  new variant("мабуть так", 1),
                                  new variant("точно так", 2));
                    questions[9] = new Question(@"Чи могли б Ви без тренування керувати
парусним човном?", false, 5,
                         new variant("точно ні", -2),
                         new variant("мабуть ні", -1),
                         new variant("щось середнє", 0),
                         new variant("мабуть так", 1),
                         new variant("точно так", 2));
                    questions[10] = new Question(@"Ви б ризикнули схопити за вуздечку коня,
що біжить?", false, 5, new variant("точно ні", -2),
                   new variant("мабуть ні", -1),
                   new variant("щось середнє", 0),
                   new variant("мабуть так", 1),
                   new variant("точно так", 2));
                    questions[11] = new Question(@"Ви б могли після 10 бокалів пива їхати
на велосипеді?", false, 5,
                       new variant("точно ні", -2),
                       new variant("мабуть ні", -1),
                       new variant("щось середнє", 0),
                       new variant("мабуть так", 1),
                       new variant("точно так", 2));
                    questions[12] = new Question(@"Чи могли б Ви стрибнути з парашутом?", false, 5,
                        new variant("точно ні", -2),
                        new variant("мабуть ні", -1),
                        new variant("щось середнє", 0),
                        new variant("мабуть так", 1),
                        new variant("точно так", 2));
                    questions[13] = new Question(@"Ви б могли за необхідності проїхати без квитка
від Таліна до Москви?", false, 5,
                              new variant("точно ні", -2),
                              new variant("мабуть ні", -1),
                              new variant("щось середнє", 0),
                              new variant("мабуть так", 1),
                              new variant("точно так", 2));
                    questions[14] = new Question(@"Ви б могли вчинити авто турне,
якби за кермом сидів Ваш знайомий,
який зовсім недавно був у важкій
дорожній події?", false, 5,
                        new variant("точно ні", -2),
                        new variant("мабуть ні", -1),
                        new variant("щось середнє", 0),
                        new variant("мабуть так", 1),
                        new variant("точно так", 2));
                    questions[15] = new Question(@"Ви б могли з 10-метрової висоти стрибнути
на тент пожежної команди?", false, 5,
                                  new variant("точно ні", -2),
                                  new variant("мабуть ні", -1),
                                  new variant("щось середнє", 0),
                                  new variant("мабуть так", 1),
                                  new variant("точно так", 2));
                    questions[16] = new Question(@"Ви б наважилися на небезпечну для життя 
операцію заради того, щоб позбутися
затяжної хвороби з постільним режимом?", false, 5,
                                               new variant("точно ні", -2),
                                               new variant("мабуть ні", -1),
                                               new variant("щось середнє", 0),
                                               new variant("мабуть так", 1),
                                               new variant("точно так", 2));
                    questions[17] = new Question(@"Ви б могли зістрибнути з підніжки товарного
вагону що рухається із швидкістю 50 км/год?", false, 5,
                                                    new variant("точно ні", -2),
                                                    new variant("мабуть ні", -1),
                                                    new variant("щось середнє", 0),
                                                    new variant("мабуть так", 1),
                                                    new variant("точно так", 2));
                    questions[18] = new Question(@"Могли б Ви, як виняток разом, з сімома іншими
людьми піднятися в ліфті,
розрахованому тільки на шість чоловік?", false, 5,
                                               new variant("точно ні", -2),
                                               new variant("мабуть ні", -1),
                                               new variant("щось середнє", 0),
                                               new variant("мабуть так", 1),
                                               new variant("точно так", 2));
                    questions[19] = new Question(@"Ви б наважилися за велику винагороду перейти
із зав’язаними очима вулицю
зі жвавим дорожнім рухом?", false, 5,
                                  new variant("точно ні", -2),
                                  new variant("мабуть ні", -1),
                                  new variant("щось середнє", 0),
                                  new variant("мабуть так", 1),
                                  new variant("точно так", 2));
                    questions[20] = new Question(@"Чи взялися б Ви за небезпечну для життя
роботу, якби за неї добре платили?", false, 5,
                                           new variant("точно ні", -2),
                                           new variant("мабуть ні", -1),
                                           new variant("щось середнє", 0),
                                           new variant("мабуть так", 1),
                                           new variant("точно так", 2));
                    questions[21] = new Question(@"Ви в могли після 10 чарок горілки обчислювати
відсотки?", false, 5,
                  new variant("точно ні", -2),
                  new variant("мабуть ні", -1),
                  new variant("щось середнє", 0),
                  new variant("мабуть так", 1),
                  new variant("точно так", 2));
                    questions[22] = new Question(@"Ви б могли за вказівкою Вашого начальника
взятися за високовольтний дріт,
якби він завірив Вас, що дріт
знеструмлений?", false, 5,
                       new variant("точно ні", -2),
                       new variant("мабуть ні", -1),
                       new variant("щось середнє", 0),
                       new variant("мабуть так", 1),
                       new variant("точно так", 2));
                    questions[23] = new Question(@"Ви б могли після деяких попередніх пояснень
управляти вертольотом?", false, 5,
                               new variant("точно ні", -2),
                               new variant("мабуть ні", -1),
                               new variant("щось середнє", 0),
                               new variant("мабуть так", 1),
                               new variant("точно так", 2));
                    questions[24] = new Question(@"Ви б могли, маючи квиток, але без грошей
і продуктів, доїхати з Москви
до Хабаровська?", false, 5,
                        new variant("точно ні", -2),
                        new variant("мабуть ні", -1),
                        new variant("щось середнє", 0),
                        new variant("мабуть так", 1),
                        new variant("точно так", 2));
                    break;
                case "ru-RU":
                    questions[0] = new Question(@"Превысили бы Вы допустимую скорость,
чтобы быстрее оказать
помощь больному человеку?", false, 5, 
                          new variant("точно нет", -2), 
                          new variant("наверное нет", -1), 
                          new variant("что-то среднее", 0), 
                          new variant("наверное да", 1), 
                          new variant("точно да", 2));
                    questions[1] = new Question(@"Согласились бы Вы ради хорошего зароботка
принять участие 
в долгой и опасной экспедиции?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[2] = new Question(@"Стали бы Вы на пути вора, который убегает?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[3] = new Question(@"Могли бы Вы ехать на подножке товарного вагона
на скорости быльше, чеи 100км/час?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[4] = new Question(@"Можете ли Вы нормально работать 
босле ночи без сна?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[5] = new Question(@"Перешли бы Вы первым очень холодную реку?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[6] = new Question(@"Одолжили бы Вы другу большую сумму денег,
будучи неуверенным, сможет он её вернуть, 
или нет?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[7] = new Question(@"Вошли бы Вы вместе с укротителем
в клетку с тигром,
если бы он уверил Вас в безопасности?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[8] = new Question(@"Могли бы Вы под руководством из вне
залезть на очень высокую 
производственную трубу?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[9] = new Question(@"Смогли бы Вы без тренировки 
управлять парусным кораблём?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[10] = new Question(@"Рискнули бы Вы схватить за стремя
коня, который бежит?", false, 5, 
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[11] = new Question(@"Смогли бы Вы после десяти
бокалов вина ехать на велосипеде?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[12] = new Question(@"Смогли бы Вы пригнуть с парашутом?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[13] = new Question(@"Могли бы Вы, по необходимости, 
проехать без билета из Таллина в Москву?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[14] = new Question(@"Могли бы Вы поехать в автотур,
если бы за рулём был Ваш знакомый,
который недавно попад в ДТП?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[15] = new Question(@"Могли бы Вы с 10-и метровой высоты
прыгнуть на полотно, растянутое 
пожарной командой?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[16] = new Question(@"Решились бы Вы на 
операцию ради того, чтобы избавится
от долгой болезни с постельным режимом?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[17] = new Question(@"Вы бы могли спрыгнуть с подножки товарного
вагона который движется со скоростью 50 км/час?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[18] = new Question(@"Могли бы Ви, как исключение, вместе с
семерыми другими людьми подняться в лифте,
рассчитаном только на шестерых?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[19] = new Question(@"Решились бы Вы, за небольшое вознаграждение, 
с закрытыми глазами, перйти улицу 
с оживлённым движением?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[20] = new Question(@"Устроились бы Вы на опасную работу,
за которую бы хорошо платили?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[21] = new Question(@"Смогли бы Вы после десяти рюмок
высчитывать проценты?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[22] = new Question(@"Могли бы Вы по поручению Вашего начальника
ухватиться за оголённый провод,
если бы он уверил, что провод 
обезточен?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[23] = new Question(@"Могли бы Вы после кратких 
объяснений управлять вертолётом?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    questions[24] = new Question(@"Могли бы Вы с билетом, но без денег
и продуктов, доехать из Москвы 
до Хабаровска?", false, 5,
                          new variant("точно нет", -2),
                          new variant("наверное нет", -1),
                          new variant("что-то среднее", 0),
                          new variant("наверное да", 1),
                          new variant("точно да", 2));
                    break;
                case "en-US":
                    questions[0] = new Question(@"Would you have exceeded the set speed
limit to provide necessary medical 
attention to seriously ill man more quickly?", false, 5, 
                             new variant("no, definitely", -2), 
                             new variant("more likely no", -1), 
                             new variant("can't decide", 0), 
                             new variant("more likely yes", 1), 
                             new variant("yes, definitely", 2));
                    questions[1] = new Question(@"Would you agree for good money 
take part in a dangerous and 
long expeditions?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[2] = new Question(@"Would you try stopping a thief that is escaping?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[3] = new Question(@"Could you hold on the running wagon 
at a speed of over 100 km / h?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[4] = new Question(@"Can you on the day after a sleepless night 
work normally?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[5] = new Question(@"Would you cross very cold river first?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[6] = new Question(@"Would you lend your friend
a huge amount of money,
not being sure, iff he would manage to 
return them?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[7] = new Question(@"Whould you enter the cage with lions with trainer
if he would ensure you of safetiness?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[8] = new Question(@"Could you with help of the person 
from outside, climb on a high factory pipe?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[9] = new Question(@"Could you, without training,
handle a sailboat?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[10] = new Question(@"Could you catch the bridle of
the running horse ?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[11] = new Question(@"Would you be able to handle the 
bicycle after ten glasses of vine?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[12] = new Question(@"Could you make a parachute jump?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[13] = new Question(@"Could you go by train from Moscow to Talin
without a ticket, if it was nessesarily?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[14] = new Question(@"Would you make an auto tour,
if the car was driven by your friend,
that participated in car accident
a while ago?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[15] = new Question(@"Could you jump on the firemen team's tent
from ten meters hight?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[16] = new Question(@"Would you agree to dangerous
surgery, knowing that it would cure your 
long lasting in bed desease?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[17] = new Question(@"Could jump off the train
that runs at speed of 50 kph?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[18] = new Question(@"Could you, as an exception,
go in the elevator with seven people,
calculated for six?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[19] = new Question(@"Would you risk to
cross the street with hard traffic
with tied eyes for some compensation?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[20] = new Question(@"Would you do dangerous, but highly paid job?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[21] = new Question(@"Would you be able to do calculations 
with percents after ten glasses of vine?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[22] = new Question(@"Could you, following to your boss'
directive, take bare wire if he 
ensured you that it is not under voltage?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[23] = new Question(@"Could you after few instructions 
handle a helicopter?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[24] = new Question(@"Could you having a ticket, but 
without money and food travel from Moscow to Habarovsk?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    break;

                default:
                    questions[0] = new Question(@"Would you have exceeded the set speed
limit to provide necessary medical 
attention to seriously ill man more quickly?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[1] = new Question(@"Would you agree for good money 
take part in a dangerous and 
long expeditions?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[2] = new Question(@"Would you try stopping a thief that is escaping?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[3] = new Question(@"Could you hold on the running wagon 
at a speed of over 100 km / h?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[4] = new Question(@"Can you on the day after a sleepless night 
work normally?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[5] = new Question(@"Would you cross very cold river first?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[6] = new Question(@"Would you lend your friend
a huge amount of money,
not being sure, iff he would manage to 
return them?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[7] = new Question(@"Whould you enter the cage with lions with trainer
if he would ensure you of safetiness?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[8] = new Question(@"Could you with help of the person 
from outside, climb on a high factory pipe?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[9] = new Question(@"Could you, without training,
handle a sailboat?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[10] = new Question(@"Could you catch the bridle of
the running horse ?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[11] = new Question(@"Would you be able to handle the 
bicycle after ten glasses of vine?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[12] = new Question(@"Could you make a parachute jump?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[13] = new Question(@"Could you go by train from Moscow to Talin
without a ticket, if it was nessesarily?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[14] = new Question(@"Would you make an auto tour,
if the car was driven by your friend,
that participated in car accident
a while ago?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[15] = new Question(@"Could you jump on the firemen team's tent
from ten meters hight?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[16] = new Question(@"Would you agree to dangerous
surgery, knowing that it would cure your 
long lasting in bed desease?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[17] = new Question(@"Could jump off the train
that runs at speed of 50 kph?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[18] = new Question(@"Could you, as an exception,
go in the elevator with seven people,
calculated for six?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[19] = new Question(@"Would you risk to
cross the street with hard traffic
with tied eyes for some compensation?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[20] = new Question(@"Would you do dangerous, but highly paid job?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[21] = new Question(@"Would you be able to do calculations 
with percents after ten glasses of vine?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[22] = new Question(@"Could you, following to your boss'
directive, take bare wire if he 
ensured you that it is not under voltage?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[23] = new Question(@"Could you after few instructions 
handle a helicopter?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
                    questions[24] = new Question(@"Could you having a ticket, but 
without money and food travel from Moscow to Habarovsk?", false, 5,
                             new variant("no, definitely", -2),
                             new variant("more likely no", -1),
                             new variant("can't decide", 0),
                             new variant("more likely yes", 1),
                             new variant("yes, definitely", 2));
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
            finRes = (((double)summResult)+50) / 100;
        }
        protected string GetConclusion()
        {
            switch (Thread.CurrentThread.CurrentUICulture.Name)
            {
                case "uk-UA":
                    conclMass[0] = new Conclusion(-1000, -10, @"Ви дуже обережні");
                    conclMass[1] = new Conclusion(-10, +10, @"Середній рівень обережності");
                    conclMass[2] = new Conclusion(10, 1000, @"Ви схильні до ризику");
                    break;
                case "ru-RU":
                    conclMass[0] = new Conclusion(-1000, -10, @"Вы очень осторожны");
                    conclMass[1] = new Conclusion(-10, +10, @"Средний уровень осторожности");
                    conclMass[2] = new Conclusion(10, 1000, @"Ви склонны к риску");
                    break;
                case "en-US":
                    conclMass[0] = new Conclusion(-1000, -10, @"You're very careful");
                    conclMass[1] = new Conclusion(-10, +10, @"Middle carefulness");
                    conclMass[2] = new Conclusion(10, 1000, @"You're predisposed to risk");
                    break;

                default:
                    conclMass[0] = new Conclusion(-1000, -10, @"You're very careful");
                    conclMass[1] = new Conclusion(-10, +10, @"Middle carefulness");
                    conclMass[2] = new Conclusion(10, 1000, @"You're predisposed to risk");
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

