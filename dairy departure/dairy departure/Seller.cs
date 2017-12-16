using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dairy_departure
{
    public partial class Seller : UserControl
    {
        struct Good
        {
            public decimal price;
            public int amount;
            public int sup_id;

            public Good(decimal price, int amount, int sup_id)
            {
                this.price = price;
                this.amount = amount;
                this.sup_id = sup_id;
            }
        }

        Dictionary<int, List<Good>> products = new Dictionary<int, List<Seller.Good>>();

        public Seller()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LogInForm f = (LogInForm)this.Parent;
            f.Logout(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int> { };
            int i = 0;
            while (true)
            {
                try
                {
                    ids.Add(Int32.Parse(dataGridView1.Rows[i].Cells["ID_product"].Value.ToString()));
                }
                catch (Exception)
                {
                    break;
                }
                i++;
            }
            Products prodF = new Products(this, ids);
            prodF.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int id_to_rem = Int32.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["ID_product"].Value.ToString());
                products.Remove(id_to_rem);

                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
        }

        public void AddProduct(string manufacturer, string name, string proc, string weight, decimal price, int id_p, int id_s, int rest)
        {
            if (!products.Keys.Contains(id_p))
            {
                dataGridView1.Rows.Add(manufacturer, name, proc, weight, price, 1, 0, id_p, id_s, rest, price);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Column4"].Tag = 1;
                products.Add(id_p, new List<Good>());
            }
            products[id_p].Add(new Good(price, rest, id_s));
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] == dataGridView1.Columns["Column4"])
            {
                if (Int32.Parse(dataGridView1.SelectedRows[0].Cells["Column4"].Value.ToString()) > Int32.Parse(dataGridView1.SelectedRows[0].Cells["Rest"].Value.ToString()))
                {
                    MessageBox.Show("To many");
                    dataGridView1.SelectedRows[0].Cells["Column4"].Value = dataGridView1.SelectedRows[0].Cells["Column4"].Tag;
                }
                else
                {
                    dataGridView1.SelectedRows[0].Cells["Column3"].Value =
                        Int32.Parse(dataGridView1.SelectedRows[0].Cells["Column4"].Value.ToString()) * Int32.Parse(dataGridView1.SelectedRows[0].Cells["price_for_1"].Value.ToString());
                    dataGridView1.SelectedRows[0].Cells["Column4"].Tag = Int32.Parse(dataGridView1.SelectedRows[0].Cells["Column4"].Value.ToString());
                }
            }
        }
    }
}
