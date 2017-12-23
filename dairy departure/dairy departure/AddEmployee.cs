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
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
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
                    string sql = @"Insert into Employee ([Full_name], [Username], [Password])
                                    values (@Full_name, @Username, @Password)
                    ";

                    string sql2 = @"Select @@Identity";

                    string sql3 = @"Insert into Employee_Position([ID_employee], [ID_position], [Date_from]) 
                                    values(@ID_e, @ID_position, @Date_p)";
                    using (OleDbCommand comm = new OleDbCommand(sql, conn))
                    {
                        comm.Parameters.AddWithValue("@Full_name", maskedTextBox1.Text);
                        comm.Parameters.AddWithValue("@Username", maskedTextBox2.Text);
                        comm.Parameters.AddWithValue("@Password", maskedTextBox3.Text);
                        comm.ExecuteNonQuery();

                        comm.Parameters.RemoveAt("@Full_name");
                        comm.Parameters.RemoveAt("@Username");
                        comm.Parameters.RemoveAt("@Password");


                        comm.CommandText = sql2;
                        ID = (int)comm.ExecuteScalar();

                        comm.CommandText = sql3;
                        comm.Parameters.AddWithValue("@ID_e", ID);
                        comm.Parameters.AddWithValue("@ID_position", ((DairyDeparture1DataSet.PositionInfoRow)((DataRowView)((ComboBox)comboBox1).SelectedItem).Row).ID_position);
                        comm.Parameters.AddWithValue("@Date_p", DateTime.Now.Day +"."+ DateTime.Now.Month + "." + DateTime.Now.Year);
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
