/* Written by arch
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.IO;

namespace Common
{
    /// <summary>
    /// Визначає інформацію про модуль
    /// </summary>
    [global::System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ModuleInfoAttribute : Attribute
    {
        readonly string moduleName;
        private string helpFileName;
        private Dictionary<string, string> dictLang = new Dictionary<string,string>();
        private string _resourceName = "Resources";
        private const string _helpFileResources = "ModuleHelp";

        public string ResourceName
        {
            get { return _resourceName; }
            set { _resourceName = value; }
        }

        [Obsolete("This property is obsolete. Use HelpFileContent instead")]
        public string HelpFileName
        {
            get { return helpFileName; }
            set { helpFileName = value; }
        }

        public ModuleInfoAttribute(string moduleName)
        {
            this.moduleName = moduleName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="langAr">содержит строки вида '[имя культуры]::[название на соответствующем языке]'</param>
        public ModuleInfoAttribute(string[] langAr)
        {
            this.moduleName = langAr[0].Split(new string[] { "::" }, StringSplitOptions.None)[1];

            foreach (string s in langAr)
            {
                string[] spl = s.Split(new string[] { "::" }, StringSplitOptions.None);
                dictLang.Add(spl[0], spl[1]);
            }
        }
        public UnmanagedMemoryStream HelpFileContent
        {
            get
            {
                ResourceManager man = new ResourceManager(_resourceName, Assembly.GetExecutingAssembly());
                return man.GetStream(_helpFileResources);
                //Assembly.GetExecutingAssembly()
            }
        }
        /// <summary>
        /// Ім'я модуля
        /// </summary>
        public string ModuleName
        {
            get
            {
                try
                {
                    return dictLang[CultureInfo.CurrentUICulture.Name];
                }
                catch
                {
                    return moduleName;
                }                
            }
        }
    }
}