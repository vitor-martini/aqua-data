namespace AQUA_DATA
{
    partial class frmAquarioConfiguracao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAquarioConfiguracao));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.grpConfiguracao = new System.Windows.Forms.GroupBox();
            this.btnCaminho = new System.Windows.Forms.Button();
            this.txtCaminhoArquivo = new System.Windows.Forms.TextBox();
            this.lblArquivos = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.grpConfiguracao.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnVoltar.Location = new System.Drawing.Point(306, 107);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(212, 30);
            this.btnVoltar.TabIndex = 7;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // grpConfiguracao
            // 
            this.grpConfiguracao.Controls.Add(this.btnCaminho);
            this.grpConfiguracao.Controls.Add(this.txtCaminhoArquivo);
            this.grpConfiguracao.Controls.Add(this.lblArquivos);
            this.grpConfiguracao.Location = new System.Drawing.Point(12, 12);
            this.grpConfiguracao.Name = "grpConfiguracao";
            this.grpConfiguracao.Size = new System.Drawing.Size(506, 89);
            this.grpConfiguracao.TabIndex = 8;
            this.grpConfiguracao.TabStop = false;
            // 
            // btnCaminho
            // 
            this.btnCaminho.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCaminho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaminho.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCaminho.Location = new System.Drawing.Point(470, 39);
            this.btnCaminho.Name = "btnCaminho";
            this.btnCaminho.Size = new System.Drawing.Size(30, 26);
            this.btnCaminho.TabIndex = 26;
            this.btnCaminho.Text = "...";
            this.btnCaminho.UseVisualStyleBackColor = false;
            this.btnCaminho.Click += new System.EventHandler(this.btnCaminho_Click);
            // 
            // txtCaminhoArquivo
            // 
            this.txtCaminhoArquivo.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCaminhoArquivo.Location = new System.Drawing.Point(6, 39);
            this.txtCaminhoArquivo.Name = "txtCaminhoArquivo";
            this.txtCaminhoArquivo.Size = new System.Drawing.Size(466, 26);
            this.txtCaminhoArquivo.TabIndex = 3;
            // 
            // lblArquivos
            // 
            this.lblArquivos.AutoSize = true;
            this.lblArquivos.BackColor = System.Drawing.Color.Transparent;
            this.lblArquivos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArquivos.Location = new System.Drawing.Point(6, 18);
            this.lblArquivos.Name = "lblArquivos";
            this.lblArquivos.Size = new System.Drawing.Size(145, 18);
            this.lblArquivos.TabIndex = 2;
            this.lblArquivos.Text = "Salvar arquivos em:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnSalvar.Location = new System.Drawing.Point(88, 107);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(212, 30);
            this.btnSalvar.TabIndex = 9;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // frmAquarioConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(207)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(530, 150);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.grpConfiguracao);
            this.Controls.Add(this.btnVoltar);
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAquarioConfiguracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizar";
            this.Load += new System.EventHandler(this.frmAquarioConfiguracao_Load);
            this.grpConfiguracao.ResumeLayout(false);
            this.grpConfiguracao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.GroupBox grpConfiguracao;
        private System.Windows.Forms.TextBox txtCaminhoArquivo;
        private System.Windows.Forms.Label lblArquivos;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCaminho;
    }
}

