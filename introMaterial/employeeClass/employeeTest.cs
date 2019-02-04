/*
 * Task: Get information about two employees and compare their yearly
 *       salaries before and after a 10% raise using the Employee class.
 * Input: The user will input the first and last names of the two
 *        employees as strings and their monthly salaries as a number
 *        that will be converted to decimal.
 * Output: The output consists of the employees' yearly salaries
 *         before the 10% raise and then after the 10% raise.
 *         There is also some user information along the way to
 *         describe what the program does.
 * Operations: Declare the varaibles and then print some user info.
 *             Get the first and last name of employee 1 from the
 *             user and assign them to different variables. Get the
 *             monthly salary for employee 1 from the user and
 *             convert it to decimal, assign that value to a variable.
 *             Create an Employee object that's initialized with
 *             those variables. Repeat the process for a second
 *             employee and create a second Employee object with the
 *             new values. Output the yearly salary for each employee,
 *             then output the yearly salary with a 10% raise.
 */

using System;

public class EmployeeTest
{
    public static void Main(string[] args)
    {
        string fName,   // variable to hold first name
               lName;   // variable to hold last name
        decimal salary; // variable to hold salary

        // user info
        Console.WriteLine("Welcome to the employee raise simulator.");
        Console.WriteLine("Compare two employees' salaries before and after a 10% raise.");
        Console.WriteLine("\nEmployee 1 Information");

        // propmt user to input first name
        Console.Write("Enter the first name of Employee 1: ");
        fName = Console.ReadLine();

        // propmt user to input last name
        Console.Write("Enter the last name of Employee 1: ");
        lName = Console.ReadLine();

        // prompt user to enter salary
        Console.Write("Enter the monthly salary for Employee 1 (2512.34): ");
        salary = Convert.ToDecimal(Console.ReadLine());

        // create object for employee 1
        Employee person1 = new Employee(fName, lName, salary);

        // user info
        Console.WriteLine("\nEmployee 2 Information");

        // propmt user to input first name
        Console.Write("Enter the first name of Employee 2: ");
        fName = Console.ReadLine();

        // propmt user to input last name
        Console.Write("Enter the last name of Employee 2: ");
        lName = Console.ReadLine();

        // prompt user to enter salary
        Console.Write("Enter the monthly salary for Employee 2 (2512.34): ");
        salary = Convert.ToDecimal(Console.ReadLine());

        // create object for employee 2
        Employee person2 = new Employee(fName, lName, salary);

        // display yearly salary for each employee object
        Console.WriteLine("\nYearly Salary:");
        Console.WriteLine("Employee 1 ({0} {1}): {2:C}",
            person1.FirstName, person1.LastName, (person1.Salary * 12));
        Console.WriteLine("Employee 2 ({0} {1}): {2:C}",
            person2.FirstName, person2.LastName, (person2.Salary * 12));

        // display yearly salary after 10% raise
        Console.WriteLine("\nYearly Salary with 10% Raise:");
        Console.WriteLine("Employee 1 ({0} {1}): {2:C}",
            person1.FirstName, person1.LastName, (person1.Salary * 12 * 1.1M));
        Console.WriteLine("Employee 2 ({0} {1}): {2:C}",
            person2.FirstName, person2.LastName, (person2.Salary * 12 * 1.1M));
    } // end Main
} // end class EmployeeTest
