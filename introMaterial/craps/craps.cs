/*
 * Task: This program allows the user to play a game of craps and wager virtual money.
 *       The user is given $1000 to start with and cannot wager more than they have.
 *       If the user busts (loses all of their money), the game informs them and exits.
 * Input: The user is expected to input the amount of money they want to wager or the
 *        sentinel value that tells the program to exit.
 * Output: The program outputs some information regarding what it does and the users
 *         starting balance. If the user tries to wager more money than they have, the
 *         program warns the user and asks for a new wager. When a proper wager is input,
 *         the program rolls the dice for the user and tell the user whether they've won,
 *         lost or made their point. When the program rolls the dice, it outputs the two
 *         die values and the sum of those values for each roll. Then, the most recent
 *         balance for the user is output and the user is asked to enter a new wager to
 *         continue playing.
 * Operations: Declare a private variable that generates random numbers, this is used to
 *             simulate rolling a die. Declare an enumerator called Status that stores
 *             the current status of the game, whether the user has won, lost or will
 *             continue playing to make their point. Declare another enumerator called
 *             DiceNames that contains common names for different combinations of dice
 *             rolls. The Main method declares some variables that the user will interact
 *             with, provides some information to the user and gets the users input for
 *             their first wager value. If the user entered the sentinel value, exit the
 *             program. Otherwise, convert the input to a decimal value and verify that
 *             it's smaller than the users current balance. While the user tries to wager
 *             more than they have or wager a negative number, inform them that they
 *             cannot do that and ask for a new amount to wager. If the user doesn't try
 *             to exit when entering a new wager, convert it to decimal and repeat the
 *             process from verifying that the wager is less than the balance. If the
 *             sentinel value is entered instead of a new wager, then set the wager to a
 *             value of 0 to prevent the game from storing and using the improper wager.
 *             The part of the program that plays the game won't run if the user inputs
 *             the sentinel value. If a proper wager is entered, set the status of the
 *             game to CONTINUE from the Status enumerator and declare the variable that
 *             holds the users point. Then call the function that simulates rolling the
 *             dice and assign the return value to an integer, this is the sum of the
 *             two die rolls. If the first roll sums to be either 7 or 11, then the user
 *             is informed that they won. If the sum is equal to 2, 3 or 12 on the first
 *             roll then the user is informed that they lost. Otherwise the sum is
 *             assigned to be the point value and the user continues rolling until the
 *             sum is either equal to the point value and the user wins or the sum is
 *             equal to 7 and the user loses. In either case the user is informed of the
 *             outcome. When the user wins the wager is added to the balance, when the
 *             user loses the wager is subtracted from the balance. Once the new balance
 *             is calculated, the user can enter a new wager or quit as long as they
 *             still have a positive balance. Entering a new wager restarts the game
 *             from verifying that the wager is less than the balance.
 */

using System;

namespace KillRowan_7._33
{
    class Craps
    {
        // random number generator
        private static Random rands = new Random();

        // enum with constants that represent game status
        private enum Status { CONTINUE, WON, LOST }

        // enum with names of common combinations of dice
        private enum DiceNames
        {
            SNAKE_EYES = 2,
            TREY = 3,
            SEVEN = 7,
            YO_LEVEN = 11,
            BOX_CARS = 12
        } // end enum DiceNames

