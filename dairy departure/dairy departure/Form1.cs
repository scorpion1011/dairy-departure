using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace dairy_departure
{
    public partial class Form1 : Form
    {
        private object emp_pos;
        private object id_emp;
        private object name_emp;
        private object pos_name;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                //                string sql = @"SELECT e.ID_employee, e.Full_name, p.Position_name
                //FROM [Position] AS p INNER JOIN (Employee AS e INNER JOIN Employee_Position AS ep ON e.ID_employee = ep.ID_employee) ON p.ID_position = ep.ID_position
                //WHERE (((e.Username)=@username) AND ((e.Password)= @password) AND ((ep.Date_for) Is Null))
                //";
                string sql = @"SELECT e.ID_employee, e.Full_name, p.Position_name, ep.ID_employee_position
FROM [Position] AS p INNER JOIN (Employee AS e INNER JOIN Employee_Position AS ep ON e.ID_employee = ep.ID_employee) ON p.ID_position = ep.ID_position
WHERE (((e.Username)=@username) AND ((e.Password)= @password))
";

                //string sql = @"SELECT e.ID_employee, e.Full_name, p.Position_name FROM (Employee e INNER JOIN Employee_Position ep ON (e.ID_employee = ep.ID_employee AND ep.Date_for IS NULL)) INNER JOIN Position p ON (ep.ID_position = p.ID_position) WHERE e.Username = @username AND e.Password = @password";

                using (OleDbCommand comm = new OleDbCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@username", username);
                    comm.Parameters.AddWithValue("@password", password);
                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            emp_pos = reader.GetInt32(3);
                            id_emp = reader.GetInt32(0);
                            name_emp = reader.GetString(1);
                            pos_name = reader.GetString(2);

                            switch (pos_name)
                            {
                                case "Admin":
                                    //this.Visible = false;
                                    MessageBox.Show("hi Admin");
                                    break;
                                case "Seller":
                                    //this.Visible = false;
                                    MessageBox.Show("hi Seller");
                                    break;
                                case "StoreKeeper":
                                    //this.Visible = false;
                                    MessageBox.Show("hi StoreKeeper");
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Access denied");
                        }
                    }
                }

            }
        }
    }
}
