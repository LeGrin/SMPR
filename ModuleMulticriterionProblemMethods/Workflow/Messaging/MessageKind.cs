using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.Workflow.Messaging
{
    /// <summary>
    /// Тип повідомленя, що буде виводитись
    /// </summary>
    internal enum MessageKind
    {
        /// <summary>
        /// Запитання
        /// </summary>
        Question_Yes_No,
        /// <summary>
        /// Інфо
        /// </summary>
        Information_Ok,
        /// <summary>
        /// Помилка
        /// </summary>
        Error_Ok,
        /// <summary>
        /// Зауваження
        /// </summary>
        Warning_Ok,
        /// <summary>
        /// Критична помилка(лише для розробників(типу при NotImplementedException), тобто юзери не повинні бачити цих повідомлень)
        /// </summary>
        Exception
    }   
}