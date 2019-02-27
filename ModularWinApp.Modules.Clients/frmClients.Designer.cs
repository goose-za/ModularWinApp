namespace ModularWinApp.Modules.Clients
{
    partial class frmClients
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
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.dbOrdersSampleDataSet = new ModularWinApp.Modules.Clients.dbOrdersSampleDataSet();
            this.dbOrdersSampleDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbClientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_ClientsTableAdapter = new ModularWinApp.Modules.Clients.dbOrdersSampleDataSetTableAdapters.tb_ClientsTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfBirthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bthReturnSelectedClients = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbOrdersSampleDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbOrdersSampleDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbClientsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClients
            // 
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.AutoGenerateColumns = false;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.dateOfBirthDataGridViewTextBoxColumn,
            this.foneDataGridViewTextBoxColumn});
            this.dgvClients.DataSource = this.tbClientsBindingSource;
            this.dgvClients.Location = new System.Drawing.Point(13, 13);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.Size = new System.Drawing.Size(555, 381);
            this.dgvClients.TabIndex = 0;
            // 
            // dbOrdersSampleDataSet
            // 
            this.dbOrdersSampleDataSet.DataSetName = "dbOrdersSampleDataSet";
            this.dbOrdersSampleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dbOrdersSampleDataSetBindingSource
            // 
            this.dbOrdersSampleDataSetBindingSource.DataSource = this.dbOrdersSampleDataSet;
            this.dbOrdersSampleDataSetBindingSource.Position = 0;
            // 
            // tbClientsBindingSource
            // 
            this.tbClientsBindingSource.DataMember = "tb_Clients";
            this.tbClientsBindingSource.DataSource = this.dbOrdersSampleDataSet;
            // 
            // tb_ClientsTableAdapter
            // 
            this.tb_ClientsTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateOfBirthDataGridViewTextBoxColumn
            // 
            this.dateOfBirthDataGridViewTextBoxColumn.DataPropertyName = "DateOfBirth";
            this.dateOfBirthDataGridViewTextBoxColumn.HeaderText = "DateOfBirth";
            this.dateOfBirthDataGridViewTextBoxColumn.Name = "dateOfBirthDataGridViewTextBoxColumn";
            this.dateOfBirthDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // foneDataGridViewTextBoxColumn
            // 
            this.foneDataGridViewTextBoxColumn.DataPropertyName = "Fone";
            this.foneDataGridViewTextBoxColumn.HeaderText = "Fone";
            this.foneDataGridViewTextBoxColumn.Name = "foneDataGridViewTextBoxColumn";
            this.foneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bthReturnSelectedClients
            // 
            this.bthReturnSelectedClients.Location = new System.Drawing.Point(434, 400);
            this.bthReturnSelectedClients.Name = "bthReturnSelectedClients";
            this.bthReturnSelectedClients.Size = new System.Drawing.Size(134, 23);
            this.bthReturnSelectedClients.TabIndex = 1;
            this.bthReturnSelectedClients.Text = "Return Selected Clients";
            this.bthReturnSelectedClients.UseVisualStyleBackColor = true;
            this.bthReturnSelectedClients.Click += new System.EventHandler(this.bthReturnSelectedClients_Click);
            // 
            // frmClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 433);
            this.Controls.Add(this.bthReturnSelectedClients);
            this.Controls.Add(this.dgvClients);
            this.Name = "frmClients";
            this.Text = "Clients";
            this.Load += new System.EventHandler(this.frmClients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbOrdersSampleDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbOrdersSampleDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbClientsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.BindingSource dbOrdersSampleDataSetBindingSource;
        private dbOrdersSampleDataSet dbOrdersSampleDataSet;
        private System.Windows.Forms.BindingSource tbClientsBindingSource;
        private dbOrdersSampleDataSetTableAdapters.tb_ClientsTableAdapter tb_ClientsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfBirthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn foneDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button bthReturnSelectedClients;
    }
}