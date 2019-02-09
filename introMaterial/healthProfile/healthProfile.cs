/*
 * Task: Allow the creation of objects that have attributes for first and
 *       last name, gender, date of birth with an attribute for the day,
 *       month and year, height, and weight. The constructor for this
 *       class will initialize all of the attributes. There are properties
 *       that calculate the users age, max heart rate, min target heart rate,
 *       max target heart rate and BMI.
 * Input: This class does not accept input directly, the user interacts with
 *        a test driver that deals with the input and then passes those values
 *        to an object of this class upon creation.
 * Output: This class does not output anything directly, the test driver
 *         calls the properties of this class to get values for an
 *         attribute of the object, which can be output by the test driver.
 * Operations: Declare the instance variables and thier properties, make sure
 *             that the integer instance variables can't be negative values,
 *             also make sure that the value for month born is between 1
 *             and 12 and the value for day born is between 1 and 31. Declare
 *             the constructor for the class, it should initialize the
 *             instance variables when a new object is created. Create a
 *             property to calculate the users age, their max heart rate, their
 *             min target heart rate, and their max target heart rate. Finally,
 *             calculate the BMI for the user.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HealthProfile
{
    private string firstName,   // instance variable to hold first name
                   lastName,    // instance variable to hold last name
                   gender;      // instance variable to hold gender
    private int monthBorn,      // instance variable to hold month of birth
                dayBorn,        // instance variable to hold day of birth
                yearBorn,       // instance variable to hold year of birth
                height,         // instance variable to hold height in inches
                weight;         // instance variable to hold weight in pounds

    // property for instance variable firstName
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

    // property for instance variable lastName
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

    // property for instance variable gender
    public string Gender {
        get
        {
            return gender;
        } // end get
        set
        {
            gender = value;
        } // end set
    } // end property Gender

    // property for instance variable monthBorn
    public int MonthBorn {
        get
        {
            return monthBorn;
        } // end get
        set
        {
            // don't change variable unless value is between 1 and 12
            if(value >= 1 && value <= 12)
            {
                monthBorn = value;
            } // end if
        } // end set
    } // end property MonthBorn

    // property for instance variable dayBorn
    public int DayBorn {
        get
        {
            return dayBorn;
        } // end get
        set
        {
            // don't change variable unless value is between 1 and 31
            if(value >= 1 && value <= 31)
            {
                dayBorn = value;
            } // end if
        } // end set
    } // end property DayBorn

    // property for instance variable yearBorn
    public int YearBorn {
        get
        {
            return yearBorn;
        } // end get
        set
        {
            // don't change variable if value is negative
            if(value >= 0)
            {
                yearBorn = value;
            } // end if
        } // end set
    } // end property YearBorn

    // property for instance variable height
    public int Height {
        get
        {
            return height;
        } // end get
        set
        {
            // don't change variable if value is negative
            if(value >= 0)
            {
                height = value;
            } // end if
        } // end set
    } // end property Height

    // property for instance variable weight
    public int Weight {
        get
        {
            return weight;
        } // end get
        set
        {
            // don't change variable if value is negative
            if(value >= 0)
            {
                weight = value;
            } // end if
        } // end set
    } // end property Weight

    // constructor for class HealthProfile, initializes instance variables
    public HealthProfile(string fName, string lName, string gender,
        int mBorn, int dBorn, int yBorn, int height, int weight)
    {
        FirstName = fName;  // use property to set firstName instance var to fName
        LastName = lName;   // use property to set lastName instance var to lName
        Gender = gender;    // use property to set gender instance var to gender
        MonthBorn = mBorn;  // use property to set monthBorn instance var to mBorn
        DayBorn = dBorn;    // use property to set dayBorn instance var to dBorn
        YearBorn = yBorn;   // use property to set yearBorn instance var to yBorn
        Height = height;    // use property to set height instance var to height
        Weight = weight;    // use property to set weight instance var to weight
    } // end constructor HealthProfile

    // property to return users age in years
    public int Age
    {
        get
        {
            // create new DateTime object to find current year
            DateTime findYear = DateTime.Now;

            // calculate age and return result
            return findYear.Year - YearBorn;
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

    // property to calculate BMI
    public double BMI
    {
        get
        {
            return (Weight * 703) / (Height * Height);
        } // end get
    } // end property BMI
} // end class HealthProfile
