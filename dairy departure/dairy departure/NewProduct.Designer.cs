namespace dairy_departure
{
    partial class NewProduct
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
            System.Windows.Forms.Label name_productLabel;
            System.Windows.Forms.Label iD_manufacturerLabel;
            System.Windows.Forms.Label mass_volumeLabel;
            System.Windows.Forms.Label ___fatLabel;
            System.Windows.Forms.Label shelfLifeLabel;
            this.dairyDeparture1DataSet = new dairy_departure.DairyDeparture1DataSet();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productTableAdapter = new dairy_departure.DairyDeparture1DataSetTableAdapters.ProductTableAdapter();
            this.tableAdapterManager = new dairy_departure.DairyDeparture1DataSetTableAdapters.TableAdapterManager();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.manufacturerЗапросBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.manufacturer_ЗапросTableAdapter = new dairy_departure.DairyDeparture1DataSetTableAdapters.Manufacturer_ЗапросTableAdapter();
            name_productLabel = new System.Windows.Forms.Label();
            iD_manufacturerLabel = new System.Windows.Forms.Label();
            mass_volumeLabel = new System.Windows.Forms.Label();
            ___fatLabel = new System.Windows.Forms.Label();
            shelfLifeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dairyDeparture1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturerЗапросBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // name_productLabel
            // 
            name_productLabel.AutoSize = true;
            name_productLabel.Location = new System.Drawing.Point(13, 17);
            name_productLabel.Name = "name_productLabel";
            name_productLabel.Size = new System.Drawing.Size(77, 13);
            name_productLabel.TabIndex = 3;
            name_productLabel.Text = "Name product:";
            // 
            // iD_manufacturerLabel
            // 
            iD_manufacturerLabel.AutoSize = true;
            iD_manufacturerLabel.Location = new System.Drawing.Point(13, 43);
            iD_manufacturerLabel.Name = "iD_manufacturerLabel";
            iD_manufacturerLabel.Size = new System.Drawing.Size(73, 13);
            iD_manufacturerLabel.TabIndex = 5;
            iD_manufacturerLabel.Text = "Manufacturer:";
            // 
            // mass_volumeLabel
            // 
            mass_volumeLabel.AutoSize = true;
            mass_volumeLabel.Location = new System.Drawing.Point(13, 69);
            mass_volumeLabel.Name = "mass_volumeLabel";
            mass_volumeLabel.Size = new System.Drawing.Size(74, 13);
            mass_volumeLabel.TabIndex = 7;
            mass_volumeLabel.Text = "Mass/volume:";
            // 
            // ___fatLabel
            // 
            ___fatLabel.AutoSize = true;
            ___fatLabel.Location = new System.Drawing.Point(13, 95);
            ___fatLabel.Name = "___fatLabel";
            ___fatLabel.Size = new System.Drawing.Size(33, 13);
            ___fatLabel.TabIndex = 9;
            ___fatLabel.Text = "%-fat:";
            // 
            // shelfLifeLabel
            // 
            shelfLifeLabel.AutoSize = true;
            shelfLifeLabel.Location = new System.Drawing.Point(13, 121);
            shelfLifeLabel.Name = "shelfLifeLabel";
            shelfLifeLabel.Size = new System.Drawing.Size(54, 13);
            shelfLifeLabel.TabIndex = 11;
            shelfLifeLabel.Text = "Shelf Life:";
            // 
            // dairyDeparture1DataSet
            // 
            this.dairyDeparture1DataSet.DataSetName = "DairyDeparture1DataSet";
            this.dairyDeparture1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.dairyDeparture1DataSet;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Add product";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 37);
            this.button2.TabIndex = 14;
            this.button2.Text = "Add new manufacturer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(105, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 15;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(105, 66);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 17;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(105, 92);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 18;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(105, 118);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 19;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.manufacturerЗапросBindingSource;
            this.comboBox1.DisplayMember = "Info";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(105, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 20;
            // 
            // manufacturerЗапросBindingSource
            // 
            this.manufacturerЗапросBindingSource.DataMember = "Manufacturer Запрос";
            this.manufacturerЗапросBindingSource.DataSource = this.dairyDeparture1DataSet;
            // 
            // manufacturer_ЗапросTableAdapter
            // 
            this.manufacturer_ЗапросTableAdapter.ClearBeforeFill = true;
            // 
            // NewProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 193);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(name_productLabel);
            this.Controls.Add(iD_manufacturerLabel);
            this.Controls.Add(mass_volumeLabel);
            this.Controls.Add(___fatLabel);
            this.Controls.Add(shelfLifeLabel);
            this.Name = "NewProduct";
            this.Text = "NewProduct";
            this.Load += new System.EventHandler(this.NewProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dairyDeparture1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturerЗапросBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DairyDeparture1DataSet dairyDeparture1DataSet;
        private System.Windows.Forms.BindingSource productBindingSource;
        private DairyDeparture1DataSetTableAdapters.ProductTableAdapter productTableAdapter;
        private DairyDeparture1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource manufacturerЗапросBindingSource;
        private DairyDeparture1DataSetTableAdapters.Manufacturer_ЗапросTableAdapter manufacturer_ЗапросTableAdapter;
    }
}