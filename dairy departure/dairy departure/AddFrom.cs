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
	public partial class AddFrom : Form
	{
		public Director parent;
		public List<string> columns;
		public int Y = 10;
		public Dictionary<string, TextBox> dictionary = new Dictionary<string, TextBox>();

		public AddFrom(Director parent, List<string> columns)
		{
			this.parent = parent;
			this.columns = columns;
			InitializeComponent();

			foreach(string column in columns)
			{
				Label newlabel = new Label();
				TextBox newTextBox = new TextBox();
				newlabel.Location = new Point(10, Y);
				newTextBox.Location = new Point(100 + newlabel.Width, Y);
				newTextBox.Width = 300;
				newlabel.Text = column;
				newlabel.AutoSize = true;
				dictionary.Add(column, newTextBox);
				this.Controls.Add(newlabel);
				this.Controls.Add(newTextBox);
				Y += 40;
			}
			Button saveButton = new Button();
			saveButton.Location = new Point(350, Y);
			saveButton.Text = "Save";

			saveButton.Click += (s, e) =>
			{
				int i = 0;
				((DataGridView)(this.parent.Controls["dataGridView1"])).Rows.Add();
				foreach (string column in columns)
				{
					((DataGridView)(this.parent.Controls["dataGridView1"])).Rows[((DataGridView)(this.parent.Controls["dataGridView1"])).Rows.Count-1].Cells[i].Value = dictionary[column].Text;
				}

			};

				Button cancelButton = new Button();
			cancelButton.Location = new Point(50, Y);
			cancelButton.Text = "Cancel";
			this.Controls.Add(saveButton);
			this.Controls.Add(cancelButton);
		}


	}
}
