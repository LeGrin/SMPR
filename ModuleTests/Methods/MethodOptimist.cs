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
            switch (Thread.CurrentThread.CurrentUICulture.Name)
            {
                case "uk-UA":
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
                    break;
                case "ru-RU": questions[0] = new Question(@"������ �� �� ��������������?", false, 2, new variant("��", 1), new variant("���", 0));
                    questions[1] = new Question(@"�������� �� ��� ��� ����-�� ���������
����� ����, ��� �� ��� ������?", false, 2, new variant("��", 1), new variant("���", 0));
                    questions[2] = new Question(@"�� ����� ���������� ����������,
��������������?", false, 2, new variant("��", 0), new variant("���", 1));
                    questions[3] = new Question(@"�������� �� ��� ������ � �����
� ��������� ������?", false, 2, new variant("��", 1), new variant("���", 0));
                    questions[4] = new Question(@"����� �� ��� ������� �����������
������������ �������������?", false, 2, new variant("��", 0), new variant("���", 1));
                    questions[5] = new Question(@"�� ������� �� ���, ��� ���� ��������
������ �������� � ����� �������� ��� ��?", false, 2, new variant("��", 0), new variant("���", 1));
                    questions[6] = new Question(@"��������� � ����� ����� �����
����� ���� ���������� ��������?", false, 2, new variant("��", 1), new variant("���", 0));
                    questions[7] = new Question(@"�������� �� ��, ��� ������ ������������� � ���?", false, 2, new variant("��", 0), new variant("���", 1));
                    questions[8] = new Question(@"��������� �� ��� �������� ������������� ����������?", false, 2, new variant("��", 0), new variant("���", 1));
                    questions[9] = new Question(@"�������� �� ��, ��� ������� �������� 
������� ������ �������, ��� ������? ", false, 2, new variant("��", 0), new variant("���", 1));
                    questions[10] = new Question(@"������ �� ������� ���� ���������?", false, 2, new variant("��", 1), new variant("���", 0));
                    questions[11] = new Question(@"�� ������������ ���� ���������?", false, 2, new variant("��", 0), new variant("���", 1));
                    questions[12] = new Question(@"����������� �� �� �� ������� � ������ �����,
���� �� ��� ��� ���������� ���������� ������?", false, 2, new variant("��", 1), new variant("���", 0));
                    questions[13] = new Question(@"�������� �� �� ����� ����������?", false, 2, new variant("��", 1), new variant("���", 0));
                    questions[14] = new Question(@"����� �� ��� ��������� �����������?", false, 2, new variant("��", 1), new variant("���", 0));
                    questions[15] = new Question(@"����� �� ��� ��������� � ���������� ���������,
����� ���� ����� � ����� ����������?", false, 2, new variant("��", 1), new variant("���", 0));
                    questions[16] = new Question(@"������� ��� ���������� ����������,
���������� ���������?", false, 2, new variant("��", 1), new variant("���", 0));
                    questions[17] = new Question(@"������ �� �� � ������������ ������?", false, 2, new variant("��", 1), new variant("���", 0));
                    questions[18] = new Question(@"���������� �� ��� ��� ������ ������
������� - �������� �����, ������� ��� ������?", false, 2, new variant("��", 1), new variant("���", 0));
                    questions[19] = new Question(@"������ �� �� � ��,
��� ������ - ��� ������ ������ �������?", false, 2, new variant("��", 1), new variant("���", 0));

                    //from optimist2

                    questions[20] = new Question(@"�� ����� �� ����������, ��� � ���� ��������?", false, 2,
                                        new variant("��", 0),
                                        new variant("���", 1));

                    questions[21] = new Question(@"����������� �� ��� �����-������
����������� � ���������, ��� �� ������ ���?", false, 2,
                                        new variant("��", 0),
                                        new variant("���", 1));

                    questions[22] = new Question(@"�� ��������, ��� ����� ������ ������?", false, 2,
                                        new variant("��", 1),
                                        new variant("���", 0));

                    questions[23] = new Question(@"�������� �� ��, ��� ����� ��������� �������,
����� ��� ����� ���� �����?", false, 2,
                                        new variant("��", 1),
                                        new variant("���", 0));

                    questions[24] = new Question(@"��������� �� ��� ����������� ����
���������� ��������� ��� ������ �������?", false, 2,
                                        new variant("��", 1),
                                        new variant("���", 0));

                    questions[25] = new Question(@"��� ������� ������� �������������?", false, 2,
                                        new variant("��", 1),
                                        new variant("���", 0));

                    questions[26] = new Question(@"�� ������� �� ���, ��� �����
������ ���������?", false, 2,
                                        new variant("��", 1),
                                        new variant("���", 0));

                    questions[27] = new Question(@"������� �� ��, ��� ��� ������� ���������?", false, 2,
                                        new variant("��", 1),
                                        new variant("���", 0));

                    questions[28] = new Question(@"������ ��� ���������� ���?", false, 2,
                                        new variant("��", 1),
                                        new variant("���", 0));

                    questions[29] = new Question(@"�������� �� ��, ��� ������
������������� � ���? ", false, 2,
                                        new variant("��", 1),
                                        new variant("���", 0));

                    questions[30] = new Question(@"�� ���������� ��� �� �����,
��� � ����, ������� �� ������?", false, 2,
                                        new variant("��", 0),
                                        new variant("���", 1));

                    questions[31] = new Question(@"�� ��������, ������ ����� �
���� ������������� �������?", false, 2,
                                        new variant("��", 0),
                                        new variant("���", 1));

                    questions[32] = new Question(@"������ �� �� ���������� �
��������� ������ ������?", false, 2,
                                        new variant("��", 1),
                                        new variant("���", 0));

                    questions[33] = new Question(@"�������� �� ��, ��� ���� �����
��������, ������� �������, ������� ������?", false, 2,
                                        new variant("��", 1),
                                        new variant("���", 0));

                    questions[34] = new Question(@"������ ��� ���������� �������?", false, 2,
                                        new variant("��", 1),
                                        new variant("���", 0));
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
