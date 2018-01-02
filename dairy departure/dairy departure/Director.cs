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
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using System.Diagnostics;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Shapes.Charts;

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
			FillInSellingPlanGrid();
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

			FillInProductGrid();
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

			FillInPlanStatisticGrid();
		}

		private void statisticsSuppliesItem_Click(object sender, EventArgs e)
		{
			hideFilterForm();
			EnableMenuItems(sender);

			FillInSupplyStatisticGrid();
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
					showFilterForm(new Filters.SellingPlanFilter());
				}
				if (!productsToolStripMenuItem.Enabled)
				{
					showFilterForm(new Filters.ProductFilter());
				}
				if (!statisticsSellingPlansItem.Enabled)
				{
					showFilterForm(new Filters.SellingPlanStatisticFilter());
				}
				if (!statisticsSuppliesItem.Enabled)
				{
					showFilterForm(new Filters.SupplyStatistic());
				}
			}
		}

        private void showSearchForm(Form sf)
        {
            sf.TopLevel = false;
            pnSearch.Controls.Add(sf);
            sf.Show();
        }

        private void showFilterForm(Form sf)
		{
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
			string sql = @" FROM Product AS P, Manufacturer AS M, Sells AS S, Supply AS Sp, Employee AS E, Employee_Position as Ep
							WHERE P.ID_manufacturer = M.ID_manufacturer AND S.ID_supply = Sp.ID_supply AND Sp.ID_product = P.ID_product
							and S.ID_employee_position = Ep.ID_employee_position and Ep.ID_employee = E.ID_employee";

			string dtpFromDate = GetFilterValue("StatisticsSellsForm", "dtpFromDate");
			if (dtpFromDate != string.Empty)
			{
				sql += " AND S.Date_sell >= @dtpFromDate";
			}
			string dtpToDate = GetFilterValue("StatisticsSellsForm", "dtpToDate");
			if (dtpToDate != string.Empty)
			{
				sql += " AND S.Date_sell <= @dtpToDate";
			}
			string cbGroupBy = GetFilterValue("StatisticsSellsForm", "cbGroupBy");
			switch (cbGroupBy)
			{
				case "Manufacturer":
					sql = "SELECT M.Name_manufacturer, Round(AVG(S.[Discount]), 2), SUM(S.[Count]), sum(Sp.[Price]*Sp.[Count]*S.[Discount]/100)"
                            + sql
							+ " GROUP BY M.ID_manufacturer, M.Name_manufacturer";
					dataGridView1.Columns.Add("Manufacturer", "Manufacturer");
					dataGridView1.Columns.Add("AvgDiscount", "AVG Discount");
					dataGridView1.Columns.Add("TotalCount", "Total Count");
					dataGridView1.Columns.Add("TotalPrice", "Total Price");
					break;
				case "Product":
					sql = "SELECT P.Name_product, P.[%-fat], P.[Mass/volume], Round(AVG(S.[Discount]), 2), SUM(S.[Count]), sum(Sp.[Price]*Sp.[Count]*S.[Discount]/100)"
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
					sql = "SELECT E.[Full_name], Round(AVG(S.[Discount]), 2), SUM(S.[Count]), sum(Sp.[Price]*Sp.[Count]*S.[Discount]/100)"
                            + sql
							+ " GROUP BY E.ID_employee, E.[Full_name]";
					dataGridView1.Columns.Add("Employee", "Employee");
					dataGridView1.Columns.Add("AvgDiscount", "AVG Discount");
					dataGridView1.Columns.Add("TotalCount", "Total Count");
					dataGridView1.Columns.Add("TotalPrice", "Total Price");
					break;
				default:
					sql = "SELECT S.Date_sell, M.Name_manufacturer, P.Name_product, P.[%-fat], P.[Mass/volume], S.[Discount], S.[Count], Sp.[Price], E.[Full_name], S.[ID_sell]" + sql;
					dataGridView1.Columns.Add("SellDate", "Date of selling");
					dataGridView1.Columns.Add("Manufacturer", "Manufacturer");
					dataGridView1.Columns.Add("PrName", "Name of product");
					dataGridView1.Columns.Add("Proc", "%");
					dataGridView1.Columns.Add("Weight", "Weight/Volume");
					dataGridView1.Columns.Add("Discount", "Discount");
					dataGridView1.Columns.Add("Amount", "Amount");
					dataGridView1.Columns.Add("Price", "Price for 1 product");
					dataGridView1.Columns.Add("Employee", "Employee");
                    DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                    bcol.HeaderText = "View discount info";
                    bcol.Text = "Info";
                    bcol.Name = "DiscountInfo";
                    dataGridView1.Columns.Add(bcol);

                    break;
			}

			using (OleDbConnection conn = new OleDbConnection(connectionString))
			{
				conn.Open();

				using (OleDbCommand comm = new OleDbCommand(sql, conn))
				{
					if (dtpFromDate != string.Empty)
					{
						comm.Parameters.AddWithValue("@dtpFromDate", Convert.ToDateTime(dtpFromDate));
					}
					if (dtpToDate != string.Empty)
					{
						comm.Parameters.AddWithValue("@dtpToDate", Convert.ToDateTime(dtpToDate));
					}

					using (OleDbDataReader reader = comm.ExecuteReader())
					{
						while (reader.Read())
						{
							object[] values = new object[reader.FieldCount];
							for(int i = 0; i < reader.FieldCount - 1; i++)
							{
								object value = reader.GetValue(i);
								if (value is DateTime)
								{
									values[i] = ((DateTime)value).ToString("dd.MM.yyyy");
								}
								else
								{
									values[i] = value.ToString();
								}
							}
                            dataGridView1.Rows.Add(values);
                            if (dataGridView1.Columns.Contains("DiscountInfo"))
                            {
                                DataGridViewCell cell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["DiscountInfo"];
                                cell.Tag = reader.GetInt32(9);
                                cell.Value = "View";
                            }
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

		public void FillInProductGrid()
		{
			dataGridView1.Rows.Clear();
			dataGridView1.Refresh();

			string sql = @"select P.ID_product, M.ID_manufacturer, M.Name_manufacturer, P.Name_product, P.[%-fat], P.[Mass/volume], P.[ShelfLife]
								from Product as P, Manufacturer as M
								where P.ID_manufacturer = M.ID_manufacturer";

			string dtpMass = GetFilterValue("ProductFilter", "cbGroupBy");
			string dtpManufacturer = GetFilterValue("ProductFilter", "comboBox1");

			if (dtpMass != string.Empty)
			{
				sql += " and P.[Mass/volume] = '" + dtpMass + "'";
			}
			if (dtpManufacturer != string.Empty)
			{
				sql += " and M.Name_manufacturer = '" + dtpManufacturer + "'";
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

		public void FillInSellingPlanGrid()
		{
			dataGridView1.Rows.Clear();
			dataGridView1.Refresh();

			string sql = @"select Sp.[ID_plan], SpP.ID_product, M.Name_manufacturer, P.Name_product, P.[%-fat], P.[Mass/volume], SpP.Amount, Sp.[Date_from], Sp.[Date_to]
								from Product as P, Selles_plan as Sp, SellesPlan_Product as SpP, Manufacturer as M
								where Sp.ID_plan = SpP.ID_plan and P.ID_product = SpP.ID_product and P.ID_manufacturer = M.ID_manufacturer";

			string dtpFrom = GetFilterValue("SellingPlanFilter", "dtpFromDate");
			string dtpTo = GetFilterValue("SellingPlanFilter", "dtpToDate");
			string dtpManufacturer = GetFilterValue("SellingPlanFilter", "cbGroupBy");

			if (dtpFrom != string.Empty)
			{
				sql += " and Sp.[Date_from] >= #" + Convert.ToDateTime(dtpFrom) + "#";
			}
			if (dtpTo != string.Empty)
			{
				sql += " and Sp.[Date_to] <= #" + Convert.ToDateTime(dtpTo) + "#";
			}
			if (dtpManufacturer != string.Empty)
			{
				sql += " and M.Name_manufacturer = '" + dtpManufacturer + "'";
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

		public void FillInPlanStatisticGrid()
		{
			ClearGrid();

			dataGridView1.Columns.Add("ID_plan", "id");
			dataGridView1.Columns["ID_plan"].Visible = false;
			dataGridView1.Columns.Add("ID_product", "idpr");
			dataGridView1.Columns["ID_product"].Visible = false;
			dataGridView1.Columns.Add("Manufacturer", "Manufacturer");
			dataGridView1.Columns.Add("PrName", "Name of product");
			dataGridView1.Columns.Add("Proc", "%");
			dataGridView1.Columns.Add("Weight", "Weight/Volume");
			dataGridView1.Columns.Add("Amount", "Amount to sell");
			dataGridView1.Columns.Add("DateFr", "Date from");
			dataGridView1.Columns.Add("DateTo", "Date to");
			dataGridView1.Columns.Add("ProcCompl", "% of completing");


			string sql = @"select Sp.[ID_plan], SpP.ID_product, M.Name_manufacturer, P.Name_product, P.[%-fat], P.[Mass/volume], SpP.Amount, Sp.[Date_from], Sp.[Date_to]
								from Product as P, Selles_plan as Sp, SellesPlan_Product as SpP, Manufacturer as M
								where Sp.ID_plan = SpP.ID_plan and P.ID_product = SpP.ID_product and P.ID_manufacturer = M.ID_manufacturer";
			
			Control[] controls = this.Controls.Find("SellingPlanStatisticFilter", true);
			bool actual;
			if (controls.Count() > 0)
			{
				actual = ((CheckBox)(controls[0] as Form).Controls["checkBox1"]).Checked;
			}
			else
			{
				actual = false;
			}

			if (actual)
			{
				sql += " and Sp.[Date_from] > Date() and Sp.[Date_to] < Date()";
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
			bool completedOff;
			if (controls.Count() > 0)
			{
				completedOff = ((CheckBox)(controls[0] as Form).Controls["checkBox2"]).Checked;
			}
			else
			{
				completedOff = false;
			}
			string procFrom = GetFilterValue("SellingPlanStatisticFilter", "from");
			string procTo = GetFilterValue("SellingPlanStatisticFilter", "to");
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				int planID = Int32.Parse(dataGridView1.Rows[i].Cells["ID_plan"].Value.ToString());
				int productID = Int32.Parse(dataGridView1.Rows[i].Cells["ID_product"].Value.ToString());

				sql = @" select iif((Sum(sl.[Count])/MIN(SpP.Amount)*100) is null, 0, (Sum(sl.[Count])/MIN(SpP.Amount)*100)) AS Procent 
						from Selles_plan as sp, SellesPlan_Product as spp, Sells as sl, Supply as s
						where sp.ID_plan = spp.ID_plan and sp.ID_plan = @plan and spp.ID_product = @product and sl.ID_supply = s.ID_supply and s.ID_product = @product and sl.Date_sell > sp.Date_from and sl.Date_sell < sp.Date_to";

				
				using (OleDbConnection conn = new OleDbConnection(connectionString))
				{
					conn.Open();

					using (OleDbCommand comm = new OleDbCommand(sql, conn))
					{
						comm.Parameters.AddWithValue("@plan", planID);
						comm.Parameters.AddWithValue("@product", productID);
						//comm.Parameters.AddWithValue("@procFrom", procFrom);
						using (OleDbDataReader reader = comm.ExecuteReader())
						{
							double proc = -1;
							if (reader.Read())
							{
								proc = Math.Round(reader.GetDouble(0));
							}
							dataGridView1.Rows[i].Cells["ProcCompl"].Value = proc;
							if (proc > 100)
							{
								dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.MediumAquamarine;
							}
							else if (proc < 30)
							{
								dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Salmon;
							}
						}
					}
				}
				if (DateTime.Now > DateTime.Parse(dataGridView1.Rows[i].Cells["DateTo"].Value.ToString()) || DateTime.Now < DateTime.Parse(dataGridView1.Rows[i].Cells["DateFr"].Value.ToString()))
				{
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
				}
				if (procFrom != string.Empty)
				{
					if (Int32.Parse(dataGridView1.Rows[i].Cells["ProcCompl"].Value.ToString()) < Int32.Parse(procFrom))
					{
						dataGridView1.Rows.RemoveAt(i);
						i--;
						continue;
					}
				}
				if (procTo != string.Empty)
				{
					if (Int32.Parse(dataGridView1.Rows[i].Cells["ProcCompl"].Value.ToString()) > Int32.Parse(procTo))
					{
						dataGridView1.Rows.RemoveAt(i);
						i--;
						continue;
					}
				}
				if (completedOff)
				{
					if (Int32.Parse(dataGridView1.Rows[i].Cells["ProcCompl"].Value.ToString()) > 100)
					{
						dataGridView1.Rows.RemoveAt(i);
						i--;
						continue;
					}
				}
			}
		}

		public void FillInSupplyStatisticGrid()
		{
			ClearGrid();
			string sql = @" from Product as P, Manufacturer as M, Supply as Sp, Employee as E, Employee_Position as Ep
								where P.ID_manufacturer = M.ID_manufacturer and Sp.ID_product = P.ID_product and Ep.ID_employee = E.ID_employee and Sp.ID_employee_position = Ep.ID_employee_position";

			string dtpFromDate = GetFilterValue("SupplyStatistic", "dtpFromDate");
			if (dtpFromDate != string.Empty)
			{
				sql += " AND Sp.Date_production >= @dtpFromDate";
			}
			string dtpToDate = GetFilterValue("SupplyStatistic", "dtpToDate");
			if (dtpToDate != string.Empty)
			{
				sql += " AND Sp.Date_production <= @dtpToDate";
			}
			string cbGroupBy = GetFilterValue("SupplyStatistic", "cbGroupBy");
			switch (cbGroupBy)
			{
				case "Manufacturer":
					sql = "SELECT M.Name_manufacturer, Sum(Sp.[Count]), sum(Sp.[Price]*Sp.[Count])"
                            + sql
							+ " GROUP BY M.ID_manufacturer, M.Name_manufacturer";
					dataGridView1.Columns.Add("Manufacturer", "Manufacturer");
					dataGridView1.Columns.Add("TotalCount", "Total Count");
					dataGridView1.Columns.Add("TotalPrice", "Total Price");
					break;
				case "Product":
					sql = "SELECT P.Name_product, P.[%-fat], P.[Mass/volume], Sum(Sp.[Count]), sum(Sp.[Price]*Sp.[Count])"
                            + sql
							+ " GROUP BY P.ID_product, P.Name_product, P.[%-fat], P.[Mass/volume]";
					dataGridView1.Columns.Add("PrName", "Name of product");
					dataGridView1.Columns.Add("Proc", "%");
					dataGridView1.Columns.Add("Weight", "Weight/Volume");
					dataGridView1.Columns.Add("TotalCount", "Total Count");
					dataGridView1.Columns.Add("TotalPrice", "Total Price");
					break;
				case "Employer":
					sql = "SELECT E.[Full_name], Sum(Sp.[Count]), sum(Sp.[Price]*Sp.[Count])"
                            + sql
							+ " GROUP BY E.ID_employee, E.[Full_name]";
					dataGridView1.Columns.Add("Employee", "Employee");
					dataGridView1.Columns.Add("TotalCount", "Total Count");
					dataGridView1.Columns.Add("TotalPrice", "Total Price");
					break;
				default:
					sql = "select M.Name_manufacturer, P.Name_product, P.[%-fat], P.[Mass/volume], Sp.[Price], SP.[Count], Date_Production, E.[Full_name]" + sql;
					dataGridView1.Columns.Add("Manufacturer", "Manufacturer");
					dataGridView1.Columns.Add("PrName", "Name of product");
					dataGridView1.Columns.Add("Proc", "%");
					dataGridView1.Columns.Add("Weight", "Weight/Volume");
					dataGridView1.Columns.Add("Price", "Price for 1 product");
					dataGridView1.Columns.Add("Count", "Count");
					dataGridView1.Columns.Add("Date", "Date of production");
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
						comm.Parameters.AddWithValue("@dtpFromDate", Convert.ToDateTime(dtpFromDate));
					}
					if (dtpToDate != string.Empty)
					{
						comm.Parameters.AddWithValue("@dtpToDate", Convert.ToDateTime(dtpToDate));
					}

					using (OleDbDataReader reader = comm.ExecuteReader())
					{
						while (reader.Read())
						{
							object[] values = new object[reader.FieldCount];
							for(int i = 0; i < reader.FieldCount; i++)
							{
								object value = reader.GetValue(i);
								if (value is DateTime)
								{
									values[i] = ((DateTime)value).ToString("dd.MM.yyyy");
								}
								else
								{
									values[i] = value.ToString();
								}
							}
							dataGridView1.Rows.Add(values);
						}
					}
				}
			}
			//dataGridView1.Columns.Add("ID_supply", "ID_supply");
			//dataGridView1.Columns["ID_supply"].Visible = false;
			//dataGridView1.Columns.Add("ID_product", "idpr");
			//dataGridView1.Columns["ID_product"].Visible = false;
			//dataGridView1.Columns.Add("Manufacturer", "Manufacturer");
			//dataGridView1.Columns.Add("PrName", "Name of product");
			//dataGridView1.Columns.Add("Proc", "%");
			//dataGridView1.Columns.Add("Weight", "Weight/Volume");
			//dataGridView1.Columns.Add("Price", "Price for 1 product");
			//dataGridView1.Columns.Add("Amount", "Amount");
			//dataGridView1.Columns.Add("Date", "Date of production");
			//dataGridView1.Columns.Add("ID_employee", "ID_employee");
			//dataGridView1.Columns["ID_employee"].Visible = false;
			//dataGridView1.Columns.Add("Employee", "Employee");


			//using (OleDbConnection conn = new OleDbConnection(connectionString))
			//{
			//	conn.Open();

			//	string sql = @"select Sp.ID_supply, P.ID_product, M.Name_manufacturer, P.Name_product, P.[%-fat], P.[Mass/volume], Sp.[Price], SP.[Count], Date_Production, E.[ID_employee], E.[Full_name]
			//					from Product as P, Manufacturer as M, Supply as Sp, Employee as E
			//					where P.ID_manufacturer = M.ID_manufacturer and Sp.ID_product = P.ID_product";
			//	using (OleDbCommand comm = new OleDbCommand(sql, conn))
			//	{
			//		using (OleDbDataReader reader = comm.ExecuteReader())
			//		{
			//			int i = 0;
			//			while (reader.Read())
			//			{
			//				dataGridView1.Rows.Add(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetString(5), reader.GetDecimal(6), reader.GetInt32(7), reader.GetDateTime(8), reader.GetInt32(9), reader.GetString(10));
			//				i++;
			//			}
			//		}

			//	}
			//}
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

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export export = new Export();
            export.ExportDocument(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns["DiscountInfo"] != null && e.ColumnIndex == dataGridView1.Columns["DiscountInfo"].Index)
            {
                string idSell = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["DiscountInfo"].Tag.ToString();
                DiscountManager manager = new DiscountManager();
                List<string> info = manager.Information(Int32.Parse(idSell));

                string message = @" Discount  Details:
                    Date of selling : {0}
                    Product : {1}

                    Shelf Life : {2}
                    Date Of Production : {3}
                    % of corruption : {4}

                    Fired Plan Information : {5}
                    % of Completing plan : {6}
                ";
                MessageBox.Show(String.Format(message, info[0], info[1], info[2], info[3], info[4], info[5], info[6]));
            }
        }
    }
}
