namespace SecEsportes.Views
{
    partial class InsertArbitro
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertArbitro));
            this.dgvArbitros = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboCamposBusca = new System.Windows.Forms.ComboBox();
            this.lblBuscarPor = new System.Windows.Forms.Label();
            this.lblBusca = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.btnDesmarcarTudo = new System.Windows.Forms.PictureBox();
            this.btnMarcarTudo = new System.Windows.Forms.PictureBox();
            this.btnInserir = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArbitros)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDesmarcarTudo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMarcarTudo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInserir)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArbitros
            // 
            this.dgvArbitros.AllowUserToAddRows = false;
            this.dgvArbitros.AllowUserToDeleteRows = false;
            this.dgvArbitros.AllowUserToOrderColumns = true;
            this.dgvArbitros.AutoGenerateColumns = false;
            this.dgvArbitros.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArbitros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArbitros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArbitros.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvArbitros.Location = new System.Drawing.Point(10, 51);
            this.dgvArbitros.MultiSelect = false;
            this.dgvArbitros.Name = "dgvArbitros";
            this.dgvArbitros.Size = new System.Drawing.Size(410, 317);
            this.dgvArbitros.TabIndex = 5;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 374);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(410, 40);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // cboCamposBusca
            // 
            this.cboCamposBusca.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCamposBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCamposBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCamposBusca.FormattingEnabled = true;
            this.cboCamposBusca.Location = new System.Drawing.Point(310, 17);
            this.cboCamposBusca.Name = "cboCamposBusca";
            this.cboCamposBusca.Size = new System.Drawing.Size(97, 23);
            this.cboCamposBusca.TabIndex = 10;
            // 
            // lblBuscarPor
            // 
            this.lblBuscarPor.AutoSize = true;
            this.lblBuscarPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarPor.Location = new System.Drawing.Point(310, 0);
            this.lblBuscarPor.Name = "lblBuscarPor";
            this.lblBuscarPor.Size = new System.Drawing.Size(66, 14);
            this.lblBuscarPor.TabIndex = 4;
            this.lblBuscarPor.Text = "Buscar por";
            // 
            // lblBusca
            // 
            this.lblBusca.AutoSize = true;
            this.lblBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusca.Location = new System.Drawing.Point(3, 0);
            this.lblBusca.Name = "lblBusca";
            this.lblBusca.Size = new System.Drawing.Size(45, 14);
            this.lblBusca.TabIndex = 0;
            this.lblBusca.Text = "Buscar";
            // 
            // txtBusca
            // 
            this.txtBusca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusca.Location = new System.Drawing.Point(3, 17);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(301, 21);
            this.txtBusca.TabIndex = 2;
            this.txtBusca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusca_KeyDown);
            // 
            // btnDesmarcarTudo
            // 
            this.btnDesmarcarTudo.Image = global::SecEsportes.Properties.Resources.desmarcar_tudo;
            this.btnDesmarcarTudo.Location = new System.Drawing.Point(51, 10);
            this.btnDesmarcarTudo.Name = "btnDesmarcarTudo";
            this.btnDesmarcarTudo.Size = new System.Drawing.Size(35, 35);
            this.btnDesmarcarTudo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDesmarcarTudo.TabIndex = 21;
            this.btnDesmarcarTudo.TabStop = false;
            this.btnDesmarcarTudo.Tag = "Desmarcar todos os árbitros";
            this.btnDesmarcarTudo.Click += new System.EventHandler(this.btnDesmarcarTudo_Click);
            // 
            // btnMarcarTudo
            // 
            this.btnMarcarTudo.Image = global::SecEsportes.Properties.Resources.marcar_tudo;
            this.btnMarcarTudo.Location = new System.Drawing.Point(10, 10);
            this.btnMarcarTudo.Name = "btnMarcarTudo";
            this.btnMarcarTudo.Size = new System.Drawing.Size(35, 35);
            this.btnMarcarTudo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMarcarTudo.TabIndex = 20;
            this.btnMarcarTudo.TabStop = false;
            this.btnMarcarTudo.Tag = "Marcar todos os árbitros";
            this.btnMarcarTudo.Click += new System.EventHandler(this.btnMarcarTudo_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Image = global::SecEsportes.Properties.Resources.crud_salvar;
            this.btnInserir.Location = new System.Drawing.Point(385, 10);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(35, 35);
            this.btnInserir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnInserir.TabIndex = 22;
            this.btnInserir.TabStop = false;
            this.btnInserir.Tag = "Inserir todos os árbitros selecionados";
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // InsertArbitro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 421);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.btnDesmarcarTudo);
            this.Controls.Add(this.btnMarcarTudo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgvArbitros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InsertArbitro";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowInTaskbar = false;
            this.Text = "Inserir árbitros na competição";
            this.Load += new System.EventHandler(this.InsertArbitro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArbitros)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDesmarcarTudo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMarcarTudo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInserir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvArbitros;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cboCamposBusca;
        private System.Windows.Forms.Label lblBuscarPor;
        private System.Windows.Forms.Label lblBusca;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.PictureBox btnDesmarcarTudo;
        private System.Windows.Forms.PictureBox btnMarcarTudo;
        private System.Windows.Forms.PictureBox btnInserir;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}