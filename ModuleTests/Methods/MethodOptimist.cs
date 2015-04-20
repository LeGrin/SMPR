using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Tests.Methods
{
    class MethodOptimist:Method
    {
        Conclusion[] conclMass = new Conclusion[3];
        public MethodOptimist()
        {
            conclMass[0] = new Conclusion(0, 13, @"�����, ����� ��� �� ��� �����������,
� �� ��� �� ������ �� ����� ����� �������.
������� ������� ����������,
������ - �����������.
������ �� ���� � ������� �� ����� ���������
��� ����� �����.
��� �������������, ��������� �������� � ������� ������,
�� ��������� ������� � ���. �� ���������:
����� ����� �� � �������� �������,
��� ���� �� ����� ���� ������ ����� ���������� �� �����.");
            conclMass[1] = new Conclusion(14, 23, @"�� ���������� ������, �� ��� ���� ��� � �����.
�� �쳺�� ������� ����� ����� ������� ���� � ���������� ��.
���� ������ ����� ������� �����, ��� �� ������ �� ���������.
��� ���� ����� � �������� �� � ������ �����,
���� �� �쳺�� � ������ � ���,
� �������� ������� ����������.");
            conclMass[2] = new Conclusion(24, 30, @"��� ������� ������ �'� ����� ����.
���������� ��� ��� ����� � �� �������,
� �� �� ��� ������ ����������� � ��������
�������� ����� �������. ����� �����������:
�� �� ���� ���������� ���� �������?
�� ���������, �� ���������� ��������� ������� ������
���� ��������� ��� ��������� � ������������ ������������.");
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
        /// �������� ��� �� �������� �������.
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
            questions[0] = new Question(@"�� ������ ������������?", false, 2, new variant("���", 1), new variant("�", 0));
            questions[1] = new Question(@"������� � ��� �� ������ ���������
��� ����, �� �� ��� �쳺��?", false, 2, new variant("���", 1), new variant("�", 0));
            questions[2] = new Question(@"�� ����� �������� �������,
�����������?", false, 2, new variant("���", 0), new variant("�", 1));
            questions[3] = new Question(@"�� ���������� ��� ������ � ����
� �������� ������?", false, 2, new variant("���", 1), new variant("�", 0));
            questions[4] = new Question(@"�� ����� ��� ������� �����������
����������, �� �����������?", false, 2, new variant("���", 0), new variant("�", 1));
            questions[5] = new Question(@"�� �� ������� ���, �� ���� ��������
����� �������� � ���� ������� �� ��?", false, 2, new variant("���", 0), new variant("�", 1));
            questions[6] = new Question(@"�� ����������� � ������ ���� ����
������ ���������� ��������?", false, 2, new variant("���", 1), new variant("�", 0));
            questions[7] = new Question(@"�� ������� ��, �� ���� ������������� �� ���?", false, 2, new variant("���", 0), new variant("�", 1));
            questions[8] = new Question(@"�� ����� ��� ������� ��������� ����������?", false, 2, new variant("���", 0), new variant("�", 1));
            questions[9] = new Question(@"�� ����� ��, �� �������� ������� �������
����� �������, �� �����? ", false, 2, new variant("���", 0), new variant("�", 1));
            questions[10] = new Question(@"�� ����� �� ������� ���� �������?", false, 2, new variant("���", 1), new variant("�", 0));
            questions[11] = new Question(@"�� ������������ ��� �����?", false, 2, new variant("���", 0), new variant("�", 1));
            questions[12] = new Question(@"���������� � �� �� ������ � ���� ����,
���� ��� ��� ������������� ������ ������?", false, 2, new variant("���", 1), new variant("�", 0));
            questions[13] = new Question(@"�� ��������� �� ���� ���������?", false, 2, new variant("���", 1), new variant("�", 0));
            questions[14] = new Question(@"�� ����� ��� �������� ����������?", false, 2, new variant("���", 1), new variant("�", 0));
            questions[15] = new Question(@"�� ����� ��� �������� � ����������� �������, ������ ��� ���� � ������ ��������?", false, 2, new variant("���", 1), new variant("�", 0));
            questions[16] = new Question(@"�� �������� ��� �������� ���������,
������� �������?", false, 2, new variant("���", 1), new variant("�", 0));
            questions[17] = new Question(@"�� ����� �� � ������������ ������?", false, 2, new variant("���", 1), new variant("�", 0));
            questions[18] = new Question(@"�� ������� ��� ��� ������� ����
�������� - ������ �����, ���� �� �����?", false, 2, new variant("���", 1), new variant("�", 0));
            questions[19] = new Question(@"�� ����� �� � ��,
�� ����� - ��� ������ ����� �����?", false, 2, new variant("���", 1), new variant("�", 0));            
            
            //from optimist2

            questions[20] = new Question(@"�� ����� �� ��������, �� � ���� ������?", false, 2,
                                new variant("���", 0),
                                new variant("�", 1));

            questions[21] = new Question(@"�� ���������� ��� ����-������
����������� � ��������, �� �� ������ ���?", false, 2,
                                new variant("���", 0),
                                new variant("�", 1));

            questions[22] = new Question(@"�� �������, �� ������� ����� �����?", false, 2,
                                new variant("���", 1),
                                new variant("�", 0));

            questions[23] = new Question(@"�� ������� ��, �� ����� ������� ���������,
���� ���� ������� ���� ������?", false, 2,
                                new variant("���", 1),
                                new variant("�", 0));

            questions[24] = new Question(@"�� ���������� ��� �������� ����
�������� ������� ��� �������� �������?", false, 2,
                                new variant("���", 1),
                                new variant("�", 0));

            questions[25] = new Question(@"��� ������� ������� �����������?", false, 2,
                                new variant("���", 1),
                                new variant("�", 0));

            questions[26] = new Question(@"�� �� ������� ���, �� �����
������ ���������?", false, 2,
                                new variant("���", 1),
                                new variant("�", 0));

            questions[27] = new Question(@"�� ������ ��, �� ��� ����� ����?", false, 2,
                                new variant("���", 1),
                                new variant("�", 0));

            questions[28] = new Question(@"�� ������ ��� ����� ���?", false, 2,
                                new variant("���", 1),
                                new variant("�", 0));

            questions[29] = new Question(@"�� ������� ��, �� ����
������������� �� ���? ", false, 2,
                                new variant("���", 1),
                                new variant("�", 0));

            questions[30] = new Question(@"�� ��������� ��� ���� �����,
�� � ����, ���� �� �����?", false, 2,
                                new variant("���", 0),
                                new variant("�", 1));

            questions[31] = new Question(@"�� �������, ������ ����� �
���� ����� ���������?", false, 2,
                                new variant("���", 0),
                                new variant("�", 1));

            questions[32] = new Question(@"�� ������ �� ���������� �
���� ���� �������?", false, 2,
                                new variant("���", 1),
                                new variant("�", 0));

            questions[33] = new Question(@"�� ������� ��, �� ���� �����
��������, �������� �����, ������ ������?", false, 2,
                                new variant("���", 1),
                                new variant("�", 0));

            questions[34] = new Question(@"�� ������ ��� ��������� �������?", false, 2,
                                new variant("���", 1),
                                new variant("�", 0));

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
