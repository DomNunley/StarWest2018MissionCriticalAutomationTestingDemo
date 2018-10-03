using CombinationGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;

namespace CombinationGeneratorUnitTests
{
    [TestClass]
    public class TestCaseTechniquePercisionUnitTests
    {
        private InputDefinition _intDef;
        private InputDefinition _doubleDef;
        private InputDefinition _stringDef;
        private TestComboGen _testGen;

        [TestInitialize]
        public void TestInitialize()
        {
            _intDef = new InputDefinition("Int", 1, new object[] { 1, 2 });
            _doubleDef = new InputDefinition("Double", 1.0, new object[] { 1.0, 2.0, 3.0 });
            _stringDef = new InputDefinition("String", "1", new object[] { "1", "2", "3" });
            _testGen = new TestComboGen(new List<InputDefinition>() { _intDef, _doubleDef, _stringDef });
        }

        [TestMethod]
        public void AllCombinationsPercisionTest()
        {
            var testCases = _testGen.GenerateAllTestCases<TestCaseTechniquePercisionUnitTestCase>();
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 1.0 && x.String == "1"), "Int 1, Double 1.0, String 1");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 1.0 && x.String == "2"), "Int 1, Double 1.0, String 2");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 1.0 && x.String == "3"), "Int 1, Double 1.0, String 3");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 2.0 && x.String == "1"), "Int 1, Double 2.0, String 1");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 2.0 && x.String == "2"), "Int 1, Double 2.0, String 2");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 2.0 && x.String == "3"), "Int 1, Double 2.0, String 3");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 3.0 && x.String == "1"), "Int 1, Double 3.0, String 1");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 3.0 && x.String == "2"), "Int 1, Double 3.0, String 2");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 3.0 && x.String == "3"), "Int 1, Double 3.0, String 3");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 1.0 && x.String == "1"), "Int 2, Double 1.0, String 1");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 1.0 && x.String == "2"), "Int 2, Double 1.0, String 2");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 1.0 && x.String == "3"), "Int 2, Double 1.0, String 3");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 2.0 && x.String == "1"), "Int 2, Double 2.0, String 1");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 2.0 && x.String == "2"), "Int 2, Double 2.0, String 2");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 2.0 && x.String == "3"), "Int 2, Double 2.0, String 3");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 3.0 && x.String == "1"), "Int 2, Double 3.0, String 1");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 3.0 && x.String == "2"), "Int 2, Double 3.0, String 2");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 3.0 && x.String == "3"), "Int 2, Double 3.0, String 3");
        }

        [TestMethod]
        public void OneFATCombinationsPercisionTest()
        {
            var testCases = _testGen.GenerateNfatTestCases<TestCaseTechniquePercisionUnitTestCase>(1);
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 1.0 && x.String == "1"), "Int 1, Double 1.0, String 1");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 1.0 && x.String == "2"), "Int 1, Double 1.0, String 2");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 1.0 && x.String == "3"), "Int 1, Double 1.0, String 3");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 2.0 && x.String == "1"), "Int 1, Double 2.0, String 1");
            Assert.IsNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 2.0 && x.String == "2"), "Int 1, Double 2.0, String 2");
            Assert.IsNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 2.0 && x.String == "3"), "Int 1, Double 2.0, String 3");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 3.0 && x.String == "1"), "Int 1, Double 3.0, String 1");
            Assert.IsNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 3.0 && x.String == "2"), "Int 1, Double 3.0, String 2");
            Assert.IsNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 3.0 && x.String == "3"), "Int 1, Double 3.0, String 3");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 1.0 && x.String == "1"), "Int 2, Double 1.0, String 1");
            Assert.IsNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 1.0 && x.String == "2"), "Int 2, Double 1.0, String 2");
            Assert.IsNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 1.0 && x.String == "3"), "Int 2, Double 1.0, String 3");
            Assert.IsNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 2.0 && x.String == "1"), "Int 2, Double 2.0, String 1");
            Assert.IsNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 2.0 && x.String == "2"), "Int 2, Double 2.0, String 2");
            Assert.IsNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 2.0 && x.String == "3"), "Int 2, Double 2.0, String 3");
            Assert.IsNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 3.0 && x.String == "1"), "Int 2, Double 3.0, String 1");
            Assert.IsNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 3.0 && x.String == "2"), "Int 2, Double 3.0, String 2");
            Assert.IsNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 3.0 && x.String == "3"), "Int 2, Double 3.0, String 3");
        }

        [TestMethod]
        public void TwoFATCombinationsPercisionTest()
        {
            var testCases = _testGen.GenerateNfatTestCases<TestCaseTechniquePercisionUnitTestCase>(2);
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 1.0 && x.String == "1"), "Int 1, Double 1.0, String 1");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 1.0 && x.String == "2"), "Int 1, Double 1.0, String 2");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 1.0 && x.String == "3"), "Int 1, Double 1.0, String 3");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 2.0 && x.String == "1"), "Int 1, Double 2.0, String 1");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 2.0 && x.String == "2"), "Int 1, Double 2.0, String 2");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 2.0 && x.String == "3"), "Int 1, Double 2.0, String 3");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 3.0 && x.String == "1"), "Int 1, Double 3.0, String 1");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 3.0 && x.String == "2"), "Int 1, Double 3.0, String 2");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 1 && x.Double == 3.0 && x.String == "3"), "Int 1, Double 3.0, String 3");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 1.0 && x.String == "1"), "Int 2, Double 1.0, String 1");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 1.0 && x.String == "2"), "Int 2, Double 1.0, String 2");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 1.0 && x.String == "3"), "Int 2, Double 1.0, String 3");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 2.0 && x.String == "1"), "Int 2, Double 2.0, String 1");
            Assert.IsNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 2.0 && x.String == "2"), "Int 2, Double 2.0, String 2");
            Assert.IsNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 2.0 && x.String == "3"), "Int 2, Double 2.0, String 3");
            Assert.IsNotNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 3.0 && x.String == "1"), "Int 2, Double 3.0, String 1");
            Assert.IsNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 3.0 && x.String == "2"), "Int 2, Double 3.0, String 2");
            Assert.IsNull(testCases.FirstOrDefault(x => x.Int == 2 && x.Double == 3.0 && x.String == "3"), "Int 2, Double 3.0, String 3");
        }

        internal class TestCaseTechniquePercisionUnitTestCase : ITestCase
        {
            public int Int { get; set; }
            public double Double { get; set; }
            public string String { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            public T ConstrainTestCase<T>(T testCase) where T : ITestCase, new()
            {
                return testCase;
            }

            public void SetPropertyOnTestCase(string propertyName, object value)
            {
                PropertyInfo[] properties = typeof(TestCaseTechniquePercisionUnitTestCase).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                foreach (PropertyInfo property in properties)
                {
                    if (property.Name == propertyName)
                    {
                        property.SetValue(this, value);
                        return;
                    }
                }
            }
        }
    }
}
