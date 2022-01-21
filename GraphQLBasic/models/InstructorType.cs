using System;

namespace GraphQLBasic.models
{
    public class InstructorType: PersonType
    {
        public double Salary { get; set; }
        public DateTime DOB { get; set; }

        public int Age()
        {
            return DateTime.Today.Year - DOB.Year;
        }
    }
}
