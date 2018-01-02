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
    public partial class Seller : UserControl
    {
		struct Good
		{
			public decimal price;
			public decimal discount;
			public int amount;
			public int sup_id;

			public Good(decimal price, decimal discount, int amount, int sup_id)
			{
				this.price = price;
				this.discount = discount;
				this.amount = amount;
				this.sup_id = sup_id;
			}
		}

		private bool doNotProcessEvent = false;
		private DiscountManager discountManager = new DiscountManager();
		Dictionary<int, List<Good>> products = new Dictionary<int, List<Good>>();

        public Seller()
        {
            InitializeComponent();

			doNotProcessEvent = true;
			dataGridView1.Rows.Add();
			dataGridView1.Rows[0].Tag = "Total";
			dataGridView1.Rows[0].ReadOnly = true;
			dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.LightGreen;
			dataGridView1.Rows[0].Cells["Discount"].Value = "Total";
			dataGridView1.Rows[0].Cells["Sum"].Value = discountManager.Format(0);
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

        public void AddProduct(string manufacturer, string name, string proc, string weight, decimal price, int id_p, int id_s, int rest, DateTime prodaction)
        {
			decimal discount = discountManager.Calculate(prodaction, id_p, DateTime.Now);

			if (!products.Keys.Contains(id_p))
            {
				doNotProcessEvent = true;

				int position = dataGridView1.Rows.Count - 1;
				dataGridView1.Rows.Insert(position, 1);


				var cells = dataGridView1.Rows[position].Cells;
				cells["Manufacturer"].Value = manufacturer;
				cells["Product"].Value = name;
				cells["Column1"].Value = proc;
				cells["Column2"].Value = weight;
				cells["Column4"].Value = 1;
				cells["Column3"].Value = discountManager.Format(price);
				cells["Discount"].Value = discount.ToString() + "%";
				cells["Sum"].Value = discountManager.CalculatePrice(price, discount);
				cells["ID_product"].Value = id_p;
				cells["ID_supplies"].Value = id_s;

				UpdateTotal();
				dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Column4"].Tag = 1;
                products.Add(id_p, new List<Good>());

				doNotProcessEvent = false;
            }
            products[id_p].Add(new Good(price, discount, rest, id_s));

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            
            if (!doNotProcessEvent && senderGrid.Columns[e.ColumnIndex] == dataGridView1.Columns["Column4"])
            {
                doNotProcessEvent = true;

				int productId = Int32.Parse(dataGridView1.SelectedRows[0].Cells["ID_product"].Value.ToString());
				Dictionary<decimal, Good> prices = GetProductPrices(productId);
				int targetAmount = Int32.Parse(dataGridView1.SelectedRows[0].Cells["Column4"].Value.ToString());
				RemoveChildren(productId);
				int index = dataGridView1.SelectedRows[0].Index;
				decimal finalPrice = 0;
				if (NeedChildren(targetAmount, prices))
				{

					int i = 1;
					int amount = 0;

					dataGridView1.Rows[index].Cells["Column3"].Value = string.Empty;
					dataGridView1.Rows[index].Cells["Discount"].Value = string.Empty;
					dataGridView1.Rows[index].Cells["ID_supplies"].Value = null;

					foreach (KeyValuePair<decimal, Good> price in prices)
					{
						int curAmount = Math.Min(price.Value.amount, targetAmount - amount);
						dataGridView1.Rows.Insert(index + i, 1);
						dataGridView1.Rows[index + i].Tag = "Child";
						dataGridView1.Rows[index + i].ReadOnly = true;
						dataGridView1.Rows[index + i].DefaultCellStyle.BackColor = Color.LightGray;

						dataGridView1.Rows[index + i].Cells["ID_product"].Value = productId;
						dataGridView1.Rows[index + i].Cells["Column3"].Value = discountManager.Format(price.Value.price);
						dataGridView1.Rows[index + i].Cells["Column4"].Value = curAmount;
						dataGridView1.Rows[index + i].Cells["Discount"].Value = price.Value.discount.ToString() + "%";
						decimal sum = discountManager.CalculatePrice(price.Value.price * curAmount, price.Value.discount);
						dataGridView1.Rows[index + i].Cells["Sum"].Value = sum;
						dataGridView1.Rows[index + i].Cells["ID_supplies"].Value = price.Value.sup_id;

						amount += price.Value.amount;
						finalPrice += sum;
						if (amount >= targetAmount)
						{
							break;
						}
						i++;
					}
				}
				else
				{
					dataGridView1.Rows[index].Cells["Column3"].Value = discountManager.Format(products[productId][0].price);
					dataGridView1.Rows[index].Cells["Discount"].Value = products[productId][0].discount.ToString() + "%";
					dataGridView1.Rows[index].Cells["ID_supplies"].Value = products[productId][0].sup_id;
					finalPrice = discountManager.CalculatePrice(targetAmount * products[productId][0].price, products[productId][0].discount);
				}

				dataGridView1.Rows[index].Cells["Sum"].Value = discountManager.Round(finalPrice);

				doNotProcessEvent = false;

				UpdateTotal();
			}
        }

		private bool NeedChildren(int targetAmount, Dictionary<decimal, Good> prices)
		{
			int amount = 0, rows = 0;

			foreach (KeyValuePair<decimal, Good> price in prices)
			{
				rows++;
				amount += price.Value.amount;
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

		private void ClearTable()
		{
			for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
			{
				DataGridViewRow row = dataGridView1.Rows[i];
				if ("Total" != GetTag(row.Tag))
				{
					dataGridView1.Rows.Remove(row);
				}
			}
			UpdateTotal();
		}

		private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			var senderGrid = sender as DataGridView;

			if (senderGrid.Columns[e.ColumnIndex] == dataGridView1.Columns["Column4"] && "Total" != GetTag(dataGridView1.SelectedRows[0].Tag) && "Child" != GetTag(dataGridView1.SelectedRows[0].Tag))
			{
				Dictionary<decimal, Good> prices = GetProductPrices(Int32.Parse(dataGridView1.SelectedRows[0].Cells["ID_product"].Value.ToString()));
				int totalAmount = prices.Sum(x => x.Value.amount);
				int targetAmount = 0;
				Int32.TryParse(e.FormattedValue.ToString(), out targetAmount);
				if (1 > targetAmount)
				{
					e.Cancel = true;
					MessageBox.Show("Amount must be greater than 0.");
				}
				else if (totalAmount < targetAmount)
				{
					e.Cancel = true;
					MessageBox.Show("Too many. Max allowed amount is " + totalAmount + ".");
				}
			}
		}

		private Dictionary<decimal, Good> GetProductPrices(int product_id)
		{
			Dictionary<decimal, Good> prices = new Dictionary<decimal, Good>();
			foreach (Good good in this.products[product_id])
			{
				decimal finalPrice = discountManager.CalculatePrice(good.price, good.discount);
				if (!prices.Keys.Contains(finalPrice))
				{
					prices.Add(finalPrice, new Good(good.price, good.discount, good.amount, good.sup_id));
				}
				Good price = prices[finalPrice];
				price.amount += good.amount;
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
					total += Decimal.Parse(row.Cells["Sum"].Value.ToString());
				}
			}

			dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Sum"].Value = discountManager.Format(total);

			btnConfirm.Enabled = total > 0;

			doNotProcessEvent = false;
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			var confirmResult = MessageBox.Show("Are you sure to complete this sell?", "Confirm Sell", MessageBoxButtons.YesNo);
			if (confirmResult == DialogResult.Yes)
			{
				string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;
				using (OleDbConnection conn = new OleDbConnection(connectionString))
				{
					conn.Open();
					string sql = @"INSERT INTO Sells ([Date_sell], [ID_supply], [Discount], [Count], [ID_employee_position])
                            values (Date(), @ID_supply, @Discount, @Count, @ID_employee_position)";
					using (OleDbCommand comm = new OleDbCommand(sql, conn))
					{
						foreach (DataGridViewRow row in dataGridView1.Rows)
						{
							if (null != row.Cells["ID_supplies"].Value)
							{
								comm.Parameters.Clear();
								comm.Parameters.AddWithValue("@ID_supply", row.Cells["ID_supplies"].Value);
								comm.Parameters.AddWithValue("@Discount", row.Cells["Discount"].Value.ToString().Trim('%'));
								comm.Parameters.AddWithValue("@Count", row.Cells["Column4"].Value);
								comm.Parameters.AddWithValue("@ID_employee_position", LogInForm.id_emp_pos);
								comm.ExecuteNonQuery();
							}
						}
					}
				}
				SellComplete sc = new SellComplete(dataGridView1);
				sc.ShowDialog();
				ClearTable();

            }
		}
	}

}
