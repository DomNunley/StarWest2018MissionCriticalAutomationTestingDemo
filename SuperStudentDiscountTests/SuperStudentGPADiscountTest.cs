using Microsoft.VisualStudio.TestTools.UnitTesting;
using CombinationGenerator;
using System.Collections.Generic;
using System.Text;
using SuperStudentDiscountOracle;
using ResultsWriter;
using SystemUnderTest;
using System.Reflection;
using System;

namespace SuperStudentDiscountTests
{
    [TestClass]
    public class SuperStudentGPADiscountTest
    {
        [TestMethod]
        public void SuperStudentQualifiesForDiscountOneDriver()
        {
            #region Define Inputs
            InputDefinition age = new InputDefinition(inputName: "DriverAge", defaultValue: 29, exerciseValues: new object[] { 29, 30, 31 });
            InputDefinition gpa = new InputDefinition(inputName: "GPA", defaultValue: 3.50, exerciseValues: new object[] { 3.50, 3.49, 3.51, 3.79, 3.80, 3.81, 4.0 });
            InputDefinition studentStatus = new InputDefinition(inputName: "StudentStatus", defaultValue: "College", exerciseValues: new object[] { "College", "HighSchool", "None" });
            InputDefinition maritialStatus = new InputDefinition(inputName: "MaritialStatus", defaultValue: "Single", exerciseValues: new object[] { "Single", "Married", "Divorced", "Separated" });
            InputDefinition violation = new InputDefinition(inputName: "ViolationStatus", defaultValue: "None", exerciseValues: new object[] { "None", "Speeding", "AtFaultAccident", "WrongWay" });
            InputDefinition relationship = new InputDefinition(inputName: "Relationship", defaultValue: "Child", exerciseValues: new object[] { "Child", "NamedInsured", "Spouse", "Other" });
            List<InputDefinition> inputs = new List<InputDefinition> { age, gpa, studentStatus, maritialStatus, violation, relationship };
            #endregion

            #region Setup Combination Generator and Generate Test Cases
            //Pass inputs to combination generator and select technique
            TestComboGen testComboGen = new TestComboGen(inputs);
            var testCases = testComboGen.GenerateNfatTestCases<SuperStudentGPADiscountOneDriverTestCase>(1);
            #endregion

            #region Setup Oracle and Results Logging
            //Instantiate oracle class
            SuperStudentGPADiscountOracle myOracle = new SuperStudentGPADiscountOracle();
            bool testCaseHasFailure = false;

            //Used to log results
            StringBuilder resultMessageSb = new StringBuilder();
            StringResultsWriter.AddHeaders<SuperStudentGPADiscountOneDriverTestCase>(resultMessageSb);
            #endregion

            #region Execute Test Cases and Log Results
            foreach (SuperStudentGPADiscountOneDriverTestCase tc in testCases)
            {
                #region Get Expected Results From Oracle and Get Actual Results From SUT
                bool qualifiesForDiscountActual = GetQualifyForDiscountValueFromSUT(tc);
                bool qualifiesForDiscountExpected = myOracle.QualifiesForDiscount(tc);
                #endregion

                #region Compare Expected VS Actual and Log Result Differences
                if (!qualifiesForDiscountExpected.Equals(qualifiesForDiscountActual))
                {
                    StringResultsWriter.AddRow<SuperStudentGPADiscountOneDriverTestCase>(tc, resultMessageSb); //log failures only
                    resultMessageSb.Append($"OUTPUT: Expected <{qualifiesForDiscountExpected}> but was <{qualifiesForDiscountActual}>");
                    testCaseHasFailure = true;
                }
                #endregion
            }
            #endregion

            Assert.IsFalse(testCaseHasFailure, resultMessageSb.ToString());
        }

