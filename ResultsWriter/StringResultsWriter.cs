using System;
using System.Text;
using CombinationGenerator;
using System.Reflection;

namespace ResultsWriter
{
    public static class StringResultsWriter
    {
        public static void AddHeaders<T>(StringBuilder sb) where T : ITestCase, new()
        {
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            sb.Append("| ");
            foreach (PropertyInfo property in properties)
            {
                sb.Append(property.Name + " | ");
            }
        }

        public static void AddRow<T>(T testCase, StringBuilder sb) where T : ITestCase, new()
        {
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            sb.AppendLine();
            sb.Append("| ");
            foreach (PropertyInfo property in properties)
            {
                var value = property.GetValue(testCase);
                sb.Append(value + " | ");
            }
        }
    }
}
