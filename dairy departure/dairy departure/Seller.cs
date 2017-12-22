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

		private bool doNotProcessEvent = false;

		Dictionary<int, List<Good>> products = new Dictionary<int, List<Seller.Good>>();

        public Seller()
        {
            InitializeComponent();

			doNotProcessEvent = true;
			dataGridView1.Rows.Add();
			dataGridView1.Rows[0].Tag = "Total";
			dataGridView1.Rows[0].ReadOnly = true;
			dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.LightGreen;
			dataGridView1.Rows[0].Cells["Column4"].Value = "Total";
			dataGridView1.Rows[0].Cells["Column3"].Value = 0;
			doNotProcessEvent = false;
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
				if("Total" != GetTag(row.Tag))
				{
					ids.Add(Int32.Parse(row.Cells["ID_product"].Value.ToString()));
				}
            }
            Products prodF = new Products(this, ids);
            prodF.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && "Total" != GetTag(dataGridView1.SelectedRows[0].Tag) && "Child" != GetTag(dataGridView1.SelectedRows[0].Tag))
            {
                int id_to_rem = Int32.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["ID_product"].Value.ToString());
                products.Remove(id_to_rem);

                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
				RemoveChildren(id_to_rem);

				UpdateTotal();
			}
        }

        public void AddProduct(string manufacturer, string name, string proc, string weight, decimal price, int id_p, int id_s, int rest)
        {
            if (!products.Keys.Contains(id_p))
            {
                dataGridView1.Rows.Insert(dataGridView1.Rows.Count - 1, manufacturer, name, proc, weight, 1, price, 0, id_p, id_s, rest, price);
				UpdateTotal();
				dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Column4"].Tag = 1;
                products.Add(id_p, new List<Good>());
            }
            products[id_p].Add(new Good(price, rest, id_s));

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            
            if (!doNotProcessEvent && senderGrid.Columns[e.ColumnIndex] == dataGridView1.Columns["Column4"])
            {
				int productId = Int32.Parse(dataGridView1.SelectedRows[0].Cells["ID_product"].Value.ToString());
				Dictionary<decimal, int> prices = GetProductPrices(productId);
				int targetAmount = Int32.Parse(dataGridView1.SelectedRows[0].Cells["Column4"].Value.ToString());
				RemoveChildren(productId);
				if(NeedChildren(targetAmount, prices))
				{
	                doNotProcessEvent = true;

					int index = dataGridView1.SelectedRows[0].Index;
					int i = 1;
					int amount = 0;

					dataGridView1.Rows[index].Cells["Column3"].Value = string.Empty;

					foreach (KeyValuePair<decimal, int> price in prices)
					{
						dataGridView1.Rows.Insert(index + i, 1);
						dataGridView1.Rows[index + i].Tag = "Child";
						dataGridView1.Rows[index + i].ReadOnly = true;
						dataGridView1.Rows[index + i].DefaultCellStyle.BackColor = Color.LightGray;

						dataGridView1.Rows[index + i].Cells["ID_product"].Value = productId;
						dataGridView1.Rows[index + i].Cells["Column3"].Value = price.Key;
						dataGridView1.Rows[index + i].Cells["Column4"].Value = Math.Min(price.Value, targetAmount - amount);

						amount += price.Value;
						if (amount >= targetAmount)
						{
							break;
						}
						i++;
					}
					doNotProcessEvent = false;
				}
				UpdateTotal();
			}
        }

		private bool NeedChildren(int targetAmount, Dictionary<decimal, int> prices)
		{
			int amount = 0, rows = 0;

			foreach (KeyValuePair<decimal, int> price in prices)
			{
				rows++;
				amount += price.Value;
				if (amount >= targetAmount)
				{
					break;
				}
			}
			return rows > 1;
		}

		private void RemoveChildren(int productId)
		{
			for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
			{
				DataGridViewRow row = dataGridView1.Rows[i];
				if ("Child" == GetTag(row.Tag) && productId == Int32.Parse(row.Cells["ID_product"].Value.ToString()))
				{
					dataGridView1.Rows.Remove(row);
				}
			}
		}

		private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			var senderGrid = sender as DataGridView;

			if (senderGrid.Columns[e.ColumnIndex] == dataGridView1.Columns["Column4"] && "Total" != GetTag(dataGridView1.SelectedRows[0].Tag) && "Child" != GetTag(dataGridView1.SelectedRows[0].Tag))
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

		private string GetTag(object tag)
		{
			return tag == null ? string.Empty : tag.ToString();
		}

		private void UpdateTotal()
		{
			doNotProcessEvent = true;

			decimal total = 0;

			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if ("Total" != GetTag(row.Tag) && string.Empty != row.Cells["Column3"].Value.ToString())
				{
					total += Decimal.Parse(row.Cells["Column3"].Value.ToString()) * Int32.Parse(row.Cells["Column4"].Value.ToString());
				}
			}

			dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Column3"].Value = total;

			doNotProcessEvent = false;
		}

	}

}
