using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CML2V2\SQLEXPRESS;Initial Catalog=LoginDatabase;Integrated Security=True");
            
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Login where Username = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'",con);
            
            DataTable dt = new DataTable();
            
            sda.Fill(dt);

            if(dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Main ss = new Main();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password! Please check and Try Again.");
            }
        }
    }
}
