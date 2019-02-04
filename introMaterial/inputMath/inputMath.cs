/*
 * Task: Calculate the sum, average and product of the input values.
 *       Also, determine the highest and lowest values out of the three inputs.
 *       Output these results to the user.
 * Input: The user will enter three integer values.
 * Output: The program outputs the sum of those values, their average, and
 *         the product of those values multiplied together. The highest and
 *         lowest of the input values are also output.
 * Operations: The first step is to declare all the variables, in this case they are all integers.
 *             Then get the input values from the user and calculate the sum.
 *             The sum is used to determine the average because we know that the user
 *             is only supposed to enter 3 values.
 *             Calculate the product of the values multiplied together. 
 *             Find which of the three values is lowest by comparing all three values.
 *             Determine which of the remaining two values is larger to find the highest value.
 *             Output the results to the user.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillRowan_3._17
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1,       // first number from user
                num2,       // second number from user
                num3;       // third number from user
            int sum,        // variable to hold the sum of the inputs
                avg,        // variable to hold the average of the inputs
                product,    // variable to hold the result of multiplying the inputs
                high = 0,   // variable to hold the largest number
                low = 0;    // variable to hold the smallest number

            // prompt user to enter the first of three integers
            Console.Write("Enter the first integer: ");
            num1 = Convert.ToInt32(Console.ReadLine());

            // prompt user to enter second of three integers
            Console.Write("Enter the second integer: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            // prompt user to enter third of three integers
            Console.Write("Enter the third integer: ");
            num3 = Convert.ToInt32(Console.ReadLine());

            // calculate the sum, average and product of the inputs
            sum = num1 + num2 + num3;
            avg = sum / 3;
            product = num1 * num2 * num3;

            // find highest and lowest input values
            if((num1 <= num2) && (num1 <= num3))
            {
                low = num1;
                if(num2 < num3)
                {
                    high = num3;
                }
                else
                {
                    high = num2;
                } // end of if/else that determines num2 is highest if num3 isn't
            } // end of if statement to determine high and low if num1 is lowest

            if((num2 <= num1) && (num2 <= num3))
            {
                low = num2;
                if (num1 < num3)
                {
                    high = num3;
                }
                else
                {
                    high = num1;
                } // end of if/else that determines num1 is highest if num3 isn't
            } // end of if statement to determine high and low if num2 is lowest

            if ((num3 <= num1) && (num3 <= num2))
            {
                low = num3;
                if (num2 < num1)
                {
                    high = num1;
                }
                else
                {
                    high = num2;
                } // end of if/else that determines num2 is highest if num1 isn't
            } // end of if statement to determine high and low if num3 is lowes
            
            // output results of calculations
            Console.WriteLine("\nThe sum {0} + {1} + {2} = {3}", num1, num2, num3, sum);
            Console.WriteLine("The average ({0} + {1} + {2}) / 3 = {3}", num1, num2, num3, avg);
            Console.WriteLine("The product {0} * {1} * {2} = {3}", num1, num2, num3, product);
            Console.WriteLine("The lowest value that was input = {0}", low);
            Console.WriteLine("The highest value that was input = {0}", high);
        } // end Main
    } // end class Program
} // end namespace KillRowan_3.17
