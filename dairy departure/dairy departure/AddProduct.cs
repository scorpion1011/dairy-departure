using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dairy_departure
{
    public partial class AddProduct : Form
    {
        Director parent;
        int id;
        public AddProduct(Director parent, int id)
        {
            this.parent = parent;
            this.id = id;
            InitializeComponent();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dairyDeparture1DataSet.Manufacturer_Запрос' table. You can move, or remove it, as needed.
            this.manufacturer_ЗапросTableAdapter.Fill(this.dairyDeparture1DataSet.Manufacturer_Запрос);

            if (id != -1)
            {
                DataGridViewRow row = (parent.Controls.Find("dataGridView1", true)[0] as DataGridView).Rows[id];

                maskedTextBox1.Text = row.Cells["PrName"].Value.ToString();
                
                var j = comboBox1.SelectedValue;
                comboBox1.SelectedValue = row.Cells["ID_manufacturer"].Value.ToString();
                maskedTextBox2.Text = row.Cells["Weight"].Value.ToString();
                maskedTextBox4.Text = row.Cells["Proc"].Value.ToString();
                maskedTextBox3.Text = row.Cells["ShelfLife"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id == -1)
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"Insert into Product ([Name_product], [ID_manufacturer], [Mass/volume], [%-fat], [ShelfLife])
                                    values (@Name_product, @ID_manufacturer, @Mass, @proc, @ShelfLife)
                    ";
                        using (OleDbCommand comm = new OleDbCommand(sql, conn))
                        {
                            comm.Parameters.AddWithValue("@Name_product", maskedTextBox1.Text);
                            comm.Parameters.AddWithValue("@ID_manufacturer", ((DairyDeparture1DataSet.Manufacturer_ЗапросRow)((DataRowView)((ComboBox)comboBox1).SelectedItem).Row).ID_manufacturer);
                            comm.Parameters.AddWithValue("@Mass", maskedTextBox2.Text);
                            comm.Parameters.AddWithValue("@proc", maskedTextBox3.Text);
                            comm.Parameters.AddWithValue("@ShelfLife", maskedTextBox4.Text);
                            comm.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Product successfully added");
                    parent.productsToolStripMenuItem_Click(this, e);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid input");
                }
            }
            else
            {
                try
                {
                    DataGridViewRow row = ((DataGridView)(parent.Controls["dataGridView1"])).Rows[id];
                    int prodID = Int32.Parse(row.Cells["ID_product"].Value.ToString());

                    string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"Update Product 
                                        set [Name_product] = @Name_product, [ID_manufacturer] = @ID_manufacturer,
                                            [Mass/volume] = @Mass, [%-fat] = @proc, [ShelfLife] = @ShelfLife
                                            where ID_product = @prodID
                    ";
                        using (OleDbCommand comm = new OleDbCommand(sql, conn))
                        {
                            comm.Parameters.AddWithValue("@Name_product", maskedTextBox1.Text);
                            comm.Parameters.AddWithValue("@ID_manufacturer", ((DairyDeparture1DataSet.Manufacturer_ЗапросRow)((DataRowView)((ComboBox)comboBox1).SelectedItem).Row).ID_manufacturer);
                            comm.Parameters.AddWithValue("@Mass", maskedTextBox2.Text);
                            comm.Parameters.AddWithValue("@proc", maskedTextBox3.Text);
                            comm.Parameters.AddWithValue("@ShelfLife", maskedTextBox4.Text);
                            comm.Parameters.AddWithValue("@ID_product", prodID);
                            comm.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Product successfully added");
                    parent.productsToolStripMenuItem_Click(this, e);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid input");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
