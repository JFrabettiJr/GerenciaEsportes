namespace SecEsportes.Views
{
    partial class CadCompeticao {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadCompeticao));
            this.tlpCadFuncao = new System.Windows.Forms.TableLayoutPanel();
            this.cboModalidades = new System.Windows.Forms.ComboBox();
            this.txtDtInicio = new System.Windows.Forms.MaskedTextBox();
            this.lblModalidade = new System.Windows.Forms.Label();
            this.lblDataInicio = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.dgvCompeticoes = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboCamposBusca = new System.Windows.Forms.ComboBox();
            this.lblBuscarPor = new System.Windows.Forms.Label();
            this.lblBusca = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new System.Windows.Forms.PictureBox();
            this.btnSalvar = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.PictureBox();
            this.btnExcluir = new System.Windows.Forms.PictureBox();
            this.btnAtualizar = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.PictureBox();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.tlpCadFuncao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompeticoes)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdicionar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalvar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtualizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisar)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpCadFuncao
            // 
            this.tlpCadFuncao.ColumnCount = 3;
            this.tlpCadFuncao.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCadFuncao.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpCadFuncao.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpCadFuncao.Controls.Add(this.cboModalidades, 0, 1);
            this.tlpCadFuncao.Controls.Add(this.txtDtInicio, 0, 1);
            this.tlpCadFuncao.Controls.Add(this.lblModalidade, 2, 0);
            this.tlpCadFuncao.Controls.Add(this.lblDataInicio, 1, 0);
            this.tlpCadFuncao.Controls.Add(this.lblNome, 0, 0);
            this.tlpCadFuncao.Controls.Add(this.txtNome, 0, 1);
            this.tlpCadFuncao.Location = new System.Drawing.Point(10, 59);
            this.tlpCadFuncao.Name = "tlpCadFuncao";
            this.tlpCadFuncao.RowCount = 2;
            this.tlpCadFuncao.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tlpCadFuncao.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpCadFuncao.Size = new System.Drawing.Size(560, 40);
            this.tlpCadFuncao.TabIndex = 0;
            // 
            // cboModalidades
            // 
            this.cboModalidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboModalidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModalidades.FormattingEnabled = true;
            this.cboModalidades.Location = new System.Drawing.Point(395, 17);
            this.cboModalidades.Name = "cboModalidades";
            this.cboModalidades.Size = new System.Drawing.Size(162, 23);
            this.cboModalidades.TabIndex = 10;
            this.cboModalidades.SelectedIndexChanged += new System.EventHandler(this.cboModalidades_SelectedIndexChanged);
            // 
            // txtDtInicio
            // 
            this.txtDtInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDtInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDtInicio.Location = new System.Drawing.Point(283, 17);
            this.txtDtInicio.Mask = "00/00/0000";
            this.txtDtInicio.Name = "txtDtInicio";
            this.txtDtInicio.Size = new System.Drawing.Size(106, 21);
            this.txtDtInicio.TabIndex = 6;
            // 
            // lblModalidade
            // 
            this.lblModalidade.AutoSize = true;
            this.lblModalidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModalidade.Location = new System.Drawing.Point(395, 0);
            this.lblModalidade.Name = "lblModalidade";
            this.lblModalidade.Size = new System.Drawing.Size(73, 14);
            this.lblModalidade.TabIndex = 4;
            this.lblModalidade.Text = "Modalidade";
            // 
            // lblDataInicio
            // 
            this.lblDataInicio.AutoSize = true;
            this.lblDataInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataInicio.Location = new System.Drawing.Point(283, 0);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(82, 14);
            this.lblDataInicio.TabIndex = 1;
            this.lblDataInicio.Text = "Data de início";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(3, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(41, 14);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(3, 17);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(274, 21);
            this.txtNome.TabIndex = 2;
            this.txtNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
            // 
            // dgvCompeticoes
            // 
            this.dgvCompeticoes.AllowUserToAddRows = false;
            this.dgvCompeticoes.AllowUserToDeleteRows = false;
            this.dgvCompeticoes.AllowUserToOrderColumns = true;
            this.dgvCompeticoes.AutoGenerateColumns = false;
            this.dgvCompeticoes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompeticoes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCompeticoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompeticoes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCompeticoes.Location = new System.Drawing.Point(10, 106);
            this.dgvCompeticoes.MultiSelect = false;
            this.dgvCompeticoes.Name = "dgvCompeticoes";
            this.dgvCompeticoes.ReadOnly = true;
            this.dgvCompeticoes.Size = new System.Drawing.Size(560, 256);
            this.dgvCompeticoes.TabIndex = 5;
            this.dgvCompeticoes.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCompeticoes_CellMouseDoubleClick);
            this.dgvCompeticoes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipes_RowEnter);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(50, 375);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(520, 40);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // cboCamposBusca
            // 
            this.cboCamposBusca.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCamposBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCamposBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCamposBusca.FormattingEnabled = true;
            this.cboCamposBusca.Location = new System.Drawing.Point(393, 17);
            this.cboCamposBusca.Name = "cboCamposBusca";
            this.cboCamposBusca.Size = new System.Drawing.Size(124, 23);
            this.cboCamposBusca.TabIndex = 10;
            // 
            // lblBuscarPor
            // 
            this.lblBuscarPor.AutoSize = true;
            this.lblBuscarPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarPor.Location = new System.Drawing.Point(393, 0);
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
            this.txtBusca.Size = new System.Drawing.Size(384, 21);
            this.txtBusca.TabIndex = 2;
            this.txtBusca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusca_KeyDown);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionar.Image")));
            this.btnAdicionar.Location = new System.Drawing.Point(10, 10);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(35, 35);
            this.btnAdicionar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAdicionar.TabIndex = 8;
            this.btnAdicionar.TabStop = false;
            this.btnAdicionar.Tag = "Adicionar competição";
            this.btnAdicionar.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.Location = new System.Drawing.Point(51, 10);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(35, 35);
            this.btnSalvar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSalvar.TabIndex = 9;
            this.btnSalvar.TabStop = false;
            this.btnSalvar.Tag = "Salvar alterações da competição";
            this.btnSalvar.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(92, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(35, 35);
            this.btnCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Tag = "Descartar alterações da competição";
            this.btnCancelar.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.Location = new System.Drawing.Point(133, 10);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(35, 35);
            this.btnExcluir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnExcluir.TabIndex = 11;
            this.btnExcluir.TabStop = false;
            this.btnExcluir.Tag = "Excluir competição";
            this.btnExcluir.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.Image")));
            this.btnAtualizar.Location = new System.Drawing.Point(174, 10);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(35, 35);
            this.btnAtualizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAtualizar.TabIndex = 12;
            this.btnAtualizar.TabStop = false;
            this.btnAtualizar.Tag = "Recarregar competições";
            this.btnAtualizar.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.Location = new System.Drawing.Point(9, 375);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(35, 35);
            this.btnPesquisar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPesquisar.TabIndex = 13;
            this.btnPesquisar.TabStop = false;
            // 
            // CadCompeticao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 421);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgvCompeticoes);
            this.Controls.Add(this.tlpCadFuncao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CadCompeticao";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowInTaskbar = false;
            this.Text = "Cadastro de competições";
            this.Load += new System.EventHandler(this.CadCompeticao_Load);
            this.tlpCadFuncao.ResumeLayout(false);
            this.tlpCadFuncao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompeticoes)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdicionar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalvar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcluir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtualizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCadFuncao;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblDataInicio;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.DataGridView dgvCompeticoes;
        private System.Windows.Forms.Label lblModalidade;
        private System.Windows.Forms.MaskedTextBox txtDtInicio;
        private System.Windows.Forms.ComboBox cboModalidades;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cboCamposBusca;
        private System.Windows.Forms.Label lblBuscarPor;
        private System.Windows.Forms.Label lblBusca;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.PictureBox btnAdicionar;
        private System.Windows.Forms.PictureBox btnSalvar;
        private System.Windows.Forms.PictureBox btnCancelar;
        private System.Windows.Forms.PictureBox btnExcluir;
        private System.Windows.Forms.PictureBox btnAtualizar;
        private System.Windows.Forms.PictureBox btnPesquisar;
        private System.Windows.Forms.ToolTip tooltip;
    }
}