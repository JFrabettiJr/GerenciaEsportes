namespace SecEsportes.Views
{
    partial class InsertEquipe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertEquipe));
            this.btnInserir = new System.Windows.Forms.Button();
            this.dgvEquipes = new System.Windows.Forms.DataGridView();
            this.btnDesmarcarTudo = new System.Windows.Forms.Button();
            this.btnMarcarTudo = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboCamposBusca = new System.Windows.Forms.ComboBox();
            this.lblBuscarPor = new System.Windows.Forms.Label();
            this.lblBusca = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipes)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(10, 10);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(410, 23);
            this.btnInserir.TabIndex = 2;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // dgvEquipes
            // 
            this.dgvEquipes.AllowUserToAddRows = false;
            this.dgvEquipes.AllowUserToDeleteRows = false;
            this.dgvEquipes.AllowUserToOrderColumns = true;
            this.dgvEquipes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvEquipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipes.Location = new System.Drawing.Point(10, 39);
            this.dgvEquipes.MultiSelect = false;
            this.dgvEquipes.Name = "dgvEquipes";
            this.dgvEquipes.Size = new System.Drawing.Size(410, 300);
            this.dgvEquipes.TabIndex = 5;
            // 
            // btnDesmarcarTudo
            // 
            this.btnDesmarcarTudo.Location = new System.Drawing.Point(107, 391);
            this.btnDesmarcarTudo.Name = "btnDesmarcarTudo";
            this.btnDesmarcarTudo.Size = new System.Drawing.Size(91, 23);
            this.btnDesmarcarTudo.TabIndex = 9;
            this.btnDesmarcarTudo.Text = "Desmarcar tudo";
            this.btnDesmarcarTudo.UseVisualStyleBackColor = true;
            this.btnDesmarcarTudo.Click += new System.EventHandler(this.btnDesmarcarTudo_Click);
            // 
            // btnMarcarTudo
            // 
            this.btnMarcarTudo.Location = new System.Drawing.Point(10, 391);
            this.btnMarcarTudo.Name = "btnMarcarTudo";
            this.btnMarcarTudo.Size = new System.Drawing.Size(91, 23);
            this.btnMarcarTudo.TabIndex = 8;
            this.btnMarcarTudo.Text = "Marcar tudo";
            this.btnMarcarTudo.UseVisualStyleBackColor = true;
            this.btnMarcarTudo.Click += new System.EventHandler(this.btnMarcarTudo_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.cboCamposBusca, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBuscarPor, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBusca, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBusca, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 346);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(410, 40);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // cboCamposBusca
            // 
            this.cboCamposBusca.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCamposBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCamposBusca.FormattingEnabled = true;
            this.cboCamposBusca.Location = new System.Drawing.Point(310, 17);
            this.cboCamposBusca.Name = "cboCamposBusca";
            this.cboCamposBusca.Size = new System.Drawing.Size(97, 21);
            this.cboCamposBusca.TabIndex = 10;
            // 
            // lblBuscarPor
            // 
            this.lblBuscarPor.AutoSize = true;
            this.lblBuscarPor.Location = new System.Drawing.Point(310, 0);
            this.lblBuscarPor.Name = "lblBuscarPor";
            this.lblBuscarPor.Size = new System.Drawing.Size(58, 13);
            this.lblBuscarPor.TabIndex = 4;
            this.lblBuscarPor.Text = "Buscar por";
            // 
            // lblBusca
            // 
            this.lblBusca.AutoSize = true;
            this.lblBusca.Location = new System.Drawing.Point(3, 0);
            this.lblBusca.Name = "lblBusca";
            this.lblBusca.Size = new System.Drawing.Size(40, 13);
            this.lblBusca.TabIndex = 0;
            this.lblBusca.Text = "Buscar";
            // 
            // txtBusca
            // 
            this.txtBusca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBusca.Location = new System.Drawing.Point(3, 17);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(301, 20);
            this.txtBusca.TabIndex = 2;
            this.txtBusca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusca_KeyDown);
            // 
            // InsertEquipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 421);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnDesmarcarTudo);
            this.Controls.Add(this.btnMarcarTudo);
            this.Controls.Add(this.dgvEquipes);
            this.Controls.Add(this.btnInserir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InsertEquipe";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowInTaskbar = false;
            this.Text = "Inserir equipes na competição";
            this.Load += new System.EventHandler(this.InsertEquipe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipes)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.DataGridView dgvEquipes;
        private System.Windows.Forms.Button btnDesmarcarTudo;
        private System.Windows.Forms.Button btnMarcarTudo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cboCamposBusca;
        private System.Windows.Forms.Label lblBuscarPor;
        private System.Windows.Forms.Label lblBusca;
        private System.Windows.Forms.TextBox txtBusca;
    }
}