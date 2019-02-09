/*
 * Task: Calculate the amount of money on deposit for each year
 *       in a 10 year period, the principle is $1000. The calculation
 *       is done using an interest rate that starts at 5% and goes
 *       up to 10% incrementally.
 * Input: None.
 * Output: The output contains the year and the amount on deposit
 *         for that year after applying the interest rate for that period.
 *         The user is also told what the current interest rate is.
 * Operations: Declare variables to hold the amount on deposit and
 *             the principle, initialize the principle. An outer for
 *             loop is used to modify the interest rate as needed,
 *             another for loop is nested in the outer for loop which
 *             calculates the amount per year for 10 years and
 *             outputs those values in a table format. The same
 *             process repeats for each interest rate.
 */

using System;

class Interest
{
    public static void Main(string[] args)
    {
        // declare variables
        decimal amount,             // amount on deposit at end of year
                principle = 1000M;  // initial amount before interest

        // calculate amount on deposit with varying interest rates for a 10 year period
        for(double rate = 0.05;  rate <= .1; rate += 0.01)
        {
            // display headers and interest rate
            Console.WriteLine("Interest Rate = {0:P}\nYear{1, 20}",
                rate,
                "Amount on deposit");

            // calculate amount on deposit for each year
            for (int year = 1; year <= 10; ++year)
            {
                // calculate new amount for current year
                amount = principle * (decimal)Math.Pow(1.0 + rate, year);

                // display year and amount
                Console.WriteLine("{0, 4}{1, 20:C}", year, amount);
            } // end nested for

            // output blank line between tables for each interest rate
            Console.WriteLine();
        } // end outer for
    } // end Main
} // end class Interest
