using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Common
{
    [Serializable]
    public class ResultsStorage
    {
        private List<TestResult> _results;

        private const String _serializationPath = "SMPRresults.dat";

        private static ResultsStorage _instance =
            IsolatedStorageHelper.Exists(_serializationPath) ?
            SerializationHelper.Deserialize<ResultsStorage>(IsolatedStorageHelper.Load(_serializationPath)) : new ResultsStorage();

        static ResultsStorage()
        {
            AppDomain.CurrentDomain.ProcessExit += (o, e) =>
                IsolatedStorageHelper.Save(_serializationPath, SerializationHelper.Serialize(_instance));
        }        

        private ResultsStorage() 
        {
            _results = new List<TestResult>();            
        }

        public static void SaveResult(ModuleAbstract module, double result)
        {
            var testResult = new TestResult(module, DateTime.Now, result);
            _instance._results.Add(testResult);
        }

        public static void Clear()
        {
            _instance._results.Clear();
            IsolatedStorageHelper.Delete(_serializationPath);
        }

        public static IEnumerable<TestResult> GetAllResults()
        {
            return _instance._results;
        }

        public static IEnumerable<TestResult> GetLastResults()
        {
            return _instance._results.GroupBy(r => r.ModuleName).Select(g => g.OrderByDescending(r => r.Timestamp).First());
        }
    }
}
