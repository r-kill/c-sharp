/*
 * Task: Ask the user to input a number and output that number rounded to
 *       various decimal places.
 * Input: The user will input a number to be rounded or <Ctrl> z to exit the program.
 * Output: The output will display the users input and that input rounded to the 
 *         nearest integer, to the nearest tenth,
 *         to the nearest hundredth and thousandth decimal places.
 * Operations: Declare the variables for the user input, display some user information
 *             and get the number input from the user. If the user does not enter the
 *             sentinel value, convert the input to a double value and assign it to one
 *             of the double variables. Output the users number and then call the method
 *             to round the users number to the nearest integer value. Assign the return
 *             value to the temp variable and output it. Repeat the process of calling
 *             the method, assigning the return to temp and outputting for the methods
 *             that round the number to the tenths, hundredths and thousandths
 *             positions. Ask the user if they want to enter another number to round
 *             or exit the program and get that input. If the user enters another
 *             number, repeat the whole process again from outputting the users number.
 */

using System;

namespace KillRowan_7._10
{
    class Rounding
    {
        static void Main(string[] args)
        {
            string inputNum;    // declare variable for input value
            double round = 0,   // declare variable for number to round
                   temp;        // declare variable to hold method returns

            // display user info
            Console.WriteLine("This program rounds a given number to various " +
                              "decimal places.");
            
            // get user input for the number to round
            Console.Write("\nEnter a number to round or <Ctrl> z to exit: ");
            inputNum = Console.ReadLine();

            // while the user doesn't want to quit, round the number and continue
            while(inputNum != null)
            {
                // change input type
                round = Convert.ToDouble(inputNum);

                // output original number
                Console.WriteLine("\nYour number: " + round);

                // round double variable with methods and output results
                // use format specifiers to force proper number of digits after decimal
                temp = RoundToInt(round);
                Console.WriteLine("\nRounded to the nearest Integer: {0}", temp);
                temp = RoundToTen(round);
                Console.WriteLine("Rounded to the nearest Tenth: {0:F1}", temp);
                temp = RoundToHundred(round);
                Console.WriteLine("Rounded to the nearest Hundredth: {0:F2}", temp);
                temp = RoundToThousand(round);
                Console.WriteLine("Rounded to the nearest Thousandth: {0:F3}", temp);

                // ask user for new number to round
                Console.Write("\nEnter a number to round or <Ctrl> z to exit: ");
                inputNum = Console.ReadLine();
            } // end while
        } // end Main

        // method to round a double argument to the nearest integer value
        public static int RoundToInt(double intNum)
        {
            // return rounded result
            // add .5 to make sure it is not able to round up
            return (int) Math.Floor(intNum + .5);
        } // end method RoundToInt

        // method to round a double argument to the nearest tenth
        public static double RoundToTen(double tenNum)
        {
            // return rounded result
            // multiply by 10 to shift decimal place to the right
            // add .5 to make sure it can't round up
            // divide by 10 to move decimal place back to ones position
            return Math.Floor(tenNum * 10 + .5) / 10;
        } // end method RoundToTen

        // method to round a double argument to the nearest hundredth
        public static double RoundToHundred(double hundredNum)
        {
            // return rounded result
            // multiply by 100 to shift decimal place right
            // add .5 to make sure it can't round up
            // divide by 100 to move decimal place back to ones position
            return Math.Floor(hundredNum * 100 + .5) / 100;
        } // end method RoundToHundred

        // method to round a double argument to the nearest thousandth
        public static double RoundToThousand(double thousandNum)
        {
            // return rounded result
            // multiply by 1000 to shift decimal place right
            // add .5 to make sure it can't round up
            // divide by 1000 to move decimal place back to ones position
            return Math.Floor(thousandNum * 1000 + .5) / 1000;
        } // end method RoundToThousand
    } // end class Rounding
} // end namespace
