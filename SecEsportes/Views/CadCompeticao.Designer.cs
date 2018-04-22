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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadCompeticao));
            this.tlpCadFuncao = new System.Windows.Forms.TableLayoutPanel();
            this.cboModalidades = new System.Windows.Forms.ComboBox();
            this.txtDtInicio = new System.Windows.Forms.MaskedTextBox();
            this.lblModalidade = new System.Windows.Forms.Label();
            this.lblDataInicio = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.dgvCompeticoes = new System.Windows.Forms.DataGridView();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.tlpCadFuncao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompeticoes)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpCadFuncao
            // 
            this.tlpCadFuncao.ColumnCount = 3;
            this.tlpCadFuncao.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCadFuncao.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpCadFuncao.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpCadFuncao.Controls.Add(this.cboModalidades, 0, 1);
            this.tlpCadFuncao.Controls.Add(this.txtDtInicio, 0, 1);
            this.tlpCadFuncao.Controls.Add(this.lblModalidade, 2, 0);
            this.tlpCadFuncao.Controls.Add(this.lblDataInicio, 1, 0);
            this.tlpCadFuncao.Controls.Add(this.lblNome, 0, 0);
            this.tlpCadFuncao.Controls.Add(this.txtNome, 0, 1);
            this.tlpCadFuncao.Location = new System.Drawing.Point(10, 47);
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
            this.cboModalidades.FormattingEnabled = true;
            this.cboModalidades.Location = new System.Drawing.Point(367, 17);
            this.cboModalidades.Name = "cboModalidades";
            this.cboModalidades.Size = new System.Drawing.Size(190, 21);
            this.cboModalidades.TabIndex = 10;
            this.cboModalidades.SelectedIndexChanged += new System.EventHandler(this.cboModalidades_SelectedIndexChanged);
            // 
            // txtDtInicio
            // 
            this.txtDtInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDtInicio.Location = new System.Drawing.Point(283, 17);
            this.txtDtInicio.Mask = "00/00/0000";
            this.txtDtInicio.Name = "txtDtInicio";
            this.txtDtInicio.Size = new System.Drawing.Size(78, 20);
            this.txtDtInicio.TabIndex = 6;
            // 
            // lblModalidade
            // 
            this.lblModalidade.AutoSize = true;
            this.lblModalidade.Location = new System.Drawing.Point(367, 0);
            this.lblModalidade.Name = "lblModalidade";
            this.lblModalidade.Size = new System.Drawing.Size(62, 13);
            this.lblModalidade.TabIndex = 4;
            this.lblModalidade.Text = "Modalidade";
            // 
            // lblDataInicio
            // 
            this.lblDataInicio.AutoSize = true;
            this.lblDataInicio.Location = new System.Drawing.Point(283, 0);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(74, 13);
            this.lblDataInicio.TabIndex = 1;
            this.lblDataInicio.Text = "Data de início";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(3, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNome.Location = new System.Drawing.Point(3, 17);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(274, 20);
            this.txtNome.TabIndex = 2;
            this.txtNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(91, 10);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(10, 10);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 2;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(172, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(253, 10);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 4;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // dgvCompeticoes
            // 
            this.dgvCompeticoes.AllowUserToAddRows = false;
            this.dgvCompeticoes.AllowUserToDeleteRows = false;
            this.dgvCompeticoes.AllowUserToOrderColumns = true;
            this.dgvCompeticoes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvCompeticoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompeticoes.Location = new System.Drawing.Point(10, 102);
            this.dgvCompeticoes.MultiSelect = false;
            this.dgvCompeticoes.Name = "dgvCompeticoes";
            this.dgvCompeticoes.ReadOnly = true;
            this.dgvCompeticoes.Size = new System.Drawing.Size(560, 300);
            this.dgvCompeticoes.TabIndex = 5;
            this.dgvCompeticoes.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCompeticoes_CellMouseDoubleClick);
            this.dgvCompeticoes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipes_RowEnter);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(334, 10);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 6;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // CadCompeticao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 421);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.dgvCompeticoes);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.tlpCadFuncao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CadCompeticao";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Cadastro de competições";
            this.tlpCadFuncao.ResumeLayout(false);
            this.tlpCadFuncao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompeticoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCadFuncao;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblDataInicio;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.DataGridView dgvCompeticoes;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label lblModalidade;
        private System.Windows.Forms.MaskedTextBox txtDtInicio;
        private System.Windows.Forms.ComboBox cboModalidades;
    }
}