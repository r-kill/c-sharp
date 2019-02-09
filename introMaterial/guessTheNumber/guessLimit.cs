/*
 * Task: Generate a random number between 1 and 1000 and ask the user to try to guess 
 *       that number. The user will be able to quit at any point. See if the user can
 *       guess the correct number in at most 10 tries.
 * Input: The user is going to input either the number they want to guess or the sentinel
 *        value to quit.
 * Output: The output consists of telling the user if their guess was too high or too
 *         low, congratulating the user for guessing the correct number along with the
 *         number of guesses it took, and then informing the user if they can guess the
 *         correct number in fewer guesses or not. The user should be able to guess the
 *         correct number in at most 10 tries because the program tells the user if they
 *         are too high or too low. If guessing 500 as first guess (half of 1000, the
 *         highest value possible), the program tells the user that the number is either
 *         in the range 1 - 499 or 501 - 1000 (higher or lower), which confirms that the
 *         number is in one of those two ranges and not the range 1 - 1000. The user can
 *         continue halving the sample size by guessing the number that's half of the max
 *         possible value (example: 500, 250, 125, 67, 33, 16, 8, 4, 2). This method will
 *         narrow the range of possible values until the correct value is obvious.
 * Operations: Declare the variables and generate a random number between 1 and 1000. Ask
 *             the user to enter their first guess or the sentinel value to quit, count
 *             that guess. While the input isn't the sentinel value, convert it to an
 *             integer and tell the user whether the number is too low or too high as 
 *             long as it isn't the correct number. Ask the user to guess again if they
 *             didn't guess the correct number and, if the user didn't enter the sentinel
 *             value, convert the input to an integer and count the guess. When the user
 *             enters the correct number, congratulate them and provide the number of
 *             guesses it took. If the user needed more than ten guesses, tell them they
 *             can do better. If the user needed exactly ten guesses then they used the
 *             method described above and the program tells the user that they knew the
 *             method. If the user needed fewer than ten guesses the program tells them
 *             that they either got lucky or knew the method. The program then generates
 *             a new random number, informs the user that a new number was generated, and
 *             asks the user to try to guess the new number. The guess counter is reset
 *             and that guess is counted as the first guess of the next round.
 */

using System;

namespace KillRowan_7._31
{
    class GuessTheNumberVersion2
    {
        static void Main(string[] args)
        {
            string userInput;   // variable to hold user input
            int randInt,        // variable to hold random number
                userInt,        // variable to hold user input as integer value
                count = 0;      // variable to count number of guesses

            // create new random object
            Random randomNumber = new Random();

            // choose random number
            randInt = randomNumber.Next(1, 1001);

            // ask user to guess number and get input, increment guess counter
            Console.Write("Guess a number between 1 and 1000 or <Ctrl> z to exit: ");
            userInput = Console.ReadLine();
            ++count;

            // allows user to play game again
            while (userInput != null)
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

                    // increment guess counter
                    ++count;
                } // end nested while

                // make sure user didn't quit before guessing the correct number
                if(userInput != null)
                {
                    // tell the user if they've guessed the correct number
                    Console.WriteLine("\nCongratulations." +
                                      " You guessed the right number in {0} guesses.",
                                      count);

                    // inform the user how well they did based on number of tries
                    if (count < 10)
                        Console.WriteLine("Either you know the secret or you got" +
                                          " lucky!");
                    else if (count == 10)
                        Console.WriteLine("Aha! You know the secret!");
                    else
                        Console.WriteLine("You should be able to do better!");

                    // reset count for next round
                    count = 0;

                    // generate new random number in case user wants to continue
                    randInt = randomNumber.Next(1, 1001);

                    // give user option to continue or exit, get input and count guess
                    Console.WriteLine("\nA new random number has been generated.");
                    Console.Write("Guess a number between 1 and 1000 or <Ctrl> z to " +
                                  "exit: ");
                    userInput = Console.ReadLine();
                    ++count;
                } // end nested if
            } // end outer while
        } // end Main
    } // end class GuessTheNumberVersion2
} // end namespace
