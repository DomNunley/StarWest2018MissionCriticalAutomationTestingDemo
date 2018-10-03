using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace CombinationGenerator
{
    //public abstract class SimpleDataModelTestCase : ITestCase
    //{
    //    #region Interface overrides
    //    public void SetPropertyOnTestCase(string propertyName, object value)
    //    {
    //        PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

    //        foreach (PropertyInfo property in properties)
    //        {
    //            if (property.Name == propertyName)
    //            {
    //                property.SetValue(this, value);
    //                return;
    //            }
    //        }
    //    }

    //    object ICloneable.Clone()
    //    {
    //        return MemberwiseClone();
    //    }

    //    public T ConstrainTestCase<T>(T testCase) where T : ITestCase, new()
    //    {
    //        return ConstrainSimpleTestCase(testCase);
    //    }

    //    public abstract SimpleDataModelTestCase ConstrainSimpleTestCase(SimpleDataModelTestCase testCase);
    //    #endregion

    //    #region Equality overloads for distinct test cases
    //    public override bool Equals(object obj)
    //    {
    //        if (object.ReferenceEquals(null, obj))
    //        {
    //            return false;
    //        }

    //        if (object.ReferenceEquals(this, obj))
    //        {
    //            return true;
    //        }

    //        if (obj.GetType() != this.GetType())
    //        {
    //            return false;
    //        }

    //        return IsEqual((SimpleDataModelTestCase)obj);
    //    }

    //    public bool Equal(SimpleDataModelTestCase testCase)
    //    {
    //        if (object.ReferenceEquals(null, testCase))
    //        {
    //            return false;
    //        }

    //        if (object.ReferenceEquals(this, testCase))
    //        {
    //            return true;
    //        }

    //        return IsEqual(testCase);
    //    }

    //    private bool IsEqual(SimpleDataModelTestCase testCase)
    //    {
    //        PropertyInfo[] testCaseProperties = testCase.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
    //        PropertyInfo[] thisTestCaseProperties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

    //        foreach(PropertyInfo thisTestCaseProperty in thisTestCaseProperties)
    //        {
    //            var testCaseProperty = testCaseProperties.FirstOrDefault(x => x.Name == thisTestCaseProperty.Name);
    //            if(testCaseProperty == null)
    //            {
    //                return false;
    //            }

    //            if(!testCaseProperty.GetValue(testCase).Equals(thisTestCaseProperty.GetValue(this)))
    //            {
    //                return false;
    //            }
    //        }

    //        return true;
    //    }

    //    public override int GetHashCode()
    //    {
    //        unchecked
    //        {
    //            // Choose large primes to avoid hashing collisions
    //            const int HashingBase = (int)2166136261;
    //            const int HashingMultiplier = 16777619;

    //            PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
    //            int hash = HashingBase;

    //            foreach (PropertyInfo property in properties)
    //            {
    //                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, property.GetValue(this)) ? property.GetValue(this).GetHashCode() : 0);
    //            }

    //            return hash;
    //        }
    //    }
    //    #endregion
    //}
}
