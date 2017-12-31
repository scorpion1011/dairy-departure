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
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView1 = (this.Parent.Parent.Parent as Director).Controls.Find("dataGridView1", true)[0] as DataGridView;
            int startPos = dataGridView1.SelectedRows[0].Index;
            string searchValue = tbSearch.Text.Trim().ToLower();

            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i-- )
            {
                DataGridViewRow row = dataGridView1.Rows[i];

                if (row.Index < startPos)
                {
                    foreach (DataGridViewCell cel in row.Cells)
                    {
                        if (cel.Value.ToString().Trim().ToLower().Contains(searchValue))
                        {
                            row.Selected = true;
                            return;
                        }
                    }
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView1 = (this.Parent.Parent.Parent as Director).Controls.Find("dataGridView1", true)[0] as DataGridView;
            int startPos = dataGridView1.SelectedRows[0].Index;
            string searchValue = tbSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index > startPos)
                {
                    foreach (DataGridViewCell cel in row.Cells)
                    {
                        if (cel.Value.ToString().Trim().ToLower().Contains(searchValue))
                        {
                            row.Selected = true;
                            return;
                        }
                    }
                }
            }
        }
    }
}
