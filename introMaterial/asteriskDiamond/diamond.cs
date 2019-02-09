/*
 * Task: Ask the user to input the number of rows they want in a diamond made
 *       of asterisks. Then output an asterisk diamond that has the same
 *       number of rows.
 * Input: The user is asked to input an odd integer value that specifies the
 *        number of rows in the diamond. This value should be between 1 and 19,
 *        inclusive.
 * Output: Asterisks in the shape of a diamond with anywhere between 1 and 19
 *         rows of asterisks, excluding even numbers.
 * Operations: Inform the user what they will need to input and what the program
 *             does. Get the number of rows from the user and verify that it's
 *             within the 1 to 19 range and is an odd number. If it doesn't
 *             meet that criteria, then ask for a different number. Initialize
 *             variables with the input provided. Print the top half of the
 *             diamond first, including the middle row. This requires an outer
 *             for loop and two nested for loops; the outer loop handles the
 *             number of rows to print, the first inner loop prints the spaces
 *             needed before the asterisks and the second inner loop prints
 *             the asterisks. Adjust the variables accordingly and use 3 new
 *             loops for the bottom half of the diamond. The loops serve the
 *             same purposes as the previous three, but the number of spaces
 *             printed is incremented and the number of asterisks is decremented.
 */

using System;

namespace KillRowan_6._24
{
    class Diamond
    {
        static void Main(string[] args)
        {
            // declare variables
            string rows;        // stores number of rows user wants in diamond
            int intRows,        // stores integer value of input for rows
                count,          // counter to handle spacing
                botCount = 0;
            // botCount controls the number of asterisks printed for the
            // bottom half of the diamond

            // tell user to enter number of rows for diamond, between 1 and 19 rows
            Console.WriteLine("This program creates a diamond out of asterisks.");
            Console.WriteLine("You choose how many rows of asterisks will be");
            Console.WriteLine("used to make up the diamond.");
            Console.WriteLine("There can only be between 1 and 19 rows, inclusive.");
            Console.WriteLine("The number of rows MUST be an odd number.");

            // get number of rows from user
            Console.Write("\nRows: ");
            rows = Console.ReadLine();

            // make sure user enters a proper value for number of rows
            // must be between 1 and 19, must be odd
            while((Convert.ToInt32(rows) < 1) || (Convert.ToInt32(rows) > 19) ||
                (Convert.ToInt32(rows) % 2 == 0))
            {
                // get new number of rows from user
                Console.WriteLine("There was a problem with your input." +
                    " Enter a new value for Rows.");
                Console.Write("Rows: ");
                rows = Console.ReadLine();
            } // end while

            // make rows variable an int value
            intRows = Convert.ToInt32(rows);

            // initialize count variable
            count = intRows / 2;

            // whitespace
            Console.WriteLine();

            // display top half with mid row of diamond
            // use intRows / 2 + 1 because this is actually the top 55%
            // so 9 rows total means that the top 55% is 5 rows.
            // top half of diamond including middle row
            for(int topRows = 1; topRows <= intRows / 2 + 1; ++topRows)
            {
                // print spaces before asterisks
                for(int topSpace = 1; topSpace <= count; ++topSpace)
                {
                    // print spaces for top half
                    Console.Write(" ");
                } // end for

                // decrement count so number of spaces printed is decremented
                --count;

                /*
                 * 2 * topRows - 1
                 * Subtract 1 to keep values odd
                 * Multiply by 2 because the diamond is just two right triangles
                 * that share the same edge on the Y axis, no multiplication means
                 * only one quarter of the diamond in printed (half of the top half)
                 */
                // display top asterisks
                for (int topAstrsk = 1; topAstrsk <= 2 * topRows - 1; ++topAstrsk)
                {
                    // print asterisks for top half
                    Console.Write("*");
                } // end for

                // whitespace
                Console.Write("\n");
            } // end outer for


            // reset count because the bottom half of the triangle needs
            // space characters to incrementally increase
            count = 1;

            // display bottom half of diamond, exclude middle row
            // use half the number of rows input because this is the
            // bottom half of the diamond
            for(int botRows = 1; botRows <= intRows / 2; ++botRows)
            {
                // print 1 space on the first line after the mid row
                // print 2 spaces on next line, etc...
                for(int botSpace = 1; botSpace <= count; ++botSpace)
                {
                    // print spaces for the bottom half of the diamond
                    Console.Write(" ");
                } // end for

                // increment the number of spaces placed before asterisks
                ++count;

                /*
                 * (intRows - botRows - botCount)
                 * Multiply by 2 so both quarters of the bottom half print.
                 * Subtract a and botCount so the number of asterisks decrements
                 * properly for the bottom half.
                 */
                // print asterisks for bottom half
                for (int botAstrsks = 1;
                    botAstrsks < (intRows - botRows - botCount);
                    ++botAstrsks)
                {
                    Console.Write("*");
                } // end nested for

                // increment botCount so that the number of asterisks in the
                // bottom half decrements properly, each row in bottom has 2
                // less asterisks than the row above it
                ++botCount;

                // whitespace
                Console.Write("\n");
            } // end outer for
        } // end Main
    } // end class Diamond
} // end namespace
