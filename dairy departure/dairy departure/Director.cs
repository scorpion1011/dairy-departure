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
    public partial class Director : UserControl
    {
		string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;

		public Director()
        {
            InitializeComponent();
			employeeToolStripMenuItem_Click(employeeToolStripMenuItem, null);
        }

        private void Director_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LogInForm f = (LogInForm)this.Parent;
            f.Logout(this);
        }

        public void employeeToolStripMenuItem_Click(object sender, EventArgs e)
		{
            hideFilterForm();
            ClearGrid();
            EnableMenuItems(sender);
            dataGridView1.Columns.Add("EmpID", "id");
            dataGridView1.Columns["EmpID"].Visible = false;
            dataGridView1.Columns.Add("EmpName", "Name of employee");
            dataGridView1.Columns.Add("EmpLog", "Login of employee");
            dataGridView1.Columns.Add("EmpPas", "Password of employee");
            dataGridView1.Columns.Add("PosID", "id");
            dataGridView1.Columns["PosID"].Visible = false;
            dataGridView1.Columns.Add("EmpPos", "Position of employee");
            FillInEmployeeGrid();
        }

		private void EnableMenuItems(object sender)
		{
			employeeToolStripMenuItem.Enabled = !employeeToolStripMenuItem.Equals(sender);
			positionsToolStripMenuItem.Enabled = !positionsToolStripMenuItem.Equals(sender);
			sellingPlansToolStripMenuItem.Enabled = !sellingPlansToolStripMenuItem.Equals(sender);
			productsToolStripMenuItem.Enabled = !productsToolStripMenuItem.Equals(sender);
			statisticsSellingPlansItem.Enabled = !statisticsSellingPlansItem.Equals(sender);
			statisticsSellsItem.Enabled = !statisticsSellsItem.Equals(sender);
			statisticsSuppliesItem.Enabled = !statisticsSuppliesItem.Equals(sender);

			if((sender as ToolStripMenuItem).Owner is ToolStripDropDownMenu)
			{
				addToolStripMenuItem.Visible = false;
				editToolStripMenuItem.Visible = false;
				deleteToolStripMenuItem.Visible = false;

				gridToolStripMenuItem.Visible = true;
				diagramToolStripMenuItem.Visible = true;
			}
			else
			{
				addToolStripMenuItem.Visible = true;
				editToolStripMenuItem.Visible = true;
				deleteToolStripMenuItem.Visible = true;

				gridToolStripMenuItem.Visible = false;
				diagramToolStripMenuItem.Visible = false;
			}
		}

		public void positionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			hideFilterForm();
            ClearGrid();
            EnableMenuItems(sender);
			dataGridView1.Columns.Add("ID_position", "id");
			dataGridView1.Columns["ID_position"].Visible = false;
			dataGridView1.Columns.Add("PosName", "Name of position");
			dataGridView1.Columns.Add("Payment", "Payment per hour");
            FillInPositionGrid();
        }

        public void sellingPlansToolStripMenuItem_Click(object sender, EventArgs e)
		{
			hideFilterForm();
			ClearGrid();

			EnableMenuItems(sender);

			dataGridView1.Columns.Add("ID_plan", "id");
			dataGridView1.Columns["ID_plan"].Visible = false;
			dataGridView1.Columns.Add("ID_product", "idpr");
			dataGridView1.Columns["ID_product"].Visible = false;
			dataGridView1.Columns.Add("Manufacturer", "Manufacturer");
			dataGridView1.Columns.Add("PrName", "Name of product");
			dataGridView1.Columns.Add("Proc", "%");
			dataGridView1.Columns.Add("Weight", "Weight/Volume");
			dataGridView1.Columns.Add("Amount", "Sell amount");
			dataGridView1.Columns.Add("DateFr", "Date from");
			dataGridView1.Columns.Add("DateTo", "Date to");

			
			using (OleDbConnection conn = new OleDbConnection(connectionString))
			{
				conn.Open();

				string sql = @"select Sp.[ID_plan], SpP.ID_product, M.Name_manufacturer, P.Name_product, P.[%-fat], P.[Mass/volume], SpP.Amount, Sp.[Date_from], Sp.[Date_to]
								from Product as P, Selles_plan as Sp, SellesPlan_Product as SpP, Manufacturer as M
								where Sp.ID_plan = SpP.ID_plan and P.ID_product = SpP.ID_product and P.ID_manufacturer = M.ID_manufacturer
";
				using (OleDbCommand comm = new OleDbCommand(sql, conn))
				{
					using (OleDbDataReader reader = comm.ExecuteReader())
					{
						int i = 0;
						while (reader.Read())
						{
							dataGridView1.Rows.Add(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetString(5), reader.GetInt32(6), reader.GetDateTime(7).Date, reader.GetDateTime(8).Date);
							i++;
						}
					}

				}
			}
		}

        public void productsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			hideFilterForm();
			ClearGrid();

			EnableMenuItems(sender);

			dataGridView1.Columns.Add("ID_product", "idpr");
			dataGridView1.Columns["ID_product"].Visible = false;
            dataGridView1.Columns.Add("ID_manufacturer", "idmn");
            dataGridView1.Columns["ID_manufacturer"].Visible = false;
            dataGridView1.Columns.Add("Manufacturer", "Manufacturer");
			dataGridView1.Columns.Add("PrName", "Name of product");
			dataGridView1.Columns.Add("Proc", "%");
			dataGridView1.Columns.Add("Weight", "Weight/Volume");
			dataGridView1.Columns.Add("ShelfLife", "Shelf Life");

			
			using (OleDbConnection conn = new OleDbConnection(connectionString))
			{
				conn.Open();

				string sql = @"select P.ID_product, M.ID_manufacturer, M.Name_manufacturer, P.Name_product, P.[%-fat], P.[Mass/volume], P.[ShelfLife]
								from Product as P, Manufacturer as M
								where P.ID_manufacturer = M.ID_manufacturer";
				using (OleDbCommand comm = new OleDbCommand(sql, conn))
				{
					using (OleDbDataReader reader = comm.ExecuteReader())
					{
						int i = 0;
						while (reader.Read())
						{
							dataGridView1.Rows.Add(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetString(5), reader.GetInt32(6));
							i++;
						}
					}

				}
			}
		}

		private void addToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!employeeToolStripMenuItem.Enabled)
            {
                AddEmployee f = new AddEmployee(this, -1);
                f.ShowDialog();
            }
            if (!positionsToolStripMenuItem.Enabled)
            {
                AddPosition f = new AddPosition(this, -1);
                f.ShowDialog();
            }
            if (!sellingPlansToolStripMenuItem.Enabled)
            {
                AddPlan f = new AddPlan(this, -1);
                f.ShowDialog();
            }
            if (!productsToolStripMenuItem.Enabled)
            {
                AddProduct f = new AddProduct(this, -1);
                f.ShowDialog();
            }
            //if (!sellsToolStripMenuItem.Enabled)
            //{
            //    AddSell f = new AddSell(-1);
            //    f.ShowDialog();
            //}
            //if (!suppliesToolStripMenuItem.Enabled)
            //{
            //    AddSupply f = new AddSupply(-1);
            //    f.ShowDialog();
            //}
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!employeeToolStripMenuItem.Enabled)
            {
                AddEmployee f = new AddEmployee(this, dataGridView1.SelectedRows[0].Index);
                f.ShowDialog();
            }
            if (!positionsToolStripMenuItem.Enabled)
            {
                AddPosition f = new AddPosition(this, dataGridView1.SelectedRows[0].Index);
                f.ShowDialog();
            }
            if (!sellingPlansToolStripMenuItem.Enabled)
            {
                AddPlan f = new AddPlan(this, dataGridView1.SelectedRows[0].Index);
                f.ShowDialog();
            }
            if (!productsToolStripMenuItem.Enabled)
            {
                AddProduct f = new AddProduct(this, dataGridView1.SelectedRows[0].Index);
                f.ShowDialog();
            }
            //if (!sellsToolStripMenuItem.Enabled)
            //{
            //    AddSell f = new AddSell(dataGridView1.SelectedRows[0].Index);
            //    f.ShowDialog();
            //}
            //if (!suppliesToolStripMenuItem.Enabled)
            //{
            //    AddSupply f = new AddSupply(dataGridView1.SelectedRows[0].Index);
            //    f.ShowDialog();
            //}
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var confirmResult = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);
			if (confirmResult == DialogResult.Yes)
			{
				if (!employeeToolStripMenuItem.Enabled)
				{
					

					using (OleDbConnection conn = new OleDbConnection(connectionString))
					{
						conn.Open();
						string sql = @"Update Employee_Position
                                        set [Date_for] = @DateNow
                                        where ID_employee = @id_e and Date_for is null;";
						string sql2 = @"Update Employee
                                        set [IsWorking] = false
                                        where ID_employee = @id_e;";

						//string sql2 = @"Delete from Employee
						//                    where ID_employee = @id_e;";

						using (OleDbCommand comm = new OleDbCommand(sql, conn))
						{
							comm.Parameters.AddWithValue("@DateNow", DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
							comm.Parameters.AddWithValue("@id_e", dataGridView1.SelectedRows[0].Cells["EmpID"].Value.ToString());
							comm.ExecuteNonQuery();

							comm.Parameters.RemoveAt("@DateNow");
							comm.Parameters.RemoveAt("@id_e");

							comm.CommandText = sql2;

							comm.Parameters.AddWithValue("@id_e", dataGridView1.SelectedRows[0].Cells["EmpID"].Value.ToString());
							comm.ExecuteNonQuery();
						}
					}
					MessageBox.Show("Employee successfully deleted");
					dataGridView1.Rows.Clear();
					dataGridView1.Refresh();
					employeeToolStripMenuItem_Click(this, e);
				}
				if (!positionsToolStripMenuItem.Enabled)
				{
					

					using (OleDbConnection conn = new OleDbConnection(connectionString))
					{
						conn.Open();
						string sql = @"Delete from [Position]
                                        where ID_position = @id_p;";
						using (OleDbCommand comm = new OleDbCommand(sql, conn))
						{
							comm.Parameters.AddWithValue("@id_p", dataGridView1.SelectedRows[0].Cells["ID_position"].Value.ToString());
							comm.ExecuteNonQuery();
						}
					}
					MessageBox.Show("Position successfully deleted");
					dataGridView1.Rows.Clear();
					dataGridView1.Refresh();
					positionsToolStripMenuItem_Click(this, e);
				}
				if (!sellingPlansToolStripMenuItem.Enabled)
				{
					

					using (OleDbConnection conn = new OleDbConnection(connectionString))
					{
						conn.Open();
						string sql = @"Delete from SellesPlan_Product
                                        where ID_plan = @planID and ID_product = @productID";
						using (OleDbCommand comm = new OleDbCommand(sql, conn))
						{

							comm.Parameters.AddWithValue("@planID", dataGridView1.SelectedRows[0].Cells["ID_plan"].Value.ToString());
							comm.Parameters.AddWithValue("@planID", dataGridView1.SelectedRows[0].Cells["ID_product"].Value.ToString());
							comm.ExecuteNonQuery();
						}
					}
					MessageBox.Show("Plan successfully deleted");
					sellingPlansToolStripMenuItem_Click(this, e);
				}
				if (!productsToolStripMenuItem.Enabled)
				{
					
					using (OleDbConnection conn = new OleDbConnection(connectionString))
					{
						conn.Open();
						string sql = @"Delete from [Product]
                                        where ID_product = @id_p;";
						using (OleDbCommand comm = new OleDbCommand(sql, conn))
						{
							comm.Parameters.AddWithValue("@ID_product", dataGridView1.SelectedRows[0].Cells["ID_product"].Value.ToString());
							comm.ExecuteNonQuery();
						}
					}
					MessageBox.Show("Product successfully deleted");
					productsToolStripMenuItem_Click(this, e);
				}
			}
        }

		private void statisticsSellingPlansItem_Click(object sender, EventArgs e)
		{
			hideFilterForm();
			EnableMenuItems(sender);
		}

		private void statisticsSuppliesItem_Click(object sender, EventArgs e)
		{
			hideFilterForm();
			ClearGrid();

			EnableMenuItems(sender);

			dataGridView1.Columns.Add("ID_supply", "ID_supply");
			dataGridView1.Columns["ID_supply"].Visible = false;
			dataGridView1.Columns.Add("ID_product", "idpr");
			dataGridView1.Columns["ID_product"].Visible = false;
			dataGridView1.Columns.Add("Manufacturer", "Manufacturer");
			dataGridView1.Columns.Add("PrName", "Name of product");
			dataGridView1.Columns.Add("Proc", "%");
			dataGridView1.Columns.Add("Weight", "Weight/Volume");
			dataGridView1.Columns.Add("Price", "Price for 1 product");
			dataGridView1.Columns.Add("Amount", "Amount");
			dataGridView1.Columns.Add("Date", "Date of production");
			dataGridView1.Columns.Add("ID_employee", "ID_employee");
			dataGridView1.Columns["ID_employee"].Visible = false;
			dataGridView1.Columns.Add("Employee", "Employee");

			
			using (OleDbConnection conn = new OleDbConnection(connectionString))
			{
				conn.Open();

				string sql = @"select Sp.ID_supply, P.ID_product, M.Name_manufacturer, P.Name_product, P.[%-fat], P.[Mass/volume], Sp.[Price], SP.[Count], Date_Production, E.[ID_employee], E.[Full_name]
								from Product as P, Manufacturer as M, Supply as Sp, Employee as E
								where P.ID_manufacturer = M.ID_manufacturer and Sp.ID_product = P.ID_product";
				using (OleDbCommand comm = new OleDbCommand(sql, conn))
				{
					using (OleDbDataReader reader = comm.ExecuteReader())
					{
						int i = 0;
						while (reader.Read())
						{
							dataGridView1.Rows.Add(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetString(5), reader.GetDecimal(6), reader.GetInt32(7), reader.GetDateTime(8), reader.GetInt32(9), reader.GetString(10));
							i++;
						}
					}

				}
			}
		}

		private void ClearGrid()
		{
			dataGridView1.Columns.Clear();
			dataGridView1.Rows.Clear();
			dataGridView1.Refresh();
		}

		private void statisticsSellsItem_Click(object sender, EventArgs e)
		{
			hideFilterForm();
			EnableMenuItems(sender);

			FillInSellGrid();
		}

		private void filterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (pnFilter.Controls.Count > 0)
			{
				pnFilter.Controls.Clear();
			}
			else
			{
				if (!statisticsSellsItem.Enabled)
				{
					showFilterForm(new Filters.StatisticsSellsForm());
				}
				if (!employeeToolStripMenuItem.Enabled)
				{
                    showFilterForm(new Filters.EmployeeFilter());
                }
				if (!positionsToolStripMenuItem.Enabled)
				{
                    showFilterForm(new Filters.PositionFilter());
                }
				if (!sellingPlansToolStripMenuItem.Enabled)
				{
				}
				if (!productsToolStripMenuItem.Enabled)
				{
				}
				if (!statisticsSellingPlansItem.Enabled)
				{
				}
				if (!statisticsSuppliesItem.Enabled)
				{
				}
			}
		}

        private void showSearchForm(Form sf)
        {
            //sf = new Filters.StatisticsSellsForm();
            sf.TopLevel = false;
            pnSearch.Controls.Add(sf);
            sf.Show();
        }

        private void showFilterForm(Form sf)
		{
            //sf = new Filters.StatisticsSellsForm();
            sf.TopLevel = false;
            pnFilter.Controls.Add(sf);
			sf.Show();
		}

		private void hideFilterForm()
		{
			if (pnFilter.Controls.Count > 0)
			{
				pnFilter.Controls.Clear();
			}
		}

		public void FillInSellGrid()
		{
			ClearGrid();

			string sql = @" FROM Product AS P, Manufacturer AS M, Sells AS S, Supply AS Sp, Employee AS E
							WHERE P.ID_manufacturer = M.ID_manufacturer AND S.ID_supply = Sp.ID_supply AND Sp.ID_product = P.ID_product";

			string dtpFromDate = GetFilterValue("StatisticsSellsForm", "dtpFromDate");
			if (dtpFromDate != string.Empty)
			{
				sql += " AND S.Date_sell >= @dtpFromDate";
			}
			string dtpToDate = GetFilterValue("StatisticsSellsForm", "dtpToDate");
			if (dtpToDate != string.Empty)
			{
				sql += " AND S.Date_sell <= @dtpFromDate";
			}
			string cbGroupBy = GetFilterValue("StatisticsSellsForm", "cbGroupBy");
			switch (cbGroupBy)
			{
				case "Manufacturer":
					sql = "SELECT M.Name_manufacturer, Round(AVG(S.[Discount]), 2), SUM(S.[Count]), SUM(Sp.[Price])"
							+ sql
							+ " GROUP BY M.ID_manufacturer, M.Name_manufacturer";
					dataGridView1.Columns.Add("Manufacturer", "Manufacturer");
					dataGridView1.Columns.Add("AvgDiscount", "AVG Discount");
					dataGridView1.Columns.Add("TotalCount", "Total Count");
					dataGridView1.Columns.Add("TotalPrice", "Total Price");
					break;
				case "Product":
					sql = "SELECT P.Name_product, P.[%-fat], P.[Mass/volume], Round(AVG(S.[Discount]), 2), SUM(S.[Count]), SUM(Sp.[Price])"
							+ sql
							+ " GROUP BY P.ID_product, P.Name_product, P.[%-fat], P.[Mass/volume]";
					dataGridView1.Columns.Add("PrName", "Name of product");
					dataGridView1.Columns.Add("Proc", "%");
					dataGridView1.Columns.Add("Weight", "Weight/Volume");
					dataGridView1.Columns.Add("AvgDiscount", "AVG Discount");
					dataGridView1.Columns.Add("TotalCount", "Total Count");
					dataGridView1.Columns.Add("TotalPrice", "Total Price");
					break;
				case "Employer":
					sql = "SELECT E.[Full_name], Round(AVG(S.[Discount]), 2), SUM(S.[Count]), SUM(Sp.[Price])"
							+ sql
							+ " GROUP BY E.ID_employee, E.[Full_name]";
					dataGridView1.Columns.Add("Employee", "Employee");
					dataGridView1.Columns.Add("AvgDiscount", "AVG Discount");
					dataGridView1.Columns.Add("TotalCount", "Total Count");
					dataGridView1.Columns.Add("TotalPrice", "Total Price");
					break;
				default:
					sql = "SELECT S.Date_sell, M.Name_manufacturer, P.Name_product, P.[%-fat], P.[Mass/volume], S.[Discount], S.[Count], Sp.[Price], E.[Full_name]" + sql;
					dataGridView1.Columns.Add("SellDate", "Date of selling");
					dataGridView1.Columns.Add("Manufacturer", "Manufacturer");
					dataGridView1.Columns.Add("PrName", "Name of product");
					dataGridView1.Columns.Add("Proc", "%");
					dataGridView1.Columns.Add("Weight", "Weight/Volume");
					dataGridView1.Columns.Add("Discount", "Discount");
					dataGridView1.Columns.Add("Amount", "Amount");
					dataGridView1.Columns.Add("Price", "Price for 1 product");
					dataGridView1.Columns.Add("Employee", "Employee");
					break;
			}

			using (OleDbConnection conn = new OleDbConnection(connectionString))
			{
				conn.Open();

				using (OleDbCommand comm = new OleDbCommand(sql, conn))
				{
					if (dtpFromDate != string.Empty)
					{
						comm.Parameters.AddWithValue("@dtpFromDate", dtpFromDate);
					}
					if (dtpToDate != string.Empty)
					{
						comm.Parameters.AddWithValue("@dtpToDate", dtpToDate);
					}

					using (OleDbDataReader reader = comm.ExecuteReader())
					{
						while (reader.Read())
						{
							object[] values = new object[reader.FieldCount];
							for(int i = 0; i < reader.FieldCount; i++)
							{
								values[i] = reader.GetValue(i).ToString();
							}
							dataGridView1.Rows.Add(values);
						}
					}
				}
			}
		}

        public void FillInEmployeeGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            string sql = @"select e.ID_employee, e.[Full_name], e.[Username], e.[Password], p.ID_position, p.[Position_name]
