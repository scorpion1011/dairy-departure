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
    public partial class AddManufacturer : Form
    {
        public AddManufacturer()
        {
            InitializeComponent();
        }

        private void manufacturerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.manufacturerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dairyDeparture1DataSet);

        }

        private void AddManufacturer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dairyDeparture1DataSet.Manufacturer' table. You can move, or remove it, as needed.
            this.manufacturerTableAdapter.Fill(this.dairyDeparture1DataSet.Manufacturer);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            manufacturerBindingNavigatorSaveItem_Click(sender, e);
        }
    }
}
