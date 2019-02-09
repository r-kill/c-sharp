/*
 * Task: This program asks the user to enter the total sales that each employee made for
 *       that week, then calculates the salary of each employee. The salaries are put
 *       into a table to determine how many employees earned a given salary range. For
 *       example, this program can determine how many employees out of 20 earned salaries
 *       in the range of $400-499.
 * Input: The user inputs an integer or decimal value that represents the total sales of
 *        the given employee for that week. The user can enter <Ctrl> z to exit the
 *        program at any time. If the user entered valid values for at least one
 *        employee, a table will be output that shows the salary distribution for the
 *        number of employees that have valid data.
 * Output: The output consists of a list of salary ranges ($200-299, $300-399, etc...)
 *         with a chart of asterisks that represent each employee that earned a salary
 *         that lands in that range. There's also a list of integers that count how many
 *         employees are in each range, this appears as the first column in the table.
 *         Finally, the number of employees that were used in the table is output under
 *         the Total column.
 * Operations: First declare the variables and the one-dimensional list of counters,
 *             there is a boolean variable that's used as a flag to catch any errors in
 *             the users input. Output some information that explains the program to the
 *             user. The user can input <Ctrl> z at any input point to either exit the
 *             program or, if the user has already input valid data, view a table that
 *             summarizes the data. Get the total sales for the first employee, if the
 *             user doesn't want to exit then try converting the input to a decimal and
 *             then casting that decimal to an integer because the problem specifies that
 *             we assume the input is an integer value. This statement will cause an
 *             error if the user does not enter a proper numeric value, which will cause
 *             the program to enter the catch block. If the user enters a proper value,
 *             the flag is set to false so the program doesn't think the user entered
 *             an improper value. If the user enters bad data, that flag is not set to
 *             false in the try block, instead the catch block sets it to true. This is
 *             used as a condition for a while loop that will force the user to either
 *             quit the program or enter valid data. The same process is used, ask for
 *             input, try to convert it and catch the error if it fails. Set the flag
 *             accordingly and then test that the user didn't try to exit and the value
 *             of the flag to determine if the user entered proper data. Use a similar
 *             process of try/catch to verify that the user didn't input a negative
 *             value. If the data passes the validation phase, the salary for that
 *             employee is calculated and the proper counter element in the array is
 *             incremented. Then the user is asked to input another total sales value for
 *             the next employee or the user can quit. If the user doesn't try to quit,
 *             the data goes through the same validation process, then the salary is
 *             calculated and the proper counter is incremented. If the user chooses to
 *             exit and there is valid data, then a table is output. If there's no valid
 *             data, the program exits without printing the table. The reason that the
 *             user input is converted to a decimal first is because the user can enter
 *             either an integer (1234) or a decimal (1234.56) and converting it directly
 *             to an integer will cause an error if a decimal format is used for input.
 *             Since the program specifies that we use integer values, the decimal value
 *             is then cast into an integer value.
 */

using System;

