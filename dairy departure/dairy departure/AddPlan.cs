using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dairy_departure
{
    public partial class AddPlan : Form
    {
        Director parent;
        DataGridViewRow row;
        public AddPlan(Director parent, DataGridViewRow row = null)
        {
            this.parent = parent;
            this.row = row;
            InitializeComponent();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dairyDeparture1DataSet.Product_Запрос' table. You can move, or remove it, as needed.
            this.product_ЗапросTableAdapter.Fill(this.dairyDeparture1DataSet.Product_Запрос);
            // TODO: This line of code loads data into the 'dairyDeparture1DataSet.PositionInfo' table. You can move, or remove it, as needed.
            this.positionInfoTableAdapter.Fill(this.dairyDeparture1DataSet.PositionInfo);
            
            if (row != null)
            {
                comboBox2.SelectedValue = row.Cells["ID_product"].Value.ToString();
                maskedTextBox2.Text = row.Cells["Amount"].Value.ToString();
                dateTimePicker1.Text = row.Cells["DateFr"].Value.ToString();
                dateTimePicker2.Text = row.Cells["DateTo"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Director f = (Director)this.parent;
            if (row == null)
            {
                try
                {
                    int count = 0;
                    string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"select Count(ID_plan) from Selles_plan where Date_from = @Date_from and Date_to = @Date_to";
                        using (OleDbCommand comm = new OleDbCommand(sql, conn))
                        {
                            comm.Parameters.AddWithValue("@Date_from", dateTimePicker1.Value.Day + "." + dateTimePicker1.Value.Month + "." + dateTimePicker1.Value.Year);
                            comm.Parameters.AddWithValue("@Date_to", dateTimePicker2.Value.Day + "." + dateTimePicker2.Value.Month + "." + dateTimePicker2.Value.Year);
                            using (OleDbDataReader reader = comm.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    count = reader.GetInt32(0);
                                }
                            }
                        }
                    }

                    if (count == 0)
                    {
                        using (OleDbConnection conn = new OleDbConnection(connectionString))
                        {
                            conn.Open();
                            int ID;
                            string sql = @"Insert into Selles_plan ([Date_from], [Date_to])
                                            values (@Date_from, @Date_to)
                            ";

                            string sql2 = @"Select @@Identity";

                            string sql3 = @"Insert into SellesPlan_product([ID_plan], [ID_product], [Amount]) 
                                            values(@ID_plan, @ID_product, @Amount)";
                            using (OleDbCommand comm = new OleDbCommand(sql, conn))
                            {

                                comm.Parameters.AddWithValue("@Date_from", dateTimePicker1.Value.Day + "." + dateTimePicker1.Value.Month + "." + dateTimePicker1.Value.Year);
                                comm.Parameters.AddWithValue("@Date_to", dateTimePicker2.Value.Day + "." + dateTimePicker2.Value.Month + "." + dateTimePicker2.Value.Year);
                                comm.ExecuteNonQuery();

                                comm.Parameters.RemoveAt("@Date_from");
                                comm.Parameters.RemoveAt("@Date_to");


                                comm.CommandText = sql2;
                                ID = (int)comm.ExecuteScalar();

                                comm.CommandText = sql3;
                                comm.Parameters.AddWithValue("@ID_plan", ID);
                                comm.Parameters.AddWithValue("@ID_product", ((DairyDeparture1DataSet.Product_ЗапросRow)((DataRowView)((ComboBox)comboBox2).SelectedItem).Row).ID_product);
                                comm.Parameters.AddWithValue("@Amount", maskedTextBox2.Text);
                                comm.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        using (OleDbConnection conn = new OleDbConnection(connectionString))
                        {
                            conn.Open();
                            int ID = -1;
                            string sql = @"select ID_plan from Selles_plan where Date_from = @Date_from and Date_to = @Date_to";

                            string sql2 = @"Insert into SellesPlan_product([ID_plan], [ID_product], [Amount]) 
                                            values(@ID_plan, @ID_product, @Amount)";
                            using (OleDbCommand comm = new OleDbCommand(sql, conn))
                            {
                                comm.Parameters.AddWithValue("@Date_from", dateTimePicker1.Value.Day + "." + dateTimePicker1.Value.Month + "." + dateTimePicker1.Value.Year);
                                comm.Parameters.AddWithValue("@Date_to", dateTimePicker2.Value.Day + "." + dateTimePicker2.Value.Month + "." + dateTimePicker2.Value.Year);
                                comm.ExecuteNonQuery();

                                using (OleDbDataReader reader = comm.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        ID = reader.GetInt32(0);
                                    }
                                }

                                comm.Parameters.RemoveAt("@Date_from");
                                comm.Parameters.RemoveAt("@Date_to");

                                comm.CommandText = sql2;
                                comm.Parameters.AddWithValue("@ID_plan", ID);
                                comm.Parameters.AddWithValue("@ID_product", ((DairyDeparture1DataSet.Product_ЗапросRow)((DataRowView)((ComboBox)comboBox2).SelectedItem).Row).ID_product);
                                comm.Parameters.AddWithValue("@Amount", maskedTextBox2.Text);
                                comm.ExecuteNonQuery();
                            }
                        }
                    }
                    MessageBox.Show("Plan successfully added");
                    f.sellingPlansToolStripMenuItem_Click(f.GetToolStripMenuItem("sellingPlansToolStripMenuItem"), e);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid input");
                }
            }
            else
            {
                try
                {
                    DateTime dayFrom = DateTime.Parse(row.Cells["DateFr"].Value.ToString());
                    DateTime dayTo = DateTime.Parse(row.Cells["DateTo"].Value.ToString());
                    int planID = Int32.Parse(row.Cells["ID_plan"].Value.ToString());
                    int productID = Int32.Parse(row.Cells["ID_product"].Value.ToString());

                    string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;

                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"Update Selles_plan
                                        set [Date_from] = @dayFrom, [Date_to] = @dayTo
                                        where ID_plan = @planID";

                        string sql2 = @"Update SellesPlan_product
                                        set [ID_product] = @ID_product, [Amount] = @Amount
                                        where ID_plan = @planID and ID_product = @productID";
                        using (OleDbCommand comm = new OleDbCommand(sql, conn))
                        {

                            comm.Parameters.AddWithValue("@dayFrom", dateTimePicker1.Value.Day + "." + dateTimePicker1.Value.Month + "." + dateTimePicker1.Value.Year);
                            comm.Parameters.AddWithValue("@dayTo", dateTimePicker2.Value.Day + "." + dateTimePicker2.Value.Month + "." + dateTimePicker2.Value.Year);
                            comm.Parameters.AddWithValue("@planID", planID);
                            comm.ExecuteNonQuery();

                            comm.Parameters.RemoveAt("@dayFrom");
                            comm.Parameters.RemoveAt("@dayTo");
                            comm.Parameters.RemoveAt("@planID");

                            comm.CommandText = sql2;
                            comm.Parameters.AddWithValue("@ID_product", ((DairyDeparture1DataSet.Product_ЗапросRow)((DataRowView)((ComboBox)comboBox2).SelectedItem).Row).ID_product);
                            comm.Parameters.AddWithValue("@Amount", Int32.Parse(maskedTextBox2.Text));
                            comm.Parameters.AddWithValue("@planID", planID);
                            comm.Parameters.AddWithValue("@productID", productID);
                            comm.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Plan successfully updated");
                    f.sellingPlansToolStripMenuItem_Click(f.GetToolStripMenuItem("sellingPlansToolStripMenuItem"), e);
                    this.Close();
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid input");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
