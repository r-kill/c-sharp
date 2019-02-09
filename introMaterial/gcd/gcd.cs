/*
 * Task: Ask the user to input two integers and find the GCD of those values.
 * Input: The user will input the two integers or <Ctrl> z to exit the program.
 * Output: The program outputs the GCD of the two integer inputs and some user
 *         information.
 * Operations: Declare variables to hold the users input and the two numbers that
 *             the user enters. Display some user information. Ask for the first input
 *             and verify it's not the sentinel value before converting it to an integer
 *             and assigning that value to one of the variables. Then get the second
 *             input from the user and, if it's not the sentinel condition, convert it
 *             to an integer value and assign it to the other variable. Then start the
 *             output for the results, in the output statement is the call to the GCD
 *             method with the users inputs as arguments. The GCD is found recursively
 *             by comparing the first two inputs and passing the second integer as an
 *             argument along with the expression (firstInt % secondInt) as the second
 *             argument. The next recursion compares the result of the previous modulus 
 *             and the result of the expression (secondInt % (firstInt % secondInt)),
 *             the third compares the last expression and the expression
 *             ((firstInt % secondInt) % (secondInt % (firstInt % secondInt))). This
 *             process repeats until the second argument is 0, which makes the first
 *             argument the GCD because the arguments now divide into each other evenly.
 *             Once the output is displayed, the user input is checked to make sure it's
 *             not the sentinel value and the process is repeated until the user enters
 *             the sentinel value.
 */

using System;

namespace KillRowan_7._27
{
    class Divisor
    {
        static void Main(string[] args)
        {
            string userInput;   // variable to hold the users input
            int firstNum,       // variable to hold integer value of first input
                secondNum;      // variable to hold integer value of second input

            // user info
            Console.WriteLine("This program finds the GCD of two integers.");

            // repeat process until user enters sentinel value
            do
            {
                // get first integer from user
                Console.Write("\nEnter the first integer or <Ctrl> z to exit: ");
                userInput = Console.ReadLine();

                // if user doesn't want to exit, convert the first input to an integer
                // and get user input for second int
                if (userInput != null)
                {
                    // convert first value to an integer
                    firstNum = Convert.ToInt32(userInput);

                    // get second integer from user
                    Console.Write("Enter the second integer or <Ctrl> z to exit: ");
                    userInput = Console.ReadLine();

                    // verify user doesn't want to exit again
                    if (userInput != null)
                    {
                        // convert second input to integer value
                        secondNum = Convert.ToInt32(userInput);

                        // output GCD
                        Console.WriteLine("\nThe GCD of {0} and {1} is {2}",
                                           firstNum, secondNum,
                                           GCD(firstNum, secondNum));
                    } // end nested if
                } // end outer if
            } while (userInput != null);    // end do while
        } // end Main

        // method to calculate the GCD of two integers
        public static int GCD(int first, int second)
        {
            // find GCD recursively
            if(second == 0)
                // return absolute value because if -2 divides first and second then
                // +2 divides both as well
                return Math.Abs(first);
            else
                // call GCD again with second and result of first % second (remainder)
                // because second will eventually reach 0 from successive modulus
                // in which case first will contain the GCD
                return GCD(second, first % second);
        } // end method GCD
    } // end class Divisor
} // end namespace
