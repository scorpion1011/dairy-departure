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
	public partial class SellingPlanFilter : Form
	{
		public SellingPlanFilter()
		{
			InitializeComponent();
			dtpFromDate.CustomFormat = " ";
			dtpToDate.CustomFormat = " ";
		}

		private void btnFilter_Click(object sender, EventArgs e)
		{
			(this.Parent.Parent.Parent as Director).FillInSellingPlanGrid();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			dtpFromDate.Format = DateTimePickerFormat.Custom;
			dtpFromDate.CustomFormat = " ";
			dtpToDate.Format = DateTimePickerFormat.Custom;
			dtpToDate.CustomFormat = " ";
			cbGroupBy.SelectedIndex = 0;

			(this.Parent.Parent.Parent as Director).FillInSellingPlanGrid();
		}

		private void dtpToDate_ValueChanged(object sender, EventArgs e)
		{
			(sender as DateTimePicker).Format = DateTimePickerFormat.Short;

		}

		private void dtpFromDate_ValueChanged(object sender, EventArgs e)
		{
			(sender as DateTimePicker).Format = DateTimePickerFormat.Short;

		}
	}
}
