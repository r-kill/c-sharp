/*
 * Task: Ask the user to input the item name, item number, price, and the nubmer of items sold.
 *       Then, calculate the total by multiplying the quantity by the price per item, 
 *       then output the result to the user.
 * Input: The user will input two strings that represent the item number and item
 *        description, as well as an integer for the quantity of an item that was sold
 *        and a decimal to represent the price of that item.
 * Output: The product of the quantity of items multiplied by the price per item for that
 *         item is the output, along with the user prompts.
 * Operations: First declare the variables to hold values that will be used to initialize
 *             the instance varaibles of the Invoice object. Print the user info that
 *             describes what the program does. Ask the user what item was sold, 
 *             then ask for the price of the item sold. Ask the user for the 
 *             item number and the quantity of the item sold. Then create the Invoice
 *             object and call the GetInvoiceAmount method to output the price of
 *             the item.
 */

using System;

public class InvoiceTest
{
    // Main method to start execution
    public static void Main(string[] args)
    {
        decimal itemPrice = 0;  // variable to hold price of each item
        int quantity = 0;       // variable to hold number of items user wants to purchase
        string itemNum,         // variable to hold the item number
               itemName = "";   // variable to hold name of item

        // user info
        Console.WriteLine("Welcome to the hardware store invoice application.");

        // prompt user to enter the item name
        Console.Write("\nWhat item was sold (hammer, screw, etc.): ");
        itemName = Console.ReadLine();

        // prompt user to enter item price
        Console.Write("\nHow much is one unit of that item worth: $");
        itemPrice = Convert.ToDecimal(Console.ReadLine());

        // prompt user to enter the item number
        Console.Write("\nWhat is the item number of the item that was sold: ");
        itemNum = Console.ReadLine();

        // get quantity of item sold
        Console.Write("\nQuantity of {0}s sold: ", itemName);
        quantity = Convert.ToInt32(Console.ReadLine());

        // create Invoice object
        Invoice invoice1 = new Invoice(itemNum, itemName, quantity, itemPrice);

        // output total amount with class method GetInvoiceAmount
        Console.WriteLine("\nItem number {0} ({1}) x{2}, the total comes to: {3:C}", 
            invoice1.PartNum, invoice1.PartInfo, invoice1.Quantity,
            invoice1.GetInvoiceAmount());
    } // end Main
} // end class InvoiceTest
