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
	public partial class SupplyStatistic : Form
	{
		public SupplyStatistic()
		{
			InitializeComponent();
			dtpFromDate.CustomFormat = " ";
			dtpToDate.CustomFormat = " ";
		}

		private void btnFilter_Click(object sender, EventArgs e)
		{
			(this.Parent.Parent.Parent as Director).FillInSupplyStatisticGrid();

		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			dtpFromDate.Format = DateTimePickerFormat.Custom;
			dtpFromDate.CustomFormat = " ";
			dtpToDate.Format = DateTimePickerFormat.Custom;
			dtpToDate.CustomFormat = " ";
			cbGroupBy.SelectedIndex = 0;

			(this.Parent.Parent.Parent as Director).FillInSupplyStatisticGrid();
		}

		private void dtpFromDate_ValueChanged(object sender, EventArgs e)
		{
			(sender as DateTimePicker).Format = DateTimePickerFormat.Short;
		}

		private void dtpToDate_ValueChanged(object sender, EventArgs e)
		{
			(sender as DateTimePicker).Format = DateTimePickerFormat.Short;
		}
	}
}
