using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Tests.Methods
{
    public class MethodVouting : Method
    {
        Conclusion[] conclMass = new Conclusion[5];
        public MethodVouting()
        {
            conclMass[0] = new Conclusion(0,5, @"�� ����, ��� ����� ������������");
            conclMass[1] = new Conclusion(6,7, @"��� ����� ����������, � �� �����");
            conclMass[2] = new Conclusion(8, 9, @"�� ����� ��������� �� ���������");
            conclMass[3] = new Conclusion(9, 10, @"�� ������ ��������� �� ��������");
            conclMass[4] = new Conclusion(11, 11, @"�� ���� �������� ������ �� �� ��������� ���������");


            numberOfQuestions = 12;
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
        /// �������� ��� �� �������� �������.
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
            questions[0] = new Question("��� � ������ ����������� � ������������?", false, 4,
 new variant("��������", 0),
 new variant("ѳ������", 0),
 new variant("����������� �����", 0),
 new variant("������� ������� � ����������", 1));
            questions[1] = new Question("��� � ����� �� ��������� � ��������� �����?", false, 4,
             new variant("������ �����������", 1),
             new variant("������ �����������(������������)", 0),
             new variant("������ �����������", 0),
             new variant("������ �������������.", 0));
            questions[2] = new Question(@"������� �������, �� ��������������� � �������� 
����� ������ � ������������� �������", false, 4,
             new variant("��������", 0),
             new variant("�����", 0),
             new variant("����������� ����������", 0),
             new variant("������������ ����������", 1));
            questions[3] = new Question(@"³���������� ����������� �������� �� ������ 
��������� ���� ��� � ���� ���, ���� 
����������� ��������� �������� �������: 
���������, ����������, 
������������ ��...", false, 4,
             new variant("������������", 1),
             new variant("�����", 0),
             new variant("�����������", 0),
             new variant("�����������", 0));
            questions[4] = new Question("������� ��������� ����������:", false, 4,
             new variant(@"������� ѳ������ ������� 
�����������, � ������� �������� 
� ����������� ������� ������", 1),
             new variant(@"������� ѳ������ ������� 
�����������, � ������� ��������
� ����������� ������� ������", 0),
             new variant(@"������� �������� � ѳ������ 
���������� ����������� ������� ������", 0),
             new variant(@"������� �������� � ѳ������ 
���������� ����������� 
������� ������", 0));
            questions[5] = new Question(@"��� � ��������� ������ 
�� ������� �������� ���������?", false, 4,
             new variant("ѳ������", 0),
             new variant("��������", 1),
             new variant("�����", 0),
             new variant("�� ������� ����������", 0));
            questions[6] = new Question(@"���������� ��������(���� ����) 
������ � ����� ����������...", false, 4,
             new variant("�������� � ѳ������ ", 1),
             new variant("ѳ������ � �����", 0),
             new variant("����� � ������� �������", 0),
             new variant("������� ������� � ��������", 0));
            questions[7] = new Question("������� ������ ����������:", false, 4,
             new variant(@"������� ѳ������ 
����������� ����� ����������", 0),
             new variant(@"������� ����� 
����������� ����� �����������", 0),
             new variant(@"������� �������� 
�� ����������� ����� �����������", 1),
             new variant(@"������� �������� 
�� ����������� ����� ����������", 0));
            questions[8] = new Question(@"��� ������� ����������� ����������� 
������� �����������, �����������,
�������, ������������� �� 
��������� ���������?", false, 4,
             new variant("������� �������", 0),
             new variant("�����", 0),
             new variant("��������", 0),
             new variant("������ ������� �� ����", 1));
            questions[9] = new Question(@"���� ��� ����� ��������� �� 
�������� �������� ���� ���������,
�� �������� ��� �����, ��...", false, 4,
             new variant("��������� �� ���� ", 1),
             new variant(@"�������� ���, �� �� 
����� ������� � �������� ����������", 0),
             new variant("���������� ���������� �������� ���", 0),
             new variant("���������� ��������� ���������� �����", 0));
            questions[10] = new Question(@"� ����� ������ �� ������ ���� ��������� 
���� ������������ 0 ���� (����),
�� ����������� � 1, ..., �� ����� � (m41).
�������� �������� � 
��������� ����� ����.", false, 4,
             new variant("������� �����", 1),
             new variant("������� ��������", 0),
             new variant("������� ѳ������", 0),
             new variant("������� ��������", 0));
            questions[11] = new Question("����������� ���������� �������� �����, ��:", false, 4,
             new variant("������� ����� ���������� �� ����� ���������", 0),
             new variant("���� ����� �� ����� ���� �� � �����", 0),
             new variant(@"���������� ��������� ��������� 
�� ����� ����� ��������", 0),
             new variant(@"������������ ������� 
������� � ���� ������������� ��������", 1));
        }
        /// <summary>
        /// ���������� (�)������
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
