using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupProject
{
    public partial class Browse : Form
    {
        //declare the connection name
        SqlConnection scon;
        //declare the sql command
        SqlCommand cmd;

        /// <summary>
        /// Method to create and open a connection
        /// </summary>
        public void CreateConnection()
        {
            ///<summary>
            ///Create a new connection using the connection string stored in the properties
            ///</summary>
            scon = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = scon.CreateCommand();
            scon.Open();
        }

        public Browse()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Add the items to combo box on form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form4_Load(object sender, EventArgs e)
        {
            displayData(""+Properties.Settings.Default.BrowseSelect);
            comboBox1.Items.Add("product_name");
            comboBox1.Items.Add("price below");
            comboBox1.Items.Add("price above");
            comboBox1.SelectedIndex = 0;
            Properties.Settings.Default.BrowseSelect = "";
        }
        /// <summary>
        /// Search the product based on different parameters selected from the combo box ie product_name, price above or price below.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="filter"></param>
        public void searchProduct(string name, string filter)
        {
            ///show error if no name for product is entered before clicking search
            if (name.Equals(""))
            {
                MessageBox.Show("Enter the Product Name before clicking the 'Search' button");
                errorProvider1.SetError(textBox2, "Textbox empty");
            }
            //find the product based on the product name entered by the user
            else if (filter.Equals("product_name"))
            {
                errorProvider1.Clear();
                CreateConnection();
                dataGridView1.DataSource = null;
                double temp;
                //shows error if user does not enter a string
                if (double.TryParse(name, out temp)) {
                    MessageBox.Show("Invalid Name entered! Try Again");
                    errorProvider1.SetError(textBox2,"Invalid Name Entered! Try Again");
                }
                else
                {
                    //connects to the databse and finds the products based on the name specified by the user.
                    errorProvider1.Clear();
                    dataGridView1.DataSource = null;
                    cmd.CommandText = "select Product_id,Product_type,Product_name,Product_price from " +
                        "grocery.dbo.Product where Product_name = '" + name+"';";
                    cmd.ExecuteNonQuery();
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    dataGridView1.DataSource = dt;
                }
                scon.Close();
            }
            //if user selects filter for price below a certain amount, it connects to the database and displays all the products below that amount.
            else if (filter.Equals("price below"))
            {
                errorProvider1.Clear();
                CreateConnection();
                dataGridView1.DataSource = null;
                double temp;
                if (double.TryParse(name, out temp))
                {
                    errorProvider1.Clear();
                    dataGridView1.DataSource = null;
                    cmd.CommandText = "select Product_id,Product_type,Product_name,Product_price from" +
                        " grocery.dbo.Product where Product_price < '" + (temp) + "';";
                    cmd.ExecuteNonQuery();
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Invalid Name entered! Try Again");
                    errorProvider1.SetError(textBox2, "Invalid Name Entered! Try Again");                    
                }
                scon.Close();
            }
            //   //if user selects filter for price above a certain amount, it connects to the database and displays all the products above that amount.
            else if (filter.Equals("price above"))
            {
                errorProvider1.Clear();
                CreateConnection();
                dataGridView1.DataSource = null;
                double temp;
                if (double.TryParse(name, out temp))
                {
                    errorProvider1.Clear();
                    dataGridView1.DataSource = null;
                    cmd.CommandText = "select Product_id,Product_type,Product_name,Product_price from " +
                        "grocery.dbo.Product where Product_price > '" + (temp) + "';";
                    cmd.ExecuteNonQuery();
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Invalid Name entered! Try Again");
                    errorProvider1.SetError(textBox2, "Invalid Name Entered! Try Again");
                }
                scon.Close();
            }
        }
        /// <summary>
        /// this method takes in the product type and displays in the gridview all the products that are of that specific type.
        /// </summary>
        /// <param name="ProductType"></param>
        public void displayData(String ProductType)
        {
            CreateConnection();
            dataGridView1.DataSource = null;
            if (ProductType.Equals(""))
            {
                cmd.CommandText = "select Product_id,Product_type,Product_name,Product_price from grocery.dbo.Product";
                cmd.ExecuteNonQuery();
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                dataGridView1.DataSource = dt;
            }
            else
            {
                cmd.CommandText = "select Product_id,Product_type,Product_name,Product_price from grocery.dbo.Product" +
                    " where Product_type = '" + ProductType+"';";
                cmd.ExecuteNonQuery();
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                dataGridView1.DataSource = dt;
            }
            scon.Close();
        }
        /// <summary>
        /// All the methods below take in the product type and call the displaymethod() on click of the button to display all the products of that specific type.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PantryFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayData("Fruits and Vegetables");
        }

        private void FruitsAndVegetablesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ShoppingCart sCart = new ShoppingCart();
            sCart.Show();
            this.Hide();
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("1) Select the Categories to display the products in the gridview\n2) ");
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void DiaryAndEggsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayData("Dairy and Eggs");
        }

        private void NaturalAndOrganicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayData("Natural and Organic");
        }

        private void MeatAndSeafoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayData("Meat and Seafood");
        }

        private void FrozenFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayData("Frozen Food");
        }

        private void DeliAndFreshMealsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayData("Deli and Fresh meals");
        }

        private void CerealAndBreakfastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayData("Cereal and Breakfast");
        }

        private void BakeryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayData("Bakery");
        }

        private void PantryFoodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayData("Pantry Foods");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //textBox2.Text
            searchProduct(textBox2.Text,comboBox1.SelectedItem.ToString());
        }
        /// <summary>
        /// This method gets the customer id of the user that is logged in from the customer table
        /// </summary>
        /// <returns>
        /// customer id
        /// </returns>
        private int getCustomerId()
        {
            CreateConnection();
            int id=0;
            cmd.CommandText = "Select Customer_id from grocery.dbo.Customer where Customer_name ='"
                +Properties.Settings.Default.CustomerName+"'";
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id = int.Parse(dr[0].ToString());
            }
            scon.Close();
            return id;
        }
        /// <summary>
        /// on the button click for add to cart, the user is asked to select a row for the product that they want to add to the cart,
        /// and if the product is selected then on click of the button the product is added to the cart.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            int temp;

            if (int.TryParse(textBox1.Text, out temp))
            {
                int Customer_id = getCustomerId();
                errorProvider1.Clear();
                String item = Properties.Settings.Default.Cart_Product_id;
                //if the user doesnt select any row, error message is given to select the row for which user wants to add the product to the cart
                if (item.Equals("empty"))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(button1, "Select a row from the Gridview to add a Product to the Cart");
                    MessageBox.Show("Select a row from the Gridview to add a Product to the Cart");
                }
                else
                {
                    //connection is created and the product is added to the cart
                    errorProvider1.Clear();
                    CreateConnection();
                    cmd.CommandText = "insert into grocery.dbo.[Order](Customer_id,Product_id,Status,Quantity) values " 
                        + "(" + Customer_id + "," + item + ",0," + temp + ")";
                    //Product_id,Product_type,Product_name,Product_price
                    int check = cmd.ExecuteNonQuery();
                    if (check > 0)
                    {
                        MessageBox.Show("Items added Successfully");
                        Properties.Settings.Default.Cart_Product_id = "empty";
                    }
                    else
                    {
                        MessageBox.Show("Items not added to the Cart");
                    }
                    scon.Close();
                }
            }
            else
            {
                MessageBox.Show("Enter an integer value in the textbox highlighted below");
                errorProvider1.SetError(textBox1,"Invalid value. Enter an Integer value");
            }
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //gets the content when the rowheader is clicked.
            Properties.Settings.Default.Cart_Product_id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
