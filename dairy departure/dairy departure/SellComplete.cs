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
	public partial class SellComplete : Form
	{
        DataGridView dataGridView1;

        public SellComplete(DataGridView dataGridView1)
		{
            this.dataGridView1 = dataGridView1;
            InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnPrint_Click(object sender, EventArgs e)
		{
            Export export = new Export();
            export.ExportDocument(dataGridView1);
        }
	}
}
