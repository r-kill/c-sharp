/*
 * Task: Display (int) type cast of A B C a b c 0 1 2 $ * + / and the space character.
 * Input: This program takes no input from the user.
 * Output: The output consists of each character mentioned above and 
 *         it's correcponding integer value in the ASCII table.
 * Operations: First tell the user what the program does.
 *             Start outputting the characters "A B C a b c 0 1 2 $ * + / (space)"
 *             along with their individual integer ASCII values.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillRowan_3._27
{
    class Program
    {
        static void Main(string[] args)
        {
            // tell user what program does
            Console.WriteLine("This program shows the integer values associated with these characters:");
            Console.WriteLine("A B C a b c 0 1 2 $ * + / and the space character.");

            // output each character and it's corresponding integer value
            Console.WriteLine("\nThe character {0} has the integer value {1}", 'A', ((int)'A'));
            Console.WriteLine("The character {0} has the integer value {1}", 'B', ((int)'B'));
            Console.WriteLine("The character {0} has the integer value {1}", 'C', ((int)'C'));
            Console.WriteLine("The character {0} has the integer value {1}", 'a', ((int)'a'));
            Console.WriteLine("The character {0} has the integer value {1}", 'b', ((int)'b'));
            Console.WriteLine("The character {0} has the integer value {1}", 'c', ((int)'c'));
            Console.WriteLine("The character {0} has the integer value {1}", '0', ((int)'0'));
            Console.WriteLine("The character {0} has the integer value {1}", '1', ((int)'1'));
            Console.WriteLine("The character {0} has the integer value {1}", '2', ((int)'2'));
            Console.WriteLine("The character {0} has the integer value {1}", '$', ((int)'$'));
            Console.WriteLine("The character {0} has the integer value {1}", '*', ((int)'*'));
            Console.WriteLine("The character {0} has the integer value {1}", '+', ((int)'+'));
            Console.WriteLine("The character {0} has the integer value {1}", '/', ((int)'/'));
            Console.WriteLine("The character {0} (space character) has the integer value {1}", ' ', ((int)' '));
        } // end Main
    } // end class Program
} // end namespace KillRowan_3.27
