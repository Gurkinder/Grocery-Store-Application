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
    public partial class Login : Form
    {
        SqlConnection scon;
        SqlCommand cmd;

        public void CreateConnection()
        {
            scon = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = scon.CreateCommand();
            scon.Open();
        }

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void Button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Customer_bonus = 0;
            Properties.Settings.Default.BrowseSelect = "";
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
            else if (double.TryParse(textBox1.Text,out check))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "The username cannot be a word");
                MessageBox.Show("Username cannot be a number,Try again in the box highlighted");
            }
            else
            {
                errorProvider1.Clear();
                cmd.CommandText = "select Customer_name,Customer_password from grocery.dbo.Customer where " +
                    "Customer_name='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    uname = dr[0].ToString();
                    pass = dr[1].ToString();
                }
                if (uname.Equals(textBox1.Text) && pass.Equals(textBox2.Text))
                {
                    Properties.Settings.Default.CustomerName = uname;
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    label4.Visible = true;
                    button1.Visible = true;
                    errorProvider1.Clear();
                    MessageBox.Show("The entered login credentials are invalid! Try again");
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';






        }
    }
}
