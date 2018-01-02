namespace dairy_departure.Filters
{
	partial class ProductFilter
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
			this.cbGroupBy = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnClear
			// 
			this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClear.Location = new System.Drawing.Point(564, 4);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 15;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnFilter
			// 
			this.btnFilter.Location = new System.Drawing.Point(474, 4);
			this.btnFilter.Name = "btnFilter";
			this.btnFilter.Size = new System.Drawing.Size(75, 23);
			this.btnFilter.TabIndex = 14;
			this.btnFilter.Text = "Filter";
			this.btnFilter.UseVisualStyleBackColor = true;
			this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
			// 
			// cbGroupBy
			// 
			this.cbGroupBy.FormattingEnabled = true;
			this.cbGroupBy.Items.AddRange(new object[] {
            "",
            "500g",
            "750g",
            "1l"});
			this.cbGroupBy.Location = new System.Drawing.Point(75, 5);
			this.cbGroupBy.Name = "cbGroupBy";
			this.cbGroupBy.Size = new System.Drawing.Size(130, 21);
			this.cbGroupBy.TabIndex = 13;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "Mass:";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "",
            "Romol",
            "Prostokvachino",
            "Giidnortem",
            "Fer Si Khar"});
			this.comboBox1.Location = new System.Drawing.Point(309, 5);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(130, 21);
			this.comboBox1.TabIndex = 17;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(230, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "Manufacturer:";
			// 
			// ProductFilter
			// 
			this.AcceptButton = this.btnFilter;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClear;
			this.ClientSize = new System.Drawing.Size(697, 30);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnFilter);
			this.Controls.Add(this.cbGroupBy);
			this.Controls.Add(this.label3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "ProductFilter";
			this.Text = "ProductFilter";
			this.Load += new System.EventHandler(this.ProductFilter_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnFilter;
		private System.Windows.Forms.ComboBox cbGroupBy;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
	}
}