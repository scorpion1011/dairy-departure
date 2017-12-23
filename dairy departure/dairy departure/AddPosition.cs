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
    public partial class AddPosition : Form
    {
        int id;
        public AddPosition(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"Insert into [Position] ([Position_name], [Payment_per_hour])
                                    values (@Position_name, @Payment_per_hour)";

                    using (OleDbCommand comm = new OleDbCommand(sql, conn))
                    {
                        comm.Parameters.AddWithValue("@Position_name", maskedTextBox1.Text);
                        comm.Parameters.AddWithValue("@Payment_per_hour", Decimal.Parse(maskedTextBox2.Text));
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
