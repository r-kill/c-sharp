/*
 * Task: Provide user with information about their max heart rate, their
 *       max and min target heart rates, their age and their name. This
 *       info is determined by user inputs.
 * Input: The user will input their full name as two strings, the year
 *        that the user was born as an integer, and the current year as
 *        an integer.
 * Output: The users name and year of birth are output along with the age
 *         of the user and the max heart rate, min target heart rate, and
 *         max target heart rate
 * Operations: Initialize variables and output some basic user info. Ask
 *             user to enter first and last names and store them in
 *             separate variables. Ask the user to input the year they
 *             were born and the current year, store those values as
 *             integers in separate variables. Create the HeartRates
 *             object and initialize the attributes with the values
 *             provided by the user. Output the users name, year of birth,
 *             age, max heart rate, max target heart rate and min target
 *             heart rate only if the user has entered proper values
 *             for the years, otherwise output an error statement that
 *             explains what happened.
 */

using System;

public class HeartRatesTest
{
    public static void Main(string[] args)
    {
        string firstName,   // variable to hold users first name
               lastName;    // variable to hold users last name
        int birthYear,      // variable to hold the year of users birth
            currentYear;    // variable to hold the current year
        
        // user info
        Console.WriteLine("Welcome to the heart rate calculator application.");
        Console.WriteLine("\nPersonal Information");
        // prompt user to enter first name
        Console.Write("Enter your first name: ");
        firstName = Console.ReadLine();

        // prompt user to enter last name
        Console.Write("Enter your last name: ");
        lastName = Console.ReadLine();

        // propmt user to enter birth year
        Console.Write("Enter the year you were born (1970): ");
        birthYear = Convert.ToInt32(Console.ReadLine());

        // prompt user to enter current year
        Console.Write("Enter the current year (2017): ");
        currentYear = Convert.ToInt32(Console.ReadLine());

        // initialize HeartRate class object
        HeartRates rates = new HeartRates(firstName, lastName, birthYear, currentYear);

        // output info if user entered proper year values
        // both year values should be positive and current year should be greater
        // than birth year
        if (rates.BirthYear > 0 && rates.CurrentYear > 0 &&
            rates.CurrentYear > rates.BirthYear)
        {
            // user info
            Console.WriteLine("\nHeart Rate Information");

            // display users first name, last name, year of birth
            Console.WriteLine("\tName: {0} {1}", rates.FirstName, rates.LastName);
            Console.WriteLine("\tYear of Birth: {0}", rates.BirthYear);

            // display users age
            Console.WriteLine("\tAge: {0} years", rates.Age);

            // display users max heart rate
            Console.WriteLine("\tMaximum Heart Rate: {0} beats per minute",
                rates.MaxHeartRate);

            // display users target heart rate range
            Console.WriteLine("\tMinimum Target Heart Rate: {0} beats per minute",
                rates.MaxTargetRate);
            Console.WriteLine("\tMaximum Target Heart Rate: {0} beats per minute",
                rates.MinTargetRate);
        }
        else
        {
            // inform user that there was an error with the inputs
            Console.WriteLine("\nThe value you entered for either your year of");
            Console.WriteLine("birth, the current year, or both, is incorrect.");
            Console.WriteLine("Your heart rates could not be determined from the information provided.");
        } // end if else
    } // end Main
} // end class HeartRatesTest
