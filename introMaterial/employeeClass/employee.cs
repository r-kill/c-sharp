/*
 *  Task: Get information about two employees so it can be
 *        used to compare them.
 *  Input: The user will set the values of instance variables
 *         for the first name, last name, and salary of an
 *         employee. The first and last name will be a string
 *         and the monthly salary will be a decimal.
 *  Output: The test driver for this class outputs values from
 *          objects of this class. The first name, last name,
 *          and yearly salary of each employee is output with
 *          and without a 10% raise.
 *  Operations: Create the salary instance varaible and it's
 *              constructor, which won't change the value of
 *              the instance variable unless the value provided
 *              is at least zero. Create two auto-implemented
 *              properties for the first and last name instance
 *              variables. Create a constructor for the 
 *              Employee class that initializes the three
 *              instance variables.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Employee
{
    private decimal salary;    // instance variable to hold monthly salary

    // property to get and set salary instance varaible
    public decimal Salary {
        get
        {
            return salary;
        } // end get
        set
        {
            // salary should remain unchanged if value is negative
            if (value >= 0)
                salary = value;
        } // end set
    } // end Salary constructor

    // auto-implemented property for first name
    public string FirstName { get; set; }

    // auto-implemented property for last name
    public string LastName { get; set; }

    // constructor for class Employee
    public Employee(string firstName, string lastName, decimal salary)
    {
        Salary = salary;        // set salary instance variable using property
        FirstName = firstName;  // set firstName instance variable using property
        LastName = lastName;    // set lastName instance variable using property
    } // end constructor Employee
} // class Employee
