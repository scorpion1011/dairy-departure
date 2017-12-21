namespace dairy_departure
{
    partial class AddManufacturer
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
            System.Windows.Forms.Label name_manufacturerLabel;
            System.Windows.Forms.Label countryLabel;
            this.dairyDeparture1DataSet = new dairy_departure.DairyDeparture1DataSet();
            this.manufacturerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.manufacturerTableAdapter = new dairy_departure.DairyDeparture1DataSetTableAdapters.ManufacturerTableAdapter();
            this.tableAdapterManager = new dairy_departure.DairyDeparture1DataSetTableAdapters.TableAdapterManager();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            name_manufacturerLabel = new System.Windows.Forms.Label();
            countryLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dairyDeparture1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dairyDeparture1DataSet
            // 
            this.dairyDeparture1DataSet.DataSetName = "DairyDeparture1DataSet";
            this.dairyDeparture1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // manufacturerBindingSource
            // 
            this.manufacturerBindingSource.DataMember = "Manufacturer";
            this.manufacturerBindingSource.DataSource = this.dairyDeparture1DataSet;
            // 
            // manufacturerTableAdapter
            // 
            this.manufacturerTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Employee_PositionTableAdapter = null;
            this.tableAdapterManager.EmployeeTableAdapter = null;
            this.tableAdapterManager.ManufacturerTableAdapter = this.manufacturerTableAdapter;
            this.tableAdapterManager.PositionTableAdapter = null;
            this.tableAdapterManager.ProductTableAdapter = null;
            this.tableAdapterManager.Sales_planTableAdapter = null;
            this.tableAdapterManager.SalesPlan_ProductTableAdapter = null;
            this.tableAdapterManager.SellsTableAdapter = null;
            this.tableAdapterManager.SupplyTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = dairy_departure.DairyDeparture1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // name_manufacturerLabel
            // 
            name_manufacturerLabel.AutoSize = true;
            name_manufacturerLabel.Location = new System.Drawing.Point(9, 14);
            name_manufacturerLabel.Name = "name_manufacturerLabel";
            name_manufacturerLabel.Size = new System.Drawing.Size(103, 13);
            name_manufacturerLabel.TabIndex = 3;
            name_manufacturerLabel.Text = "Name manufacturer:";
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.Location = new System.Drawing.Point(9, 40);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new System.Drawing.Size(46, 13);
            countryLabel.TabIndex = 5;
            countryLabel.Text = "Country:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 26);
            this.button1.TabIndex = 7;
            this.button1.Text = "Add manufacturer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 16;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(118, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 17;
            // 
            // AddManufacturer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 99);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(name_manufacturerLabel);
            this.Controls.Add(countryLabel);
            this.Name = "AddManufacturer";
            this.Text = "AddManufacturer";
            this.Load += new System.EventHandler(this.AddManufacturer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dairyDeparture1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DairyDeparture1DataSet dairyDeparture1DataSet;
        private System.Windows.Forms.BindingSource manufacturerBindingSource;
        private DairyDeparture1DataSetTableAdapters.ManufacturerTableAdapter manufacturerTableAdapter;
        private DairyDeparture1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}