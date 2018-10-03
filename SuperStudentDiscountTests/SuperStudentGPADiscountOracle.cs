using SuperStudentDiscountTests;
using SystemUnderTest;
using System.Collections.Generic;
using System.Linq;

namespace SuperStudentDiscountOracle
{
    public class SuperStudentGPADiscountOracle
    {
        public bool QualifiesForDiscount(SuperStudentGPADiscountOneDriverTestCase testCase)
        {
            bool qualifiesForDiscount = false;

            if(testCase.DriverAge < 30 && 
                testCase.GPA >= 3.5 && 
                testCase.MaritialStatus == "Single" && 
                testCase.Relationship == "Child" && 
                testCase.StudentStatus == "College" && 
                testCase.ViolationStatus == "None")
            {
                qualifiesForDiscount = true;
            }

            return qualifiesForDiscount;
        }

        public double DiscountAmount(SuperStudentGPADiscountOneDriverTestCase testCase)
        {
            if(QualifiesForDiscount(testCase) && testCase.GPA >= 3.8)
            {
                return 40.00;
            }
            else if(QualifiesForDiscount(testCase) && testCase.GPA >= 3.5)
            {
                return 20.00;
            }
            else
            {
                return 0;
            }
        }

        public double DiscountAmountWithMultipleDrivers(ICollection<SuperStudentGPADriverDataSUT> driversData)
        {
            var driverWithHighestGPA = driversData.Aggregate((i1, i2) => i1.GPA > i2.GPA ? i1 : i2);
            SuperStudentGPADiscountOneDriverTestCase tc = new SuperStudentGPADiscountOneDriverTestCase()
            {
                GPA = driverWithHighestGPA.GPA,
                DriverAge = driverWithHighestGPA.DriverAge,
                MaritialStatus = driverWithHighestGPA.MaritialStatus,
                Relationship = driverWithHighestGPA.Relationship,
                StudentStatus = driverWithHighestGPA.StudentStatus,
                ViolationStatus = driverWithHighestGPA.ViolationStatus
            };
            return DiscountAmount(tc);
        }
    }
}
