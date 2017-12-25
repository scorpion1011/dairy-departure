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
        Director parent;
        int id;
        public AddEmployee(Director parent, int id)
        {
            this.parent = parent;
            this.id = id;
            InitializeComponent();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dairyDeparture1DataSet.PositionInfo' table. You can move, or remove it, as needed.
            this.positionInfoTableAdapter.Fill(this.dairyDeparture1DataSet.PositionInfo);

            if (id != -1)
            {
                DataGridViewRow row = ((DataGridView)(parent.Controls["dataGridView1"])).Rows[id];
                maskedTextBox1.Text = row.Cells["EmpName"].Value.ToString();
                maskedTextBox2.Text = row.Cells["EmpLog"].Value.ToString();
                maskedTextBox3.Text = row.Cells["EmpPas"].Value.ToString();
                var j = comboBox1.SelectedValue;
                comboBox1.SelectedValue = row.Cells["EmpPos"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id == -1)
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
                            comm.Parameters.AddWithValue("@Date_p", DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                            comm.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Employee successfully added");
                    ((DataGridView)parent.Controls["dataGridView1"]).Rows.Clear();
                    ((DataGridView)parent.Controls["dataGridView1"]).Refresh();
                    parent.employeeToolStripMenuItem_Click(this, e);
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
                    string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;

                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        DataGridViewRow row = ((DataGridView)(parent.Controls["dataGridView1"])).Rows[id];
                        int empID = Int32.Parse(row.Cells["EmpID"].Value.ToString());
                        int posID = Int32.Parse(row.Cells["PosID"].Value.ToString());
                        string sql = @"Update Employee 
                                        set [Full_name] = @Full_name, [Username] = @Username, [Password] = @Password
                                        where ID_employee = @id_e;";

                        string sql3 = @"Update Employee_Position
                                        set [Date_for] = @DateNow
                                        where ID_employee = @id_e and Date_for is null;";

                        string sql4 = @"Insert into Employee_Position([ID_employee], [ID_position], [Date_from]) 
                                         values(@ID_e, @ID_position, @Date_p)";
                        
                        using (OleDbCommand comm = new OleDbCommand(sql, conn))
                        {
                            comm.Parameters.AddWithValue("@Full_name", maskedTextBox1.Text);
                            comm.Parameters.AddWithValue("@Username", maskedTextBox2.Text);
                            comm.Parameters.AddWithValue("@Password", maskedTextBox3.Text);
                            comm.Parameters.AddWithValue("@id_e", empID);
                            comm.ExecuteNonQuery();

                            comm.Parameters.RemoveAt("@id_e");
                            comm.Parameters.RemoveAt("@Full_name");
                            comm.Parameters.RemoveAt("@Username");
                            comm.Parameters.RemoveAt("@Password");

                            if (((DairyDeparture1DataSet.PositionInfoRow)((DataRowView)((ComboBox)comboBox1).SelectedItem).Row).ID_position != posID)
                            {
                                comm.CommandText = sql3;
                                comm.Parameters.AddWithValue("@DateNow", DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                                comm.Parameters.AddWithValue("@id_e", empID);
                                comm.ExecuteNonQuery();

                                comm.Parameters.RemoveAt("@id_e");
                                comm.Parameters.RemoveAt("@DateNow");

                                comm.CommandText = sql4;
                                comm.Parameters.AddWithValue("@ID_e", empID);
                                comm.Parameters.AddWithValue("@ID_position", ((DairyDeparture1DataSet.PositionInfoRow)((DataRowView)((ComboBox)comboBox1).SelectedItem).Row).ID_position);
                                comm.Parameters.AddWithValue("@Date_p", DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                                comm.ExecuteNonQuery();
                            }
                        }

                    }
                    MessageBox.Show("Employee successfully updated");
                    ((DataGridView)parent.Controls["dataGridView1"]).Rows.Clear();
                    ((DataGridView)parent.Controls["dataGridView1"]).Refresh();
                    parent.employeeToolStripMenuItem_Click(this, e);
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
