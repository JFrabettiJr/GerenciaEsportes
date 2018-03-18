namespace SecEsportes.Views
{
    partial class EditCompeticao {
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
            this.tlp1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDtFim = new System.Windows.Forms.MaskedTextBox();
            this.lblFim = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtDtInicio = new System.Windows.Forms.MaskedTextBox();
            this.cboModalidades = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvEquipes = new System.Windows.Forms.DataGridView();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtNumTimes = new System.Windows.Forms.MaskedTextBox();
            this.txtNumGrupos = new System.Windows.Forms.MaskedTextBox();
            this.lblGruposNomeados = new System.Windows.Forms.Label();
            this.cboNomeacaoGrupos = new System.Windows.Forms.ComboBox();
            this.lblMataMata = new System.Windows.Forms.Label();
            this.cboMataMata = new System.Windows.Forms.ComboBox();
            this.lblNumGrupos = new System.Windows.Forms.Label();
            this.lblNumTimes = new System.Windows.Forms.Label();
            this.chkIdaEVolta = new System.Windows.Forms.CheckBox();
            this.chkIdaEVoltaMataMata = new System.Windows.Forms.CheckBox();
            this.tabGrupo1 = new System.Windows.Forms.TabPage();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tlp1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipes)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp1
            // 
            this.tlp1.ColumnCount = 4;
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlp1.Controls.Add(this.label1, 3, 0);
            this.tlp1.Controls.Add(this.txtDtFim, 2, 1);
            this.tlp1.Controls.Add(this.lblFim, 2, 0);
            this.tlp1.Controls.Add(this.lblInicio, 1, 0);
            this.tlp1.Controls.Add(this.txtNome, 0, 1);
            this.tlp1.Controls.Add(this.lblNome, 0, 0);
            this.tlp1.Controls.Add(this.txtDtInicio, 1, 1);
            this.tlp1.Controls.Add(this.cboModalidades, 3, 1);
            this.tlp1.Location = new System.Drawing.Point(10, 47);
            this.tlp1.Name = "tlp1";
            this.tlp1.RowCount = 2;
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp1.Size = new System.Drawing.Size(710, 40);
            this.tlp1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(499, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Modalidade";
            // 
            // txtDtFim
            // 
            this.txtDtFim.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDtFim.Location = new System.Drawing.Point(393, 17);
            this.txtDtFim.Mask = "00/00/0000";
            this.txtDtFim.Name = "txtDtFim";
            this.txtDtFim.Size = new System.Drawing.Size(100, 20);
            this.txtDtFim.TabIndex = 7;
            this.txtDtFim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
            // 
            // lblFim
            // 
            this.lblFim.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFim.AutoSize = true;
            this.lblFim.Location = new System.Drawing.Point(393, 0);
            this.lblFim.Name = "lblFim";
            this.lblFim.Size = new System.Drawing.Size(100, 14);
            this.lblFim.TabIndex = 6;
            this.lblFim.Text = "Fim";
            // 
            // lblInicio
            // 
            this.lblInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(287, 0);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(100, 14);
            this.lblInicio.TabIndex = 4;
            this.lblInicio.Text = "Início";
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.Location = new System.Drawing.Point(3, 17);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(278, 20);
            this.txtNome.TabIndex = 3;
            this.txtNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
            // 
            // lblNome
            // 
            this.lblNome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(3, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(278, 14);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome";
            // 
            // txtDtInicio
            // 
            this.txtDtInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDtInicio.Location = new System.Drawing.Point(287, 17);
            this.txtDtInicio.Mask = "00/00/0000";
            this.txtDtInicio.Name = "txtDtInicio";
            this.txtDtInicio.Size = new System.Drawing.Size(100, 20);
            this.txtDtInicio.TabIndex = 5;
            this.txtDtInicio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
            // 
            // cboModalidades
            // 
            this.cboModalidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboModalidades.FormattingEnabled = true;
            this.cboModalidades.Location = new System.Drawing.Point(499, 17);
            this.cboModalidades.Name = "cboModalidades";
            this.cboModalidades.Size = new System.Drawing.Size(208, 21);
            this.cboModalidades.TabIndex = 9;
            this.cboModalidades.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(10, 10);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(91, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvEquipes
            // 
            this.dgvEquipes.AllowUserToAddRows = false;
            this.dgvEquipes.AllowUserToDeleteRows = false;
            this.dgvEquipes.AllowUserToOrderColumns = true;
            this.dgvEquipes.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvEquipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipes.Location = new System.Drawing.Point(10, 149);
            this.dgvEquipes.Name = "dgvEquipes";
            this.dgvEquipes.ReadOnly = true;
            this.dgvEquipes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipes.Size = new System.Drawing.Size(710, 228);
            this.dgvEquipes.TabIndex = 5;
            this.dgvEquipes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPessoas_RowEnter);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(173, 10);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 6;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanel1.Controls.Add(this.txtNumTimes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNumGrupos, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblGruposNomeados, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboNomeacaoGrupos, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMataMata, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboMataMata, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNumGrupos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNumTimes, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkIdaEVolta, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkIdaEVoltaMataMata, 4, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 97);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(710, 40);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // txtNumTimes
            // 
            this.txtNumTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumTimes.Location = new System.Drawing.Point(3, 17);
            this.txtNumTimes.Mask = "00";
            this.txtNumTimes.Name = "txtNumTimes";
            this.txtNumTimes.PromptChar = ' ';
            this.txtNumTimes.Size = new System.Drawing.Size(47, 20);
            this.txtNumTimes.TabIndex = 18;
            this.txtNumTimes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
            // 
            // txtNumGrupos
            // 
            this.txtNumGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumGrupos.Location = new System.Drawing.Point(56, 17);
            this.txtNumGrupos.Mask = "00";
            this.txtNumGrupos.Name = "txtNumGrupos";
            this.txtNumGrupos.PromptChar = ' ';
            this.txtNumGrupos.Size = new System.Drawing.Size(47, 20);
            this.txtNumGrupos.TabIndex = 17;
            this.txtNumGrupos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
            // 
            // lblGruposNomeados
            // 
            this.lblGruposNomeados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGruposNomeados.AutoSize = true;
            this.lblGruposNomeados.Location = new System.Drawing.Point(588, 0);
            this.lblGruposNomeados.Name = "lblGruposNomeados";
            this.lblGruposNomeados.Size = new System.Drawing.Size(119, 14);
            this.lblGruposNomeados.TabIndex = 16;
            this.lblGruposNomeados.Text = "Grupos nomeados";
            // 
            // cboNomeacaoGrupos
            // 
            this.cboNomeacaoGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNomeacaoGrupos.FormattingEnabled = true;
            this.cboNomeacaoGrupos.Location = new System.Drawing.Point(588, 17);
            this.cboNomeacaoGrupos.Name = "cboNomeacaoGrupos";
            this.cboNomeacaoGrupos.Size = new System.Drawing.Size(119, 21);
            this.cboNomeacaoGrupos.TabIndex = 15;
            this.cboNomeacaoGrupos.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // lblMataMata
            // 
            this.lblMataMata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMataMata.AutoSize = true;
            this.lblMataMata.Location = new System.Drawing.Point(109, 0);
            this.lblMataMata.Name = "lblMataMata";
            this.lblMataMata.Size = new System.Drawing.Size(136, 14);
            this.lblMataMata.TabIndex = 12;
            this.lblMataMata.Text = "Mata-mata";
            // 
            // cboMataMata
            // 
            this.cboMataMata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMataMata.FormattingEnabled = true;
            this.cboMataMata.Location = new System.Drawing.Point(109, 17);
            this.cboMataMata.Name = "cboMataMata";
            this.cboMataMata.Size = new System.Drawing.Size(136, 21);
            this.cboMataMata.TabIndex = 11;
            this.cboMataMata.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // lblNumGrupos
            // 
            this.lblNumGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumGrupos.AutoSize = true;
            this.lblNumGrupos.Location = new System.Drawing.Point(56, 0);
            this.lblNumGrupos.Name = "lblNumGrupos";
            this.lblNumGrupos.Size = new System.Drawing.Size(47, 14);
            this.lblNumGrupos.TabIndex = 4;
            this.lblNumGrupos.Text = "Grupos";
            // 
            // lblNumTimes
            // 
            this.lblNumTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumTimes.AutoSize = true;
            this.lblNumTimes.Location = new System.Drawing.Point(3, 0);
            this.lblNumTimes.Name = "lblNumTimes";
            this.lblNumTimes.Size = new System.Drawing.Size(47, 14);
            this.lblNumTimes.TabIndex = 1;
            this.lblNumTimes.Text = "Times";
            // 
            // chkIdaEVolta
            // 
            this.chkIdaEVolta.AutoSize = true;
            this.chkIdaEVolta.Location = new System.Drawing.Point(251, 17);
            this.chkIdaEVolta.Name = "chkIdaEVolta";
            this.chkIdaEVolta.Size = new System.Drawing.Size(121, 17);
            this.chkIdaEVolta.TabIndex = 13;
            this.chkIdaEVolta.Text = "Jogos de ida e volta";
            this.chkIdaEVolta.UseVisualStyleBackColor = true;
            this.chkIdaEVolta.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChange);
            // 
            // chkIdaEVoltaMataMata
            // 
            this.chkIdaEVoltaMataMata.AutoSize = true;
            this.chkIdaEVoltaMataMata.Location = new System.Drawing.Point(393, 17);
            this.chkIdaEVoltaMataMata.Name = "chkIdaEVoltaMataMata";
            this.chkIdaEVoltaMataMata.Size = new System.Drawing.Size(180, 17);
            this.chkIdaEVoltaMataMata.TabIndex = 14;
            this.chkIdaEVoltaMataMata.Text = "Jogos de ida e volta (Mata-mata)";
            this.chkIdaEVoltaMataMata.UseVisualStyleBackColor = true;
            this.chkIdaEVoltaMataMata.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChange);
            // 
            // tabGrupo1
            // 
            this.tabGrupo1.Location = new System.Drawing.Point(4, 22);
            this.tabGrupo1.Name = "tabGrupo1";
            this.tabGrupo1.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrupo1.Size = new System.Drawing.Size(702, 117);
            this.tabGrupo1.TabIndex = 0;
            this.tabGrupo1.Text = "Grupo 1";
            this.tabGrupo1.UseVisualStyleBackColor = true;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabGrupo1);
            this.tabs.Location = new System.Drawing.Point(10, 387);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(710, 143);
            this.tabs.TabIndex = 8;
            // 
            // EditCompeticao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 536);
            this.Controls.Add(this.dgvEquipes);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.tlp1);
            this.Name = "EditCompeticao";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Cadastro de competição";
            this.tlp1.ResumeLayout(false);
            this.tlp1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipes)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp1;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvEquipes;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.MaskedTextBox txtDtInicio;
        private System.Windows.Forms.MaskedTextBox txtDtFim;
        private System.Windows.Forms.Label lblFim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboModalidades;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblNumGrupos;
        private System.Windows.Forms.Label lblNumTimes;
        private System.Windows.Forms.ComboBox cboMataMata;
        private System.Windows.Forms.Label lblMataMata;
        private System.Windows.Forms.CheckBox chkIdaEVolta;
        private System.Windows.Forms.CheckBox chkIdaEVoltaMataMata;
        private System.Windows.Forms.TabPage tabGrupo1;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.ComboBox cboNomeacaoGrupos;
        private System.Windows.Forms.Label lblGruposNomeados;
        private System.Windows.Forms.MaskedTextBox txtNumTimes;
        private System.Windows.Forms.MaskedTextBox txtNumGrupos;
    }
}