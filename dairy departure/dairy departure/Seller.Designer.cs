namespace dairy_departure
{
    partial class Seller
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.button1 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.button2 = new System.Windows.Forms.Button();
			this.Manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnDel = new System.Windows.Forms.DataGridViewButtonColumn();
			this.ID_product = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ID_supplies = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Rest = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.price_for_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(640, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(57, 20);
			this.toolStripMenuItem1.Text = "Logout";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(4, 28);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 66);
			this.button1.TabIndex = 1;
			this.button1.Text = "Add new";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Manufacturer,
            this.Product,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3,
            this.btnDel,
            this.ID_product,
            this.ID_supplies,
            this.Rest,
            this.price_for_1});
			this.dataGridView1.Location = new System.Drawing.Point(4, 101);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(630, 278);
			this.dataGridView1.TabIndex = 2;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
			this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(538, 29);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 66);
			this.button2.TabIndex = 3;
			this.button2.Text = "Confirm";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// Manufacturer
			// 
			this.Manufacturer.Frozen = true;
			this.Manufacturer.HeaderText = "Manufacturer";
			this.Manufacturer.Name = "Manufacturer";
			this.Manufacturer.ReadOnly = true;
			// 
			// Product
			// 
			this.Product.Frozen = true;
			this.Product.HeaderText = "Name";
			this.Product.Name = "Product";
			this.Product.ReadOnly = true;
			// 
			// Column1
			// 
			this.Column1.Frozen = true;
			this.Column1.HeaderText = "%";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 75;
			// 
			// Column2
			// 
			this.Column2.Frozen = true;
			this.Column2.HeaderText = "Weight/volume";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			// 
			// Column4
			// 
			this.Column4.HeaderText = "Amount";
			this.Column4.Name = "Column4";
			this.Column4.Width = 75;
			// 
			// Column3
			// 
			this.Column3.HeaderText = "Price";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 75;
			// 
			// btnDel
			// 
			this.btnDel.HeaderText = "";
			this.btnDel.Name = "btnDel";
			this.btnDel.ReadOnly = true;
			this.btnDel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.btnDel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.btnDel.Text = "X";
			this.btnDel.UseColumnTextForButtonValue = true;
			this.btnDel.Width = 25;
			// 
			// ID_product
			// 
			this.ID_product.HeaderText = "id_p";
			this.ID_product.Name = "ID_product";
			this.ID_product.Visible = false;
			// 
			// ID_supplies
			// 
			this.ID_supplies.HeaderText = "id_s";
			this.ID_supplies.Name = "ID_supplies";
			this.ID_supplies.Visible = false;
			// 
			// Rest
			// 
			this.Rest.HeaderText = "left";
			this.Rest.Name = "Rest";
			this.Rest.Visible = false;
			// 
			// price_for_1
			// 
			this.price_for_1.HeaderText = "price_for_1";
			this.price_for_1.Name = "price_for_1";
			this.price_for_1.Visible = false;
			// 
			// Seller
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.button2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "Seller";
			this.Size = new System.Drawing.Size(640, 387);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Manufacturer;
		private System.Windows.Forms.DataGridViewTextBoxColumn Product;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewButtonColumn btnDel;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID_product;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID_supplies;
		private System.Windows.Forms.DataGridViewTextBoxColumn Rest;
		private System.Windows.Forms.DataGridViewTextBoxColumn price_for_1;
	}
}
