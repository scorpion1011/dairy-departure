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
    public partial class NewProduct : Form
    {
        public NewProduct()
        {
            InitializeComponent();
        }

        private void productBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dairyDeparture1DataSet);

        }

        private void NewProduct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dairyDeparture1DataSet.Manufacturer_Запрос' table. You can move, or remove it, as needed.
            this.manufacturer_ЗапросTableAdapter.Fill(this.dairyDeparture1DataSet.Manufacturer_Запрос);
            // TODO: This line of code loads data into the 'dairyDeparture1DataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.dairyDeparture1DataSet.Product);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddManufacturer f = new AddManufacturer();
            f.ShowDialog();
			manufacturer_ЗапросTableAdapter.ClearBeforeFill = true;
			manufacturer_ЗапросTableAdapter.Fill(dairyDeparture1DataSet.Manufacturer_Запрос);
		}

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"Insert into Product ([Name_product], [ID_manufacturer], [Mass/volume], [%-fat], [ShelfLife])
                                    values (@Name_product, @ID_manufacturer, @Mass, @Proc, @ShelfLife)
                ";
                    using (OleDbCommand comm = new OleDbCommand(sql, conn))
                    {
                        comm.Parameters.AddWithValue("@Name_product", textBox1.Text);
                        comm.Parameters.AddWithValue("@ID_manufacturer", ((DairyDeparture1DataSet.Manufacturer_ЗапросRow)((DataRowView)((ComboBox)comboBox1).SelectedItem).Row).ID_manufacturer);
                        comm.Parameters.AddWithValue("@Mass", textBox3.Text);
                        comm.Parameters.AddWithValue("@Proc", Int32.Parse(textBox4.Text));
                        comm.Parameters.AddWithValue("@ShelfLife", Int32.Parse(textBox5.Text));
                        comm.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Product successfully added");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid values");
            }
        }
	}
}
