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
    public partial class CustomerPage : Form
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
        public CustomerPage()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            CreateConnection();
            if (textBox2.Text.Equals("")) {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2,"Password cannot be empty");
                MessageBox.Show("Password cannot be empty");
            }
            else if(textBox3.Text.Equals("")){
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Email cannot be empty");
                MessageBox.Show("Email cannot be empty");
            }
            else if (textBox4.Text.Equals(""))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox4, "Phone cannot be empty");
                MessageBox.Show("Phone cannot be empty");
            }
            else if (textBox2.Text.Length>14)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Password cannot be exceed 14 characters");
                MessageBox.Show("Password cannot exceed 14 characters");
            }
            else if (textBox3.Text.Length > 20)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Email cannot exceed 20 digits");
                MessageBox.Show("Email cannot exceed 20 digits");
            }
            else if (textBox4.Text.Length > 7)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox4, "Phone cannot be exceed 7 digits");
                MessageBox.Show("Phone cannot exceed 7 digits");
            }
            else
            {
                errorProvider1.Clear();
                double check1;
                if(double.TryParse(textBox2.Text, out check1))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(textBox2, "Password must contain characters");
                    MessageBox.Show("Password must contain characters");
                }
                else
                {
                    double check2;
                    if(double.TryParse(textBox3.Text, out check2))
                    {
                        errorProvider1.Clear();
                        errorProvider1.SetError(textBox2, "Email must contain characters");
                        MessageBox.Show("Email must contain characters");
                    }
                    else
                    {
                        if(textBox3.Text.IndexOf('@') != -1)
                        {
                            long check3;
                            if(long.TryParse(textBox4.Text, out check3))
                            {
                                cmd.CommandText = "UPDATE grocery.dbo.Customer SET Customer_password = '"+textBox2.Text+"', " +
                                    "Customer_email = '"+textBox3.Text+"',Customer_phone = "+check3+" WHERE Customer_id = "+
                                    Properties.Settings.Default.Customer_id+";";
                                int check4 = cmd.ExecuteNonQuery();
                                if(check4 > 0)
                                {
                                    MessageBox.Show("Customer Info Updated successfully");
                                    textBox2.Enabled = false;
                                    textBox3.Enabled = false;
                                    textBox4.Enabled = false;
                                    button2.Enabled = false;
                                    displayProfile();
                                }
                                else
                                {
                                    MessageBox.Show("Customer Info not Updated");
                                }
                            }
                            else
                            {
                                errorProvider1.Clear();
                                errorProvider1.SetError(textBox2, "Phone should contain only numbers");
                                MessageBox.Show("Phone should contain only numbers");
                            }
                        }
                        else
                        {
                            errorProvider1.Clear();
                            errorProvider1.SetError(textBox3, "Email must contain @ character");
                            MessageBox.Show("Email must contain @ character");
                        }
                    }
                }
            }
            scon.Close();
        }

        private void HistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void HistoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            History history = new History();
            history.Show();
            this.Hide();
        }

        private void ShoppingCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShoppingCart sCart = new ShoppingCart();
            sCart.Show();
            this.Hide();
        }

        private void HomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void CustomerPage_Load(object sender, EventArgs e)
        {
            displayProfile();
        }

        private void displayProfile()
        {
            CreateConnection();
            cmd.CommandText = "SELECT Customer_name,Customer_password,Customer_email,Customer_phone,Customer_bonus" +
                " FROM grocery.dbo.Customer where Customer_id = "+Properties.Settings.Default.Customer_id+";";
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                textBox5.Text = dr[4].ToString();
            }
            textBox6.Text = (int.Parse(textBox5.Text)/100.0).ToString();
            scon.Close();
        }

    }
}
