using CombinationGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;

namespace CombinationGeneratorUnitTests
{
    [TestClass]
    public class DistinctTestCasesUnitTests
    {
        private InputDefinition _intDef;
        private InputDefinition _doubleDef;
        private InputDefinition _stringDef;
        private TestComboGen _testGen;

        [TestInitialize]
        public void TestInitialize()
        {
            _intDef = new InputDefinition("Int", 1, new object[] { 1, 2, 3 });
            _doubleDef = new InputDefinition("Double", 1.0, new object[] { 1.0, 2.0, 3.0 });
            _stringDef = new InputDefinition("String", "1", new object[] { "1", "2", "3" });
            _testGen = new TestComboGen(new List<InputDefinition>() { _intDef, _doubleDef, _stringDef });
        }

        [TestMethod]
        public void NonDistinctTestCaseCountTest()
        {
            var testCases = _testGen.GenerateNfatTestCases<NonDistinctTestCase>(1);
            Assert.AreEqual(9, testCases.Count());
        }

        [TestMethod]
        public void DistinctTestCaseCountTest()
        {
            var testCases = _testGen.GenerateNfatTestCases<DistinctTestCase>(1);
            Assert.AreEqual(7, testCases.Count());
        }

        [TestMethod]
        public void AllCombosDistinctTestCaseCountTest()
        {
            var testCases = _testGen.GenerateAllTestCases<DistinctTestCase>();
            Assert.AreEqual(27, testCases.Count()); //All combos should generate the same amount of test cases regardless if the test case is setup for distinct vs non distinct
        }

        [TestMethod]
        public void AllCombosNonDistinctTestCaseCountTest()
        {
            var testCases = _testGen.GenerateAllTestCases<NonDistinctTestCase>();
            Assert.AreEqual(27, testCases.Count()); //All combos should generate the same amount of test cases regardless if the test case is setup for distinct vs non distinct
        }

        [TestMethod]
        public void NonDistinctTestCasePrecisionTest()
        {
            var testCases = _testGen.GenerateNfatTestCases<NonDistinctTestCase>(1);
            Assert.IsTrue(testCases.Count(x => x.Int == 1 && x.Double == 1.0 && x.String == "1") == 3);
            Assert.IsTrue(testCases.Count(x => x.Int == 2 && x.Double == 1.0 && x.String == "1") == 1);
            Assert.IsTrue(testCases.Count(x => x.Int == 3 && x.Double == 1.0 && x.String == "1") == 1);
            Assert.IsTrue(testCases.Count(x => x.Int == 1 && x.Double == 2.0 && x.String == "1") == 1);
            Assert.IsTrue(testCases.Count(x => x.Int == 1 && x.Double == 3.0 && x.String == "1") == 1);
            Assert.IsTrue(testCases.Count(x => x.Int == 1 && x.Double == 1.0 && x.String == "2") == 1);
            Assert.IsTrue(testCases.Count(x => x.Int == 1 && x.Double == 1.0 && x.String == "3") == 1);
        }

        [TestMethod]
        public void DistinctTestCasePrecisionTest()
        {
            var testCases = _testGen.GenerateNfatTestCases<DistinctTestCase>(1);
            Assert.IsTrue(testCases.Count(x => x.Int == 1 && x.Double == 1.0 && x.String == "1") == 1);
            Assert.IsTrue(testCases.Count(x => x.Int == 2 && x.Double == 1.0 && x.String == "1") == 1);
            Assert.IsTrue(testCases.Count(x => x.Int == 3 && x.Double == 1.0 && x.String == "1") == 1);
            Assert.IsTrue(testCases.Count(x => x.Int == 1 && x.Double == 2.0 && x.String == "1") == 1);
            Assert.IsTrue(testCases.Count(x => x.Int == 1 && x.Double == 3.0 && x.String == "1") == 1);
            Assert.IsTrue(testCases.Count(x => x.Int == 1 && x.Double == 1.0 && x.String == "2") == 1);
            Assert.IsTrue(testCases.Count(x => x.Int == 1 && x.Double == 1.0 && x.String == "3") == 1);
        }

        internal class NonDistinctTestCase : ITestCase
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
                PropertyInfo[] properties = typeof(NonDistinctTestCase).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

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

        internal class DistinctTestCase : ITestCase
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
                PropertyInfo[] properties = typeof(DistinctTestCase).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                foreach (PropertyInfo property in properties)
                {
                    if (property.Name == propertyName)
                    {
                        property.SetValue(this, value);
                        return;
                    }
                }
            }

            #region Equality overloads for distinct test cases
            public override bool Equals(object obj)
            {
                if (object.ReferenceEquals(null, obj))
                {
                    return false;
                }

                if (object.ReferenceEquals(this, obj))
                {
                    return true;
                }

                if (obj.GetType() != this.GetType())
                {
                    return false;
                }

                return IsEqual((DistinctTestCase)obj);
            }

            public bool Equal(DistinctTestCase testCase)
            {
                if (object.ReferenceEquals(null, testCase))
                {
                    return false;
                }

                if (object.ReferenceEquals(this, testCase))
                {
                    return true;
                }

                return IsEqual(testCase);
            }

            private bool IsEqual(DistinctTestCase testCase)
            {
                return testCase.Int.Equals(this.Int) &&
                    testCase.Double.Equals(this.Double) &&
                    testCase.String.Equals(this.String);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    // Choose large primes to avoid hashing collisions
                    const int HashingBase = (int)2166136261;
                    const int HashingMultiplier = 16777619;

                    int hash = HashingBase;
                    hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Int) ? Int.GetHashCode() : 0);
                    hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Double) ? Double.GetHashCode() : 0);
                    hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, String) ? String.GetHashCode() : 0);
                    return hash;
                }
            }
            #endregion
        }
    }
}
