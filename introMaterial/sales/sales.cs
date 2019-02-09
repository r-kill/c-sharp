/*
 * Task: Calculate the total of all products sold by multiplying the quantity
 *       of each product sold by its price. The user enters which product was
 *       sold and then enters the quantity sold.
 * Input: The user enters the product number and the quantity of product
 *        that was sold. The user also enters the sentinel value <Ctrl> z.
 * Output: The total value of everything sold is output.
 * Operations: Declare variables for the user input, the sum, and the prices
 *             for each product. Display a list of product numbers and their
 *             corresponding prices for the user. Tell the user to input
 *             the product number and quantity or enter <Ctrl> z to quit.
 *             Get the product number from the user, then verify that the
 *             user didn't try to quit. Get the quantity sold and verify
 *             that the user didn't try to quit again. Determine the price
 *             for the product sold, calculate the value of the sale and
 *             then add that value to the total of all sales. Once the user
 *             has entered the sentinel value, output the total of all sales
 *             made. Only output the total if the user input values.
 */

using System;

namespace KillRowan_6._17
{
    class Sales
    {
        static void Main(string[] args)
        {
            // declare variables
            string product,           // stores value for the product sold
                   quantity = null;   // holds value for quantity of product sold
            decimal price = 0M,       // hold price of product
                    total = 0M;       // holds total sales

            // show user menu of products and get product and quantity sold
            do
            {
                // list of products and prices
                Console.WriteLine("Product Number{0, 20}", "Price Per Item");
                Console.WriteLine("{0, 14}{1, 20:C}", 1, 2.98M);
                Console.WriteLine("{0, 14}{1, 20:C}", 2, 4.50M);
                Console.WriteLine("{0, 14}{1, 20:C}", 3, 9.98M);

                // user info and get input
                Console.WriteLine("\nEnter the product number and quantity sold " +
                                  "or enter <Ctrl> z to quit.");
                Console.Write("Enter the product number: ");
                product = Console.ReadLine();

                // make sure user didn't try to quit before entering quantity
                if (product != null)
                {
                    // get input for quantity sold
                    Console.Write("Enter the quantity sold: ");
                    quantity = Console.ReadLine();

                    // determine price and total if user still has not tried to quit
                    if(quantity != null)
                    {
                        // switch statement to determine price of product entered
                        switch (Convert.ToInt32(product))
                        {
                            case 1:
                                // set price for product 1
                                price = 2.98M;
                                break;
                            case 2:
                                // set price for product 2
                                price = 4.50M;
                                break;
                            case 3:
                                // set price for product 3
                                price = 9.98M;
                                break;
                            default:
                                Console.WriteLine("That item is not on the list!");
                                price = 0M;
                                break;
                        } // end switch

                        // add sales to total sales
                        total += Convert.ToDecimal(quantity) * price;
                    } // end nested if
                } // end outer if

                // whitespace
                Console.WriteLine();
            } while ((product != null) && (quantity != null));

            // make sure the user entered values
            if (total != 0M)
            {
                // display total sales to user when sentinel value entered
                Console.WriteLine("Total of all products sold: {0:C}", total);
            }
            else
            {
                // tell user that there was nothing sold
                Console.WriteLine("You didn't sell anything on the list.");
            } // end if else
        } // end Main
    } // end class Sales
} // end namespace
