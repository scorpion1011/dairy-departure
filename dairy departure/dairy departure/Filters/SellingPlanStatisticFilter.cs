using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dairy_departure.Filters
{
	public partial class SellingPlanStatisticFilter : Form
	{
		public SellingPlanStatisticFilter()
		{
			InitializeComponent();
		}

		private void btnFilter_Click(object sender, EventArgs e)
		{
			(this.Parent.Parent.Parent as Director).FillInPlanStatisticGrid();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			from.Text = "";
			to.Text = "";
			checkBox1.Checked = false;
			checkBox2.Checked = false;
			(this.Parent.Parent.Parent as Director).FillInPlanStatisticGrid();
		}
	}
}
