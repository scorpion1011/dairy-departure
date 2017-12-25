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
    public partial class Supplies : Form
    {
        Storekeeper parent;
        public static int  price = -1;
        public static int amount = -1;


        public Supplies(Storekeeper parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void Supplies_Load(object sender, EventArgs e)
        {
			this.productTableAdapter.ClearBeforeFill = true;
			this.productTableAdapter.Fill(this.dairyDeparture1DataSet.Product);
            
            string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                string sql = @"select Name_manufacturer from Manufacturer where ID_manufacturer = @ID_manufacturer";
                using (OleDbCommand comm = new OleDbCommand(sql, conn))
                {
                    for (int index = 0; index < productDataGridView.Rows.Count; index++)
                    {
						comm.Parameters.AddWithValue("@ID_manufacturer", Int32.Parse(productDataGridView.Rows[index].Cells[3].Value.ToString()));

						using (OleDbDataReader reader = comm.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                productDataGridView.Rows[index].Cells[2].Value = reader.GetString(0);
                            }
                        }
						comm.Parameters.RemoveAt("@ID_manufacturer");
                    }
                }
            }
        }

        private void productBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dairyDeparture1DataSet);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int prod_id = Int32.Parse(productDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            PriceDialog pr = new PriceDialog();
            pr.ShowDialog();

            AmountDialog am = new AmountDialog();
            am.ShowDialog();

            if (price != -1 && amount != -1)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"Insert into Supply (ID_product, [Price], [Count], Date_Production, ID_employee_position)
                                                    values (@ID_product, @Price, @Count, @Date_Production, @ID_employee_position)
                ";
                            using (OleDbCommand comm = new OleDbCommand(sql, conn))
                            {
                                comm.Parameters.AddWithValue("@ID_product", prod_id);
                                comm.Parameters.AddWithValue("@Price", (decimal)price);
                                comm.Parameters.AddWithValue("@Count", amount);
                                comm.Parameters.AddWithValue("@Date_Production", DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                                comm.Parameters.AddWithValue("@ID_employee_position", LogInForm.id_emp_pos);
                                comm.ExecuteNonQuery();
                            }
                }
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewProduct f = new NewProduct();
            f.ShowDialog();
			Supplies_Load(this, null);
		}
	}
}
