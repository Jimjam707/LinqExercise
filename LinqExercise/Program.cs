using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            
            var numbersSum = numbers.Sum();
            Console.WriteLine($"Numbers Sum: {numbersSum}");
            Console.WriteLine();
            
            //TODO: Print the Average of numbers
            
            var numbersAverage = numbers.Average();
            Console.WriteLine($"Numbers average: {numbersAverage}");
            Console.WriteLine();
            
            //TODO: Order numbers in ascending order and print to the console
            
            Console.WriteLine("Numbers in ascending order: ");
            var numbersOrdered = numbers.OrderBy(x => x);
            foreach (var number in numbersOrdered)
            {
                Console.WriteLine(number);
                
            }
            Console.WriteLine();
            
            //TODO: Order numbers in descending order and print to the console
            
            Console.WriteLine("Numbers in descending order: ");
            var numbersOrderedDescending = numbers.OrderByDescending(x => x);
            foreach (var number in numbersOrderedDescending)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
            
            //TODO: Print to the console only the numbers greater than 6
            
            Console.WriteLine("Numbers greater than 6: ");
            var numbersGreaterThan6 = numbers.Where(x => x > 6);
            foreach (var number in numbersGreaterThan6)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
            
            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            
            Console.WriteLine("Numbers in any order: ");
            var numbersOrderedAny = numbers.OrderBy(x => x).Take(4);
            foreach (var number in numbersOrderedAny)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
            
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            
            numbers[4] = 25;
            Console.WriteLine("Numbers in descending order: ");
            var numbersOrderedDescending2 = numbers.OrderByDescending(x => x);
            foreach (var number in numbersOrderedDescending2)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
            
            
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("Employees with first name starting with C or S: ");
            var firstLetter = employees
                .Where(e => e.FirstName.StartsWith('C') || e.FirstName.StartsWith('S'))
                .OrderBy(e => e.FirstName);
            foreach (var e in firstLetter)
            {
                Console.WriteLine(e.FullName);
            }
            Console.WriteLine();

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Employees over age 26 (ordered by age, then first name):");
            var over26 = employees
                .Where(e => e.Age > 26)
                .OrderBy(e => e.Age)
                .ThenBy(e => e.FirstName);
            foreach (var e in over26)
            {
                Console.WriteLine($"{e.FullName} - Age: {e.Age}");
            }
            Console.WriteLine();

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var filteredForSum = employees.Where(e => e.YearsOfExperience <= 10 && e.Age > 35);
            var sumYoe = filteredForSum.Sum(e => e.YearsOfExperience);
            Console.WriteLine($"Sum of years of experience (YOE <= 10 and Age > 35): {sumYoe}");
            Console.WriteLine();

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var avgYoe = filteredForSum.Any() ? filteredForSum.Average(e => e.YearsOfExperience) : 0;
            Console.WriteLine($"Average years of experience (YOE <= 10 and Age > 35): {avgYoe}");
            Console.WriteLine();

            //TODO: Add an employee to the end of the list without using employees.Add()
            
            employees = employees.Append(new Employee("Jimi", "Adams", 29, 9)).ToList();    
            
            Console.WriteLine("All employees:");
            Console.WriteLine();
           var totalEmployees = employees.Count();
           foreach (var e in employees)
           {
               Console.WriteLine($"{e.FullName} - Age: {e.Age}");
           }

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
