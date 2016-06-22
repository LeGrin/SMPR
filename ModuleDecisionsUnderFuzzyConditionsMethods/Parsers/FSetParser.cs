using System;
using System.Collections.Generic;
using System.Text;
using FuzzySets;

namespace FuzzySetFParser
{
    class SynError : Exception 
    {
        public SynError(string text) : base(text)
        {
        }
    }

    class SemError : Exception
    {
        public SemError(string text)
            : base(text)
        {
        }
    }

    class Token{
        public const int EOF     = 0000;
        public const int IDN     = 1000;
        public const int ASSING  = 1001;
        public const int UNION   = 1002;
        public const int SUB     = 1003;
        public const int INTRS   = 1004;
        public const int MULT    = 1005;
        public const int COMPOS  = 1006;
        public const int OP      = 1007;
        public const int CP      = 1008;
        public const int ERR     = 1100;


        private int tType;
        private string text;
        private int pos;

        public int Type     { get { return tType; } }
        public string Text  { 
            get {
                if (tType == 0) return "кінець виразу";
                return text; 
            } 
        }
        public int Pos      { get { return pos; } }

        public Token(int tType_, string text_, int pos_){
            tType = tType_;
            text  = text_;
            pos   = pos_;
        }
        public Token()
        {
            tType = 0;
            text = "";
            pos = 0;
        }
    }

    class FSetParser
    {
        private string s;
        private int pos;
        private Token cTk;
        private bool resultOK = false;
        private string errText;
        private FuzzySet result;
        private string outName;
        public string ErrText { get { return errText; } }
        public bool ResultOK { get { return resultOK; } }
        public FuzzySet Result { get { return result; } }

        private Stack<FuzzySet> stack = new Stack<FuzzySet>();
        private List<FuzzySet> sets;
        public List<FuzzySet> Sets { get { return sets; } set { sets = value; } }

        public FuzzySet FindSet(string name){
            foreach (FuzzySet set in sets){
                if (set.Name.ToUpper() == name.ToUpper()) return set;
            }
            return null;
        }

        public FSetParser(string s_, List<FuzzySet> sets_){
            s = s_;
            sets = sets_;
            pos = 0;
        }

        private string GetIDN(){
            string res = "";
            res += s[pos++];
            while (pos < s.Length && Char.IsLetterOrDigit(s[pos])) res += s[pos++];
            return res;
        }

        public Token GetToken_(){
            while (pos < s.Length && (s[pos] == '\t' || s[pos] == '\r' || s[pos] == '\n' || s[pos] == ' ')) pos++;
            if (pos >= s.Length) return new Token();
            int ppos = pos;
            string text = "";

            if (Char.IsLetter(s[pos]))
            {
                ppos = pos;
                text = GetIDN();
                switch (text.ToUpper())
                {
                    case "UNION": return new Token(Token.UNION, text, ppos);
                    case "SUB":
                    case "SUBSTRACTION":
                    case "SUBSTRACT": return new Token(Token.SUB, text, ppos);
                    case "INTRS":
                    case "INTERSECT":
                    case "INTERSECTION": return new Token(Token.UNION, text, ppos);
                    case "MUL":
                    case "MULT":
                    case "MULTIPLY": return new Token(Token.MULT, text, ppos);
                    case "COMPOSITION": return new Token(Token.COMPOS, text, ppos);
                    default: return new Token(Token.IDN, text, ppos);
                }
            }

            text = LookAhead(1);
            if (text.Length == 0) return new Token();
            switch (text){
                case "="  : pos++; return new Token(Token.ASSING, text, ppos);
                case "|"  : pos++; return new Token(Token.UNION, text, ppos);
                case "\\" : 
                case "-"  : pos++; return new Token(Token.SUB, text, ppos);
                case "&"  : pos++; return new Token(Token.INTRS, text, ppos);
                case "*"  : pos++; return new Token(Token.MULT, text, ppos);
                case "@"  : pos++; return new Token(Token.COMPOS, text, ppos);
                case "("  : pos++; return new Token(Token.OP, text, ppos);
                case ")"  : pos++; return new Token(Token.CP, text, ppos);
                default   : pos++; return new Token(Token.ERR, text, ppos);
            }
        }

        public void GetToken(){
            cTk = GetToken_();
        }

        private string LookAhead(int cnt){
            return s.Substring(pos, Math.Min(cnt, s.Length - pos));
        }

        private void A(){
            Token t1 = GetToken_();
            Token t2 = GetToken_();
            if (t1.Type == Token.IDN && t2.Type == Token.ASSING){
                outName = t1.Text;
                GetToken();
                B();
            } else{
                pos = 0;
                GetToken();
                B();
            }
        }

        private void B(){
            C();
            if (cTk.Type != Token.UNION) return;
            GetToken();
            B();
            {
                FuzzySet s1 = stack.Pop();
                FuzzySet s2 = stack.Pop();
                if (s1.GetType().ToString() != s2.GetType().ToString()) throw new SemError("Об'єднання множин різних розмірностей невизначене!");
                if (s1 is FuzzySet1D ){
                    if (s1.Discrete == s2.Discrete)
                        stack.Push((s1 as FuzzySet1D) | (s2 as FuzzySet1D));
                    else if (s1.Discrete){
                        s1.Discrete = false;
                        stack.Push((s1 as FuzzySet1D) | (s2 as FuzzySet1D));
                    }
                    else {
                        s2.Discrete = false;
                        stack.Push((s1 as FuzzySet1D) | (s2 as FuzzySet1D));
                    }
                }
                if (s1 is FuzzySet2D)
                {
                    if (s1.Discrete == s2.Discrete)
                        stack.Push((s1 as FuzzySet2D) | (s2 as FuzzySet2D));
                    else if (s1.Discrete)
                    {
                        s1.Discrete = false;
                        stack.Push((s1 as FuzzySet2D) | (s2 as FuzzySet2D));
                    }
                    else
                    {
                        s2.Discrete = false;
                        stack.Push((s1 as FuzzySet2D) | (s2 as FuzzySet2D));
                    }
                }
            }
        }

