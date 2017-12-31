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
    public partial class Products : Form
    {
        Seller parent;
        List<int> ids;


        public Products(Seller parent, List<int> ids)
        {
            this.ids = ids;
            this.parent = parent;
            InitializeComponent();
        }

        private void productBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dairyDeparture1DataSet);

        }

        private void Products_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dairyDeparture1DataSet.ProductsForSaleView' table. You can move, or remove it, as needed.
            this.productsForSaleViewTableAdapter.Fill(this.dairyDeparture1DataSet.ProductsForSaleView);
            
            int prod_id;
			for (int i = productDataGridView.Rows.Count - 1; i >= 0; i--)
			{
				DataGridViewRow row = productDataGridView.Rows[i];
				prod_id = Int32.Parse(row.Cells[0].Value.ToString());
				if (ids.Contains(prod_id) || !isAvailable(prod_id))
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
                    }
                }
            }
        }

        private bool isAvailable(int prod_id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                string sql = @"SELECT (select sum(sl.[Count]) from Sells sl where sl.ID_supply = s.ID_supply group by sl.ID_supply) AS Sold, sum(s.[Count]-IIF( ISNULL(Sold), 0, Sold)) AS [Left]
								FROM Supply AS s
								WHERE s.ID_Product = @ID_product;
								";
                using (OleDbCommand comm = new OleDbCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@ID_product", prod_id);

                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            try
                            {
                                int i = (int)reader.GetDouble(1);
                                return i > 0;
                            }
                            catch(Exception)
                            {
                                return false;
                            }
                        }
                        return false;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetSupplies();
            this.Close();
        }

        private void GetSupplies()
        {
            int prod_id = Int32.Parse(productDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            //int manuf_id = Int32.Parse(productDataGridView.SelectedRows[0].Cells[2].Value.ToString());

            string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                string sql = @"SELECT s.ID_supply,
                                        s.Price, 
                                        (select sum(sl.[Count]) from Sells sl where sl.ID_supply = s.ID_supply group by sl.ID_supply) as Sold, 
                                        s.[Count]-IIF( ISNULL(Sold), 0, Sold) AS [Left],
										s.Date_Production
                                FROM Supply AS s
                                WHERE s.ID_Product = @ID_product
                                and s.ID_supply not in (
                                    select s1.ID_supply from Supply s1, Sells sl where s1.ID_Product = @ID_product and sl.ID_supply = s1.ID_supply group by s1.ID_supply having min(s1.[Count]) = sum(sl.[Count]))
                                and s.ID_supply not in (
                                    select s2.ID_supply from Supply s2, Product as p where s2.ID_Product = p.ID_product and p.ID_Product = @ID_product and s2.Date_Production + p.ShelfLife < Date())
                                ORDER BY s.[Date_Production]; ";
                using (OleDbCommand comm = new OleDbCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@ID_product", prod_id);
                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        Seller f = (Seller)this.parent;
                        string manuf = productDataGridView.SelectedRows[0].Cells[2].Value.ToString();
                        string name_pr = productDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                        string proc = productDataGridView.SelectedRows[0].Cells[5].Value.ToString();
                        string weight = productDataGridView.SelectedRows[0].Cells[4].Value.ToString();
                                

                        while (reader.Read())
                        {
                            f.AddProduct(manuf, name_pr, proc, weight, reader.GetDecimal(1), prod_id, reader.GetInt32(0), (int)reader.GetDouble(3), reader.GetDateTime(4));
                        }
                    }
                }
            }
        }
    }
}
