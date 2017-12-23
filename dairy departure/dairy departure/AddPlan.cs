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
        public AddPlan()
        {
            InitializeComponent();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dairyDeparture1DataSet.Product_Запрос' table. You can move, or remove it, as needed.
            this.product_ЗапросTableAdapter.Fill(this.dairyDeparture1DataSet.Product_Запрос);
            // TODO: This line of code loads data into the 'dairyDeparture1DataSet.PositionInfo' table. You can move, or remove it, as needed.
            this.positionInfoTableAdapter.Fill(this.dairyDeparture1DataSet.PositionInfo);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;

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
                MessageBox.Show("Plan successfully added");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