        private void C()
        {
            D();
            Z();
        }

        private void Z(){
            if (cTk.Type != Token.SUB) return;
            GetToken();
            D();
            {
                FuzzySet s2 = stack.Pop();
                FuzzySet s1 = stack.Pop();
                if (s1.GetType().ToString() != s2.GetType().ToString()) throw new SemError("Різниця множин різних розмірностей невизначена!");
                if (s1 is FuzzySet1D)
                {
                    if (s1.Discrete == s2.Discrete)
                        stack.Push((s1 as FuzzySet1D) / (s2 as FuzzySet1D));
                    else if (s1.Discrete)
                    {
                        s1.Discrete = false;
                        stack.Push((s1 as FuzzySet1D) / (s2 as FuzzySet1D));
                    }
                    else
                    {
                        s2.Discrete = false;
                        stack.Push((s1 as FuzzySet1D) / (s2 as FuzzySet1D));
                    }
                }
                if (s1 is FuzzySet2D)
                {
                    if (s1.Discrete == s2.Discrete)
                        stack.Push((s1 as FuzzySet2D) / (s2 as FuzzySet2D));
                    else if (s1.Discrete)
                    {
                        s1.Discrete = false;
                        stack.Push((s1 as FuzzySet2D) / (s2 as FuzzySet2D));
                    }
                    else
                    {
                        s2.Discrete = false;
                        stack.Push((s1 as FuzzySet2D) / (s2 as FuzzySet2D));
                    }
                }
            }
            Z();
        }

        private void D()
        {
            E();
            if (cTk.Type != Token.INTRS) return;
            GetToken();
            D();
            {
                FuzzySet s1 = stack.Pop();
                FuzzySet s2 = stack.Pop();
                if (s1.GetType().ToString() != s2.GetType().ToString()) throw new SemError("Об'єднання множин різних розмірностей невизначене!");
                if (s1 is FuzzySet1D)
                {
                    if (s1.Discrete == s2.Discrete)
                        stack.Push((s1 as FuzzySet1D) & (s2 as FuzzySet1D));
                    else if (s1.Discrete)
                    {
                        s1.Discrete = false;
                        stack.Push((s1 as FuzzySet1D) & (s2 as FuzzySet1D));
                    }
                    else
                    {
                        s2.Discrete = false;
                        stack.Push((s1 as FuzzySet1D) & (s2 as FuzzySet1D));
                    }
                }
                if (s1 is FuzzySet2D)
                {
                    if (s1.Discrete == s2.Discrete)
                        stack.Push((s1 as FuzzySet2D) & (s2 as FuzzySet2D));
                    else if (s1.Discrete)
                    {
                        s1.Discrete = false;
                        stack.Push((s1 as FuzzySet2D) & (s2 as FuzzySet2D));
                    }
                    else
                    {
                        s2.Discrete = false;
                        stack.Push((s1 as FuzzySet2D) & (s2 as FuzzySet2D));
                    }
                }
            }
        }

        private void E()
        {
            F(); 
            Y();
        }

        private void Y(){
            if (cTk.Type != Token.MULT && cTk.Type != Token.COMPOS) return;
            int tType = cTk.Type;
            GetToken();
            F();
            if (tType == Token.MULT)
            {
                FuzzySet1D s1 = stack.Pop() as FuzzySet1D;
                FuzzySet1D s2 = stack.Pop() as FuzzySet1D;
                if (s1 == null || s2 == null ) throw new SemError("Декартів добуток для двовимірних нечітких множин не визначено");
                FuzzySet2D res = s1 * s2;
                if (res != null) stack.Push(s1 * s2);
                else throw new SemError("Помилка при декартовому добутку");
            }
            if (tType == Token.COMPOS)
            {
                FuzzySet2D s1 = stack.Pop() as FuzzySet2D;
                FuzzySet2D s2 = stack.Pop() as FuzzySet2D;
                if (s1 == null || s2 == null) throw new SemError("Композиція визначена тільки для двовимірних множин");
                stack.Push(FuzzySet2D.MaxMinCompose(s1, s2));
            }
            Y();
        }

        private void F()
        {
            if (cTk.Type == Token.IDN){
                FuzzySet set = FindSet(cTk.Text);
                if (set == null) throw new SemError("Множини '"+cTk.Text+"' не існує");
                if (set is FuzzySet1D) stack.Push(new FuzzySet1D(set as FuzzySet1D));
                if (set is FuzzySet2D) stack.Push(new FuzzySet2D(set as FuzzySet2D));
                GetToken();
                return;
            }
            if (cTk.Type == Token.OP){
                GetToken();
                B();
                if (cTk.Type != Token.CP) throw new SynError("Очікувалась дужка, що закривається, а знайдено '" + cTk.Text + '"');
                GetToken();
                return;
            }
            throw new SynError("Очікувався ідентифікатор множини чи вираз, а знайдено '"+cTk.Text+"'");
        }

        public void Eval(){
            pos = 0;
            outName = "Res";
            stack.Clear();
            try{
                A();
                if (cTk.Type != Token.EOF) throw new SynError("Неочікуваний символ: '" + cTk.Text + "'");
                if (stack.Count != 1) throw new SemError("Семантична помилка");
                result = stack.Pop();
                if (result != null) result.Name = outName;
            } catch(Exception e){
                errText = e.Message;
                resultOK = false;
                return;
            }
            resultOK = true;
        }

    }
}
