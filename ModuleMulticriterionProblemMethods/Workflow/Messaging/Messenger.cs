using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Modules.MulticriterionProblemMethods.Workflow.Messaging
{
    /// <summary>
    /// Відповідає за показ повідомлень користувачу
    /// </summary>
    internal class Messenger
    {
        #region Singleton

        private static Messenger _theOnly = new Messenger ( );

        private Messenger()
        { }

        /// <summary>
        /// Екземпляр класу, що відповідає за показ повідомлень користувачу
        /// </summary>
        public static Messenger Current
        {
            get { return _theOnly; }
        }

        #endregion

        /// <summary>
        /// Показати повідомлення
        /// </summary>
        /// <param name="messageKind">Тип повідомлення</param>
        /// <param name="messageText">Текст повідомлення</param>
        /// <returns>Стандартний DialogResult, вибір користувача</returns>
        public DialogResult ShowMessage(MessageKind messageKind, string messageText)
        {
            string messageCaption;
            MessageBoxButtons messageBoxButtons;
            MessageBoxIcon messageBoxIcon;
            switch ( messageKind )
            {
                case MessageKind.Question_Yes_No:
                    messageCaption = "Підтвердження";
                    messageBoxButtons = MessageBoxButtons.YesNo;
                    messageBoxIcon = MessageBoxIcon.Question;
                    break;
                case MessageKind.Error_Ok:
                    messageCaption = "Помилка";
                    messageBoxButtons = MessageBoxButtons.OK;
                    messageBoxIcon = MessageBoxIcon.Error;
                    break;
                case MessageKind.Warning_Ok:
                    messageCaption = Properties.Resources.Er;
                    messageBoxButtons = MessageBoxButtons.OK;
                    messageBoxIcon = MessageBoxIcon.Warning;
                    break;
                case MessageKind.Information_Ok:
                    messageCaption = "Інформація";
                    messageBoxButtons = MessageBoxButtons.OK;
                    messageBoxIcon = MessageBoxIcon.Information;
                    break;
                case MessageKind.Exception:
                    messageCaption = "Критична помилка";
                    messageBoxButtons = MessageBoxButtons.OK;
                    messageBoxIcon = MessageBoxIcon.Error;
                    break;

                default: throw new NotImplementedException ( string.Format ( "В Messanger.ShowMessage() не реалізовано поведінки для {0}. ", messageKind ) );
            }
            return MessageBox.Show ( messageText, messageCaption, messageBoxButtons, messageBoxIcon );
        }
    }
}