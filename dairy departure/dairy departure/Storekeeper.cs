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
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LogInForm f = (LogInForm)this.Parent;
            f.Logout(this);
        }

        private void suppliesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void add_supply_but_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int> { };
            int i = 0;
            while (true)
            {
                try
                {
                    ids.Add(Int32.Parse(dataGridView1.Rows[i].Cells["ID_pr"].Value.ToString()));
                }
                catch (Exception)
                {
                    break;
                }
                i++;
            }
            Supplies prodF = new Supplies(this, ids);
            prodF.ShowDialog();
        }

        public void AddProduct(string manufacturer, string name, string proc, string weight, decimal price, int id_p)
        {
            dataGridView1.Rows.Add(manufacturer, name, proc, weight, price, 1, DateTime.Now.Date, "X", id_p);
            //products.Add(id_p, new List<Good>());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int id_to_rem = Int32.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["ID_pr"].Value.ToString());

                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                add_all_but.Enabled = dataGridView1.Rows.Count != 0;
            }
        }

        private void add_all_but_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                string sql = @"Insert into Supply (ID_product, [Price], [Count], Date_Production, ID_employee_position)
                                                    values (@ID_product, @Price, @Count, @Date_Production, @ID_employee_position)
                ";
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    using (OleDbCommand comm = new OleDbCommand(sql, conn))
                    {
                        comm.Parameters.AddWithValue("@ID_product", Int32.Parse(dataGridView1.Rows[i].Cells["ID_pr"].Value.ToString()));
                        comm.Parameters.AddWithValue("@Price", Int32.Parse(dataGridView1.Rows[i].Cells["Price"].Value.ToString()));
                        comm.Parameters.AddWithValue("@Count", Int32.Parse(dataGridView1.Rows[i].Cells["Amount"].Value.ToString()));
                        comm.Parameters.AddWithValue("@Date_Production", DateTime.Parse(dataGridView1.Rows[i].Cells["Date"].Value.ToString()).Date);
                        comm.Parameters.AddWithValue("@ID_employee_position", ((LogInForm)this.Parent).emp_pos);
                        dataGridView1.Rows.RemoveAt(i);
                        i--;
                        comm.ExecuteNonQuery();

                        
                    }
                }
            }
            add_all_but.Enabled = false;
        }

        
    }
}
