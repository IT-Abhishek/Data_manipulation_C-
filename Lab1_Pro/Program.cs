using System;
using System.IO;

/// <summary>
/// Statement of authership: I, Abhishek Chauhan, 000815438 certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// 
/// Submit Date: 27/09/2020
/// 
/// </summary>

namespace Lab1_Pro
{

    class Program
    {
        public static Employee[] employees = new Employee[100];     //Creating Employee object to store employees 
        static int employeeLength = 0;                              //Int variable to store emplyees length
        public static string sortBy;                                //String variable that indicates how to sort data

        /// <summary>
        /// The Main function where program starts to execute
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Read();     //Calling read method to get employees data
            Console.WriteLine("**************** Before sort ****************");
            Show();     //Displaying employees data on console
            bool flag = true;   //Bollean variable to control the loop
            while (flag)
            {
                Console.WriteLine("\n\n1. Sort by Employee Name(ascending)\n" +
                                  "2. Sort by Employee Number(ascending)\n" +
                                  "3. Sort by Employee Pay Rate(descending)\n" +
                                  "4. Sort by Employee Hours(descending)\n" +
                                  "5. Sort by Employee Gross Pay(descending)\n" +
                                  "6. Exit\n");
                int sort_num = int.Parse(Console.ReadLine());

                switch (sort_num)   //Switch using user input
                {
                    case 1:
                        sortBy = "name";    //Initializing sortBy to name
                        break;
                    case 2:
                        sortBy = "number";  //Initializing sortBy to number
                        break;
                    case 3:
                        sortBy = "rate";    //Initializing sortBy to rate
                        break;
                    case 4:
                        sortBy = "hours";   //Initializing sortBy to hours
                        break;
                    case 5:
                        sortBy = "gross";   //Initializing sortBy to gross
                        break;
                    case 6:
                        flag = false;       //seting false to exit loop
                        break;
                    default:
                        Console.Error.WriteLine("Invalid Selection");
                        break;

                }
                if (flag && (sort_num >= 1 && sort_num <= 6))
                {
                    QuickSort(0, employeeLength - 1);   //Calling QuickSort method to sort the data
                    Console.WriteLine("**************** After sort ****************");
                    Show();     //Displaying employees data on console
                }

            }

        }

