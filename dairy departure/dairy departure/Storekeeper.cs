using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;

namespace dairy_departure
{
    public partial class Storekeeper : UserControl
    {
        public Storekeeper()
        {
            InitializeComponent();
            FillDGV();
        }

        private void FillDGV()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                string sql = @"SELECT m.Name_manufacturer, p.Name_product, p.[%-fat], p.[Mass/volume], s.[Price], 
sum(s.[Count])-IIF( ISNULL((select sum(sl.[Count]) from Sells as sl where sl.ID_supply = s.ID_supply)), 0, (select sum(sl.[Count]) from Sells as sl where sl.ID_supply = s.ID_supply)) AS Total, 
p.ID_product
FROM Manufacturer AS m, Product AS p, Supply AS s
WHERE m.ID_manufacturer = p.ID_manufacturer and s.ID_product = p.ID_product
and s.ID_supply not in (
SELECT s1.ID_supply
FROM Sells AS sl, Supply AS s1
WHERE (((sl.ID_supply)=[s1].[ID_supply]))
GROUP BY s1.ID_supply
HAVING min(s1.Count)<Sum([sl].[Count])
)
group by m.Name_manufacturer, p.Name_product, p.[%-fat], p.[Mass/volume], s.[Price], p.ID_product, s.ID_supply;

";              using (OleDbCommand comm = new OleDbCommand(sql, conn))
                {
                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetDecimal(4), reader.GetDouble(5), -1,  reader.GetInt32(6));
                            dataGridView1.Rows[i].ReadOnly = true;
                            i++;
                        }
                    }
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LogInForm f = (LogInForm)this.Parent;
            f.Logout(this);
        }

        private void add_supply_but_Click(object sender, EventArgs e)
        {
            Supplies prodF = new Supplies(this);
            prodF.ShowDialog();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            FillDGV();
        }

        public void AddProduct(string manufacturer, string name, string proc, string weight, decimal price, int id_p)
        {
            dataGridView1.Rows.Add(manufacturer, name, proc, weight, price, 1, DateTime.Now, id_p);
        }
    }
}
