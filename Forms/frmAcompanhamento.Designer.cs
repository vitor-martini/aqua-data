namespace AQUA_DATA
{
    partial class frmAcompanhamento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAcompanhamento));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.grpAcessorio = new System.Windows.Forms.GroupBox();
            this.cboData = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.grdAcompanhamento = new System.Windows.Forms.DataGridView();
            this.lblData = new System.Windows.Forms.Label();
            this.grpAcessorio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAcompanhamento)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnVoltar.Location = new System.Drawing.Point(613, 455);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(212, 30);
            this.btnVoltar.TabIndex = 1;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::AQUA_DATA.Properties.Resources.lapis;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 5;
            // 
            // grpAcessorio
            // 
            this.grpAcessorio.Controls.Add(this.cboData);
            this.grpAcessorio.Controls.Add(this.btnFiltrar);
            this.grpAcessorio.Controls.Add(this.grdAcompanhamento);
            this.grpAcessorio.Controls.Add(this.lblData);
            this.grpAcessorio.Font = new System.Drawing.Font("Arial", 12F);
            this.grpAcessorio.Location = new System.Drawing.Point(12, 12);
            this.grpAcessorio.Name = "grpAcessorio";
            this.grpAcessorio.Size = new System.Drawing.Size(820, 437);
            this.grpAcessorio.TabIndex = 0;
            this.grpAcessorio.TabStop = false;
            // 
            // cboData
            // 
            this.cboData.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboData.Font = new System.Drawing.Font("Arial", 12F);
            this.cboData.FormattingEnabled = true;
            this.cboData.Location = new System.Drawing.Point(6, 40);
            this.cboData.Name = "cboData";
            this.cboData.Size = new System.Drawing.Size(589, 26);
            this.cboData.TabIndex = 0;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnFiltrar.Location = new System.Drawing.Point(601, 36);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(212, 30);
            this.btnFiltrar.TabIndex = 1;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // grdAcompanhamento
            // 
            this.grdAcompanhamento.AllowUserToAddRows = false;
            this.grdAcompanhamento.AllowUserToDeleteRows = false;
            this.grdAcompanhamento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdAcompanhamento.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdAcompanhamento.BackgroundColor = System.Drawing.Color.Silver;
            this.grdAcompanhamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAcompanhamento.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdAcompanhamento.Location = new System.Drawing.Point(6, 72);
            this.grdAcompanhamento.Name = "grdAcompanhamento";
            this.grdAcompanhamento.Size = new System.Drawing.Size(807, 359);
            this.grdAcompanhamento.TabIndex = 2;
            this.grdAcompanhamento.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAcompanhamento_CellDoubleClick);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.BackColor = System.Drawing.Color.Transparent;
            this.lblData.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(6, 19);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(46, 18);
            this.lblData.TabIndex = 0;
            this.lblData.Text = "Data:";
            // 
            // frmAcompanhamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(207)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(838, 497);
            this.Controls.Add(this.grpAcessorio);
            this.Controls.Add(this.btnVoltar);
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAcompanhamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aquário";
            this.Load += new System.EventHandler(this.frmAcompanhamento_Load);
            this.grpAcessorio.ResumeLayout(false);
            this.grpAcessorio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAcompanhamento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.GroupBox grpAcessorio;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView grdAcompanhamento;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.ComboBox cboData;
    }
}

