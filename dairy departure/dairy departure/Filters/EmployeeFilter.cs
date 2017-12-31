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
    public partial class EmployeeFilter : Form
    {
        public EmployeeFilter()
        {
            InitializeComponent();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            (this.Parent.Parent.Parent as Director).FillInEmployeeGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbGroupBy.SelectedIndex = 0;
            (this.Parent.Parent.Parent as Director).FillInEmployeeGrid();
        }
    }
}
