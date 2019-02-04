/*
 * Task: Class that allows user to specify an item that was sold and how many
 *       of that item were sold at a given price in order to output the total
 *       price of the sale.
 * Input: This class receives input from the properties of instance variables.
 *        The user will input a string for the item number and the item name,
 *        as well as an integer for the quantity of the item sold and a decimal
 *        that represents the price of the item.
 * Output: This class outputs the product of quantity * pricePerItem.
 * Operations: Create two private instance variables and their properties,
 *             the properties don't allow the two variables to be set to
 *             a value that's lower than 0. The set two automatic properties
 *             for instance variables that don't need special conditions.
 *             Create a class constructor to initialize the instance
 *             variables. The method simply calculates the product of the
 *             quantity and the pricePerItem varaibles and returns the result.
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Invoice
{
    private int quantity;           // instance variable to hold quantity of items
    private decimal pricePerItem;   // instance variable to hold price per item

    // property to get and set quantity of item to purchase
    public int Quantity
    {
        get
        {
            return quantity;
        } // end get
        set
        {
            // if the value passed to the set accessor is negative,
            // quantity should not change
            if(value >= 0)
            {
                quantity = value;
            } // end if
        } // end set
    } // end property Quantity

    // property to get and set the price per item bought
    public decimal PricePerItem
    {
        get
        {
            return pricePerItem;
        } // end get
        set
        {
            // if the value passed to the set accessor is negative,
            // pricePerItem should not change
            if(value >= 0)
            {
                pricePerItem = value;
            } // end if
        } // end set
    } // end property PricePerItem

    // auto-implemented property for partNum instance variable (implicitly created)
    public string PartNum { get; set; }

    // auto-implemented property for partInto instance variable
    public string PartInfo { get; set; }

    // constructor to initialize instance variables
    public Invoice(string partNum, string partInfo, int quant, decimal pricePerItem)
    {
        // set PartNum to partNum
        PartNum = partNum;

        // set PartInfo to partInfo
        PartInfo = partInfo;

        // set Quantity to quant
        Quantity = quant;

        // set PricePerItem to pricePerItem
        PricePerItem = pricePerItem;
    } // end constructor Invoice

    // method that calculates quantity * pricePerItem
    public decimal GetInvoiceAmount()
    {
        // initialize and find value of variable to be return
        decimal invoiceAmount = Quantity * PricePerItem;

        return invoiceAmount;
    } // end method GetInvoiceAmount
} // end class Invoice
