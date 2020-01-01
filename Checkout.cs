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
    public partial class Checkout : Form
    {
        SqlConnection scon;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlCommand cmd2;
        /// <summary>
        /// create and open the connection.
        /// </summary>
        public void CreateConnection()
        {
            scon = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = scon.CreateCommand();
            cmd1 = scon.CreateCommand();
            cmd2 = scon.CreateCommand();
            scon.Open();
        }
        public Checkout()
        {
            InitializeComponent();
        }
        /// <summary>
        /// goes back to the home page when the button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        /// <summary>
        /// whenever the user checks out, their bonus points are updated based on how much they spent, ie
        /// for every $100 spent user gets 1 bonus point
        /// </summary>
        /// <param name="bonus"></param>
        private void updateBonus(double bonus)
        {
            //connection is created and bonus points are updated in customer table
            CreateConnection();
            cmd.CommandText = "UPDATE grocery.dbo.Customer SET Customer_bonus = "+bonus+"  WHERE Customer_id= "
                +Properties.Settings.Default.Customer_id+"";
            int check = cmd.ExecuteNonQuery();
            if(check > 0)
            {
                MessageBox.Show("Bonus updated");
            }
            else
            {
                MessageBox.Show("Bonus not updated");
            }
        }
        /// <summary>
        /// on the click of the button, all the textboxes are validate.
        /// the card number should be 16 digits only.
        /// the cvs should be 3 digits only.
        /// the bonus points should not be gretaer than what the user has
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            CreateConnection();
            long check1;
            double check11;
            if (textBox2.Text.Length != 16)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2,"The Cardnumber should be of 16 digits");
                MessageBox.Show("The card number should be 16 digits");
            }
            else if(textBox3.Text.Length != 3)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "The CVS should be of 3 digits");
                MessageBox.Show("The CVS should be of 3 digits");
            }
            else if (textBox5.Text.Equals(""))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox5, "Bonus credit cannot be empty");
                MessageBox.Show("Bonus credit cannot be empty\n ");
            }
            else if (double.Parse(textBox5.Text) > (Properties.Settings.Default.Customer_bonus/100.0))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox5, "You cannot spend over your bonus credit");
                MessageBox.Show("You cannot spend over your bonus credit\n You can spend till $ " + Properties.Settings.Default.Customer_bonus/100.0);
            }
            else if (double.Parse(textBox5.Text) > double.Parse(textBox1.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox5, "You cannot spend over your bonus credit");
                MessageBox.Show("You cannot spend over your Total cost that is $ " + textBox1.Text);
            }
            else if (long.TryParse(textBox2.Text, out check1))
            {
                if (double.TryParse(textBox5.Text, out check11))
                {
                    //connection is created and the payment status is updated in the databse.
                    errorProvider1.Clear();
                    int check2;
                    if (int.TryParse(textBox3.Text, out check2))
                    {
                        errorProvider1.Clear();
                        int[] order0 = getOrders0();
                        foreach (int i in order0)
                        {
                            cmd.CommandText = "INSERT INTO grocery.dbo.Payment (Order_id,Customer_id,Cardnumber,CVS) VALUES" +
                                "(" + i + "," + Properties.Settings.Default.Customer_id + "," + check1 + "," + check2 + ")";
                            int check4 = cmd.ExecuteNonQuery();
                            if (check4 > 0)
                            {
                                //MessageBox.Show("Order No." + i + " successful");
                            }
                            else
                            {
                                //MessageBox.Show("Order No." + i + " unsuccessful");
                            }
                        }
                        int[] payment0 = new int[order0.Length];
                        for (int j = 0; j < order0.Length; j++)
                        {
                            payment0[j] = getPaymentId(order0[j]);
                        }
                        int l = 0;
                        bool valid = true;
                        //the status is changed to 1 ie order completed whenever the user successfully checks out.
                        foreach (int k in payment0)
                        {
                            cmd.CommandText = "UPDATE grocery.dbo.[Order] SET Payment_id = " + k + " ,[Status] = 1 " +
                                "WHERE Order_id = " + order0[l++] + ";";
                            int check4 = cmd.ExecuteNonQuery();
                            if (check4 > 0)
                            {

                            }
                            else
                            {
                                valid = false;
                            }
                        }
                        if (valid)
                            //whenever order is successful, it updates the bonus points also
                        {
                            MessageBox.Show("Order Successfull");
                            double bonus = Properties.Settings.Default.Customer_bonus - (double.Parse(textBox5.Text) * 100) + Properties.Settings.Default.Customer_total;
                            updateBonus(bonus);
                            ShoppingCart scart = new ShoppingCart();
                            scart.Show();
                            this.Hide();
                        }
                    }

                    else
                    {
                        errorProvider1.Clear();
                        errorProvider1.SetError(textBox3, "The CVS cannot have characters");
                        MessageBox.Show("The CVS cannot have character");
                    }
                }
                else
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(textBox5, "The Bonus cannot have characters");
                    MessageBox.Show("The Bonus cannot have character");
                }
            }
            else
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "The Cardnumber cannot have characters");
                MessageBox.Show("The Cardnumber cannot have character");
            }
            

            scon.Close();
        }
        /// <summary>
        /// get the order id for the selected order from the database
        /// </summary>
        /// <returns></returns>
        private int[] getOrders0()
        {
            cmd.CommandText = "select Order_id from grocery.dbo.[Order] where status = 0 and customer_id = '"
                +Properties.Settings.Default.Customer_id+"';";
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count++;
            }
            dr.Close();
            int[] a = new int[count];
            cmd1.CommandText = "select Order_id from grocery.dbo.[Order] where status = 0 and customer_id = '" +
                Properties.Settings.Default.Customer_id + "';";
            cmd1.ExecuteNonQuery();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            int i = 0;
            while (dr1.Read())
            {
                a[i++] = int.Parse(dr1[0].ToString());
            }
            dr1.Close();
            return a;
        }

        /// <summary>
        /// get the payment id for the selected order from the database
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        private int getPaymentId(int orderid)
        {
            cmd.CommandText = "select Payment_id from grocery.dbo.[Payment] where Order_id = '" + orderid + "';";
            cmd.ExecuteNonQuery();
            SqlDataReader dr2 = cmd.ExecuteReader();
            int a = 0;
            while (dr2.Read())
            {
                a = int.Parse(dr2[0].ToString());
            }
            dr2.Close();
            return a;
        }
        /// <summary>
        /// shows how many bonus points the user has.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is your Bonus Credit Points\n" +
                "Currently you have " + Properties.Settings.Default.Customer_bonus + " points which is eqvivalent to $"+ Properties.Settings.Default.Customer_bonus/100.0 );
            /*
            foreach(int i in getOrders())
            {
                MessageBox.Show("order : " + i);
            }
            */
        }

        private void Checkout_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.Customer_total.ToString();
            setBonus();
            textBox5.Text = (Properties.Settings.Default.Customer_bonus/100).ToString();
        }
        private void setBonus()
        {
            CreateConnection();
            cmd.CommandText = "SELECT Customer_bonus" +
                " FROM grocery.dbo.Customer where Customer_id = " + Properties.Settings.Default.Customer_id + ";";
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Properties.Settings.Default.Customer_bonus = double.Parse(dr[0].ToString());
                
            }
            scon.Close();
        }
    }
}
