/*
 * Task: Allow the creation of objects that have attributes for first and
 *       last name, year of birth and current year. These attributes are used
 *       to determine the users age, max heart rate, min target heart rate,
 *       and max target heart rate.
 * Input: This class does not accept input directly, the user interacts with
 *        a test driver that deals with the input and then passes those values
 *        to an object of this class upon creation.
 * Output: This class does not output anything directly, the test driver
 *         calls the properties of this class to get values for an
 *         attribute of the object, which can be output in the test driver.
 * Operations: Declare the instance variables and thier properties, make sure
 *             that the integer instance variables can't be negative values.
 *             Declare the constructor for the class, it should initialize the
 *             instance variables when a new object is created. Create a
 *             property to calculate the users age, their max heart rate, their
 *             min target heart rate, and their max target heart rate.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HeartRates
{
    private string firstName,   // instance variable to hold first name
                   lastName;    // instance variable to hold last name
    private int birthYear,      // instance variable to hold year of birth
                currentYear;    // instance variable to hold current year

    // property for firstName instance varaible
    public string FirstName {
        get
        {
            return firstName;
        } // end get
        set
        {
            firstName = value;
        } // end set
    } // end property FirstName

    // property for lastName instance variable
    public string LastName {
        get
        {
            return lastName;
        } // end get
        set
        {
            lastName = value;
        } // end set
    } // end property LastName

    // property for birthYear instance variable
    public int BirthYear {
        get
        {
            return birthYear;
        } // end get
        set
        {
            // only change instance variable if value is positive
            if (value >= 0)
            {
                birthYear = value;
            } // end if
        } // end set
    } // end property BirthYear

    // property for currentYear instance variable
    public int CurrentYear {
        get
        {
            return currentYear;
        } // end get
        set
        {
            // only change instnace variable if value is positive
            if (value >= 0)
            {
                currentYear = value;
            } // end if
        } // end set
    } // end property CurrentYear

    // constructor for HeartRates class that initializes the instance variables
    public HeartRates(string fName, string lName, int bYear, int crntYear)
    {
        // initialize instance variables
        FirstName = fName;
        LastName = lName;
        BirthYear = bYear;
        CurrentYear = crntYear;
    } // end constructor HeartRates

    // property to return users age in years
    public int Age
    {
        get
        {
        return CurrentYear - BirthYear;
        } // end get
    } // end property Age

    // property to calculate and return max heart rate
    public int MaxHeartRate
    {
        get
        {
            return 220 - Age;
        } // end get
    } // end property MaxHeartRate

    // property to calculate and return min target heart rate
    public double MinTargetRate
    {
        get
        {
            return MaxHeartRate * 0.5;
        } // end get
    } // end property MinTargetRate

    // property to calculate and return max target heart rate
    public double MaxTargetRate
    {
        get
        {
            return MaxHeartRate * 0.85;
        } // end get
    } // end property MaxTargetRate
} // end class HeartRates
