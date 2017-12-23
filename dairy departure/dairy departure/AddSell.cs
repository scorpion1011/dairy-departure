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
    public partial class AddSell : Form
    {
        int id;
        public AddSell(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void AddSell_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dairyDeparture1DataSet.Supply_Product_View' table. You can move, or remove it, as needed.
            this.supply_Product_ViewTableAdapter.Fill(this.dairyDeparture1DataSet.Supply_Product_View);
            // TODO: This line of code loads data into the 'dairyDeparture1DataSet.Product_Запрос' table. You can move, or remove it, as needed.
            this.product_ЗапросTableAdapter.Fill(this.dairyDeparture1DataSet.Product_Запрос);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"Insert into [Sells] ([ID_supply], [Date_sell], [Discount], [Count], [ID_employee_position])
                                    values (@ID_supply, @Date_sell, @Discount, @Count, @ID_employee_position)
                    ";
                    using (OleDbCommand comm = new OleDbCommand(sql, conn))
                    {
                        comm.Parameters.AddWithValue("@ID_supply", ((DairyDeparture1DataSet.Supply_Product_ViewRow)((DataRowView)((ComboBox)comboBox1).SelectedItem).Row).ID_supply);
                        comm.Parameters.AddWithValue("@Date_sell", dateTimePicker1.Value.Day + "." + dateTimePicker1.Value.Month + "." + dateTimePicker1.Value.Year);
                        comm.Parameters.AddWithValue("@Discount", Int32.Parse(maskedTextBox2.Text));
                        comm.Parameters.AddWithValue("@Count", Int32.Parse(maskedTextBox3.Text));
                        comm.Parameters.AddWithValue("@ID_employee_position", LogInForm.id_emp);
                        comm.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Employee successfully added");
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
