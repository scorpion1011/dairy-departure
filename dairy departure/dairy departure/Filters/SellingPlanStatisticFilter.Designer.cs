namespace dairy_departure.Filters
{
	partial class SellingPlanStatisticFilter
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnClear = new System.Windows.Forms.Button();
			this.btnFilter = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.from = new System.Windows.Forms.TextBox();
			this.to = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnClear
			// 
			this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClear.Location = new System.Drawing.Point(613, 4);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 15;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnFilter
			// 
			this.btnFilter.Location = new System.Drawing.Point(523, 4);
			this.btnFilter.Name = "btnFilter";
			this.btnFilter.Size = new System.Drawing.Size(75, 23);
			this.btnFilter.TabIndex = 14;
			this.btnFilter.Text = "Filter";
			this.btnFilter.UseVisualStyleBackColor = true;
			this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "% From";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(164, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(20, 13);
			this.label2.TabIndex = 17;
			this.label2.Text = "To";
			// 
			// from
			// 
			this.from.Location = new System.Drawing.Point(67, 5);
			this.from.Name = "from";
			this.from.Size = new System.Drawing.Size(83, 20);
			this.from.TabIndex = 18;
			// 
			// to
			// 
			this.to.Location = new System.Drawing.Point(198, 5);
			this.to.Name = "to";
			this.to.Size = new System.Drawing.Size(83, 20);
			this.to.TabIndex = 19;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(295, 7);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(80, 17);
			this.checkBox1.TabIndex = 20;
			this.checkBox1.Text = "Actual Only";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(389, 7);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(116, 17);
			this.checkBox2.TabIndex = 21;
			this.checkBox2.Text = "Exclude completed";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// SellingPlanStatisticFilter
			// 
			this.AcceptButton = this.btnFilter;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClear;
			this.ClientSize = new System.Drawing.Size(697, 30);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.to);
			this.Controls.Add(this.from);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnFilter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SellingPlanStatisticFilter";
			this.Text = "SellingPlanStatisticFilter";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnFilter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox from;
		private System.Windows.Forms.TextBox to;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
	}
}