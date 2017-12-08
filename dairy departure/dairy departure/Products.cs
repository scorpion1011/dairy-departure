using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dairy_departure
{
    public partial class Products : Form
    {
        Seller parent;
        public Products(Seller parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void productBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dairyDeparture1DataSet);

        }

        private void Products_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dairyDeparture1DataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.dairyDeparture1DataSet.Product);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            (parent.Controls["dataGridView1"] as DataGridView).Rows.Add(productDataGridView.SelectedRows[0].Cells[0].Value.ToString(), 
                productDataGridView.SelectedRows[0].Cells[1].Value.ToString(), 
                productDataGridView.SelectedRows[0].Cells[2].Value.ToString(),
                productDataGridView.SelectedRows[0].Cells[3].Value.ToString()
                );
            this.Close();
        }
    }
}
