namespace dairy_departure.Filters
{
	partial class SupplyStatistic
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
			this.dtpToDate = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
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
			// cbGroupBy
			// 
			this.cbGroupBy.FormattingEnabled = true;
			this.cbGroupBy.Items.AddRange(new object[] {
            "",
            "Manufacturer",
            "Product",
            "Employer"});
			this.cbGroupBy.Location = new System.Drawing.Point(387, 5);
			this.cbGroupBy.Name = "cbGroupBy";
			this.cbGroupBy.Size = new System.Drawing.Size(121, 21);
			this.cbGroupBy.TabIndex = 13;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(322, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "Group by";
			// 
			// dtpToDate
			// 
			this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpToDate.Location = new System.Drawing.Point(217, 5);
			this.dtpToDate.Name = "dtpToDate";
			this.dtpToDate.Size = new System.Drawing.Size(90, 20);
			this.dtpToDate.TabIndex = 11;
			this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(177, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "and";
			// 
			// dtpFromDate
			// 
			this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFromDate.Location = new System.Drawing.Point(72, 5);
			this.dtpFromDate.Name = "dtpFromDate";
			this.dtpFromDate.Size = new System.Drawing.Size(90, 20);
			this.dtpFromDate.TabIndex = 9;
			this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Between";
			// 
			// SupplyStatistic
			// 
			this.AcceptButton = this.btnFilter;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClear;
			this.ClientSize = new System.Drawing.Size(697, 30);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnFilter);
			this.Controls.Add(this.cbGroupBy);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dtpToDate);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dtpFromDate);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SupplyStatistic";
			this.Text = "SupplyStatistic";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnFilter;
		private System.Windows.Forms.ComboBox cbGroupBy;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dtpToDate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpFromDate;
		private System.Windows.Forms.Label label1;
	}
}