namespace KillRowan_8._10
{
    class Sales
    {
        static void Main(string[] args)
        {
            // salary variable is used to hold the final salary for each employee
            // problem 8.10 states "assume that each salesperson's salary is an integer"
            int salary = 0,
                employeeIndex = 0,  // index variable for sales array
                inputTester = 0,    // variable to test user input and hold input values
                sum = 0;            // variable to hold the sum of the elements in freq

            // freq array contains number of employees in each sales range
            // this is the array of counters
            // each element is a counter for a different salarry range
            // freq[0] corresponds to the 200-299 salary range, freq[1] to 300-399, etc
            int[] freq = new int[9];

            string userInput;   // variable to hold the gross sales or sentinel values
            bool catchFlag = false;     // flag variable, verifies that input is correct

            // output some user info
            Console.WriteLine("1. Enter the gross sales for employee {0}," + 
                              " or enter <Ctrl> z to exit.", employeeIndex + 1);
            Console.WriteLine("2. You can enter <Ctrl> z at any point throughout the " +
                              "program to stop entering\n    employee sales values and" +
                              " view the distribution chart.");
            Console.WriteLine("3. Enter the gross sales in one of two ways:" + 
                              " 1234 or 1234.56");

            // allow user to input first gross sales amount or exit
            Console.Write("\nGross sales for employee {0}: ",
                          employeeIndex + 1);
            userInput = Console.ReadLine();

            // continue getting gross sales data until user chooses to exit
            while (userInput != null)
            {
                // make sure userInput can be converted to a decimal and cast to an int
                // user may enter a decimal value so it must be converted to decimal
                // first, then it needs to be cast to an int according to problem 8.10
                // if it's converted to an integer directly, inputs that include a
                // decimal point will cause an error
                try
                {
                    // try the conversion
                    inputTester = (int)Convert.ToDecimal(userInput);

                    // set flag to false
                    // this statement isn't executed if error found in previous statement
                    catchFlag = false;
                } // end outer try
                catch
                {
                    // set catch flag to true to start new input loop
                    catchFlag = true;

                    // get and verify new input
                    while(catchFlag == true && userInput != null)
                    {
                        // tell user there was an error
                        Console.WriteLine("\nThere was an issure with your input, " + 
                                          "please enter a new number that matches one" +
                                          "\nof the formats shown at the beginning of" +
                                          " the program.");

                        // get new input value
                        Console.Write("Gross sales for employee {0}: ",
                              employeeIndex + 1);
                        userInput = Console.ReadLine();

                        // check new input for errors if user didn't quit
                        // this inner try/catch is used to break out of loop if a proper
                        // value is input, without it the catchFlag never becomes false
                        if (userInput != null)
                        {
                            try
                            {
                                // try the conversion
                                inputTester = (int)Convert.ToDecimal(userInput);

                                // if the conversion works, the flag needs to be false
                                catchFlag = false;
                            } // end nested try
                            catch
                            {
                                // set flag to true to continue looping
                                catchFlag = true;
                            } // end nested catch
                        } // end nested if
                    } // end nested while
                } // end outer catch

                // make sure user inputs positive values
                while (inputTester < 0 && userInput != null)
                {
                    // inform user of the input problem
                    Console.WriteLine("\nYour input must be a positive numeric value.");

                    // get new input value
                    Console.Write("Gross sales for employee {0}: ",
                          employeeIndex + 1);
                    userInput = Console.ReadLine();

                    // verify new input value if user didn't exit
                    if(userInput != null)
                    {
                        // verify user entered a positive numeric value
                        try
                        {
                            // try to convert input to numeric value
                            inputTester = (int)Convert.ToDecimal(userInput);

                            // set flag to false
                            catchFlag = false;
                        } // end nested try
                        catch
                        {
                            // set flag to true
                            catchFlag = true;
                        } // end nested catch
                    } // end nested if
                } // end nested while

                // verify user didn't quit after entering an improper value
                if(userInput != null)
                {
                    // calculate employees salary
                    // $200 base payment plus 9% of gross sales
                    salary = 200 + (int)(.09 * inputTester);

                    // increment appropriate element in freq array
                    // if salary < 1000, element to increment can be found mathematically
                    if (salary < 1000)
                        ++freq[(salary / 100) - 2];
                    else
                        // if salary > 1000 then calculation gives out of range index, so
                        // the index needs to be specified
                        ++freq[8];

                    // allow user to input next gross sales amount or exit
                    // increment employeeIndex value for next exmployee
                    Console.Write("Gross sales for employee {0}: ", ++employeeIndex + 1);
                    userInput = Console.ReadLine();
                } // end nested if
            } // end outer while

            // calculate the sum of the elements in the freq array
            foreach (int num in freq)
                sum += num;

            // output chart if there are values in the frequency array, meaning the user
            // has input acceptable values that would give meaningful output
            if (sum != 0)
            {
                // employee payment distribution
                Console.WriteLine("\n\nWeekly Employee Salary Distribution Chart");

                // display headers
                Console.WriteLine("\n{0}  {1}   {2}", "Total",
                                  "Salary", "Graphical");

                // display bar chart for distribution
                // initialize count to 2 so chart starts at $200-299, count is used to
                // determine the sales values for the chart
                for (int count = 0; count < freq.Length; ++count)
                {
                    // output row labels for the chart
                    // compare count to freq.Length - 1 because an array with a
                    // length of 10 contains indecies array[0] to array[9]
                    if (count == freq.Length - 1)
                        // display specific phrase for sales of $1000 and over
                        Console.Write("{0, 3}{1, 13}", freq[count], "$1000+: ");
                    else
                        // display ranges, $200-299, $300-399, etc...
                        Console.Write("{0, 3}{1, 7:C0}-{2:D3}:\t", freq[count],
                                      (count + 2) * 100, (count + 2) * 100 + 99);

                    // display asterisks as bars for chart
                    // subtract 2 from count to adjust for counts initial value
                    for (int star = 0; star < freq[count]; ++star)
                        // print asterisk
                        Console.Write("*");

                    // whitespace
                    Console.WriteLine();
                } // end nested for

                // print sum
                Console.WriteLine("Sum = {0}", sum);
            } // end outer if
        } // end Main
    } // end class Sales
} // end namespace
