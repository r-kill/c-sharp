/*
 * Task: Print various shapes on the screen using asterisks.
 * Input: None.
 * Output: Asterisks in the shape of a square, circle, arrow and diamond.
 * Operations: The program first prints one blank line for readability.
 *             After, the program prints the asterisks using nine WriteLine calls
 *             and careful asterisk placement.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillRowan_3._18
{
    class Program
    {
        static void Main(string[] args)
        {
            // print one blank line before printing ASCII shapes for readability
            Console.WriteLine();

            // print asterisks
            Console.WriteLine("*********     ***       *         *");
            Console.WriteLine("*       *   *     *    ***       * *");
            Console.WriteLine("*       *  *       *  *****     *   *");
            Console.WriteLine("*       *  *       *    *      *     *");
            Console.WriteLine("*       *  *       *    *     *       *");
            Console.WriteLine("*       *  *       *    *      *     *");
            Console.WriteLine("*       *  *       *    *       *   *");
            Console.WriteLine("*       *   *     *     *        * *");
            Console.WriteLine("*********     ***       *         *");
        } // end Main
    } // end class Program
} // end namespace KillRowan_3.18
