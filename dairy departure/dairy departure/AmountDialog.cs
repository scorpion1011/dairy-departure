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
    public partial class AmountDialog : Form
    {
        public AmountDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Supplies.amount = Int32.Parse(textBox1.Text);
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (Int32.TryParse(textBox1.Text, out number) && Int32.Parse(textBox1.Text) > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}
