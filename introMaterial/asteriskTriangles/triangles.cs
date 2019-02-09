/*
 * Task: Use for loops to create and print four different right
 *       triangles made from asterisks and space characters.
 * Input: None.
 * Output: Asterisks shaped in the form of four separate right
 *         triangles.
 * Operations: Use a for loop nested in another for loop to create
 *             the first and second triangles. The third and fourth
 *             triangles need two for loops nested in one outer for
 *             loop because the asterisks need to have spaces in front
 *             of them to shape them properly. One loop handles spaces
 *             and the other handles asterisks, the outer loop handles
 *             the number of columns of asterisks.
 */

using System;

namespace KillRowan_6._15
{
    class Triangles
    {
        static void Main(string[] args)
        {
            // display first triangle
            for(int firstRows = 0; firstRows < 10; ++firstRows)
            {
                // display asterisks
                for (int firstAstrsks = (10 - firstRows); firstAstrsks <= 10;
                    ++firstAstrsks)
                {
                    // output firstRows + 1 asterisks
                    Console.Write("*");
                } // end nested for

                // whitespace
                Console.WriteLine();
            } // end outer for

            // display second triangle
            for (int secondRows = 0; secondRows < 10; ++secondRows)
            {
                // whitespace
                Console.WriteLine();

                // for loop to place asterisks
                for (int secondAstrsks = secondRows; secondAstrsks < 10;
                    ++secondAstrsks)
                {
                    // output secondRows asterisks
                    Console.Write("*");
                } // end nested for
            } // end outer for

            // whitespace
            Console.WriteLine();

            // display third triangle
            for (int thirdRows = 10; thirdRows > 0; --thirdRows)
            {
                // whitespace
                Console.WriteLine();

                // for loop to place space characters before asterisks
                for(int thirdSpaces = 10; thirdSpaces > thirdRows;
                    --thirdSpaces)
                {
                    // output 10 - thirdRows spaces
                    Console.Write(" ");
                } // end first nested for loop

                // for loop to place asterisks in proper positions
                for (int thirdAstrsks = thirdRows; thirdAstrsks > 0;
                    --thirdAstrsks)
                {
                    // output thirdRows asterisks
                    Console.Write("*");
                } // end second nested for loop
            } // end for loop

            // whitespace
            Console.WriteLine();

            // display fourth triangle
            for (int fourthRows = 0; fourthRows < 10; ++fourthRows)
            {
                // whitespace
                Console.WriteLine();

                // for loop to place spaces
                // compare fourthSpaces - 1 to fourthRows to prevent
                // 1 extra space character from printing
                for(int fourthSpaces = 10; (fourthSpaces - 1) > fourthRows;
                    --fourthSpaces)
                {
                    // output fourthSpaces - 1 spaces
                    Console.Write(" ");
                } // end nested for loop

                // for loop to place asterisks
                for(int fourthAstrsks = fourthRows; fourthAstrsks >= 0;
                    --fourthAstrsks)
                {
                    // output fourthRows + 1 asterisks
                    // fouthRows = 0, print 1 asterisk
                    Console.Write("*");
                } // end nested for loop
            } // end outer for loop
        } // end Main
    } // end class Triangles
} // end namespace
