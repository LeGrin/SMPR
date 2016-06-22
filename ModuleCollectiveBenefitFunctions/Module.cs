using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common;
using Common.DataTypes;

namespace Modules.CollectiveBenefitFunctions
{
    [ModuleInfoAttribute(new string[] { "uk-UA::Функції колективної корисності", "ru-RU::Функции колективной полезности", "en-US::Collective Benefit Functions", "zh::集体的效用函数" })]// "Функції колективної корисності")]
    [Common.About("Галкін Олександр Анатолійович", Group = "ТК-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos))]
    public class Module : Common.ModuleAbstractEx<Method>
    {
        frmModule form;
        Method currentMethod;
        
        private Scalar<double>[] m_Result;

        public class CollectiveBenefitFunctionsCloseEventArgs : CloseEventArgs
        {
        }

        public Module()
        {
          
        }

        public Module(Method method)
        {
            currentMethod = method;
        }

        private void RunMethod()
        {
            if (form.HasData())
            {
                Method method = form.GetMethod();
                try
                {
                    method.Init(form.GetData());
                    m_Result = method.DoCalculate();
                    form.ShowResult(m_Result);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Невірно введені данні!!!", "Помилка формату!!!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DivideByZeroException)
                {
                    MessageBox.Show("Спроба ділення на нуль!!!", "Помилка Обчислення!!!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Метод обчислення не вибраний!!!", "Помилка вибору методу!!!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Не всі данні введені!!!", "Помилка вводу!!!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public override void Show(Form MdiParent)
        {
            form = new frmModule(Methods, currentMethod);
            form.Text = Name;
            if (MdiParent!=null && MdiParent.IsMdiContainer)
                form.MdiParent = MdiParent;
            form.Show();
            form.FormClosed += form_FormClosed;
            form.DataCalculate += delegate { RunMethod(); };
            form.DataLoad += _loadVector;
            form.DataSave += _saveVector;
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            LastResult = new CollectiveBenefitFunctionsCloseEventArgs();
            OnClose(LastResult);
        }

        public override CloseEventArgs ShowDialog()
        {
            form = new frmModule(Methods, currentMethod);
            form.DataCalculate += delegate { RunMethod(); };
            form.DataLoad += _loadVector;
            form.DataSave += _saveVector;
            form.ShowDialog();
            return LastResult;
        }

        /// <summary>
        /// Зберігає вектор
        /// </summary>        
        private void _saveVector(Vector<int> vector1, Vector<int> vector2)
        {
            Common.DataBuffer.Instance.SaveDialog(vector1);
            if (vector2 != null)
                Common.DataBuffer.Instance.SaveDialog(vector2);
        }

        /// <summary>
        /// Завантажує вектор
        /// </summary>
        private void _loadVector()
        {
            Vector<int> vector1 = (Vector<int>)Common.DataBuffer.Instance.LoadDialog(_validateData);
            Vector<int> vector2 = null;
            if (form.GetPigu())
                vector2 = (Vector<int>)Common.DataBuffer.Instance.LoadDialog(_validateData);
            if (vector1 != null && vector2 == null || vector1 != null && vector2 != null && form.GetPigu())
                form.SetData(vector1, vector2);
        }

        /// <summary>
        /// Перевірка даних, що зберігаються/завантажуються.
        /// </summary>
        /// <param name="data">Дані</param>        
        private bool _validateData(Common.DataTypes.BufferData data)
        {
            return data is Vector<int>;
        }

        protected override void OnClose(CloseEventArgs args)
        {
            //              Buffer.Instance.Save("Останні результати модуля " + this.GetType().Name, args.result);
            base.OnClose(args);
        }
  
    }
}