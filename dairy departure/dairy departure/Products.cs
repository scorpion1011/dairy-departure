﻿using System;
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
            this.productTableAdapter.Fill(this.dairyDeparture1DataSet.Product);
            int prod_id;
            int i = 0;
            while (true)
            {
                try
                {
                    prod_id = Int32.Parse(productDataGridView.Rows[i].Cells[0].Value.ToString());
                    if (!isAvailable(prod_id))
                    {
                        productDataGridView.Rows.RemoveAt(i);
                        i--;
                    }
                }
                catch (Exception)
                {
                    break;
                }
                i++;
            }
            
            i = 0;
            
            while (true)
            {
                try
                {
                    Int32.Parse(productDataGridView.Rows[i].Cells[0].Value.ToString());
                }
                catch (Exception)
                {
                    break;
                }
                int j = 0;
                while (true)
                {
                    try
                    {
                        if (Int32.Parse(productDataGridView.Rows[i].Cells[0].Value.ToString()) == ids[j])
                        {
                            productDataGridView.Rows.RemoveAt(i);
                        }
                        j++;
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                i++;
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
            int manuf_id = Int32.Parse(productDataGridView.SelectedRows[0].Cells[2].Value.ToString());

            string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                string sql = @"SELECT s.ID_supply,
                                        s.Price, 
                                        (select sum(sl.[Count]) from Sells sl where sl.ID_supply = s.ID_supply group by sl.ID_supply) as Sold, 
                                        s.[Count]-IIF( ISNULL(Sold), 0, Sold) AS [Left],
                                        m.Name_manufacturer
                                FROM Supply AS s, Manufacturer AS m
                                WHERE s.ID_Product = @ID_product
                                and m.ID_manufacturer = @ID_manufacturer
                                and s.ID_supply not in (
                                select s1.ID_supply from Supply s1, Sells sl where s1.ID_Product = @ID_product and sl.ID_supply = s1.ID_supply group by s1.ID_supply having min(s1.[Count]) = sum(sl.[Count]))
                                ORDER BY s.[Date_Production]; ";
                using (OleDbCommand comm = new OleDbCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@ID_product", prod_id);
                    comm.Parameters.AddWithValue("@ID_manufacturer", manuf_id);
                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        Seller f = (Seller)this.parent;
                        string manuf = productDataGridView.SelectedRows[0].Cells[2].Value.ToString();
                        string name_pr = productDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                        string proc = productDataGridView.SelectedRows[0].Cells[4].Value.ToString();
                        string weight = productDataGridView.SelectedRows[0].Cells[3].Value.ToString();
                                

                        while (reader.Read())
                        {
                            f.AddProduct(reader.GetString(4), name_pr, proc, weight, reader.GetDecimal(1), prod_id, reader.GetInt32(0), (int)reader.GetDouble(3));
                        }
                    }
                }
            }
        }
    }
}
