using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GiftShopee
{
    public partial class Login : Form
    {
        public string username;
        public string password;
        public Login()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
             username = textBox1.Text;
            password = textBox2.Text;
            if(username=="rohit"&& password=="pass")
            {
                MessageBox.Show("Welcome Rohit Sir");
                this.Hide();
                Owner obj = new Owner();
                obj.Show();

            }
            else
            {
                MessageBox.Show("Unauthorised Login");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
           

                // When password text box clixked, the watermark will disappear

                textBox2.Text = "";

            textBox2.ForeColor = Color.Black;

            textBox2.PasswordChar = '●'; // Password masking for added security

            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
