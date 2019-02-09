/*
 * Task: This program determines if the user entered any duplicate values. The user can
 *       only enter 5 values total and all of the unique values are output as a new one
 *       is entered. The goal is to use the smallest one-dimensional array possible.
 * Input: The user can input numbers between 10 and 100, inclusive. The user can also
 *        input a sentinel value that exits the program.
 * Output: The program outputs some user information, prompts for user input, and error
 *         messages that inform the user if their input didn't fit the criteria. Each
 *         time a user enters a new unique number, that number and the previously entered
 *         unique numbers are listed. If the user enters a duplicate, then only the
 *         previous unique numbers are output.
 * Operations: Declare the variables for the program. Define the one-dimensional array
 *             without any values because the user can quit before entering any valid
 *             input and the problem specifies that we use the smallest array possible.
 *             Get the users first input, if they didn't try to quit then initialize the
 *             array with it's first value or add another element to the existing array
 *             with the Resize method. These elements hold the incoming user input if
 *             it's unique, otherwise they hold their initial value of 0. After adjusting
 *             the array, the input is converted to a decimal value in case the user used
 *             a decimal format (1234.56), then that value is cast to an integer (1234)
 *             to avoid an error from converting from decimal to integer. If the input
 *             value is able to convert and cast without error, the program verifies that
 *             the value is between 10 and 100, inclusive. If the input gets through
 *             that process, the flag that determines if the input is good or bad is
 *             changed to represent that the input is good. If the input isn't in the
 *             correct range, the flag doesn't change and still represents bad input and
 *             the user is asked to input a new value, then the process repeats from
 *             trying to convert the new value to a decimal (if the user didn't try to
 *             quit first). If the user enters a value, at any point, that causes the
 *             conversion or casting to error, then the rest of the process is skipped
 *             and the catch block sets the flag to represent bad input and asks the user
 *             to enter a new value so the loop tests the new input (if the user didn't
 *             quit). This loop continues asking the user for new input as long as they
 *             don't quit and keep entering erroneous input values. Once a proper value
 *             is input and the user didn't try to quit, then that value is compared to
 *             the other values that are in the array of unique values. If the input
 *             matches any of the values in the array, then the flag that represents bad
 *             input is repurposed to represent duplicate values and is assigned a value
 *             that tells the program that a duplicate was caught. The loop then breaks
 *             because there's no need to check any other values in the array since it
 *             has already found a duplicate. The input value is only appended to the
 *             array if the flag that represents duplicates is false, meaning there were
 *             no duplicates found between the previous unique values and the latest
 *             input value. If the new input value isn't added to the list, then there
 *             will be an element that contains the value 0, so the program checks if the
 *             last element in the list is 0 and Resizes the array with one less element
 *             to effectively remove the 0-value element. After that the count variable
 *             is incremented, this keeps track of the number of values between 10 and
 *             100, inclusive, that are input by the user. If the user has entered their
 *             last value and it was added to the list, then some explanatory information
 *             is output before the list of unique numbers that were entered is output.
 *             Otherwise, the list of unique numbers is output by itself with the latest
 *             input value appearing at the end of the list. The program asks the user
 *             to enter another value or to quit the program at this point, but only if
 *             the user has entered less than 5 values. The program terminates after
 *             printing the list of unique values if the user has entered the fifth
 *             value.
 */

using System;

