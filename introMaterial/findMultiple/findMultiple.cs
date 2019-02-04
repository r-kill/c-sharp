/*
 * Task: Ask user to input two integers and check if the first integer is a multiple of the second integer.
 * Input: The user will input two integer values.
 * Output: The output tells the user if the first number is a multiple of the second number
 *         and identifies which numbers were used.
 * Operations: Declare the variables to hold the input values and tell the user what the program does.
 *             Get input from the user and convert it to integer data type.
 *             If the first number is 0, then it is a multiple of the second number.
 *             If the second number is 0, then the first number is not a multiple of the second,
 *             unless the first number is 0 as well.
 *             The first will be a multiple of the second if the absolute value of the first number
 *             is larger than the absolute value of the second number and the two numbers can divide
 *             into each other evenly, without a remainder. Otherwise, the first number is not
 *             a multiple of the second.
 *             Output is shown to the user along the way, either stating that the first number
 *             is or is not a multiple of the second number.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillRowan_3._25
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1,   // variable to store the first integer
                num2;   // variable to store the second integer

            // tell the user what the program does
            Console.WriteLine("This program takes two integer inputs and determines if");
            Console.WriteLine("the FIRST integer is a multiple of the SECOND integer.");

            // prompt user to input first integer
            Console.Write("\nEnter the first integer: ");
            num1 = Convert.ToInt32(Console.ReadLine());

            // prompt user to input second integer
            Console.Write("Enter the second integer: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            // determine whether first number is a multiple of the second number
            // zero is a multiple of every number, but only 0 is a multiple of 0
            if (num1 == 0)
            {
                Console.WriteLine("\nThe number {0} is a multiple of {1}", num1, num2);
            }
            else if(num2 == 0)
            {
                Console.WriteLine("\nThe number {0} is not a multiple of {1}", num1, num2);
            }
            else if ((num1 == 0) && (num2 == 0))
            {
                Console.WriteLine("\nThe number {0} is a multiple of {1}", num1, num2);
            }
            else if((num1 % num2 == 0) && (Math.Abs(num1) >= Math.Abs(num2)))
            {
                Console.WriteLine("\nThe number {0} is a multiple of {1}", num1, num2);
            }
            else
            {
                Console.WriteLine("\nThe number {0} is not a multiple of {1}", num1, num2);
            } // end if/elseif/else statement to determine if num1 is a multiple of num2
        } // enda Main
    } // end class Program
} // end namespace KillRowan_3.25
