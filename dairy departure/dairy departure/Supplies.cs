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
        List<int> ids;
        public static int  price = -1;

        public Supplies(Storekeeper parent, List<int> ids)
        {
            this.ids = ids;
            this.parent = parent;
            InitializeComponent();
        }

        private void Supplies_Load(object sender, EventArgs e)
        {
			this.productTableAdapter.ClearBeforeFill = true;
			this.productTableAdapter.Fill(this.dairyDeparture1DataSet.Product);

			int prod_id;
			for (int i = productDataGridView.Rows.Count - 1; i >= 0; i--)
			{
				DataGridViewRow row = productDataGridView.Rows[i];
				prod_id = Int32.Parse(row.Cells[0].Value.ToString());
				if (ids.Contains(prod_id))
				{
					productDataGridView.Rows.Remove(row);
				}
			}

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


            Storekeeper f = (Storekeeper)this.parent;
            string manuf = productDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            string name_pr = productDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            string proc = productDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            string weight = productDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            

            PriceDialog pr = new PriceDialog();
            pr.ShowDialog();

            if (price != -1)
            { 
                f.AddProduct(manuf, name_pr, proc, weight, price, prod_id);
            }

            this.parent.Controls["add_all_but"].Enabled = true;

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
