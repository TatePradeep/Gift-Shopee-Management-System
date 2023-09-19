
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
using System.Drawing.Printing;
using System.Text.RegularExpressions;

namespace GiftShopee
{

    public partial class home : Form
    {
        public String Name;
        public String Contact;
        public String ID;
        public String ProductName;
        public String Quantity;
        public String price;
        public home()
        {
            InitializeComponent();

            dataGridView2.DataSource = null;
            dataGridView2.ColumnCount = 7;
            dataGridView2.Columns[0].Name = "Name";
            dataGridView2.Columns[1].Name = "Contact";
            dataGridView2.Columns[2].Name = "ID";
            dataGridView2.Columns[3].Name = "Product";
            dataGridView2.Columns[4].Name = "Price";
            dataGridView2.Columns[5].Name = "Quantity";
            dataGridView2.Columns[6].Name = "Total Price";
            dataGridView2.Columns[6].ReadOnly = false;


            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        SqlConnection sc = new SqlConnection("Data Source=DESKTOP-QQ7FMUC;Initial Catalog=Register_info;Integrated Security=True");


        private void home_Load(object sender, EventArgs e)
        {
            // button8.Click += new EventHandler(button8_Click);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from GiftShop", sc);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            dataGridView1.DataSource = dt;
            sc.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void registerinfoDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void homeBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void homeBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }



        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from GiftShop where category='Toys'", sc);
            DataTable dt1 = new DataTable();

            sda.Fill(dt1);

            dataGridView1.DataSource = dt1;
            sc.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from GiftShop where category='Jewelry'", sc);
            DataTable dt1 = new DataTable();

            sda.Fill(dt1);

            dataGridView1.DataSource = dt1;
            sc.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from GiftShop where category='Accessories'", sc);
            DataTable dt1 = new DataTable();

            sda.Fill(dt1);

            dataGridView1.DataSource = dt1;
            sc.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            textBox2.BackColor = Color.White;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();

            int selectedRow = dataGridView2.CurrentCell.RowIndex;
            dataGridView2.Rows.RemoveAt(selectedRow);
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from GiftShop where category='Jewelry'", sc);

            sc.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            sc.Open();
            SqlCommand cmd = new SqlCommand("select ProductName,Price from GiftShop where ProductID='" + textBox3.Text + "' ", sc);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                textBox4.Text = da.GetValue(0).ToString();
                textBox6.Text = da.GetValue(1).ToString();

            }

            sc.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.BackColor = Color.LightGray;
                MessageBox.Show("Enter the name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            Regex ex = new Regex("^[0-9]{10}");
            bool isValid = ex.IsMatch(textBox2.Text);
            if (!isValid)
            {
                MessageBox.Show("Invalid Contact No");
                return;


            }
            if (textBox2.Text == "")
            {
                textBox2.BackColor = Color.LightGray;
                MessageBox.Show("Enter the mobile number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                
                
                return;
            }
           

            dataGridView2.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox6.Text);

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dataGridView2.Columns["Quantity"].Index || e.ColumnIndex == dataGridView2.Columns["Price"].Index))
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                double quantity;
                if (double.TryParse(row.Cells["Quantity"].Value?.ToString(), out quantity))
                {
                    double price;
                    if (double.TryParse(row.Cells["Price"].Value?.ToString(), out price))
                    {
                        double totalPrice = quantity * price;
                        row.Cells["Total Price"].Value = totalPrice;
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();

        }






        private void button8_Click(object sender, EventArgs e)
        {
            // Create an instance of the DataGridViewPrinter class
            DataGridViewPrinter dataGridViewPrinter = new DataGridViewPrinter(dataGridView2, new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

            // Print the entire dataGridView2 content
            dataGridViewPrinter.Print();
        }


        internal class DataGridViewPrinter
        {
            private DataGridView dataGridView;
            private Font font;
            private Color color;
            private bool isCentered;

            public DataGridViewPrinter(DataGridView dataGridView, Font font, Color color, bool isCentered)
            {
                this.dataGridView = dataGridView;
                this.font = font;
                this.color = color;
                this.isCentered = isCentered;
            }

            public void Print()
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += PrintDocument_PrintPage;

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }

            private int currentPageIndex = 0; // Class-level variable to track the current page index

            private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
            {
                Graphics graphics = e.Graphics;
                Brush brush = new SolidBrush(color);
                Pen pen = new Pen(color);

                int rowHeight = dataGridView.RowTemplate.Height;
                int columnWidth = 0;

                // Calculate the total width of the columns
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    columnWidth += column.Width;
                }

                // Calculate the total height of the rows
                int totalHeight = dataGridView.RowCount * rowHeight;

                // Calculate the number of rows that can fit on a page
                int rowsPerPage = e.MarginBounds.Height / rowHeight;

                // Calculate the number of pages needed
                int totalPages = (int)Math.Ceiling((double)dataGridView.RowCount / rowsPerPage);

                // Set the starting position
                int x = e.MarginBounds.Left;
                int y = e.MarginBounds.Top;

                // Draw the column headers
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    graphics.FillRectangle(brush, new Rectangle(x, y, column.Width, rowHeight));
                    graphics.DrawRectangle(pen, new Rectangle(x, y, column.Width, rowHeight));
                    if (isCentered)
                    {
                        graphics.DrawString(column.HeaderText, font, Brushes.Black, new RectangleF(x, y, column.Width, rowHeight), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        graphics.DrawString(column.HeaderText, font, Brushes.Black, new RectangleF(x, y, column.Width, rowHeight));
                    }
                    x += column.Width;
                }

                y += rowHeight;

                // Draw the rows
                int startIndex = currentPageIndex * rowsPerPage;
                int endIndex = startIndex + rowsPerPage - 1;
                if (endIndex >= dataGridView.RowCount)
                {
                    endIndex = dataGridView.RowCount - 1;
                }

                for (int rowIndex = startIndex; rowIndex <= endIndex; rowIndex++)
                {
                    DataGridViewRow row = dataGridView.Rows[rowIndex];

                    x = e.MarginBounds.Left;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        graphics.FillRectangle(Brushes.White, new Rectangle(x, y, cell.OwningColumn.Width, rowHeight));
                        graphics.DrawRectangle(pen, new Rectangle(x, y, cell.OwningColumn.Width, rowHeight));
                        if (isCentered)
                        {
                            graphics.DrawString(cell.Value?.ToString(), font, Brushes.Black, new RectangleF(x, y, cell.OwningColumn.Width, rowHeight), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                        }
                        else
                        {
                            graphics.DrawString(cell.Value?.ToString(), font, Brushes.Black, new RectangleF(x, y, cell.OwningColumn.Width, rowHeight));
                        }
                        x += cell.OwningColumn.Width;
                    }

                    y += rowHeight;
                }

                currentPageIndex++; // Increment the current page index

                e.HasMorePages = (currentPageIndex < totalPages);
            }

            // Method to initiate the printing process
            private void PrintDataGridView()
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += PrintDocument_PrintPage;

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                currentPageIndex = 0; // Reset the current page

                printDocument.Print();
            }
        }

       

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text== "Enter Your Full Name")
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Contact  No")
            {
                textBox2.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from GiftShop where category='Home Decor'", sc);
            DataTable dt1 = new DataTable();

            sda.Fill(dt1);

            dataGridView1.DataSource = dt1;
            sc.Close();

        }
    }
}