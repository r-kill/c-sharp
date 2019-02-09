/*
 * Task: Generate a random number between 1 and 1000 and ask the user to try to guess
 *       that number. The user can stop guessing and quit at any point.
 * Input: The user is going to enter either a number between 1 and 1000 or the sentinel
 *        value to quit.
 * Output: The program will let the user know if their guess is too high or too low if
 *         they don't enter the correct number. If the correct number is input, the
 *         program congratulates the user and asks them if they want to play again.
 * Operations: Declare the variables and generate the first random number. Ask the user
 *             to input their guess or the sentinel value. Then, as long as the user
 *             doesn't enter the sentinel value, convert the input to an integer and make
 *             sure it's not equivalent to the random number. Analyze the input and tell
 *             the user if their guess was too high or too low, then get the next guess
 *             from the user and convert it to an integer. Repeat the analysis process
 *             until the user enters the correct number or the sentinel value. Once the
 *             correct number is input, congratulate the user, generate a new random
 *             number, tell the user that a new number has been generated and ask for
 *             another guess or the sentinel value to quit.
 */

using System;

namespace KillRowan_7._30
{
    class GuessTheNumber
    {
        static void Main(string[] args)
        {
            string userInput;   // variable to hold user input
            int randInt,        // variable to hold random number
                userInt;        // variable to hold user input as integer value

            // create new random object
            Random randomNumber = new Random();

            // choose random number
            randInt = randomNumber.Next(1, 1001);

            // ask user to guess number and get input
            Console.Write("Guess a number between 1 and 1000 or <Ctrl> z to exit: ");
            userInput = Console.ReadLine();

            // allows user to play game again
            while(userInput != null)
            {
                // convert userInput to int
                userInt = Convert.ToInt32(userInput);

                // user keeps guessing until the correct number is entered
                while ((userInt != randInt) && (userInput != null))
                {
                    // tell user if they're too high or too low
                    if (userInt < randInt)
                    {
                        // tell user they're too low and get new input
                        Console.Write("\nToo low. Try again or <Ctrl> z to exit: ");
                        userInput = Console.ReadLine();
                    }
                    else if (userInt > randInt)
                    {
                        // tell user they're too high and get new input
                        Console.Write("\nToo high. Try again or <Ctrl> z to exit: ");
                        userInput = Console.ReadLine();
                    } // end nested if else

                    // convert new input to integer before it's evaluated by while loop
                    userInt = Convert.ToInt32(userInput);
                } // end nested while

                // make sure user didn't quit before guessing the correct number
                if(userInput != null)
                {
                    // tell the user if they've guessed the correct number
                    Console.WriteLine("\nCongratulations." +
                                      " You guessed the right number!");

                    // generate new random number in case user wants to continue
                    randInt = randomNumber.Next(1, 1001);

                    // give user option to continue or exit and get input
                    Console.WriteLine("\nA new random number has been generated.");
                    Console.Write("Guess a number between 1 and 1000 or <Ctrl> z to" + 
                                  " exit: ");
                    userInput = Console.ReadLine();
                } // end nested if
            } // end outer while
        } // end Main
    } // end class GuessTheNumber
} // end namespace