from [Employee] as e, [Position] as p, [Employee_Position] as ep
where e.ID_employee = ep.ID_employee and p.ID_position = ep.ID_position and EP.Date_for is null and E.IsWorking = true";

            string cbGroupBy = GetFilterValue("EmployeeFilter", "cbGroupBy");
            if (cbGroupBy != string.Empty)
            {
                sql += " and p.Position_name = '" + cbGroupBy + "'";
            }

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                using (OleDbCommand comm = new OleDbCommand(sql, conn))
                {
                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object[] values = new object[reader.FieldCount];
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                values[i] = reader.GetValue(i).ToString();
                            }
                            dataGridView1.Rows.Add(values);
                        }
                    }
                }
            }
        }

        public void FillInPositionGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            string sql = @"select [ID_position], [Position_name], [Payment_per_hour]
                            from [Position] as p
                            where 1 = 1 
                            ";

            string dtpFrom = GetFilterValue("PositionFilter", "textBox1");
            if (dtpFrom != string.Empty)
            {
                sql += " and Payment_per_hour >= " + dtpFrom;
            }
            string dtpTo = GetFilterValue("PositionFilter", "textBox2");
            if (dtpTo != string.Empty)
            {
                sql += " and Payment_per_hour <= " + dtpTo;
            }

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                using (OleDbCommand comm = new OleDbCommand(sql, conn))
                {
                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object[] values = new object[reader.FieldCount];
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                values[i] = reader.GetValue(i).ToString();
                            }
                            dataGridView1.Rows.Add(values);
                        }
                    }
                }
            }
        }

        private string GetFilterValue(string formName, string controlName)
		{
			Control[] controls = this.Controls.Find(formName, true);
			if(controls.Count() > 0)
			{
				Control control = (controls[0] as Form).Controls[controlName];
				if(control != null)
				{
					return control.Text.Trim();
				}
			}
			return string.Empty;
		}

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pnSearch.Controls.Count > 0)
            {
                pnSearch.Controls.Clear();
            }
            else
            {
                
                showSearchForm(new SearchForm());
                
            }
        }
    }
}
