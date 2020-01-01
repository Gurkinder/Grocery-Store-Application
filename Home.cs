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
    public partial class Home : Form
    {
        SqlConnection scon;
        SqlCommand cmd;

        public void CreateConnection()
        {
            scon = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = scon.CreateCommand();
            scon.Open();
        }
        public Home()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text += " - " + Properties.Settings.Default.CustomerName;
            Properties.Settings.Default.Customer_id = getID();
            displaySale();
        }
        int getID()
        {
            CreateConnection();
            int id = 0;
            cmd.CommandText = "select Customer_id from grocery.dbo.customer where customer_name='"
                + Properties.Settings.Default.CustomerName + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id = int.Parse(dr[0].ToString());
            }
            dr.Close();
            scon.Close();
            return id;
        }

        private void Chart1_Click(object sender, EventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private int[] getPIds()
        {
            CreateConnection();
            cmd.CommandText = "SELECT TOP(5) Product_id FROM grocery.dbo.[Order] where [Status] = 1 group by " +
                "Product_id order by Count(*) desc;";
            cmd.ExecuteNonQuery();
            SqlDataReader dr1 = cmd.ExecuteReader();
            int count = 0;
            while (dr1.Read())
            {
                count++;
            }
            dr1.Close();
            int[] id = new int[count];
            cmd.CommandText = "SELECT TOP(5) Product_id FROM grocery.dbo.[Order] where [Status] = 1 group by " +
                "Product_id order by Count(*) desc;";
            cmd.ExecuteNonQuery();
            SqlDataReader dr2 = cmd.ExecuteReader();
            int i = 0;
            while(dr2.Read()){
                id[i++] = int.Parse(dr2[0].ToString());
            }
            scon.Close();
            return id;
        }

        private void displaySale()
        {
            dataGridView1.DataSource = null;
            int[] a = getPIds();
            //foreach (int i in a)
            //{
            //    MessageBox.Show("Id : " + i);
            //}
            CreateConnection();
            if (a.Length == 5)
            {
                cmd.CommandText = "SELECT Product_Type,Product_name,Product_price FROM grocery.dbo.[Product] " +
                        "where Product_id = " + a[0] + " OR Product_id = " + a[1] + " OR Product_id = " + a[2] + " OR" +
                        " Product_id = "+a[3]+" OR Product_id = "+a[4]+";";
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
            }
            else if (a.Length == 4)
            {
                cmd.CommandText = "SELECT Product_Type,Product_name,Product_price FROM grocery.dbo.[Product] " +
                        "where Product_id = " + a[0] + " OR Product_id = " + a[1] + " OR Product_id = " + a[2] + " OR" +
                        " Product_id = " + a[3] + ";";
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
            }
            else if (a.Length == 3)
            {
                cmd.CommandText = "SELECT Product_Type,Product_name,Product_price FROM grocery.dbo.[Product] " +
                        "where Product_id = " + a[0] + " OR Product_id = " + a[1] + " OR Product_id = " + a[2] + ";";
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
            }
            else if(a.Length == 2)
            {
                cmd.CommandText = "SELECT Product_Type,Product_name,Product_price FROM grocery.dbo.[Product] " +
                        "where Product_id = " + a[0] + " OR Product_id = " + a[1] +";";
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
            }
            scon.Close();
        }
       

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Browse browse = new Browse();
            browse.Show();
            this.Hide();
        }

        private void ShoppingCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerPage cpage = new CustomerPage();
            cpage.Show();
            this.Hide();
        }

        private void DiaryAndEggsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Browse browse = new Browse();
            Properties.Settings.Default.BrowseSelect = "Dairy and Eggs";
            browse.Show();
            this.Hide();
        }

        private void PantryFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Browse browse = new Browse();
            Properties.Settings.Default.BrowseSelect = "Fruits and Vegetables";
            browse.Show();
            this.Hide();
        }

        private void NaturalAndOrganicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Browse browse = new Browse();
            Properties.Settings.Default.BrowseSelect = "Natural and Organic";
            browse.Show();
            this.Hide();
        }

        private void MeatAndSeafoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Browse browse = new Browse();
            Properties.Settings.Default.BrowseSelect = "Meat and Seafood";
            browse.Show();
            this.Hide();
        }

        private void FrozenFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Browse browse = new Browse();
            Properties.Settings.Default.BrowseSelect = "Frozen Food";
            browse.Show();
            this.Hide();
        }

        private void DeliAndFreshMealsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Browse browse = new Browse();
            Properties.Settings.Default.BrowseSelect = "Deli and Fresh meals";
            browse.Show();
            this.Hide();
        }

        private void CerealAndBreakfastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Browse browse = new Browse();
            Properties.Settings.Default.BrowseSelect = "Cereal and Breakfast";
            browse.Show();
            this.Hide();
        }

        private void BakeryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Browse browse = new Browse();
            Properties.Settings.Default.BrowseSelect = "Bakery";
            browse.Show();
            this.Hide();
        }

        private void PantryFoodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Browse browse = new Browse();
            Properties.Settings.Default.BrowseSelect = "Pantry Foods";
            browse.Show();
            this.Hide();
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            Properties.Settings.Default.CustomerName = "";
            this.Hide();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
