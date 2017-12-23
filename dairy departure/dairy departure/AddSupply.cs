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
    public partial class AddSupply : Form
    {
        public AddSupply()
        {
            InitializeComponent();
        }

        private void AddSupply_Load(object sender, EventArgs e)
        {
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
                    string sql = @"Insert into [Supply] ([ID_product], [Price], [Count], [Date_Production], [ID_employee_position])
                                values (@ID_product, @Price, @Count, @Date_Production, @ID_employee_position)
                ";
                    using (OleDbCommand comm = new OleDbCommand(sql, conn))
                    {
                        comm.Parameters.AddWithValue("@ID_product", ((DairyDeparture1DataSet.Product_ЗапросRow)((DataRowView)((ComboBox)comboBox1).SelectedItem).Row).ID_product);
                        comm.Parameters.AddWithValue("@Price", maskedTextBox1.Text);
                        comm.Parameters.AddWithValue("@Count", maskedTextBox2.Text);
                        comm.Parameters.AddWithValue("@Date_Production", dateTimePicker1.Value.Day + "." + dateTimePicker1.Value.Month + "." + dateTimePicker1.Value.Year);
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
