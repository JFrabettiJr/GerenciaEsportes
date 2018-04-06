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
            this.tlpCadFuncao = new System.Windows.Forms.TableLayoutPanel();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.dgvAtletas = new System.Windows.Forms.DataGridView();
            this.btnExcluirAtleta = new System.Windows.Forms.Button();
            this.btnIncluirAtleta = new System.Windows.Forms.Button();
            this.tlpCadFuncao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtletas)).BeginInit();
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
            this.tlpCadFuncao.Location = new System.Drawing.Point(10, 8);
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
            this.txtNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
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
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
            // 
            // dgvAtletas
            // 
            this.dgvAtletas.AllowUserToAddRows = false;
            this.dgvAtletas.AllowUserToDeleteRows = false;
            this.dgvAtletas.AllowUserToOrderColumns = true;
            this.dgvAtletas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAtletas.Location = new System.Drawing.Point(10, 93);
            this.dgvAtletas.MultiSelect = false;
            this.dgvAtletas.Name = "dgvAtletas";
            this.dgvAtletas.ReadOnly = true;
            this.dgvAtletas.Size = new System.Drawing.Size(560, 315);
            this.dgvAtletas.TabIndex = 5;
            this.dgvAtletas.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipes_RowEnter);
            // 
            // btnExcluirAtleta
            // 
            this.btnExcluirAtleta.Location = new System.Drawing.Point(138, 64);
            this.btnExcluirAtleta.Name = "btnExcluirAtleta";
            this.btnExcluirAtleta.Size = new System.Drawing.Size(122, 23);
            this.btnExcluirAtleta.TabIndex = 15;
            this.btnExcluirAtleta.Text = "Excluir atleta";
            this.btnExcluirAtleta.UseVisualStyleBackColor = true;
            // 
            // btnIncluirAtleta
            // 
            this.btnIncluirAtleta.Location = new System.Drawing.Point(10, 64);
            this.btnIncluirAtleta.Name = "btnIncluirAtleta";
            this.btnIncluirAtleta.Size = new System.Drawing.Size(122, 23);
            this.btnIncluirAtleta.TabIndex = 14;
            this.btnIncluirAtleta.Text = "Incluir atletas";
            this.btnIncluirAtleta.UseVisualStyleBackColor = true;
            this.btnIncluirAtleta.Click += new System.EventHandler(this.btnIncluirAtleta_Click);
            // 
            // EditEquipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 421);
            this.Controls.Add(this.btnExcluirAtleta);
            this.Controls.Add(this.btnIncluirAtleta);
            this.Controls.Add(this.dgvAtletas);
            this.Controls.Add(this.tlpCadFuncao);
            this.Name = "EditEquipe";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Cadastro de equipes - Inserção de atletas";
            this.Load += new System.EventHandler(this.EditEquipe_Load);
            this.tlpCadFuncao.ResumeLayout(false);
            this.tlpCadFuncao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtletas)).EndInit();
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
    }
}