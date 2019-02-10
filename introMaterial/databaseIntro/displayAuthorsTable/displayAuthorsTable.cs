/*
 * Task: This program allows a user to view a list of authors that includes their first
 * 	      name, last name and Author ID. The user can use the textbox and buttons
 * 	      provided to filter the data by the authors’ last names. The user can also
 * 	      clear their filter and view the original data set again.
 * Input: The user can input a string into the textbox that’s compared to the last names
 *        of the authors in the database and any new rows to the database using the
 *        navigation bar.
 * Output: The program outputs a GUI that contains the navigation bar that allows the
 *         user to manipulate the data in the database, a view of the data in the
 *         database that’s in a grid format with the given filter applied and some
 *         buttons that tell the program to filter the data or remove a current filter
 *         from the data.
 * Operations: The first step is to connect the database to the solution, which is
                detailed at the end of this report. After that, create the basic form for
                the GUI and connect the data objects from the database to the new form.
                Once that’s finished, the data objects need to be added to the form so
                the user can view and manipulate the data in the grid view mentioned
                previously. The constructor for the form only calls the method
                InitializeComponent, this was placed there automatically by Visual
                Studio. When the form is first loaded, the Load event occurs and the
                data in the table is refreshed, if the form is loading for the first time
                the refresh causes the table to contain all of the data in the form. In
                order to refresh the form, any old data in the database is cleared and
                the dbcontext variable is assigned a new reference to the BookEntities
                object so it contains all of the Authors that are in the database. The
                list of authors is them sorted or filtered with a LINQ statement, first
                the authors are sorted by last name, then first name. When the user
                manipulates data in the database, they can save it with a button on the
                navigation bar. When clicked, that button first validates that all of the
                new data is proper and all of the fields contain data. Then the editing
                session for editing the database is ended so the user can’t edit the data
                while it’s trying to save. Next, the program tries to save the data and
                will output a message box with an error message if saving the data fails
                for any reason. After that, the data is refreshed so the old data in the
                database is cleared and the new, manipulated data can be saved. The user
                can search for authors by last name by entering part of all of a last
                name into the textbox and clicking the Search button. This button click
                event uses a LINQ statement to filter the authors by last name. Any
                authors that have last names that start with the same string that was
                input into the textbox are placed at the top of the list, the authors
                are also sorted by first name and last name. The data source is then
                assigned the values of the LINQ statement, this assigns the filter to the
                values in the database. Finally, the user is prevented from adding or
                removing any data from the database when it’s filtered. The button that
                clears the search just allows adding and removing data from the database
                again and then refreshes the data. 
 */

using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Windows.Forms;

namespace DisplayTable
{
    public partial class DisplayAuthorsTable : Form
    {
        // constructor
        public DisplayAuthorsTable()
        {
            InitializeComponent();
        } // end constructor

        // Entity Framework dbcontext
        private KillRowan_22._3.BooksEntities dbcontext = null;

        // refresh the data in the display
        private void RefreshData()
        {
            // clear any old data in dbcontext
            if (dbcontext != null)
                dbcontext.Dispose();

            // create new dbcontext so it can be refreshed with new data
            dbcontext = new KillRowan_22._3.BooksEntities();

            // load Authors table ordered by LastName then FirstName
            dbcontext.Authors
               .OrderBy(author => author.LastName)
               .ThenBy(author => author.FirstName)
               .Load();

            // specify DataSource for authorBindingSource
            authorBindingSource.DataSource = dbcontext.Authors.Local;
            authorBindingSource.MoveFirst();    // get the first result
            txtSearchAuthors.Clear();           // clear the text in the search box
        } // end method Refresh

        // load data from database into DataGridView
        private void DisplayAuthorsTable_Load(object sender, EventArgs e)
        {
            RefreshData();  // add data from database to the authorBindingSource
        } // end method load

        // method handles click events for the Save Button in the BindingNavigator
        // saves the changes made to the data
        private void authorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();                     // validate the input fields
            authorBindingSource.EndEdit();  // complete current edit

            // try saving changes
            try
            {
                // write changes to database file
                dbcontext.SaveChanges();
            } // end try
            catch (DbEntityValidationException)
            {
                // display error message in message box
                MessageBox.Show("FirstName and LastName must contain values",
                   "Entity Validation Exception");
            } // end catch

            // refresh the display with the new data
            RefreshData();
        } // end method for save button on navigation bar

        // method controls what happens when Search button is clicked
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // filter contacts with last names that start with the string entered by the
            // user in the textbox
            var filterLastNames =
               from author in dbcontext.Authors
               where author.LastName.StartsWith(txtSearchAuthors.Text)
               orderby author.LastName, author.FirstName
               select author;

            // display matching contacts
            // assign filtered list to the data source for Authors, changing values in
            // the data source
            authorBindingSource.DataSource = filterLastNames.ToList();
            authorBindingSource.MoveFirst(); // go to first result

            // user cannot add or remove items from the display while it's filtered
            bindingNavigatorAddNewItem.Enabled = false;
            bindingNavigatorDeleteItem.Enabled = false;
        } // end method for Search button

        // method for clearing users filter and showing all data again
        private void btnClear_Click(object sender, EventArgs e)
        {
            // allow user to add and remove items from display
            bindingNavigatorAddNewItem.Enabled = true;
            bindingNavigatorDeleteItem.Enabled = true;

            // refresh data
            RefreshData();
        } // end method for Clear Search button
    } // end partial class DisplayAuthorsTable
} // end namespace
