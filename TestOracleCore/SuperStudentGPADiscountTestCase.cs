using System;
using System.Collections.Generic;
using System.Text;
using CombinationGenerator;
using System.Reflection;

namespace SuperStudentDiscountOracle
{
    public class SuperStudentGPADiscountTestCase : ITestCase
    {
        public int DriverAge { get; set; }
        public string Relationship { get; set; }
        public string StudentStatus { get; set; }
        public string ViolationStatus { get; set; }
        public double GPA { get; set; }
        public string MaritialStatus { get; set; }

        public SuperStudentGPADiscountTestCase() { }

        public void SetPropertyOnTestCase(string propertyName, object value)
        {
            PropertyInfo[] properties = typeof(SuperStudentGPADiscountTestCase).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach(PropertyInfo property in properties)
            {
                if(property.Name == propertyName)
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
    }
}
