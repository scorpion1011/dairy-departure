namespace dairy_departure
{
    partial class Storekeeper
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prod_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Volume_Mass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID_pr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add_all_but = new System.Windows.Forms.Button();
            this.add_supply_but = new System.Windows.Forms.Button();
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
            this.menuStrip1.Size = new System.Drawing.Size(789, 24);
            this.menuStrip1.TabIndex = 1;
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Manufacturer,
            this.Prod_name,
            this.proc,
            this.Volume_Mass,
            this.Price,
            this.Amount,
            this.Date,
            this.X,
            this.ID_pr});
            this.dataGridView1.Location = new System.Drawing.Point(3, 108);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(773, 271);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Manufacturer
            // 
            this.Manufacturer.HeaderText = "Manufacturer";
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.ReadOnly = true;
            // 
            // Prod_name
            // 
            this.Prod_name.HeaderText = "Name";
            this.Prod_name.Name = "Prod_name";
            this.Prod_name.ReadOnly = true;
            // 
            // proc
            // 
            this.proc.HeaderText = "%";
            this.proc.Name = "proc";
            this.proc.ReadOnly = true;
            // 
            // Volume_Mass
            // 
            this.Volume_Mass.HeaderText = "Volume/Mass";
            this.Volume_Mass.Name = "Volume_Mass";
            this.Volume_Mass.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // X
            // 
            this.X.DataPropertyName = "Name_product";
            this.X.HeaderText = "";
            this.X.Name = "X";
            this.X.ReadOnly = true;
            this.X.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.X.Text = "X";
            this.X.Width = 25;
            // 
            // ID_pr
            // 
            this.ID_pr.DataPropertyName = "ID_product";
            this.ID_pr.HeaderText = "ID_pr";
            this.ID_pr.Name = "ID_pr";
            this.ID_pr.ReadOnly = true;
            this.ID_pr.Visible = false;
            // 
            // add_all_but
            // 
            this.add_all_but.Enabled = false;
            this.add_all_but.Location = new System.Drawing.Point(660, 27);
            this.add_all_but.Name = "add_all_but";
            this.add_all_but.Size = new System.Drawing.Size(116, 75);
            this.add_all_but.TabIndex = 3;
            this.add_all_but.Text = "Save all in DataBase";
            this.add_all_but.UseVisualStyleBackColor = true;
            this.add_all_but.Click += new System.EventHandler(this.add_all_but_Click);
            // 
            // add_supply_but
            // 
            this.add_supply_but.Location = new System.Drawing.Point(3, 27);
            this.add_supply_but.Name = "add_supply_but";
            this.add_supply_but.Size = new System.Drawing.Size(120, 75);
            this.add_supply_but.TabIndex = 4;
            this.add_supply_but.Text = "Add supply";
            this.add_supply_but.UseVisualStyleBackColor = true;
            this.add_supply_but.Click += new System.EventHandler(this.add_supply_but_Click);
            // 
            // Storekeeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.add_supply_but);
            this.Controls.Add(this.add_all_but);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Storekeeper";
            this.Size = new System.Drawing.Size(789, 382);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button add_all_but;
        private System.Windows.Forms.Button add_supply_but;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prod_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn proc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Volume_Mass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewButtonColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_pr;
    }
}
