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
                    ids.Add(Int32.Parse(dataGridView1.Rows[i].Cells["ID_product"].Value.ToString()));
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
            dataGridView1.Rows.Add(manufacturer, name, proc, weight, price, 1, DateTime.Now.Date, 0, id_p);
            //products.Add(id_p, new List<Good>());
        }
    }
}
