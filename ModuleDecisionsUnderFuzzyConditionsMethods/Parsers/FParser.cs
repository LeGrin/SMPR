using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaParser
{

    class FPException : Exception
    {
        private bool semanticException = true;
        public bool IsSemantic {
            get { return semanticException; }
        }
        public FPException(string text, bool isSemantic): base(text)
        {
            semanticException = isSemantic;
        }
        public FPException(string text): base(text)
        {
            semanticException = true;
        }
    }
    /// <summary>
    /// Real-value formula parser
    /// Copyright Kerghan (c) 2008
    /// </summary>
    /// <grammar>
    /// A->BZ
    /// B->CY
    /// C->DX
    /// Z->+BZ|-BZ|eps
    /// Y->*CY|/CY|eps
    /// X->^DX|eps
    /// D->sin(A)|cos(A)|...|(A)|+D|-D|X|Y|real_number
    /// </grammar>
    class FParser
    {
        private Stack<double> stack = new Stack<double>();
        private String s;
        private int pstr;
        private int synError;
        private double x;
        private double y;
        private double res;
        private string errText;
        private Char cc;
        private Char Getch(){
            if (pstr < s.Length) return cc = s[pstr++];
            else return cc = '\0';//throw new Exception("end of string");
        }

        public string ErrText{
            get { return errText; }
        }

        private void Z(){
            if (cc == '+'){
                Getch();
                B();
                double q = stack.Pop();
                double p = stack.Pop();
                stack.Push(p + q);
                Z();
            }
            if (cc == '-'){
                Getch();
                B();
                double q = stack.Pop();
                double p = stack.Pop();
                stack.Push(p - q);
                Z();
            }
        }

        private void Y(){
            if (cc == '*'){
                Getch();
                C();
                double q = stack.Pop();
                double p = stack.Pop();
                stack.Push(p*q);
                Y();
            }
            if (cc == '/'){
                Getch();
                C();
                double q = stack.Pop();
                double p = stack.Pop();
                stack.Push(p/q);
                Y();
            }
        }

        private void X(){
            if (cc == '^'){
                Getch();
                D();
                double q = stack.Pop();
                double p = stack.Pop();
                stack.Push(Math.Pow(p,q));
                X();
            }
        }

        private void D(){
            String ss = "";

            #region 2l-tokens
            if (s.Length - pstr + 1 >= 2) ss = s.Substring(pstr-1, 2);
            if (ss == "PI"){
                stack.Push(Math.PI);
            }
            #endregion

            #region 3l-tokens
            if (s.Length - pstr + 1 >= 3) ss = s.Substring(pstr - 1, 3);
            if (ss == "TG(" || ss == "LG(" || ss == "LN("){
                Getch(); Getch(); Getch(); // =D
                A();
                switch (ss){
                    case "TG(": stack.Push(Math.Tan(stack.Pop())); break;
                    case "LG(": stack.Push(Math.Log10(stack.Pop())); break;
                    case "LN(": stack.Push(Math.Log(stack.Pop())); break;
                }
                if (cc == ')'){
                    Getch();
                    return;
                }
                else throw new FPException("Очікувалась дужка, що закривається!", false);
            }
            #endregion

            #region 4l-tokens
            if (s.Length - pstr + 1 >= 4) ss = s.Substring(pstr - 1, 4);
            if (ss == "SQR(" || ss == "SIN(" || ss == "COS(" || ss == "CTG(" || ss == "EXP(" || ss == "ABS(" || ss == "TGH(")
            {
                Getch(); Getch(); Getch(); Getch(); // =D
                A();
                switch (ss)
                {
                    case "SQR(": stack.Push(Math.Pow(stack.Pop(),2)); break;
                    case "SIN(": stack.Push(Math.Sin(stack.Pop())); break;
                    case "COS(": stack.Push(Math.Cos(stack.Pop())); break;
                    case "CTG(": stack.Push(1/Math.Tan(stack.Pop())); break;
                    case "EXP(": stack.Push(Math.Exp(stack.Pop())); break;
                    case "ABS(": stack.Push(Math.Abs(stack.Pop())); break;
                    case "TGH(": stack.Push(Math.Tanh(stack.Pop())); break;
                }
                if (cc == ')')
                {
                    Getch();
                    return;
                }
                else throw new FPException("Очікувалась дужка, що закривається!", false);
            }
            #endregion

            #region 5l tokens
            if (s.Length - pstr + 1 >= 5) ss = s.Substring(pstr - 1, 5);
            if (ss == "SQRT(" || ss == "SINH(" || ss == "COSH(" || ss == "CTGH(")
            {
                Getch(); Getch(); Getch(); Getch(); Getch(); // =D
                A();
                switch (ss)
                {
                    case "SQRT(": stack.Push(Math.Sqrt(stack.Pop())); break;
                    case "SINH(": stack.Push(Math.Sinh(stack.Pop())); break;
                    case "COSH(": stack.Push(Math.Cosh(stack.Pop())); break;
                    case "CTGH(": stack.Push(1/Math.Tanh(stack.Pop())); break;
                }
                if (cc == ')')
                {
                    Getch();
                    return;
                }
                else throw new FPException("Очікувалась дужка, що закривається!", false);
            }
            #endregion

            #region 6l tokens
            if (s.Length - pstr + 1 >= 6) ss = s.Substring(pstr - 1, 6);
            if (ss == "ARCTG(")
            {
                Getch(); Getch(); Getch(); Getch(); Getch(); Getch(); // =D
                A();
                switch (ss)
                {
                    case "ARCTG(": stack.Push(Math.Sqrt(stack.Pop())); break;
                }
                if (cc == ')')
                {
                    Getch();
                    return;
                }
                else throw new FPException("Очікувалась дужка, що закривається!", false);
            }
            #endregion

            #region 7l-tokens
            if (s.Length - pstr + 1 >= 7) ss = s.Substring(pstr - 1, 7);
            if (ss == "ARCCTG(" || ss == "ARCSIN(" || ss == "ARCCOS(")
            {
                Getch(); Getch(); Getch(); Getch(); Getch(); Getch(); Getch(); // =D
                A();
                switch (ss)
                {
                    case "ARCCTG(": 
                        double q = stack.Pop();
                        if (q > 0) stack.Push(Math.Atan(1/q));
                        else stack.Push(Math.PI + Math.Atan(1/q)); break;
                    case "ARCSIN(": stack.Push(Math.Asin(stack.Pop())); break;
                    case "ARCCOS(": stack.Push(Math.Acos(stack.Pop())); break;
                }
                if (cc == ')')
                {
                    Getch();
                    return;
                }
                else throw new FPException("Очікувалась дужка, що закривається!", false);
            }
            #endregion

            #region unary +- and parentheses
            if (cc == '-'){
                Getch();
                D();
                stack.Push(-stack.Pop());
                return;
            }
            if (cc == '+')
            {
                Getch();
                D();
                stack.Push(stack.Pop());
                return;
            }
            if (cc == '('){
                Getch();
                A();
                if (cc == ')')
                {
                    Getch();
                    return;
                }
                else throw new FPException("Очікувалась дужка, що закривається!", false);
            }
            #endregion

            #region base tokens
            if (Char.IsDigit(cc))
            {
                stack.Push(getd());
                return;
            }
            if (cc == 'X'){
                Getch();
                stack.Push(x);
                return;
            }
            if (cc == 'Y')
            {
                Getch();
                stack.Push(y);
                return;
            }
            #endregion

            throw new FPException("Очікувалась змінна чи число!", false);
        }

        private double getd(){
            String ss = cc.ToString();
            while (true){
                Getch();
                if ((cc == '-' || cc == '+') && !((ss.Length > 0)&&(ss[ss.Length-1] == 'E'))) break;
                if (Char.IsDigit(cc) || cc == '-' || cc == '+' || cc == ',' || cc == '.' || cc == 'E') ss += cc;
                else break;
            }
            return Convert.ToDouble(ss);
        }

        private void C(){
            D(); X();
        }
        private void B(){
            C(); Y();
        }
        private void A(){
            B(); Z();
        }

        public bool SyntaxCorrect
        {
            get { return synError != 1; }
        }

        public void Eval(String s, double x) { Eval(s, x, 0); }
        public void Eval(String s, double x, double y){
            stack.Clear();
            pstr = 0;
            synError = 1;
            res = 0;
            this.x = x;
            this.y = y;
            this.s = s.ToUpper();

            try{
                Getch();
                A();
                if (stack.Count != 1 || pstr != s.Length) throw new FPException("Некоректний синтаксис!", false);
                res = stack.Pop();
                synError = 0;
            }
            catch(FPException e){
                if (!e.IsSemantic) synError = 1;
                else synError = 0;
                errText = e.Message;
                res = 0;
            }
            catch(Exception e){
                synError = 0;
                errText = e.Message;
                res = 0;
            }
        }

        public int ErrCode{
            get{
                return synError;
            }
        }

        public double Result(){
            if ((synError == 0) && res >= 0 && res <= 1) return res;
            if ((synError == 0) && res < 0) return 0;
            if ((synError == 0) && res > 1) return 1;
            return 0;
        }

    }
}
