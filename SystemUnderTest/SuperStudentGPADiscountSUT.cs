using System;
using System.Collections.Generic;

namespace SystemUnderTest
{
    public class SuperStudentGPADiscountSUT
    {
        public bool DiscountGranted(ICollection<SuperStudentGPADriverDataSUT> driversData)
        {
            bool discountGranted = true;

            foreach (SuperStudentGPADriverDataSUT driverData in driversData)
            {
                discountGranted = true;

                if (driverData.DriverAge > 30) //BUG >=
                {
                    discountGranted = false;
                }

                if (driverData.GPA < 3.5)
                {
                    discountGranted = false;
                }

                if (driverData.Relationship != "Child")
                {
                    discountGranted = false;
                }

                if (driverData.MaritialStatus != "Single")
                {
                    discountGranted = false;
                }

                if (driverData.StudentStatus != "College")
                {
                    discountGranted = false;
                }

                if (driverData.ViolationStatus != "None")
                {
                    discountGranted = false;
                }

                if (discountGranted)
                {
                    break;
                }
            }

            return discountGranted;
        }

        public double GetDiscountAmount(ICollection<SuperStudentGPADriverDataSUT> driversData)
        {
            double discountAmount = 0;
            if (DiscountGranted(driversData))
            {
                double highestAmount = 0;
                foreach (SuperStudentGPADriverDataSUT driverData in driversData)
                {
                    if (driverData.GPA < 3.5)
                    {
                        discountAmount = 0;
                    }
                    else if (driverData.GPA >= 3.5 && driverData.GPA < 3.8)
                    {
                        discountAmount = 20.00;
                    }
                    else
                    {
                        discountAmount = 40.00;
                    }

                    if (discountAmount < highestAmount)
                    {
                        highestAmount = discountAmount;
                    }
                }

                //discountAmount = highestAmount; //BUG
            }
            else
            {
                return discountAmount = -1; //BUG 0
            }

            return discountAmount;
        }
    }

    public class SuperStudentGPADriverDataSUT
    {
        public int DriverAge { get; set; }
        public string Relationship { get; set; }
        public string StudentStatus { get; set; }
        public string ViolationStatus { get; set; }
        public double GPA { get; set; }
        public string MaritialStatus { get; set; }
    }
}
