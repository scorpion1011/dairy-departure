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
        public AddProduct()
        {
            InitializeComponent();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dairyDeparture1DataSet.Manufacturer_Запрос' table. You can move, or remove it, as needed.
            this.manufacturer_ЗапросTableAdapter.Fill(this.dairyDeparture1DataSet.Manufacturer_Запрос);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    int ID;
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
                MessageBox.Show("Employee successfully added");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