        [TestMethod]
        public void SuperStudentDiscountAmountOneDriver()
        {
            #region Define Inputs
            InputDefinition age = new InputDefinition(inputName: "DriverAge", defaultValue: 29, exerciseValues: new object[] { 29, 30, 31 });
            InputDefinition gpa = new InputDefinition(inputName: "GPA", defaultValue: 3.50, exerciseValues: new object[] { 3.50, 3.49, 3.51, 3.79, 3.80, 3.81, 4.0 });
            InputDefinition studentStatus = new InputDefinition(inputName: "StudentStatus", defaultValue: "College", exerciseValues: new object[] { "College", "HighSchool", "None" });
            InputDefinition maritialStatus = new InputDefinition(inputName: "MaritialStatus", defaultValue: "Single", exerciseValues: new object[] { "Single", "Married", "Divorced", "Separated" });
            InputDefinition violation = new InputDefinition(inputName: "ViolationStatus", defaultValue: "None", exerciseValues: new object[] { "None", "Speeding", "AtFaultAccident", "WrongWay" });
            InputDefinition relationship = new InputDefinition(inputName: "Relationship", defaultValue: "Child", exerciseValues: new object[] { "Child", "NamedInsured", "Spouse", "Other" });
            List<InputDefinition> inputs = new List<InputDefinition> { age, gpa, studentStatus, maritialStatus, violation, relationship };
            #endregion

            #region Setup Combination Generator and Generate Test Cases
            //Pass inputs to combination generator and select technique
            TestComboGen testComboGen = new TestComboGen(inputs);
            var testCases = testComboGen.GenerateNfatTestCases<SuperStudentGPADiscountOneDriverTestCase>(1);
            #endregion

            #region Setup Oracle and Results Logging
            //Instantiate oracle class
            SuperStudentGPADiscountOracle myOracle = new SuperStudentGPADiscountOracle();
            bool testCaseHasFailure = false;

            //Used to log results
            StringBuilder resultMessageSb = new StringBuilder();
            StringResultsWriter.AddHeaders<SuperStudentGPADiscountOneDriverTestCase>(resultMessageSb);
            #endregion

            #region Execute Test Cases and Log Results
            foreach (SuperStudentGPADiscountOneDriverTestCase tc in testCases)
            {
                #region Get Expected Results From Oracle and Get Actual Results From SUT
                double discountAmountActual = GetDiscountAmountValueFromSUT(tc);
                double discountAmountExpected = myOracle.DiscountAmount(tc);
                #endregion

                #region Compare Expected VS Actual and Log Result Differences
                if (!discountAmountExpected.Equals(discountAmountActual))
                {
                    StringResultsWriter.AddRow<SuperStudentGPADiscountOneDriverTestCase>(tc, resultMessageSb); //log failures only\
                    resultMessageSb.Append($"OUTPUT: Expected <{discountAmountExpected}> but was <{discountAmountActual}>");
                    testCaseHasFailure = true;
                }
                #endregion
            }
            #endregion

            Assert.IsFalse(testCaseHasFailure, resultMessageSb.ToString());
        }

        [TestMethod]
        public void SuperStudentDiscountAmountMultipleDrivers()
        {
            #region Define Inputs
            InputDefinition gpa1 = new InputDefinition(inputName: "Driver1GPA", defaultValue: 3.50, exerciseValues: new object[] { 3.50, 3.49, 3.51, 3.79, 3.80, 3.81, 4.0 });
            InputDefinition gpa2 = new InputDefinition(inputName: "Driver2GPA", defaultValue: 3.50, exerciseValues: new object[] { 3.50, 3.49, 3.51, 3.79, 3.80, 3.81, 4.0 });
            InputDefinition gpa3 = new InputDefinition(inputName: "Driver3GPA", defaultValue: 3.50, exerciseValues: new object[] { 3.50, 3.49, 3.51, 3.79, 3.80, 3.81, 4.0 });
            List<InputDefinition> inputs = new List<InputDefinition> { gpa1, gpa2, gpa3 };
            #endregion

            #region Setup Combination Generator and Generate Test Cases
            //Pass inputs to combination generator and select technique
            TestComboGen testComboGen = new TestComboGen(inputs);
            var testCases = testComboGen.GenerateNfatTestCases<SuperStudentGPADiscountMultiDriverTestCase>(1);
            #endregion

            #region Setup Oracle and Results Logging
            //Instantiate oracle class
            SuperStudentGPADiscountOracle myOracle = new SuperStudentGPADiscountOracle();
            bool testCaseHasFailure = false;

            //Used to log results
            StringBuilder resultMessageSb = new StringBuilder();
            StringResultsWriter.AddHeaders<SuperStudentGPADiscountMultiDriverTestCase>(resultMessageSb);
            #endregion

            #region Execute Test Cases and Log Results
            foreach (SuperStudentGPADiscountMultiDriverTestCase tc in testCases)
            {
                #region Get Expected Results From Oracle and Get Actual Results From SUT
                double discountAmountActual = GetDiscountAmountValueFromSUT(tc);
                double discountAmountExpected = myOracle.DiscountAmountWithMultipleDrivers(GetMultiDriverSUTData(tc));
                #endregion

                #region Compare Expected VS Actual and Log Result Differences
                if (!discountAmountExpected.Equals(discountAmountActual))
                {
                    StringResultsWriter.AddRow<SuperStudentGPADiscountMultiDriverTestCase>(tc, resultMessageSb); //log failures only
                    resultMessageSb.Append($"OUTPUT: Expected <{discountAmountExpected}> but was <{discountAmountActual}>");
                    testCaseHasFailure = true;
                }
                #endregion
            }
            #endregion

            Assert.IsFalse(testCaseHasFailure, resultMessageSb.ToString());
        }

