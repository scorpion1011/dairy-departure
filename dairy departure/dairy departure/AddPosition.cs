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
        Director parent;
        DataGridViewRow row;
        public AddPosition(Director parent, DataGridViewRow row = null)
        {
            this.parent = parent;
            this.row = row;
            InitializeComponent();


            
            if (row != null)
            {
                maskedTextBox1.Text = row.Cells["PosName"].Value.ToString();
                maskedTextBox2.Text = row.Cells["Payment"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Director f = (Director)this.parent;
            if (row == null)
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
                    MessageBox.Show("Position successfully added");
                    f.positionsToolStripMenuItem_Click(f.GetToolStripMenuItem("positionsToolStripMenuItem"), e);
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
                    int posID = Int32.Parse(row.Cells["ID_position"].Value.ToString());
                    string connectionString = ConfigurationManager.ConnectionStrings["DairyDepartureConnectionString"].ConnectionString;

                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"Update [Position] 
                                        set [Position_name] = @Position_name, [Payment_per_hour] = @Payment_per_hour
                                        where ID_position = @id";

                        using (OleDbCommand comm = new OleDbCommand(sql, conn))
                        {
                            comm.Parameters.AddWithValue("@Position_name", maskedTextBox1.Text);
                            comm.Parameters.AddWithValue("@Payment_per_hour", Decimal.Parse(maskedTextBox2.Text));
                            comm.Parameters.AddWithValue("@Position_name", posID);
                            comm.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Position successfully updated");
                    this.Close();
                    f.positionsToolStripMenuItem_Click(f.GetToolStripMenuItem("positionsToolStripMenuItem"), e);
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
