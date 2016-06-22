using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SMPR.Tests
{
    [TestClass()]
    public class TestResultTest
    {
        [TestMethod()]
        public void ModuleNameTest()
        {
            var module = new Modules.CollectiveBenefitFunctions.Module();            
            TestResult target = new TestResult(module, DateTime.Now, 34.5);
            string before = target.ModuleName;
            {
                byte[] serializedTarget = SerializationHelper.Serialize(target);
                target = SerializationHelper.Deserialize<TestResult>(serializedTarget);
            }
            string actual = target.ModuleName;
            string expected = module.Name;
            Assert.AreEqual<String>(expected, actual);
        }
    }
}