        #region Convert Test Case Data to SUT Data and Get Actual Results
        private bool GetQualifyForDiscountValueFromSUT(SuperStudentGPADiscountOneDriverTestCase tc)
        {
            SuperStudentGPADiscountSUT systemUnderTest = new SuperStudentGPADiscountSUT();

            //Convert our test case to SUT data
            SuperStudentGPADriverDataSUT driverData = new SuperStudentGPADriverDataSUT()
            {
                DriverAge = tc.DriverAge,
                GPA = tc.GPA,
                MaritialStatus = tc.MaritialStatus,
                Relationship = tc.Relationship,
                StudentStatus = tc.StudentStatus,
                ViolationStatus = tc.ViolationStatus
            };

            List<SuperStudentGPADriverDataSUT> driversData = new List<SuperStudentGPADriverDataSUT> { driverData };
            return systemUnderTest.DiscountGranted(driversData);
        }

        private double GetDiscountAmountValueFromSUT(SuperStudentGPADiscountOneDriverTestCase tc)
        {
            SuperStudentGPADiscountSUT systemUnderTest = new SuperStudentGPADiscountSUT();

            SuperStudentGPADriverDataSUT driverData = new SuperStudentGPADriverDataSUT()
            {
                DriverAge = tc.DriverAge,
                GPA = tc.GPA,
                MaritialStatus = tc.MaritialStatus,
                Relationship = tc.Relationship,
                StudentStatus = tc.StudentStatus,
                ViolationStatus = tc.ViolationStatus
            };

            List<SuperStudentGPADriverDataSUT> driversData = new List<SuperStudentGPADriverDataSUT> { driverData };
            return systemUnderTest.GetDiscountAmount(driversData);
        }

        private double GetDiscountAmountValueFromSUT(SuperStudentGPADiscountMultiDriverTestCase tc)
        {
            SuperStudentGPADiscountSUT systemUnderTest = new SuperStudentGPADiscountSUT();
            return systemUnderTest.GetDiscountAmount(GetMultiDriverSUTData(tc));
        }

        private List<SuperStudentGPADriverDataSUT> GetMultiDriverSUTData(SuperStudentGPADiscountMultiDriverTestCase tc)
        {
            SuperStudentGPADriverDataSUT driver1Data = new SuperStudentGPADriverDataSUT()
            {
                DriverAge = 29,
                GPA = tc.Driver1GPA,
                MaritialStatus = "Single",
                Relationship = "Child",
                StudentStatus = "College",
                ViolationStatus = "None"
            };

            SuperStudentGPADriverDataSUT driver2Data = new SuperStudentGPADriverDataSUT()
            {
                DriverAge = 29,
                GPA = tc.Driver2GPA,
                MaritialStatus = "Single",
                Relationship = "Child",
                StudentStatus = "College",
                ViolationStatus = "None"
            };

            SuperStudentGPADriverDataSUT driver3Data = new SuperStudentGPADriverDataSUT()
            {
                DriverAge = 29,
                GPA = tc.Driver3GPA,
                MaritialStatus = "Single",
                Relationship = "Child",
                StudentStatus = "College",
                ViolationStatus = "None"
            };

            return new List<SuperStudentGPADriverDataSUT> { driver1Data, driver2Data, driver3Data };
        }
        #endregion
    }

