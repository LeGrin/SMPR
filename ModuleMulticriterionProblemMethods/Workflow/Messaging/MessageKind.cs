using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.Workflow.Messaging
{
    /// <summary>
    /// ��� ����������, �� ���� ����������
    /// </summary>
    internal enum MessageKind
    {
        /// <summary>
        /// ���������
        /// </summary>
        Question_Yes_No,
        /// <summary>
        /// ����
        /// </summary>
        Information_Ok,
        /// <summary>
        /// �������
        /// </summary>
        Error_Ok,
        /// <summary>
        /// ����������
        /// </summary>
        Warning_Ok,
        /// <summary>
        /// �������� �������(���� ��� ����������(���� ��� NotImplementedException), ����� ����� �� ������ ������ ��� ����������)
        /// </summary>
        Exception
    }   
}