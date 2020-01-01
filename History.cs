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
    public partial class History : Form
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
        public History()
        {
            InitializeComponent();
        }

        private void History_Load(object sender, EventArgs e)
        {
            DisplayHistory();
        }
        public void DisplayHistory()
        {
            CreateConnection();
            dataGridView1.DataSource = null;
            cmd.CommandText =  "SELECT a.Order_id,b.Customer_id,Product_name,[Status],[Quantity],customer_name " +
                "FROM grocery.dbo.[Order] a inner join grocery.dbo.Customer b on a.Customer_id = b.Customer_id " +
                "inner join grocery.dbo.Product c on a.Product_id = c.Product_id where status = 1 and " +
                "b.Customer_name = '"+Properties.Settings.Default.CustomerName + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            rd.Close();
            dataGridView1.DataSource = dt;
            scon.Close();
        }
        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Properties.Settings.Default.DeleteHistory = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.DeleteHistory.Equals("empty"))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(button2,"Select a row in the girdview");
                MessageBox.Show("Select a row in Gridview to delete a history record");
            }
            else
            {
                errorProvider1.Clear();
                CreateConnection();
                cmd.CommandText = "delete from grocery.dbo.[Order] where Customer_id = "+Properties.Settings.Default.Customer_id
                    +" and Order_id = " +Properties.Settings.Default.DeleteHistory+"";
                int check = cmd.ExecuteNonQuery();
                if(check > 0)
                {
                    MessageBox.Show("The Order No." + Properties.Settings.Default.DeleteHistory + " was deleted");
                    DisplayHistory();
                }
                else
                {
                    MessageBox.Show("The Order No." + Properties.Settings.Default.DeleteHistory + " was not deleted");
                }
                scon.Close();
            }
        }

        int getID()
        {
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
            return id;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CreateConnection();
            cmd.CommandText = "DELETE from grocery.dbo.[Order] where status = 1 and Customer_id = " + getID() + ";";
            int check = cmd.ExecuteNonQuery();
            if (check > 0)
            {
                MessageBox.Show("History successfully deleted");
                DisplayHistory();
            }
            else
            {
                MessageBox.Show("History is empty");
            }
            scon.Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
