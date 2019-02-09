/*
 * Task: This program takes in a variable number of integers from the user and multiplies
 *       them together. The product of the numbers is updated with each new number and a
 *       final product is output when the user exits the program.
 * Input: The user inputs numbers that they want to multiply together, the sentinel value
 *        to exit the program, or either Y or N (upper- or lower-case) depending on if
 *        the user enters 0 and wants to keep that value.
 * Output: The program outputs some user information, the prompts for user input, a
 *         warning to the user if they input 0, and error messages if the user doesn't
 *         input a proper number or if the user doesn't enter any proper values at all
 *         and exits the program. There's also an error message that tells the user if
 *         the product result will overflow the int value range. The program outputs the
 *         product as new numbers are added to the argument list, allowing the user to
 *         see the results of multiplying the previous product with the new number. When
 *         the user quits, the program outputs the final product value.
 * Operations: Declare variables and output some basic user information. Ask the user
 *             for their first input, if they didn't enter the sentinel value to exit the
 *             program, then try to convert the input value to a decimal and cast the
 *             decimal value into an integer value. If this causes an error, the catch
 *             block sets the catchFlag to true to signify that the input was not valid
 *             and asks the user to input a new value. The flag causes the loop to keep
 *             iterating until the input is valid (the flag will be false), as long as
 *             the user doesn't try to quit first. If the input conversion in the try
 *             block doesn't cause an error, then the catchFlag is set to false to show
 *             that no errors occurred. If the input value is equal to 0, then the user
 *             is warned that multiplying by 0 will cause all subsequent results to be 0
 *             and asked if they want to continue with 0 or change the value. If the user
 *             enters Y (yes, change the value) then they are prompted to enter a new
 *             value. If the user enters N (no, keep the 0) then there in no prompt for a
 *             value change. If the user tries to exit, then the final product is output
 *             because the null input is carried through the program. Once the input is
 *             validated, the array is resized with one more element to accommodate the
 *             new value, the value is added, and the catch flag is set to true so that
 *             the next input value is also validated. The program then outputs the
 *             current product of the input values entered so far. This is accomplished
 *             by calling the Multiply method and passing the array of integer input
 *             values as an argument. This method returns a boolean value that tells the
 *             Main method if there was an overflow during the multiplication. If there's
 *             an overflow, then the bad array element is removed by resizing the array
 *             with one less element. The bad array element is the element that caused
 *             the product value to overflow the integer value range. The user is told by
 *             the Multiply method that there was an overflow and the user is asked to
 *             input a new value to replace the previous one that caused the overflow.
 *             The user can quit here (or at any point where input is accepted) or enter
 *             a new value that will then be validated and go through the same process as
 *             the previous values. The final product will only output if the user has
 *             actually entered valid data, if array of input values is empty then the
 *             final output tells the user that they didn't input any valid numbers to
 *             multiply. The Multiply method takes a variable length list of arguments,
 *             first variables are declared to handle the product value and to handle the
 *             results of the product multiplied by the following number, the second
 *             variable is used as a way to peek at the next multiplication result to
 *             determine if the result will overflow the integer value range. The method
 *             loops through each argument that was passed and first tests the result of
 *             the multiplication using the second variable mentioned before, that
 *             variable is assigned the result of taking the product (which will be 1 or
 *             the value of the previous multiplication) multiplied by the next argument
 *             in the list. That variable uses the long data type because it accepts
 *             more values than the integer data type, making it easy to determine when
 *             a product has overflowed it's integer boundary. The test variable is
 *             compared to the int.MaxValue attribute that gives the value of the highest
 *             integer value possible with the integer data type. If the test variable
 *             is greater than or equal to the max int value, then the program tells the
 *             user that the product can't be computed, that the previous input is going
 *             to be disregarded and what the user should consider the current product to
 *             be. The method then returns true to indicate that an overflow occurred and
 *             the user is asked to input a new value that's validated and sent to the
 *             Multiply method in place of the input that caused the overflow. If the
 *             test value didn't overflow the integer value range, then the method
 *             performs the multiplication of the product and argument. The product is
 *             multiplies by the arguments sequentially, so this block will also output
 *             the final product when the loop calculates the last product of the
 *             arguments. If there was no overflow, then the method returns false to
 *             indicate that no overflow occurred.
 */

using System;

