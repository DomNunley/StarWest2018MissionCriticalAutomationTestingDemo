namespace SuperStudentDiscountOracle
{
    public class SuperStudentGPADiscountOracle
    {
        public bool QualifiesForDiscount(SuperStudentGPADiscountTestCase testCase)
        {
            bool qualifiesForDiscount = false;

            if(testCase.DriverAge < 30 && testCase.GPA >= 3.5 && testCase.MaritialStatus == "Single" && 
                testCase.Relationship == "Child" && testCase.StudentStatus == "College" && testCase.ViolationStatus == "None")
            {
                qualifiesForDiscount = true;
            }

            return qualifiesForDiscount;
        }

        public double DiscountAmount(SuperStudentGPADiscountTestCase testCase)
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
    }
}
