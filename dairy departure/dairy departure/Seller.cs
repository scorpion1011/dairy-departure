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
			foreach (DataGridViewRow row in dataGridView1.Rows)
            {
				ids.Add(Int32.Parse(row.Cells["ID_product"].Value.ToString()));
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

        private bool doNotProcessEvent = false;

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            
            if (!doNotProcessEvent && senderGrid.Columns[e.ColumnIndex] == dataGridView1.Columns["Column4"])
            {

				Dictionary<decimal, int> prices = GetProductPrices(Int32.Parse(dataGridView1.SelectedRows[0].Cells["ID_product"].Value.ToString()));

				if(prices.Count > 1)
				{
	                doNotProcessEvent = true;

					int index = dataGridView1.SelectedRows[0].Index;
					int i = 1;

					foreach (KeyValuePair<decimal, int> row in prices)
					{
						dataGridView1.Rows.Insert(index + i, 1);
						dataGridView1.Rows[index + i].Cells["Column3"].Value = row.Key;
						dataGridView1.Rows[index + i].Cells["Column4"].Value = row.Value;
						dataGridView1.Rows[index + i].Tag = "Child";
						dataGridView1.Rows[index + i].Cells["btnDel"].Value = String.Empty;
						//dataGridView1.Rows[index + i].Cells["btnDel"].Text = String.Empty;
						dataGridView1.Rows[index + i].DefaultCellStyle.BackColor = Color.LightGray;
					}

					doNotProcessEvent = false;
				}
				//int product_id = Int32.Parse(dataGridView1.SelectedRows[0].Cells["ID_product"].Value.ToString());
				//int targetAmount = Int32.Parse(dataGridView1.SelectedRows[0].Cells["Column4"].Value.ToString());
				//Dictionary<decimal, int> rows = new Dictionary<decimal, int> ( );
				//int addedAmount = 0;
				////////////////////////////remove here?
				//foreach (Good good in products[product_id])
				//{
				//    if (!rows.Keys.Contains(good.price))
				//    {
				//        rows.Add(good.price, 0);
				//    }
				//    rows[good.price] += Math.Min(good.amount, targetAmount - addedAmount);
				//    addedAmount += good.amount;
				//    if (addedAmount >= targetAmount)
				//    {
				//        break;
				//    }
				//}



				//if (rows.Count > 1)
				//{
				//    bool cond = true;
				//    int index = dataGridView1.SelectedRows[0].Index;
				//    int i = 0;

				//    foreach (KeyValuePair<decimal, int> row in rows)
				//    {
				//        if (cond)
				//        {
				//            cond = false;
				//            dataGridView1.SelectedRows[0].Cells["Column4"].Value = row.Value;
				//        }
				//        else
				//        {
				//            dataGridView1.Rows.InsertCopy(index, index+i);
				//            dataGridView1.Rows[index + i].Cells["Column3"].Value = row.Key;
				//            dataGridView1.Rows[index + i].Cells["Column4"].Value = row.Value;
				//            dataGridView1.Rows[index + i].Cells["Manufacturer"].Value = dataGridView1.Rows[index].Cells["Manufacturer"].Value;
				//            dataGridView1.Rows[index + i].Cells["Product"].Value = dataGridView1.Rows[index].Cells["Product"].Value;
				//            dataGridView1.Rows[index + i].Cells["Column1"].Value = dataGridView1.Rows[index].Cells["Column1"].Value;
				//            dataGridView1.Rows[index + i].Cells["Column2"].Value = dataGridView1.Rows[index].Cells["Column2"].Value;
				//            dataGridView1.Rows[index + i].Cells["ID_product"].Value = dataGridView1.Rows[index].Cells["ID_product"].Value;
				//            dataGridView1.Rows[index + i].Cells["ID_supplies"].Value = dataGridView1.Rows[index].Cells["ID_supplies"].Value;
				//            dataGridView1.Rows[index + i].Cells["Rest"].Value = dataGridView1.Rows[index].Cells["Rest"].Value;
				//            dataGridView1.Rows[index + i].Cells["price_for_1"].Value = dataGridView1.Rows[index].Cells["price_for_1"].Value;

				//        }
				//        i++;
				//    }
				//}

				//senderGrid.RefreshEdit();
				//if (Int32.Parse(dataGridView1.SelectedRows[0].Cells["Column4"].Value.ToString()) > )
				//{
				//    MessageBox.Show("To many");
				//    dataGridView1.SelectedRows[0].Cells["Column4"].Value = dataGridView1.SelectedRows[0].Cells["Column4"].Tag;
				//}
				//else
				//{
				//    dataGridView1.SelectedRows[0].Cells["Column3"].Value =
				//        Int32.Parse(dataGridView1.SelectedRows[0].Cells["Column4"].Value.ToString()) * Int32.Parse(dataGridView1.SelectedRows[0].Cells["price_for_1"].Value.ToString());
				//    dataGridView1.SelectedRows[0].Cells["Column4"].Tag = Int32.Parse(dataGridView1.SelectedRows[0].Cells["Column4"].Value.ToString());
				//}
			}
        }

		private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			var senderGrid = sender as DataGridView;

			if (senderGrid.Columns[e.ColumnIndex] == dataGridView1.Columns["Column4"])
			{
				Dictionary<decimal, int> prices = GetProductPrices(Int32.Parse(dataGridView1.SelectedRows[0].Cells["ID_product"].Value.ToString()));
				int totalAmount = prices.Sum(x => x.Value);
				int targetAmount = Int32.Parse(e.FormattedValue.ToString());
				if (totalAmount < targetAmount)
				{
					e.Cancel = true;
					MessageBox.Show("Too many. Max allowed amount is " + totalAmount + ".");
				}
			}
		}

		private Dictionary<decimal, int> GetProductPrices(int product_id)
		{
			Dictionary<decimal, int> prices = new Dictionary<decimal, int>();
			foreach (Good good in this.products[product_id])
			{
				if (!prices.Keys.Contains(good.price))
				{
					prices.Add(good.price, 0);
				}
				prices[good.price] += good.amount;
			}
			return prices;
		}
	}
}
