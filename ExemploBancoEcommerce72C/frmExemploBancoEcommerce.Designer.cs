namespace ExemploBancoEcommerce72C
{
    partial class frmExemploBancoEcommerce
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
            this.dgvPesquisa = new System.Windows.Forms.DataGridView();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.lblFabricante = new System.Windows.Forms.Label();
            this.cmbFabricante = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisa)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPesquisa
            // 
            this.dgvPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesquisa.Location = new System.Drawing.Point(12, 317);
            this.dgvPesquisa.Name = "dgvPesquisa";
            this.dgvPesquisa.Size = new System.Drawing.Size(776, 225);
            this.dgvPesquisa.TabIndex = 0;
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisa.Location = new System.Drawing.Point(313, 563);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(140, 42);
            this.btnPesquisa.TabIndex = 1;
            this.btnPesquisa.Text = "&Pesquisar";
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // txtSQL
            // 
            this.txtSQL.AllowDrop = true;
            this.txtSQL.Location = new System.Drawing.Point(12, 126);
            this.txtSQL.Multiline = true;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(776, 176);
            this.txtSQL.TabIndex = 2;
            // 
            // lblFabricante
            // 
            this.lblFabricante.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFabricante.Location = new System.Drawing.Point(482, 52);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(115, 30);
            this.lblFabricante.TabIndex = 3;
            this.lblFabricante.Text = "Fabricante";
            this.lblFabricante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbFabricante
            // 
            this.cmbFabricante.FormattingEnabled = true;
            this.cmbFabricante.Location = new System.Drawing.Point(603, 60);
            this.cmbFabricante.Name = "cmbFabricante";
            this.cmbFabricante.Size = new System.Drawing.Size(121, 21);
            this.cmbFabricante.TabIndex = 4;
            this.cmbFabricante.SelectionChangeCommitted += new System.EventHandler(this.cmbFabricante_SelectionChangeCommitted);
            // 
            // frmExemploBancoEcommerce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 617);
            this.Controls.Add(this.cmbFabricante);
            this.Controls.Add(this.lblFabricante);
            this.Controls.Add(this.txtSQL);
            this.Controls.Add(this.btnPesquisa);
            this.Controls.Add(this.dgvPesquisa);
            this.Name = "frmExemploBancoEcommerce";
            this.Text = "&Exemplo Banco Ecommerce";
            this.Activated += new System.EventHandler(this.frmExemploBancoEcommerce_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExemploBancoEcommerce_FormClosing);
            this.Load += new System.EventHandler(this.frmExemploBancoEcommerce_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPesquisa;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.TextBox txtSQL;
        private System.Windows.Forms.Label lblFabricante;
        private System.Windows.Forms.ComboBox cmbFabricante;
    }
}

