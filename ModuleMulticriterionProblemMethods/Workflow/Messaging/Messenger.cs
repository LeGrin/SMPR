using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Modules.MulticriterionProblemMethods.Workflow.Messaging
{
    /// <summary>
    /// ³������ �� ����� ���������� �����������
    /// </summary>
    internal class Messenger
    {
        #region Singleton

        private static Messenger _theOnly = new Messenger ( );

        private Messenger()
        { }

        /// <summary>
        /// ��������� �����, �� ������� �� ����� ���������� �����������
        /// </summary>
        public static Messenger Current
        {
            get { return _theOnly; }
        }

        #endregion

        /// <summary>
        /// �������� �����������
        /// </summary>
        /// <param name="messageKind">��� �����������</param>
        /// <param name="messageText">����� �����������</param>
        /// <returns>����������� DialogResult, ���� �����������</returns>
        public DialogResult ShowMessage(MessageKind messageKind, string messageText)
        {
            string messageCaption;
            MessageBoxButtons messageBoxButtons;
            MessageBoxIcon messageBoxIcon;
            switch ( messageKind )
            {
                case MessageKind.Question_Yes_No:
                    messageCaption = "ϳ�����������";
                    messageBoxButtons = MessageBoxButtons.YesNo;
                    messageBoxIcon = MessageBoxIcon.Question;
                    break;
                case MessageKind.Error_Ok:
                    messageCaption = "�������";
                    messageBoxButtons = MessageBoxButtons.OK;
                    messageBoxIcon = MessageBoxIcon.Error;
                    break;
                case MessageKind.Warning_Ok:
                    messageCaption = Properties.Resources.Er;
                    messageBoxButtons = MessageBoxButtons.OK;
                    messageBoxIcon = MessageBoxIcon.Warning;
                    break;
                case MessageKind.Information_Ok:
                    messageCaption = "����������";
                    messageBoxButtons = MessageBoxButtons.OK;
                    messageBoxIcon = MessageBoxIcon.Information;
                    break;
                case MessageKind.Exception:
                    messageCaption = "�������� �������";
                    messageBoxButtons = MessageBoxButtons.OK;
                    messageBoxIcon = MessageBoxIcon.Error;
                    break;

                default: throw new NotImplementedException ( string.Format ( "� Messanger.ShowMessage() �� ���������� �������� ��� {0}. ", messageKind ) );
            }
            return MessageBox.Show ( messageText, messageCaption, messageBoxButtons, messageBoxIcon );
        }
    }
}