namespace KillRowan_8._14
{
    class Product
    {
        static void Main(string[] args)
        {
            string userInput;        // variable to hold user input
            bool catchFlag = true,   // variable to signify improper inputs
                overflow = false;    // flag that controls integer overflow control
            int index = 0,           // variable to maintain array index
            inputValue = 0;          // variable to hold the value of the user input

            // array holds argument list, initially empty in case user quits before
            // entering valid data
            int[] values = { };

            // user information
            Console.WriteLine("This program takes any number of integers and " +
                              "multiplies them together.");
            Console.WriteLine("Enter <Ctrl> z as an input at any point to exit the " +
                              "program.");

            // get user input
            Console.Write("\nEnter an integer: ");
            userInput = Console.ReadLine();

            // loop to allow user to keep entering integers until sentinel value is input
            while(userInput != null)
            {
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

                        // set catchFlag to false, this is skipped if error occurs when
                        // converting/casting the input value
                        catchFlag = false;

                        // if user entered zero, warn them that they can't recover
                        // testing this in the try block so the next input (if there is
                        // one) is validated by the while loop
                        if (inputValue == 0)
                        {
                            string multiplyByZero;  // allows user to change input value

                            // user warning and get input
                            Console.WriteLine("Warning! Multiplying by 0 now will " +
                                              "multiply all subsequent values by 0.");
                            Console.Write("Input Y to change the value or N to " + 
                                          "continue with multiplication by 0: "); 
                            multiplyByZero = Console.ReadLine();

                            // make sure user enters Y, y, N, n, or null
                            while (multiplyByZero != "N" && multiplyByZero != "n" &&
                                  multiplyByZero != "Y" && multiplyByZero != "y" &&
                                  multiplyByZero != null)
                            {
                                Console.WriteLine("\nEnter one of these five values:" +
                                                  " Y, y, N, n, <Ctrl> z.");
                                Console.Write("Enter one of the values: ");
                                multiplyByZero = Console.ReadLine();
                            } // end nested while

                            // if user tries to quit instead of choosing Y or N, set
                            // userInput variable to null so the quit value carries thru
                            // the program
                            if (multiplyByZero == null)
                                userInput = null;

                            // if the user does want to change the value, then the value
                            // is replaced by new input and the program won't multiply by
                            // 0, otherwise catchFlag is still true so the loop continues
                            if(multiplyByZero == "Y" || multiplyByZero == "y" &&
                               multiplyByZero != null)
                            {
                                // ask user to input new value
                                Console.Write("Enter a new integer: ");
                                userInput = Console.ReadLine();

                                // set catchFlag to true so the next input is checked
                                catchFlag = true;
                            } // end nested if

                            // whitespace
                            Console.WriteLine();
                        } // end outer if
                    } // end try
                    catch
                    {
                        // user entered bad input value, set flag to true
                        catchFlag = true;

                        // tell user what proper input is
                        Console.WriteLine("Enter integer values such as 123, 4, 21...");

                        // get new user input
                        Console.Write("\nEnter an integer: ");
                        userInput = Console.ReadLine();
                    } // end catch
                } // end nested while

                // make sure user didn't try to quit
                if (userInput != null)
                {
                    // verified good input, resize array first
                    Array.Resize(ref values, values.Length + 1);

                    // add input to the argument array
                    values[index] = inputValue;

                    // reset catchFlag to true so next input gets checked for errors
                    catchFlag = true;

                    // pass input values to Multiply method, updates user on current
                    // product
                    Console.Write("The current product is: ");
                    overflow = Multiply(values);

                    // if overflow occurred, remove last element from array and don't
                    // increment index variable
                    if (overflow)
                    {
                        // resize array
                        Array.Resize(ref values, values.Length - 1);
                    } // end nested if
                    else
                    {
                        // increment index
                        ++index;
                    } // end nested if/else

                    // whitespace
                    Console.WriteLine();

                    // get new user input
                    Console.Write("\nEnter an integer: ");
                    userInput = Console.ReadLine();
                } // end nested if
            } // end outer while

            // output the final product if the array isn't empty, otherwise tell user the
            // array was empty
            if(values.Length != 0)
            {
                Console.Write("The final product is: ");
                Multiply(values);
            } // end if
            else
            {
                Console.WriteLine("There were no valid numbers to multiply.");
            } // end if/else
        } // end Main

        // method that multiplies arguments together and outputs the product
        public static bool Multiply(params int[] inputs)
        {
            int product = 1;     // variable to hold product of integers
            long tester = 0;     // variable to test product value
            
            // multiply all input values together
            for(int item = 0; item < inputs.Length; ++item)
            {
                // test what value of product would be if there were no overflow due to
                // the int range
                tester = (long)product * inputs[item];

                // make sure product value won't exceeded the integer value range
                // problem specifies that the values be integers, so the int data type
                // needed to be used
                if (tester >= int.MaxValue)
                {
                    // tell user that product overflowed int range
                    Console.Write("N/A");
                    Console.WriteLine("\nThe product was too large to compute.");
                    Console.WriteLine("Ignoring the previous input ({0}).",
                                      inputs[item]);
                    Console.WriteLine("Continue as if the previous input never" +
                                      " occurred or exit the program (<Ctrl> z).");

                    // update product for user before breaking
                    Console.Write("The current product is:  {0}", product);

                    // break out of loop to stop multiplication, no need to continue
                    // creating more garbage results
                    // returning true signifies that there was an overflow
                    return true;
                } // end nested if
                else
                {
                    // calculate product because int value has not overflowed yet
                    product *= inputs[item];

                    // update user on current product value if it's the last value in the
                    // array (last value to multiply)
                    if (item == inputs.Length - 1)
                        Console.Write(product);
                } // end nested if/else

                // reset tester value
                tester = 0;
            } // end for

            // return false to signify there was no overflow
            return false;
        } // end method Multiply
    } // end class Product
} // end namespace
