/* Written by arch
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.Resources;
using System.Drawing;

namespace Common
{
    /// <summary>
    /// Incapsulates module information
    /// </summary>
    public class ModuleInfo
    {
        private const string _resourceName = "Resources";
        private const string _helpFileResources = "ModuleHelp";
        private const string _helpUIFileResources = "ModuleUIHelp";
        protected static Dictionary<string, ModuleInfo> registry = new Dictionary<string, ModuleInfo>();

        public static bool CultureChanged = false;

        public static ModuleInfo GetModuleInfo(Type moduleType)
        {
            ModuleInfo res;
            if (!registry.TryGetValue(moduleType.FullName, out res))
            {
                res = new ModuleInfo(moduleType);
                registry.Add(moduleType.FullName, res);
            }

            return res;
        }

        public static ModuleInfo GetModuleInfo(ModuleAbstract module)
        {
            return GetModuleInfo(module.GetType());
        }

        protected static List<ModuleInfo> modules;

        public static List<ModuleInfo> Modules
        {
            get
            {
                if (ModuleInfo.modules == null)
                {
                    ModuleInfo.modules = new List<ModuleInfo>();
                    string dir = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                    string[] files = System.IO.Directory.GetFiles(dir, "*.dll");


                    foreach (string file in files)
                    {
                        try
                        {
                            Type[] types = Assembly.LoadFile(file).GetExportedTypes();
                            Type parent = typeof(Common.ModuleAbstract);
                            foreach (Type type in types)
                                if (type.IsSubclassOf(parent) && !type.Equals(parent)
                                    && type.Namespace.Contains("Modules"))
                                    modules.Add(ModuleInfo.GetModuleInfo(type));
                        }
                        catch (BadImageFormatException)
                        {
                        }
                    }

                    modules.Sort(delegate(ModuleInfo a, ModuleInfo b) { return a.Name.CompareTo(b.Name); });
                }
                return ModuleInfo.modules;
            }
        }

        protected ModuleInfoAttribute moduleInfoAttribute;
        public readonly Type ModuleType;
        public readonly string AssemblyFile;
        public readonly Type MethodType;
        protected string helpFileName;

        public List<MethodAbstract> methods = new List<MethodAbstract>();

        private List<AboutAttribute> about;

        public List<AboutAttribute> About
        {
            get
            {
                if (about == null)
                {
                    about = new List<AboutAttribute>();
                    foreach (object attr in ModuleType.GetCustomAttributes(typeof(AboutAttribute), false))
                        about.Add(attr as AboutAttribute);
                    about.Sort(
                            delegate(AboutAttribute a, AboutAttribute b)
                            {
                                return a.Name.CompareTo(b.Name);
                            }
                            );
                }
                return about;
            }
        }

        public string Name
        {
            get
            {
                checkModuleInfoAttribute();
                return moduleInfoAttribute.ModuleName;
            }
        }
        private string _helpFileString;

        private ResourceManager moduleResourceManager = null;
        public ResourceManager ModuleResourceManager
        {
            get
            {
                if (moduleResourceManager == null)
                    moduleResourceManager = new ResourceManager(ModuleType.Namespace + ".Properties.Resources", ModuleType.Assembly);
                return moduleResourceManager;
            }
        }
        public string HelpFileString
        {
            get
            {
                try
                {
                    if (_helpFileString == null)
                    {
                        checkModuleInfoAttribute();

                        _helpFileString = ModuleResourceManager.GetString("ModuleHelp");
                    }
                }
                catch
                {
                    _helpFileString = null;
                }
                return _helpFileString;
            }
        }

        private string _helpUIFileString;

        public string HelpUIFileString
        {
            get
            {
                try
                {
                    if (_helpUIFileString == null)
                    {
                        checkModuleInfoAttribute();

                        _helpUIFileString = ModuleResourceManager.GetString("ModuleUIHelp");
                    }
                }
                catch
                {
                    _helpUIFileString = null;
                }
                return _helpUIFileString;
            }
        }

        private Image menuIcon;

        public Image MenuIcon
        {
            get
            {
                try
                {
                    if (menuIcon == null)
                    {
                        checkModuleInfoAttribute();

                        object o = ModuleResourceManager.GetObject("Icon");

                        menuIcon = (Image)o;
                    }
                }
                catch (Exception ex)
                {
                    menuIcon = null;
                }
                return menuIcon;
            }
        }

        private void invalidateHelp()
        {
            _helpFileString = null;
            _helpUIFileString = null;
        }

        public static void InvalidateHelp()
        {
            foreach (ModuleInfo mi in modules)
            {
                mi.invalidateHelp();
            }
        }

        [Obsolete("This property is obsolete. Use HelpFileContentStream instead")]
        public string HelpFileName
        {
            get
            {
                if (helpFileName == null)
                {
                    checkModuleInfoAttribute();
                    helpFileName = moduleInfoAttribute.HelpFileName;
                    string appPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\";
                    if (File.Exists(appPath + helpFileName))
                        helpFileName = appPath + helpFileName;
                    else if (File.Exists(appPath + "Modules\\" + helpFileName))
                        helpFileName = appPath + "Modules\\" + helpFileName;
                    else if (File.Exists(appPath + "Help\\" + helpFileName))
                        helpFileName = appPath + "Help\\" + helpFileName;
                    else
                        helpFileName = "";
                }

                return helpFileName;
            }
        }

        protected void checkModuleInfoAttribute()
        {
            if (moduleInfoAttribute != null) return;
            object[] moduleInfo = ModuleType.GetCustomAttributes(typeof(ModuleInfoAttribute), false);

            if (moduleInfo.Length == 0)
                throw new NotImplementedException("Модуль " + ModuleType.Name + " повинен містити аттрибут ModuleInfoAttribute");
            moduleInfoAttribute = (ModuleInfoAttribute)moduleInfo[0];
        }

        public ModuleAbstract NewInstance()
        {
            return
                ModuleType.InvokeMember(null, System.Reflection.BindingFlags.CreateInstance,
                 null, null, new object[] { }) as ModuleAbstract;
        }

        public ModuleAbstract NewInstance(MethodAbstract method)
        {
            return
                ModuleType.InvokeMember(null, System.Reflection.BindingFlags.CreateInstance,
                 null, null, new object[] { method }) as ModuleAbstract;
        }

        public class MethodNotFoundException : Exception
        {
            public MethodNotFoundException(string ModuleName)
                : base("There is no Method associated with module '" + ModuleName + "'")
            { }
        }

        protected ModuleInfo(Type moduleType)
        {
            if (!moduleType.IsSubclassOf(typeof(ModuleAbstract)))
                throw new ArgumentException("moduleType must subclass ModuleAbstract");

            if (moduleType.Name != "Module")
                throw new ArgumentException("module classs must have name 'Module'");

            ModuleType = moduleType;

            Type[] types = ModuleType.Assembly.GetTypes();
            Type abstractMethod = typeof(MethodAbstract);

            string Namespace = ModuleType.Namespace;

            // Get base method
            foreach (Type method in types)
                if (method.Name == "Method" && method.IsSubclassOf(abstractMethod)
                       && method.Namespace == Namespace)
                {
                    MethodType = method;
                    break;
                }
            if (MethodType == null)
                throw new MethodNotFoundException(moduleType.Name);

            //Get methods
            Namespace += ".Methods";
            foreach (Type method in types)
                if (method.IsSubclassOf(MethodType)
                       && method.Namespace == Namespace)
                    methods.Add(method.InvokeMember(null,
                        BindingFlags.CreateInstance, null, null, new object[] { }) as MethodAbstract);
        }
    }
}
