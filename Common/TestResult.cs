using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace Common
{
    [Serializable]
    [DebuggerDisplay("{Timestamp} : {ModuleName} - {Result}")]
    public class TestResult
    {
        // added for efficiency (quick ModuleType lookup)
        private static Dictionary<String, Type> _typeCache = new Dictionary<string, Type>();

        private String _moduleTypeName;
        private Type _moduleType;
        private Type ModuleType
        {
            get
            {
                if (_moduleType == null)
                {
                    lock (_typeCache)
                    {
                        if (!_typeCache.TryGetValue(_moduleTypeName, out _moduleType))
                        {
                            _moduleType = AppDomain.CurrentDomain
                                .GetAssemblies()
                                .Where(a => a.GetType(_moduleTypeName, false) != null)
                                .Select(a => a.GetType(_moduleTypeName, false))
                                .Single();
                            _typeCache.Add(_moduleTypeName, _moduleType);
                        }
                    }
                }
                return _moduleType;
            }
        }

        public String ModuleName
        {
            get
            {
                return ReflectionHelper.GetAttribute<ModuleInfoAttribute>(ModuleType).ModuleName;
            }
        }
        public DateTime Timestamp { get; private set; }
        public double Result { get; private set; }

        // for serialization
        private TestResult() { }

        /// <param name="module">Module that ran test.</param>
        /// <param name="timestamp">Time of passing the test.</param>
        /// <param name="result">Must be in [0, 100]</param>
        public TestResult(ModuleAbstract module, DateTime timestamp, double result)
        {
            if (result < 0 || result > 100)
            {
                throw new ArgumentException(String.Format("Result ({0}) must be in range [0, 100].", result), "result");
            }
            _moduleTypeName = module.GetType().FullName;
            Timestamp = timestamp;
            Result = result;
        }
    }
}