        // Main method, gets user input and calls RollDice method
        static void Main(string[] args)
        {
            decimal balance = 1000M,    // variable to hold balance for player
                    wager = 0M;         // variable to hold decimal value of wager
            string userInput;           // variable to hold wager amount

            // display some user info
            Console.WriteLine("Bet virtual currency on a game of Craps!");

            // display balance
            Console.WriteLine("\nYour current balance is {0:C}", balance);

            // get wager amount from user, assign to userInput
            Console.Write("Enter a wager amount or <Ctrl> z to exit: ");
            userInput = Console.ReadLine();

            // check value of userInput (wager)
            while (userInput != null)
            {
                // convert userInput to decimal if it isn't sentinel value
                wager = Convert.ToDecimal(userInput);

                // verify wager is positive
                while(Convert.ToDecimal(wager) < 0)
                {
                    // tell user they cannot wager negative amounts
                    Console.WriteLine("\nYou cannot bet a negative value.");

                    // get wager amount from user, assign to userInput
                    Console.Write("Enter a new wager amount or <Ctrl> z to exit: ");
                    userInput = Console.ReadLine();

                    // verify wager isn't sentinel value and is <= balance
                    if (userInput != null)
                        // convert userInput to decimal
                        wager = Convert.ToDecimal(userInput);
                    else
                        // set wager to 0 to exit loop, game will not run
                        wager = 0M;
                } // end nested while

                // verify wager is less than balance
                while (Convert.ToDecimal(wager) > balance)
                {
                    // tell user that wager was too high
                    Console.WriteLine("\nYou cannot bet more than you have.");

                    // get wager amount from user, assign to userInput
                    Console.Write("Enter a new wager amount or <Ctrl> z to exit: ");
                    userInput = Console.ReadLine();

                    // verify wager isn't sentinel value and is <= balance
                    if (userInput != null)
                        // convert userInput to decimal
                        wager = Convert.ToDecimal(userInput);
                    else
                        // set wager to 0 to exit loop, game will not run
                        wager = 0M;
                } // end nested while

                // play game if user didn't quit before entering a proper wager
                // technically wagering 0 is possible, but not realistic
                if((userInput != null) && (wager >= 0))
                {
                    // set game status to continue
                    Status gameStatus = Status.CONTINUE;
                    int myPoint = 0;    // variable to hold users point value

                    // whitespace
                    Console.WriteLine();

                    // first dice roll
                    int sumDice = RollDice();

                    // determine game status after first roll
                    // case variable as type DiceNames so a roll of 11 == YO_LEVEN
                    switch ((DiceNames)sumDice)
                    {
                        case DiceNames.SEVEN:
                        case DiceNames.YO_LEVEN:
                            // win with 7 or 11 on first roll
                            gameStatus = Status.WON;
                            break;
                        case DiceNames.SNAKE_EYES:
                        case DiceNames.TREY:
                        case DiceNames.BOX_CARS:
                            // lose with 2, 3, 12 on first roll
                            gameStatus = Status.LOST;
                            break;
                        default:
                            // didn't win or lose so keep playing to make point
                            gameStatus = Status.CONTINUE;

                            // set point to sum of last roll
                            myPoint = sumDice;

                            // display point
                            Console.WriteLine("Your Point is {0}", myPoint);
                            break;
                    } // end nested switch

                    // while game isn't over, keep rolling until player wins
                    while (gameStatus == Status.CONTINUE)
                    {
                        // roll dice again
                        sumDice = RollDice();

                        // determine game status
                        if (sumDice == myPoint)
                        {
                            // if player makes point, they win
                            gameStatus = Status.WON;
                        }
                        else
                        {
                            // lost by rolling 7 before making point
                            if (sumDice == (int)DiceNames.SEVEN)
                                gameStatus = Status.LOST;
                        } // end nested if else
                    } // end nested while

                    // inform user if they won or lost and adjust balance
                    if (gameStatus == Status.WON)
                    {
                        Console.WriteLine("You win.");

                        // add wager to balance
                        balance += wager;
                    }
                    else
                    {
                        Console.WriteLine("You lose.");

                        // subtract wager from balance
                        balance -= wager;
                    } // end nested if else

                    // display balance
                    Console.WriteLine("\nYour latest balance is {0:C}", balance);

                    // if balance is 0 or less, inform user and exit
                    // balance should never be negative because you can't wager more
                    // than you have, but still use <= as precaution
                    if(balance <= 0)
                    {
                        Console.WriteLine("Sorry. You busted!");
                        break;
                    } // end nested if

                    // get new wager amount from user if they haven't busted
                    Console.Write("Enter a new wager amount or <Ctrl> z to exit: ");
                    userInput = Console.ReadLine();
                } // end nested if
            } // end outer while
        } // end Main

        // method to generate random numbers between 1 and 6 to represent die rolls
        public static int RollDice()
        {
            // generate random die values
            int die1 = rands.Next(1, 7);
            int die2 = rands.Next(1, 7);

            // add random values
            int sum = die1 + die2;

            // display results
            Console.WriteLine("Player rolled {0} + {1} = {2}",
                die1, die2, sum);

            // return the sum of the dice faces
            return sum;
        } // end method RollDice
    } // end class Craps
} // end namespace
