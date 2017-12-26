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
		public SellComplete()
		{
			InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnPrint_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Todo");
		}
	}
}
