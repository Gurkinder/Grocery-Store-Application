using System;
using System.Collections;
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
    public partial class ShoppingCart : Form
    {
        SqlConnection scon;
        SqlCommand cmd;
        SqlCommand cmd1;

        public void CreateConnection()
        {
            scon = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = scon.CreateCommand();
            cmd1 = scon.CreateCommand();
            scon.Open();
        }
        public ShoppingCart()
        {
            InitializeComponent();
        }

        private void ShoppingCart_Load(object sender, EventArgs e)
        {
            DisplayCart();
            textBox1.Text = CalculateCost().ToString();
        }
        public void DisplayCart()
        {
            CreateConnection();
            dataGridView1.DataSource = null;
            cmd.CommandText = "SELECT  a.Order_id,c.Customer_name,b.Product_type,b.Product_name,a.Quantity,b.Product_price " +
                "FROM grocery.dbo.[Order] a inner join grocery.dbo.Product b on a.Product_id = b.Product_id  " +
                "inner join grocery.dbo.Customer c on a.Customer_id = c.Customer_id where c.Customer_name = '"
                +Properties.Settings.Default.CustomerName+ "' and Status= 0; ";
            cmd.ExecuteNonQuery();
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            rd.Close();
            dataGridView1.DataSource = dt;
            scon.Close();
        }

        public double CalculateCost()
        {
            CreateConnection();
            cmd1.CommandText = "SELECT a.Quantity,b.Product_price FROM grocery.dbo.[Order] a inner join " +
                "grocery.dbo.Product b on a.Product_id = b.Product_id inner join grocery.dbo.Customer c " +
                "on a.Customer_id = c.Customer_id where c.Customer_name = '"
                +Properties.Settings.Default.CustomerName+ "' and Status= 0 ; ";
            cmd1.ExecuteNonQuery();
            SqlDataReader rd1 = cmd1.ExecuteReader();
            int length = 0;
            while (rd1.Read())
            {
                length++;
            }
            rd1.Close();
            SqlDataReader rd2 = cmd1.ExecuteReader();
            double[,] temp = new double[length,2];
            int i = 0;
            while (rd2.Read())
            {
                temp[i,0] = double.Parse(rd2[0].ToString());
                temp[i,1] = double.Parse(rd2[1].ToString());
                i++;
            }
            rd2.Close();
            double sum = 0;
            for (int j = 0; j< length; j++)
            {
                sum += (temp[j, 0] * temp[j, 1]);
            }
            scon.Close();
            return sum;
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Properties.Settings.Default.DeleteOrderid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Checkout checkout = new Checkout();
            Properties.Settings.Default.Customer_total = double.Parse(textBox1.Text);
            checkout.Show();
            this.Hide();
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Browse browse = new Browse();
            browse.Show();
            this.Hide();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String orderid = Properties.Settings.Default.DeleteOrderid;
            if (orderid.Equals("empty"))
            {
                errorProvider1.Clear();
                MessageBox.Show("Select row from the gridview to remove the Order");
                errorProvider1.SetError(button1, "Select row from the gridview to remove the Order");
            }
            else
            {
                errorProvider1.Clear();
                CreateConnection();
                cmd.CommandText = "Delete from grocery.dbo.[Order] where Order_id = " + orderid;
                cmd.ExecuteNonQuery();
                scon.Close();
                MessageBox.Show("Order Removed Successfully");
                dataGridView1.DataSource = null;
                DisplayCart();
                textBox1.Text = CalculateCost().ToString();
            }
        }
    }
}
