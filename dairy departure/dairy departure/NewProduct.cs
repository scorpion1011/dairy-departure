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
    public partial class NewProduct : Form
    {
        public NewProduct()
        {
            InitializeComponent();
        }

        private void productBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dairyDeparture1DataSet);

        }

        private void NewProduct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dairyDeparture1DataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.dairyDeparture1DataSet.Product);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddManufacturer f = new AddManufacturer();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            productBindingNavigatorSaveItem_Click(sender, e);
        }
    }
}
