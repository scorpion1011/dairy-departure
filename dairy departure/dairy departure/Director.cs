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
        public Director()
        {
            InitializeComponent();
            employeeToolStripMenuItem_Click(this, null);
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

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
			dataGridView1.Refresh();

			employeeToolStripMenuItem.Enabled = false;
			positionsToolStripMenuItem.Enabled = true;
			sellingPlansToolStripMenuItem.Enabled = true;
			productsToolStripMenuItem.Enabled = true;
			sellsToolStripMenuItem.Enabled = true;
			suppliesToolStripMenuItem.Enabled = true;

			dataGridView1.Columns.Add("EmpID", "id");
            dataGridView1.Columns["EmpID"].Visible = false;
            dataGridView1.Columns.Add("EmpName", "Name of employee");
            dataGridView1.Columns.Add("EmpLog", "Login of employee");
            dataGridView1.Columns.Add("EmpPas", "Password of employee");
            dataGridView1.Columns.Add("EmpPos", "Position of employee");

            string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                string sql = @"select E.*, P.Position_name  from [Employee] as E, Employee_Position as EP, [Position] as P where EP.ID_employee = E.ID_employee and P.ID_position = EP.ID_position";
                using (OleDbCommand comm = new OleDbCommand(sql, conn))
                {
                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                            i++;
                        }
                    }
					conn.Close();

				}
            }
        }

		private void positionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
			dataGridView1.Refresh();

			employeeToolStripMenuItem.Enabled = true;
			positionsToolStripMenuItem.Enabled = false;
			sellingPlansToolStripMenuItem.Enabled = true;
			productsToolStripMenuItem.Enabled = true;
			sellsToolStripMenuItem.Enabled = true;
			suppliesToolStripMenuItem.Enabled = true;

			dataGridView1.Columns.Add("ID_position", "id");
			dataGridView1.Columns["ID_position"].Visible = false;
			dataGridView1.Columns.Add("PosName", "Name of position");
			dataGridView1.Columns.Add("Payment", "Payment per hour");

			string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;
			using (OleDbConnection conn = new OleDbConnection(connectionString))
			{
				conn.Open();

				string sql = @"select * from [Position]";
				using (OleDbCommand comm = new OleDbCommand(sql, conn))
				{
					using (OleDbDataReader reader = comm.ExecuteReader())
					{
						int i = 0;
						while (reader.Read())
						{
							dataGridView1.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2));
							i++;
						}
					}

				}
			}
		}

		private void employeespositionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
			dataGridView1.Refresh();

			employeeToolStripMenuItem.Enabled = true;
			positionsToolStripMenuItem.Enabled = true;
			sellingPlansToolStripMenuItem.Enabled = true;
			productsToolStripMenuItem.Enabled = true;
			sellsToolStripMenuItem.Enabled = true;
			suppliesToolStripMenuItem.Enabled = true;

			dataGridView1.Columns.Add("ID_employee_position", "id");
			dataGridView1.Columns["ID_employee_position"].Visible = false;
			dataGridView1.Columns.Add("EmpID", "ID of employee");
			dataGridView1.Columns["EmpID"].Visible = false;
			dataGridView1.Columns.Add("PosID", "ID of position");
			dataGridView1.Columns["PosID"].Visible = false;
			dataGridView1.Columns.Add("[EmpName]", "Name of employee");
			dataGridView1.Columns.Add("[PosName]", "Name of position");
			dataGridView1.Columns.Add("Datefrom", "Date of starting position");
			dataGridView1.Columns.Add("Datefore", "Date of ending position");

			string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;
			using (OleDbConnection conn = new OleDbConnection(connectionString))
			{
				conn.Open();

				string sql = @"select EP.[ID_employee_position], E.[ID_employee], P.[ID_position], E.[Full_name], P.[Position_name], EP.[Date_from], EP.[Date_for]
								from [Employee_Position] as EP, [Employee] as E, [Position] as P
								where EP.[ID_employee] = E.[ID_employee] and EP.[ID_position] = P.[ID_position]";
				using (OleDbCommand comm = new OleDbCommand(sql, conn))
				{
					using (OleDbDataReader reader = comm.ExecuteReader())
					{
						int i = 0;
						while (reader.Read())
						{
							if (!reader.IsDBNull(6))
							{
								dataGridView1.Rows.Add(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetDateTime(5).Date, reader.GetDateTime(6).Date);
							}
							else
							{
								dataGridView1.Rows.Add(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetDateTime(5).Date, null);
							}
								i++;
						}
					}

				}
			}
		}

		private void sellingPlansToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
			dataGridView1.Refresh();

			employeeToolStripMenuItem.Enabled = true;
			positionsToolStripMenuItem.Enabled = true;
			sellingPlansToolStripMenuItem.Enabled = false;
			productsToolStripMenuItem.Enabled = true;
			sellsToolStripMenuItem.Enabled = true;
			suppliesToolStripMenuItem.Enabled = true;

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

			string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;
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

		private void productsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
			dataGridView1.Refresh();

			employeeToolStripMenuItem.Enabled = true;
			positionsToolStripMenuItem.Enabled = true;
			sellingPlansToolStripMenuItem.Enabled = true;
			productsToolStripMenuItem.Enabled = false;
			sellsToolStripMenuItem.Enabled = true;
			suppliesToolStripMenuItem.Enabled = true;
			
			dataGridView1.Columns.Add("ID_product", "idpr");
			dataGridView1.Columns["ID_product"].Visible = false;
			dataGridView1.Columns.Add("Manufacturer", "Manufacturer");
			dataGridView1.Columns.Add("PrName", "Name of product");
			dataGridView1.Columns.Add("Proc", "%");
			dataGridView1.Columns.Add("Weight", "Weight/Volume");
			dataGridView1.Columns.Add("ShelfLife", "Shelf Life");

			string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;
			using (OleDbConnection conn = new OleDbConnection(connectionString))
			{
				conn.Open();

				string sql = @"select P.ID_product, M.Name_manufacturer, P.Name_product, P.[%-fat], P.[Mass/volume], P.[ShelfLife]
								from Product as P, Manufacturer as M
								where P.ID_manufacturer = M.ID_manufacturer
";
				using (OleDbCommand comm = new OleDbCommand(sql, conn))
				{
					using (OleDbDataReader reader = comm.ExecuteReader())
					{
						int i = 0;
						while (reader.Read())
						{
							dataGridView1.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5));
							i++;
						}
					}

				}
			}
		}

		private void sellsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
			dataGridView1.Refresh();

			employeeToolStripMenuItem.Enabled = true;
			positionsToolStripMenuItem.Enabled = true;
			sellingPlansToolStripMenuItem.Enabled = true;
			productsToolStripMenuItem.Enabled = true;
			sellsToolStripMenuItem.Enabled = false;
			suppliesToolStripMenuItem.Enabled = true;

			dataGridView1.Columns.Add("ID_sell", "ID_sell");
			dataGridView1.Columns["ID_sell"].Visible = false;
			dataGridView1.Columns.Add("ID_product", "idpr");
			dataGridView1.Columns["ID_product"].Visible = false;
			dataGridView1.Columns.Add("ID_supply", "ID_supply");
			dataGridView1.Columns["ID_supply"].Visible = false;
			dataGridView1.Columns.Add("SellDate", "Date of selling");
			dataGridView1.Columns.Add("Manufacturer", "Manufacturer");
			dataGridView1.Columns.Add("PrName", "Name of product");
			dataGridView1.Columns.Add("Proc", "%");
			dataGridView1.Columns.Add("Weight", "Weight/Volume");
			dataGridView1.Columns.Add("Discount", "Discount");
			dataGridView1.Columns.Add("Amount", "Amount");
			dataGridView1.Columns.Add("Price", "Price for 1 product");
			dataGridView1.Columns.Add("ID_employee", "ID_employee");
			dataGridView1.Columns["ID_employee"].Visible = false;
			dataGridView1.Columns.Add("Employee", "Employee");

			string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;
			using (OleDbConnection conn = new OleDbConnection(connectionString))
			{
				conn.Open();

				string sql = @"select S.ID_sell, P.ID_product, Sp.ID_supply, S.Date_sell, M.Name_manufacturer, P.Name_product, P.[%-fat], P.[Mass/volume], S.[Discount], S.[Count], Sp.[Price], E.[ID_employee], E.[Full_name]
								from Product as P, Manufacturer as M, Sells as S, Supply as Sp, Employee as E
								where P.ID_manufacturer = M.ID_manufacturer and S.ID_supply = Sp.ID_supply and Sp.ID_product = P.ID_product
";
				using (OleDbCommand comm = new OleDbCommand(sql, conn))
				{
					using (OleDbDataReader reader = comm.ExecuteReader())
					{
						int i = 0;
						while (reader.Read())
						{
							dataGridView1.Rows.Add(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetString(7), reader.GetInt32(8), reader.GetInt32(9), reader.GetDecimal(10), reader.GetInt32(11), reader.GetString(12));
							i++;
						}
					}

				}
			}
		}

		private void suppliesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
			dataGridView1.Refresh();

			employeeToolStripMenuItem.Enabled = true;
			positionsToolStripMenuItem.Enabled = true;
			sellingPlansToolStripMenuItem.Enabled = true;
			productsToolStripMenuItem.Enabled = true;
			sellsToolStripMenuItem.Enabled = true;
			suppliesToolStripMenuItem.Enabled = false;

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

			string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;
			using (OleDbConnection conn = new OleDbConnection(connectionString))
			{
				conn.Open();

				string sql = @"select Sp.ID_supply, P.ID_product, M.Name_manufacturer, P.Name_product, P.[%-fat], P.[Mass/volume], Sp.[Price], SP.[Count], Date_Production, E.[ID_employee], E.[Full_name]
								from Product as P, Manufacturer as M, Supply as Sp, Employee as E
								where P.ID_manufacturer = M.ID_manufacturer and Sp.ID_product = P.ID_product
";
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

		private void addToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!employeeToolStripMenuItem.Enabled)
            {
                AddEmployee f = new AddEmployee(this, 0);
                f.ShowDialog();
            }
            if (!positionsToolStripMenuItem.Enabled)
            {
                AddPosition f = new AddPosition(0);
                f.ShowDialog();
            }
            if (!sellingPlansToolStripMenuItem.Enabled)
            {
                AddPlan f = new AddPlan(0);
                f.ShowDialog();
            }
            if (!productsToolStripMenuItem.Enabled)
            {
                AddProduct f = new AddProduct(0);
                f.ShowDialog();
            }
            if (!sellsToolStripMenuItem.Enabled)
            {
                AddSell f = new AddSell(0);
                f.ShowDialog();
            }
            if (!suppliesToolStripMenuItem.Enabled)
            {
                AddSupply f = new AddSupply(0);
                f.ShowDialog();
            }
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
                AddPosition f = new AddPosition(dataGridView1.SelectedRows[0].Index);
                f.ShowDialog();
            }
            if (!sellingPlansToolStripMenuItem.Enabled)
            {
                AddPlan f = new AddPlan(dataGridView1.SelectedRows[0].Index);
                f.ShowDialog();
            }
            if (!productsToolStripMenuItem.Enabled)
            {
                AddProduct f = new AddProduct(dataGridView1.SelectedRows[0].Index);
                f.ShowDialog();
            }
            if (!sellsToolStripMenuItem.Enabled)
            {
                AddSell f = new AddSell(dataGridView1.SelectedRows[0].Index);
                f.ShowDialog();
            }
            if (!suppliesToolStripMenuItem.Enabled)
            {
                AddSupply f = new AddSupply(dataGridView1.SelectedRows[0].Index);
                f.ShowDialog();
            }
        }
    }
}
