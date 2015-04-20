using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Resources;

namespace Common
{
    /// <summary>
    /// ����������� ����, �� ����������� �����
    /// </summary>
    public abstract class MethodAbstract
    {
        private const string _helpFileName = "HelpMethod_";
        /// <summary>
        /// ��� ������
        /// </summary>
        public abstract String Name { get; }

        public override string ToString()
        {
            return Name;
        }
        private string _helpFileString;
        public string HelpFileString
        {
            get
            {

                try
                {
                    if (_helpFileString == null)
                    {
                        ResourceManager manager = new ResourceManager(
                            this.GetType().Namespace.Replace(".Methods", "") + ".Properties.Resources", this.GetType().Assembly);
                        _helpFileString = manager.GetString("MethodHelp_" + this.GetType().Name);
                    }
                }
                catch
                {
                    _helpFileString = null;
                }
                return _helpFileString;
            }
        }     
    }
}
