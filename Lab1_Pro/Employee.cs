using System;
using System.Text;

//Author: Abhishek Chauhan

namespace Lab1_Pro
{
    /// <summary>
    /// Employee class with employee's name, number, rate, and hours worked.
    /// </summary>
    class Employee
    {
        public String Name { get; set; }    //.Net style getter and setter for Name of employee
        public int Number { get; set; }     //.Net style getter and setter for Number of employee
        public Decimal Rate { get; set; }   //.Net style getter and setter for Rate of employee
        public Double Hours { get; set; }   //.Net style getter and setter for Hours of employee
        public Decimal Gross { get; set; }  //.Net style getter and setter for Gross of employee

        /// <summary>
        /// Emplyee constructor to create employee object.
        /// </summary>
        /// <param name="name">Name of the employee</param>
        /// <param name="number">Number of the employee</param>
        /// <param name="rate">Rate of the employee</param>
        /// <param name="hours">Hours of the employee</param>
        public Employee(String name, int number, Decimal rate, Double hours)
        {
            this.Name = name;       //Initializing name of the employee
            this.Number = number;   //Initializing number of the employee
            this.Rate = rate;       //Initializing rate of the employee
            this.Hours = hours;     ////Initializing hours of the employee
            if (Hours <= 40)
                this.Gross = (decimal)hours * rate;     //Calculating gross and initializing if hours less than 40 
            else
                this.Gross = (40 * rate) + (((decimal)hours - 40) * rate * 1.5M);   //Calculating gross and initializing if hours more than 40
        }

        /// <summary>
        /// Overriding tostring method
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            StringBuilder sb = new System.Text.StringBuilder(); //Creating stringbuilder object.
            sb.Append(String.Format("{0,8} \t {1,8} \t {2,8} \t {3, 8:F2} \t {4,8:F2}", Name, Number, Rate, Hours, Gross)); //Formating string and appending to the stringbuilder object
            return sb.ToString();
        }
    }
}
