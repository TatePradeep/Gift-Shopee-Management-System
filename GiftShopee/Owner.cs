using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GiftShopee
{
    public partial class Owner : Form
    {
       /* public string ProductID;
        public string ProductName;
        public string Price;
        public string Category;*/
        public Owner()
        {
            InitializeComponent();
        }
       // SqlConnection sc = new SqlConnection("Data Source=DESKTOP-QQ7FMUC;Initial Catalog=Register_info;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 cs = new Class1();
            int no = cs.add_data(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            if (no >= 1)
            {
                MessageBox.Show("Data Added Successfully");
            }
            else
            {
                MessageBox.Show("Data Not Added");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Class1 cs = new Class1();
            dt = cs.display_info();
            dataGridView1.DataSource = dt;
        }

        private void Owner_Load(object sender, EventArgs e)
        {
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 cs = new Class1();
            int no = cs.delete_data(textBox5.Text);
            if (no >= 1)
            {
                MessageBox.Show("Data Deleted Successfully");
            }
            else
            {
                MessageBox.Show("Data Not Deleted");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Class1 cs = new Class1();
            int no = cs.update_data(textBox6.Text,textBox7.Text);
            if (no >= 1)
            {
                MessageBox.Show("Data updated Successfully");
            }
            else
            {
                MessageBox.Show("Data Not updated");

            }
        }
    }
}
