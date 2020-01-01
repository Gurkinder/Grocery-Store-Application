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
    public partial class Register : Form
    {
        SqlConnection scon;
        SqlCommand cmd;

        public void CreateConnection()
        {
            scon = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = scon.CreateCommand();
            scon.Open();
        }
        public Register()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            CreateConnection();
            double check;
            string uname = "";
            string pass = "";
            if (textBox1.Text.Equals(""))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "The usename cannot be empty");
                MessageBox.Show("Please enter username inn the textbox highlighted");
            }
            else if (textBox2.Text.Equals(""))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "The password cannot be empty");
                MessageBox.Show("Please enter password in the textbox highlighted");
            }
            else if (double.TryParse(textBox1.Text, out check))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "The username cannot be a word");
                MessageBox.Show("Username cannot be a number,Try again in the box highlighted");
            }
            else
            {
                errorProvider1.Clear();
                cmd.CommandText = "insert into grocery.dbo.Customer(Customer_name,Customer_password,Customer_bonus)" +
                    " values ('" +textBox1.Text + "','"+textBox2.Text+"',0)";
                int result = cmd.ExecuteNonQuery();
                if(result > 0)
                {
                    Properties.Settings.Default.CustomerName = textBox1.Text;
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                    MessageBox.Show("Congrats, New Customer added to the database");
                }
                else
                {
                    MessageBox.Show("Customer is not added");
                }
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
