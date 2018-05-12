namespace SecEsportes.Views
{
    partial class EditEquipe {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditEquipe));
            this.tlpCadFuncao = new System.Windows.Forms.TableLayoutPanel();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.dgvAtletas = new System.Windows.Forms.DataGridView();
            this.btnExcluirAtleta = new System.Windows.Forms.Button();
            this.btnIncluirAtleta = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboRepresentante = new System.Windows.Forms.ComboBox();
            this.cboTreinador = new System.Windows.Forms.ComboBox();
            this.lblTécnico = new System.Windows.Forms.Label();
            this.lblRepresentante = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.tlpCadFuncao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtletas)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpCadFuncao
            // 
            this.tlpCadFuncao.ColumnCount = 2;
            this.tlpCadFuncao.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpCadFuncao.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpCadFuncao.Controls.Add(this.txtNome, 1, 1);
            this.tlpCadFuncao.Controls.Add(this.lblNome, 1, 0);
            this.tlpCadFuncao.Controls.Add(this.label1, 0, 0);
            this.tlpCadFuncao.Controls.Add(this.txtCodigo, 0, 1);
            this.tlpCadFuncao.Location = new System.Drawing.Point(10, 41);
            this.tlpCadFuncao.Name = "tlpCadFuncao";
            this.tlpCadFuncao.RowCount = 2;
            this.tlpCadFuncao.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tlpCadFuncao.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpCadFuncao.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCadFuncao.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCadFuncao.Size = new System.Drawing.Size(560, 40);
            this.tlpCadFuncao.TabIndex = 0;
            // 
            // txtNome
            // 
            this.txtNome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNome.Location = new System.Drawing.Point(115, 17);
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(442, 20);
            this.txtNome.TabIndex = 3;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(115, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCodigo.Location = new System.Drawing.Point(3, 17);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(106, 20);
            this.txtCodigo.TabIndex = 2;
            // 
            // dgvAtletas
            // 
            this.dgvAtletas.AllowUserToAddRows = false;
            this.dgvAtletas.AllowUserToDeleteRows = false;
            this.dgvAtletas.AllowUserToOrderColumns = true;
            this.dgvAtletas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvAtletas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAtletas.Location = new System.Drawing.Point(10, 133);
            this.dgvAtletas.MultiSelect = false;
            this.dgvAtletas.Name = "dgvAtletas";
            this.dgvAtletas.Size = new System.Drawing.Size(560, 275);
            this.dgvAtletas.TabIndex = 5;
            this.dgvAtletas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAtletas_CellEndEdit);
            this.dgvAtletas.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipes_RowEnter);
            this.dgvAtletas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // btnExcluirAtleta
            // 
            this.btnExcluirAtleta.Location = new System.Drawing.Point(447, 12);
            this.btnExcluirAtleta.Name = "btnExcluirAtleta";
            this.btnExcluirAtleta.Size = new System.Drawing.Size(122, 23);
            this.btnExcluirAtleta.TabIndex = 15;
            this.btnExcluirAtleta.Text = "Excluir atleta";
            this.btnExcluirAtleta.UseVisualStyleBackColor = true;
            this.btnExcluirAtleta.Click += new System.EventHandler(this.btnExcluirAtleta_Click);
            // 
            // btnIncluirAtleta
            // 
            this.btnIncluirAtleta.Location = new System.Drawing.Point(319, 12);
            this.btnIncluirAtleta.Name = "btnIncluirAtleta";
            this.btnIncluirAtleta.Size = new System.Drawing.Size(122, 23);
            this.btnIncluirAtleta.TabIndex = 14;
            this.btnIncluirAtleta.Text = "Incluir atletas";
            this.btnIncluirAtleta.UseVisualStyleBackColor = true;
            this.btnIncluirAtleta.Click += new System.EventHandler(this.btnIncluirAtleta_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cboRepresentante, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboTreinador, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTécnico, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblRepresentante, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 87);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(560, 40);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // cboRepresentante
            // 
            this.cboRepresentante.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRepresentante.FormattingEnabled = true;
            this.cboRepresentante.Location = new System.Drawing.Point(3, 17);
            this.cboRepresentante.Name = "cboRepresentante";
            this.cboRepresentante.Size = new System.Drawing.Size(274, 21);
            this.cboRepresentante.TabIndex = 13;
            this.cboRepresentante.SelectedIndexChanged += new System.EventHandler(this.selectedIndexChanged);
            // 
            // cboTreinador
            // 
            this.cboTreinador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTreinador.FormattingEnabled = true;
            this.cboTreinador.Location = new System.Drawing.Point(283, 17);
            this.cboTreinador.Name = "cboTreinador";
            this.cboTreinador.Size = new System.Drawing.Size(274, 21);
            this.cboTreinador.TabIndex = 12;
            this.cboTreinador.SelectedIndexChanged += new System.EventHandler(this.selectedIndexChanged);
            // 
            // lblTécnico
            // 
            this.lblTécnico.AutoSize = true;
            this.lblTécnico.Location = new System.Drawing.Point(283, 0);
            this.lblTécnico.Name = "lblTécnico";
            this.lblTécnico.Size = new System.Drawing.Size(46, 13);
            this.lblTécnico.TabIndex = 1;
            this.lblTécnico.Text = "Técnico";
            // 
            // lblRepresentante
            // 
            this.lblRepresentante.AutoSize = true;
            this.lblRepresentante.Location = new System.Drawing.Point(3, 0);
            this.lblRepresentante.Name = "lblRepresentante";
            this.lblRepresentante.Size = new System.Drawing.Size(77, 13);
            this.lblRepresentante.TabIndex = 0;
            this.lblRepresentante.Text = "Representante";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(173, 12);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 19;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(91, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(10, 12);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 17;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // EditEquipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 421);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnExcluirAtleta);
            this.Controls.Add(this.btnIncluirAtleta);
            this.Controls.Add(this.dgvAtletas);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tlpCadFuncao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditEquipe";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowInTaskbar = false;
            this.Text = "Cadastro de equipes - Inserção de atletas";
            this.Load += new System.EventHandler(this.load);
            this.tlpCadFuncao.ResumeLayout(false);
            this.tlpCadFuncao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtletas)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCadFuncao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.DataGridView dgvAtletas;
        private System.Windows.Forms.Button btnExcluirAtleta;
        private System.Windows.Forms.Button btnIncluirAtleta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTécnico;
        private System.Windows.Forms.Label lblRepresentante;
        private System.Windows.Forms.ComboBox cboTreinador;
        private System.Windows.Forms.ComboBox cboRepresentante;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
    }
}