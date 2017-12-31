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
    public partial class PositionFilter : Form
    {
        public PositionFilter()
        {
            InitializeComponent();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            (this.Parent.Parent.Parent as Director).FillInPositionGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            (this.Parent.Parent.Parent as Director).FillInPositionGrid();
        }
    }
}