        /// <summary>
        /// Read method that reads data from the employee.txt file
        /// </summary>
        public static void Read()
        {

            int NumberOfEmployees = 0; 
            try
            {
                StreamReader reader = new StreamReader("employee.txt");     //Creating streamreader object for employee.txt
                while (!reader.EndOfStream)     //Loop till data is not finished
                {

                    string[] employee = reader.ReadLine().Split(',');      //Reading data of employees using comma as a seperator
                    int Number = int.Parse(employee[1]);                   //Converting number string to int 
                    Decimal Rate = Decimal.Parse(employee[2]);             //Converting rate string to decimal 
                    Double Hours = Double.Parse(employee[3]);              //Converting hour string to double 

                    employees[NumberOfEmployees] = new Employee(employee[0], Number, Rate, Hours);  //Initializing Employee object
                    NumberOfEmployees++;
                    employeeLength++;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Show method to diaplay data on console.
        /// </summary>
        public static void Show()
        {
            Console.Write(String.Format("{0,8} \t {1,8} \t {2,8} \t {3, 8} \t {4,8}", "Name", "Number", "Rate", "Hours", "Gross\n"));
            foreach (Employee employee in employees)
            {
                if (employee == null)
                    break;
                else
                    Console.WriteLine(employee);

            }
        }

        /// <summary>
        /// QuickSort method to sort the data.
        /// Cite : https://www.tutorialspoint.com/data_structures_algorithms/quick_sort_algorithm.htm
        /// </summary>
        /// <param name="left">Starting index</param>
        /// <param name="right">End index</param>
        public static void QuickSort(int left, int right)
        {
            if (right - left <= 0)
                return;
            else
            {
                Employee pivot = employees[right];                      //Initializing pivot element
                int partitionPoint = Partition(left, right, pivot);     //Getting partition point by calling partition method
                QuickSort(left, partitionPoint - 1);                    //Again calling QuickSort for left part
                QuickSort(partitionPoint + 1, right);                   //Again calling QuickSort for right part
            }

        }

        /// <summary>
        /// Partition method to make part of an array.
        /// Cite : https://www.tutorialspoint.com/data_structures_algorithms/quick_sort_algorithm.htm
        /// </summary>
        /// <param name="left">Starting index</param>
        /// <param name="right">End index</param>
        /// <param name="employee">Pivot element</param>
        /// <returns></returns>
        public static int Partition(int left, int right, Employee employee)
        {
            int leftPointer = left - 1;
            int rightPointer = right;

            //Sorting by name
            if (sortBy == "name")
            {
                while (true)
                {
                    //Comparing and doing nothing while starting index employee name is less than pivot element name and incrementing leftpointer
                    while (employees[++leftPointer].Name.CompareTo(employee.Name) < 0) { }
                    //Comparing doing nothing while right pointer greater than zero and end index employee name is greater than pivot element name and decrementing right pointer
                    while (rightPointer > 0 && (employees[--rightPointer].Name.CompareTo(employee.Name) > 0)) { }

                    //Breaking loop if leftpointer is greater than or equal to rightpointer
                    if (leftPointer >= rightPointer)    
                        break;

                    //Swaping two employees 
                    else
                        Swap(leftPointer, rightPointer);
                }
            }

            //Sorting by number
            else if (sortBy == "number")
            {
                while (true)
                {
                    //Comparing and doing nothing while starting index employee number is less than pivot element number and incrementing leftpointer
                    while (employees[++leftPointer].Number < employee.Number) { }
                    //Comparing and doing nothing while right pointer greater than zero and end index employee number is greater than pivot element number and decrementing right pointer
                    while (rightPointer > 0 && (employees[--rightPointer].Number > employee.Number)) { }

                    //Breaking loop if leftpointer is greater than or equal to rightpointer
                    if (leftPointer >= rightPointer)
                        break;
                    //Swaping two employees 
                    else
                        Swap(leftPointer, rightPointer);

                }
            }

            //Sorting by rate
            else if (sortBy=="rate")
            {
                while (true)
                {
                    //Comparing and doing nothing while starting index employee rate is greater than pivot element rate and incrementing leftpointer
                    while (employees[++leftPointer].Rate > employee.Rate) { }
                    //Comparing and doing nothing while right pointer greater than zero and right pointer index employee rate is less than pivot element rate and decrementing right pointer
                    while (rightPointer > 0 && (employees[--rightPointer].Rate < employee.Rate)) { }

                    //Breaking loop if leftpointer is greater than or equal to rightpointer
                    if (leftPointer >= rightPointer)
                        break;
                    //Swaping two employees 
                    else
                        Swap(leftPointer, rightPointer);
                }
            }

            //Sorting by hours
            else if (sortBy == "hours")
            {
                while (true)
                {
                    //Comparing and doing nothing while starting index employee hours is greater than pivot element hours and incrementing leftpointer
                    while (employees[++leftPointer].Hours > employee.Hours) { }
                    //Comparing and doing nothing while right pointer greater than zero and right pointer index employee hours is less than pivot element hours and decrementing right pointer
                    while (rightPointer > 0 && (employees[--rightPointer].Hours < employee.Hours)) { }

                    //Breaking loop if leftpointer is greater than or equal to rightpointer
                    if (leftPointer >= rightPointer)
                        break;
                    //Swaping two employees 
                    else
                        Swap(leftPointer, rightPointer);

                }
            }

            //Sorting by gross
            else if (sortBy == "gross")
            {
                while (true)
                {
                    //Comparing and doing nothing while starting index employee gross is greater than pivot element gross and incrementing leftpointer
                    while (employees[++leftPointer].Gross > employee.Gross) { }
                    //Comparing and doing nothing while right pointer greater than zero and right pointer index employee gross is less than pivot element gross and decrementing right pointer
                    while (rightPointer > 0 && (employees[--rightPointer].Gross < employee.Gross)) { }

                    //Breaking loop if leftpointer is greater than or equal to rightpointer
                    if (leftPointer >= rightPointer)
                        break;
                    //Swaping two employees 
                    else
                        Swap(leftPointer, rightPointer);
                }
            }

            Swap(leftPointer, right);
            return leftPointer;     //Returning partition point
        }

        /// <summary>
        /// Swap method to swap two data using temporary element.
        /// </summary>
        /// <param name="left">First element</param>
        /// <param name="right">Second element</param>
        public static void Swap(int left, int right)
        {
            Employee temp = employees[left];
            employees[left] = employees[right];
            employees[right] = temp;
        }
    }
}