    public class SuperStudentGPADiscountOneDriverTestCase : ITestCase
    {
        public int DriverAge { get; set; }
        public string Relationship { get; set; }
        public string StudentStatus { get; set; }
        public string ViolationStatus { get; set; }
        public double GPA { get; set; }
        public string MaritialStatus { get; set; }

        public SuperStudentGPADiscountOneDriverTestCase() { }

        #region Interface overrides
        public void SetPropertyOnTestCase(string propertyName, object value)
        {
            PropertyInfo[] properties = typeof(SuperStudentGPADiscountOneDriverTestCase).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (PropertyInfo property in properties)
            {
                if (property.Name == propertyName)
                {
                    property.SetValue(this, value);
                    return;
                }
            }
        }

        object ICloneable.Clone()
        {
            return MemberwiseClone();
        }

        public T ConstrainTestCase<T>(T testCase) where T : ITestCase, new()
        {
            return testCase;
        }
        #endregion

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

            return IsEqual((SuperStudentGPADiscountOneDriverTestCase)obj);
        }

        public bool Equal(SuperStudentGPADiscountOneDriverTestCase testCase)
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

        private bool IsEqual(SuperStudentGPADiscountOneDriverTestCase testCase)
        {
            return testCase.DriverAge.Equals(this.DriverAge) &&
                testCase.GPA.Equals(this.GPA) &&
                testCase.MaritialStatus.Equals(this.MaritialStatus) &&
                testCase.Relationship.Equals(this.Relationship) &&
                testCase.StudentStatus.Equals(this.StudentStatus) &&
                testCase.ViolationStatus.Equals(this.ViolationStatus);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // Choose large primes to avoid hashing collisions
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, DriverAge) ? DriverAge.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Relationship) ? Relationship.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, StudentStatus) ? StudentStatus.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, ViolationStatus) ? ViolationStatus.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, GPA) ? GPA.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, MaritialStatus) ? MaritialStatus.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }

    public class SuperStudentGPADiscountMultiDriverTestCase : ITestCase
    {
        public double Driver1GPA { get; set; }
        public double Driver2GPA { get; set; }
        public double Driver3GPA { get; set; }

        public SuperStudentGPADiscountMultiDriverTestCase() { }

        #region Interface overrides
        public void SetPropertyOnTestCase(string propertyName, object value)
        {
            PropertyInfo[] properties = typeof(SuperStudentGPADiscountMultiDriverTestCase).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (PropertyInfo property in properties)
            {
                if (property.Name == propertyName)
                {
                    property.SetValue(this, value);
                    return;
                }
            }
        }

        object ICloneable.Clone()
        {
            return MemberwiseClone();
        }

        public T ConstrainTestCase<T>(T testCase) where T : ITestCase, new()
        {
            return testCase;
        }
        #endregion

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

            return IsEqual((SuperStudentGPADiscountMultiDriverTestCase)obj);
        }

        public bool Equal(SuperStudentGPADiscountMultiDriverTestCase testCase)
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

        private bool IsEqual(SuperStudentGPADiscountMultiDriverTestCase testCase)
        {
            return testCase.Driver1GPA.Equals(this.Driver1GPA) &&
                testCase.Driver2GPA.Equals(this.Driver2GPA) &&
                testCase.Driver3GPA.Equals(this.Driver3GPA);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // Choose large primes to avoid hashing collisions
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!ReferenceEquals(null, Driver1GPA) ? Driver1GPA.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!ReferenceEquals(null, Driver2GPA) ? Driver2GPA.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!ReferenceEquals(null, Driver3GPA) ? Driver3GPA.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}