namespace KillRowan_8._12
{
    class Duplicates
    {
        static void Main(string[] args)
        {
            // variables
            bool catchFlag = true;  // used to test input values
            string userInput;       // string to handle user input
            int inputValue = 0,     // handles user input value
                count = 0;          // counter to handle array index values
            int[] numbers = { };    // array to hold numbers input by user
            // define array without values because user may only enter 1 unique value
            // array is resized each time a new unique value is entered

            // output user info
            Console.WriteLine("Enter five numbers and find out which ones were not" +
                              " duplicates.");
            Console.WriteLine("The numbers need to be between 10 and 100, inclusive.");
            Console.WriteLine("Enter <Ctrl> z at any point to exit the program.");

            // get user input
            Console.Write("\nEnter a number or <Ctrl> z: ");
            userInput = Console.ReadLine();

            // if user didn't try to quit, cast value to integer and add to array
            // user can enter 5 integers max
            while(userInput != null && count < 5)
            {
                // resize array with one more element if this isn't first iteration
                if (count != 0)
                    Array.Resize(ref numbers, numbers.Length + 1);
                else if (count == 0)
                    // initialize array with first element for first loop iteration
                    numbers = new int[1];

                // assume input was bad, continue getting new input until user enters
                // proper value (bad input means catchFlag = true)
                while (catchFlag && userInput != null)
                {
                    // try casting user input into an integer value
                    try
                    {
                        // promote user input to decimal in case user used decimal format
                        // then cast decimal value to int for smooth conversion
                        inputValue = (int)Convert.ToDecimal(userInput);

                        // if input value is valid, catchFlag can be set to false
                        // if an error occurs, this statement is skipped and catch block
                        // takes control
                        // only set to allow input if value is between 10 and 100
                        // forces user to input correct value
                        if(inputValue >= 10 && inputValue <= 100)
                            catchFlag = false;
                        else
                        {
                            // tell user what proper input is
                            Console.WriteLine("Input an integer between 10 and 100, " +
                                              "inclusive.");

                            // get new user input
                            Console.Write("Enter a number or <Ctrl> z: ");
                            userInput = Console.ReadLine();
                        } // end else
                    } // end try
                    catch
                    {
                        // user entered bad input value, set flag to true
                        catchFlag = true;

                        // tell user what proper input is
                        Console.WriteLine("Input an integer between 10 and 100, " +
                                          "inclusive.");

                        // get new user input
                        Console.Write("Enter a number or <Ctrl> z: ");
                        userInput = Console.ReadLine();
                    } // end catch
                } // end nested while
                
                // verify user didn't try to quit before adding value to array
                if(userInput != null)
                {
                    // add number to array if it's not a duplicate
                    foreach (int item in numbers)
                        // compare each value in array to the input value
                        if (item == inputValue)
                        {
                            // if input value matches a value in the array, set flag to
                            // true to signify that input is a duplicate
                            catchFlag = true;

                            // break out of for loop because ther's no need to check
                            // the other items in numbers if a duplicate is found
                            break;
                        } // end nested if

                    // if the catchFlag is true, do not add the users input to the array
                    if(catchFlag != true)
                    {
                        // add input to array if it's unique, meaning catchFlag = false
                        numbers[numbers.Length - 1] = inputValue;

                        // set catchFlag to true so the next input is validated
                        catchFlag = true;
                    } // end nested if

                    // remove last array element if it has value 0
                    if (numbers[numbers.Length - 1] == 0)
                        Array.Resize(ref numbers, numbers.Length - 1);

                    // increment count
                    ++count;

                    // output some extra information for final output
                    if(count == 5)
                    {
                        Console.WriteLine("\nOut of the five numbers entered, here are" +
                                          " the ones that weren't duplicates.");

                        // sort list so it's easier to read in final output
                        Array.Sort(numbers);
                    } // end nested if
                        

                    // output header
                    Console.Write("Unique Numbers: ");

                    // output unique numbers
                    for(int num = 0; num < numbers.Length; ++num)
                    {
                        // formatting so the numbers appear as 11, 12, 13, 14, 15 and not
                        // 11, 12, 13, 14, 15, (last comma removed from list)
                        if (num != numbers.Length - 1)
                            Console.Write("{0}, ", numbers[num]);
                        else
                            Console.Write("{0}", numbers[num]);
                    } // end nested for

                    // whitespace
                    Console.WriteLine();

                    // get user input, don't get user input on last iteration of loop
                    if(count < 5)
                    {
                        Console.Write("\nEnter a number or <Ctrl> z: ");
                        userInput = Console.ReadLine();
                    } // end nested if
                } // end nested if
            } // end outer while
        } // end Main
    } // end class Duplicates
} // end namespace
