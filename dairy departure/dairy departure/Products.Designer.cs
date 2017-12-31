namespace dairy_departure
{
    partial class Products
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.productDataGridView = new System.Windows.Forms.DataGridView();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dairyDeparture1DataSet = new dairy_departure.DairyDeparture1DataSet();
            this.productTableAdapter = new dairy_departure.DairyDeparture1DataSetTableAdapters.ProductTableAdapter();
            this.tableAdapterManager = new dairy_departure.DairyDeparture1DataSetTableAdapters.TableAdapterManager();
            this.productsForSaleViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productsForSaleViewTableAdapter = new dairy_departure.DairyDeparture1DataSetTableAdapters.ProductsForSaleViewTableAdapter();
            this.iDproductDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameproductDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namemanufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDmanufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.massvolumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dairyDeparture1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsForSaleViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU-ExtB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(152, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Products available:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("PMingLiU-ExtB", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(187, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // productDataGridView
            // 
            this.productDataGridView.AllowUserToAddRows = false;
            this.productDataGridView.AllowUserToDeleteRows = false;
            this.productDataGridView.AutoGenerateColumns = false;
            this.productDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDproductDataGridViewTextBoxColumn,
            this.nameproductDataGridViewTextBoxColumn,
            this.namemanufacturerDataGridViewTextBoxColumn,
            this.iDmanufacturerDataGridViewTextBoxColumn,
            this.massvolumeDataGridViewTextBoxColumn,
            this.fatDataGridViewTextBoxColumn});
            this.productDataGridView.DataSource = this.productsForSaleViewBindingSource;
            this.productDataGridView.Location = new System.Drawing.Point(12, 31);
            this.productDataGridView.MultiSelect = false;
            this.productDataGridView.Name = "productDataGridView";
            this.productDataGridView.ReadOnly = true;
            this.productDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productDataGridView.Size = new System.Drawing.Size(457, 220);
            this.productDataGridView.TabIndex = 4;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.dairyDeparture1DataSet;
            // 
            // dairyDeparture1DataSet
            // 
            this.dairyDeparture1DataSet.DataSetName = "DairyDeparture1DataSet";
            this.dairyDeparture1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Employee_PositionTableAdapter = null;
            this.tableAdapterManager.EmployeeTableAdapter = null;
            this.tableAdapterManager.ManufacturerTableAdapter = null;
            this.tableAdapterManager.PositionTableAdapter = null;
            this.tableAdapterManager.ProductTableAdapter = this.productTableAdapter;
            this.tableAdapterManager.Sales_planTableAdapter = null;
            this.tableAdapterManager.SalesPlan_ProductTableAdapter = null;
            this.tableAdapterManager.SellsTableAdapter = null;
            this.tableAdapterManager.SupplyTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = dairy_departure.DairyDeparture1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // productsForSaleViewBindingSource
            // 
            this.productsForSaleViewBindingSource.DataMember = "ProductsForSaleView";
            this.productsForSaleViewBindingSource.DataSource = this.dairyDeparture1DataSet;
            // 
            // productsForSaleViewTableAdapter
            // 
            this.productsForSaleViewTableAdapter.ClearBeforeFill = true;
            // 
            // iDproductDataGridViewTextBoxColumn
            // 
            this.iDproductDataGridViewTextBoxColumn.DataPropertyName = "ID_product";
            this.iDproductDataGridViewTextBoxColumn.HeaderText = "ID_product";
            this.iDproductDataGridViewTextBoxColumn.Name = "iDproductDataGridViewTextBoxColumn";
            this.iDproductDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDproductDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameproductDataGridViewTextBoxColumn
            // 
            this.nameproductDataGridViewTextBoxColumn.DataPropertyName = "Name_product";
            this.nameproductDataGridViewTextBoxColumn.HeaderText = "Product";
            this.nameproductDataGridViewTextBoxColumn.Name = "nameproductDataGridViewTextBoxColumn";
            this.nameproductDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // namemanufacturerDataGridViewTextBoxColumn
            // 
            this.namemanufacturerDataGridViewTextBoxColumn.DataPropertyName = "Name_manufacturer";
            this.namemanufacturerDataGridViewTextBoxColumn.HeaderText = "Manufacturer";
            this.namemanufacturerDataGridViewTextBoxColumn.Name = "namemanufacturerDataGridViewTextBoxColumn";
            this.namemanufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iDmanufacturerDataGridViewTextBoxColumn
            // 
            this.iDmanufacturerDataGridViewTextBoxColumn.DataPropertyName = "ID_manufacturer";
            this.iDmanufacturerDataGridViewTextBoxColumn.HeaderText = "ID_manufacturer";
            this.iDmanufacturerDataGridViewTextBoxColumn.Name = "iDmanufacturerDataGridViewTextBoxColumn";
            this.iDmanufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDmanufacturerDataGridViewTextBoxColumn.Visible = false;
            // 
            // massvolumeDataGridViewTextBoxColumn
            // 
            this.massvolumeDataGridViewTextBoxColumn.DataPropertyName = "Mass/volume";
            this.massvolumeDataGridViewTextBoxColumn.HeaderText = "Mass/volume";
            this.massvolumeDataGridViewTextBoxColumn.Name = "massvolumeDataGridViewTextBoxColumn";
            this.massvolumeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fatDataGridViewTextBoxColumn
            // 
            this.fatDataGridViewTextBoxColumn.DataPropertyName = "%-fat";
            this.fatDataGridViewTextBoxColumn.HeaderText = "%-fat";
            this.fatDataGridViewTextBoxColumn.Name = "fatDataGridViewTextBoxColumn";
            this.fatDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 292);
            this.Controls.Add(this.productDataGridView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Products";
            this.Text = "Products";
            this.Load += new System.EventHandler(this.Products_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dairyDeparture1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsForSaleViewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DairyDeparture1DataSet dairyDeparture1DataSet;
        private System.Windows.Forms.BindingSource productBindingSource;
        private DairyDeparture1DataSetTableAdapters.ProductTableAdapter productTableAdapter;
        private DairyDeparture1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView productDataGridView;
        private System.Windows.Forms.BindingSource productsForSaleViewBindingSource;
        private DairyDeparture1DataSetTableAdapters.ProductsForSaleViewTableAdapter productsForSaleViewTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDproductDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameproductDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namemanufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDmanufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn massvolumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fatDataGridViewTextBoxColumn;
    }
}