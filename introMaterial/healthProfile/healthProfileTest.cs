/*
 * Task: Get users full name, gender, date of birth, height and weight,
 *       then use that information to calculate the users age in years,
 *       maximum heart rate, target heart rate range, and BMI and output
 *       the results.
 * Input: The user will need to input their first name, last name, gender,
 *        date of birth, height in inches and weight in pounds. The users
 *        name and gender are strings, the rest of the attributes are
 *        integers.
 * Output: The output is a health profile that contains the users name,
 *         gender, date of birth, height, weight, age in years, max heart
 *         rate, min and max target heart rates, the users BMI and a
 *         chart of BMI values. If the user entered any inaccurate info,
 *         the program will output an error message.
 * Operations: Initialize the variables to hold user information and output
 *             some information explaining what the app does. Propmt the
 *             user to input their first and last name, gender, date of
 *             birth (separated into month, day, and year), height in inches
 *             and weight in pounds. Create the HealthProfile object and
 *             initialize the attributes. Validate that the year, month,
 *             day, age, height and weight are positive integers. If that
 *             is true, output the full name, date of birth, height, weight,
 *             age in years, max heart rate, min target heart rate, max
 *             target heart rate, BMI and BMI values. Otherwise output an
 *             error message to the user.
 */

using System;

public class HealthProfileTest
{
    public static void Main(string[] args)
    {
        string firstName,   // variable to hold first name
               lastName,    // variable to hold last name
               gender;      // variable to hold gender
        int monthBorn,      // variable to hold month of birth
            dayBorn,        // variable to hold day of birth
            yearBorn,       // variable to hold year of birth
            height,         // variable to hold height in inches
            weight;         // variable to hold weight in pounds

        // user info
        Console.WriteLine("Welcome to the Health Profile Application.");
        Console.WriteLine("This application provides a health profile based on personal information.");
        Console.WriteLine("\nPersonal Information");

        // prompt user to input first name
        Console.Write("Enter your first name (John): ");
        firstName = Console.ReadLine();

        // prompt user to input last name
        Console.Write("Enter your last name (Doe): ");
        lastName = Console.ReadLine();

        // prompt user to input gender
        Console.Write("Enter your gender: ");
        gender = Console.ReadLine();

        // prompt user to input month of birth
        Console.WriteLine("\nMonth Numbers: Jan = 1, Dec = 12");
        Console.Write("Enter the month number of the month you were born: ");
        monthBorn = Convert.ToInt32(Console.ReadLine());

        // prompt user to input day of birth
        Console.Write("Enter the day number for the day you were born (1 to 31): ");
        dayBorn = Convert.ToInt32(Console.ReadLine());

        // prompt user to input year of birth
        Console.Write("Enter the year you were born (1970): ");
        yearBorn = Convert.ToInt32(Console.ReadLine());

        // prompt user to input height in inches
        Console.Write("Enter your height in inches (72): ");
        height = Convert.ToInt32(Console.ReadLine());

        // prompt user to input weight in pounds
        Console.Write("Enter your weight in pounds (175): ");
        weight = Convert.ToInt32(Console.ReadLine());

        // create HealthProfile object with attributes initialized to user input data
        HealthProfile profile1 = new HealthProfile(firstName, lastName, gender,
            monthBorn, dayBorn, yearBorn, height, weight);

        // output if info provided is accurate
        // age, month born, day born, year born, height, weight all need to be positive
        // month born and day born have upper limits - handled in HealthProfile
        // use AND (&&) because it's the same as nesting if statements
        if(profile1.Age > 0 && profile1.MonthBorn > 0 && profile1.DayBorn > 0 &&
            profile1.YearBorn > 0 && profile1.Height > 0 && profile1.Weight > 0)
        {
            // user info
            Console.WriteLine("\nHealth Profile");

            // display users first name, last name, gender, year of birth
            Console.WriteLine("\tName: {0} {1}", profile1.FirstName, profile1.LastName);
            Console.WriteLine("\tGender: {0}", profile1.Gender);
            Console.WriteLine("\tDate of Birth (mm/dd/yyyy): {0}/{1}/{2}",
                profile1.MonthBorn, profile1.DayBorn, profile1.YearBorn);

            // display users age
            Console.WriteLine("\tAge: {0} years", profile1.Age);

            // display users height and weight
            Console.WriteLine("\tHeight: {0} inches", profile1.Height);
            Console.WriteLine("\tWeight: {0} pounds", profile1.Weight);

            // display users max heart rate
            Console.WriteLine("\tMaximum Heart Rate: {0} beats per minute",
                profile1.MaxHeartRate);

            // display users target heart rate range
            Console.WriteLine("\tMinimum Target Heart Rate: {0} beats per minute",
                profile1.MaxTargetRate);
            Console.WriteLine("\tMaximum Target Heart Rate: {0} beats per minute",
                profile1.MinTargetRate);

            // display users BMI with BMI Values table
            Console.WriteLine("\tBody Mass Index (BMI) = {0}", profile1.BMI);
            Console.WriteLine("\nBMI VALUES");
            Console.WriteLine("\tUnderweight: less than 18.5");
            Console.WriteLine("\tNormal:      between 18.5 and 24.9");
            Console.WriteLine("\tOverweight:  between 25 and 29.9");
            Console.WriteLine("\tObese:       30 or greater");
        }
        else
        {
            // inform user that there was an error with the inputs
            Console.WriteLine("\nOne or more of the values entered is incorrect.");
            Console.Write("Your health profile could not be completed ");
            Console.WriteLine("using the information provided.");
        } // end if else
    } // end Main
} // end class HealthProfileTest
