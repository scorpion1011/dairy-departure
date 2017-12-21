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
    public partial class LogInForm : Form
    {
        public string name;
        public string manufacturer;
        public string weight;
        public string proc;
        public int emp_pos;
        private int id_emp;
        private string name_emp;
        private string pos_name;
        private Director dir;
        private Seller sel;
        private Storekeeper keep;

        public LogInForm()
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
                string sql = @"SELECT e.ID_employee, e.Full_name, p.Position_name, ep.ID_employee_position
FROM [Position] AS p INNER JOIN (Employee AS e INNER JOIN Employee_Position AS ep ON e.ID_employee = ep.ID_employee) ON p.ID_position = ep.ID_position
WHERE (((e.Username)=@username) AND ((e.Password)= @password))
";
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

                            

                            ShowUserControl(pos_name);
                        }
                        else
                        {
                            MessageBox.Show("Access denied");
                        }
                    }
                }

            }
        }

        public void SetLogVisibility(bool visibility)
        {
            label1.Visible = visibility;
            label2.Visible = visibility;
            label3.Visible = visibility;
            textBox1.Visible = visibility;
            textBox2.Visible = visibility;
            button1.Visible = visibility;
        }

        private void ShowUserControl(string controlType)
        {
            this.Text = "Welcome, " + name_emp;
            switch (controlType)
            {
                case "Director":
                    SetLogVisibility(false);
                    if (dir == null)
                    {
                        dir = new Director();
                    }
                    this.Size = new System.Drawing.Size(675, 425);
                    this.Controls.Add(dir);
                    break;
                case "Seller":
                    SetLogVisibility(false);
                    if (sel == null)
                    {
                        sel = new Seller();
                    }
                    this.Size = new System.Drawing.Size(675, 425);
                    this.Controls.Add(sel);
                    break;
                case "StoreKeeper":
                    SetLogVisibility(false);
                    if (keep == null)
                    {
                        keep = new Storekeeper();
                    }
                    this.Size = new System.Drawing.Size(800, 425);
                    this.Controls.Add(keep);
                    break;
            }
            return;
        }

        public void Logout(Control control)
        {
            this.Controls.Remove(control);
            SetLogVisibility(true);
            this.Size = new System.Drawing.Size(377, 234);
            this.Text = "Login";
        }
    }
}
