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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCompeticao));
            this.tlp1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNumJogadores = new System.Windows.Forms.Label();
            this.txtNumMinJogadores = new System.Windows.Forms.MaskedTextBox();
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
            this.tlp2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtNumTimes = new System.Windows.Forms.MaskedTextBox();
            this.txtNumGrupos = new System.Windows.Forms.MaskedTextBox();
            this.lblGruposNomeados = new System.Windows.Forms.Label();
            this.cboNomeacaoGrupos = new System.Windows.Forms.ComboBox();
            this.lblFaseFinal = new System.Windows.Forms.Label();
            this.cboFaseFinal = new System.Windows.Forms.ComboBox();
            this.lblNumGrupos = new System.Windows.Forms.Label();
            this.lblNumTimes = new System.Windows.Forms.Label();
            this.chkIdaEVolta = new System.Windows.Forms.CheckBox();
            this.chkIdaEVoltaFaseFinal = new System.Windows.Forms.CheckBox();
            this.tcGrupos = new System.Windows.Forms.TabControl();
            this.btnAvancar = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.Label();
            this.btnIncluirEquipes = new System.Windows.Forms.Button();
            this.btnExcluirEquipe = new System.Windows.Forms.Button();
            this.btnGerarGrupos = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnGerarPartidas = new System.Windows.Forms.Button();
            this.btnVisaoGeral = new System.Windows.Forms.Button();
            this.btnArbitros = new System.Windows.Forms.Button();
            this.tlp3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSuspensao = new System.Windows.Forms.Label();
            this.cboSuspensao = new System.Windows.Forms.ComboBox();
            this.chkZerarCartoesFaseFinal = new System.Windows.Forms.CheckBox();
            this.tlp1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipes)).BeginInit();
            this.tlp2.SuspendLayout();
            this.tlp3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp1
            // 
            this.tlp1.ColumnCount = 5;
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tlp1.Controls.Add(this.lblNumJogadores, 4, 0);
            this.tlp1.Controls.Add(this.txtNumMinJogadores, 4, 1);
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
            this.tlp1.Size = new System.Drawing.Size(710, 40);
            this.tlp1.TabIndex = 0;
            // 
            // lblNumJogadores
            // 
            this.lblNumJogadores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumJogadores.AutoSize = true;
            this.lblNumJogadores.Location = new System.Drawing.Point(587, 0);
            this.lblNumJogadores.Name = "lblNumJogadores";
            this.lblNumJogadores.Size = new System.Drawing.Size(120, 14);
            this.lblNumJogadores.TabIndex = 20;
            this.lblNumJogadores.Text = "Mínimo de jogadores";
            // 
            // txtNumMinJogadores
            // 
            this.txtNumMinJogadores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumMinJogadores.Location = new System.Drawing.Point(587, 17);
            this.txtNumMinJogadores.Mask = "00";
            this.txtNumMinJogadores.Name = "txtNumMinJogadores";
            this.txtNumMinJogadores.PromptChar = ' ';
            this.txtNumMinJogadores.Size = new System.Drawing.Size(120, 20);
            this.txtNumMinJogadores.TabIndex = 19;
            this.txtNumMinJogadores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(445, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Modalidade";
            // 
            // txtDtFim
            // 
            this.txtDtFim.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDtFim.Location = new System.Drawing.Point(357, 17);
            this.txtDtFim.Mask = "00/00/0000";
            this.txtDtFim.Name = "txtDtFim";
            this.txtDtFim.Size = new System.Drawing.Size(82, 20);
            this.txtDtFim.TabIndex = 7;
            this.txtDtFim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
            // 
            // lblFim
            // 
            this.lblFim.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFim.AutoSize = true;
            this.lblFim.Location = new System.Drawing.Point(357, 0);
            this.lblFim.Name = "lblFim";
            this.lblFim.Size = new System.Drawing.Size(82, 14);
            this.lblFim.TabIndex = 6;
            this.lblFim.Text = "Fim";
            // 
            // lblInicio
            // 
            this.lblInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(269, 0);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(82, 14);
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
            this.txtNome.Size = new System.Drawing.Size(260, 20);
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
            this.lblNome.Size = new System.Drawing.Size(260, 14);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome";
            // 
            // txtDtInicio
            // 
            this.txtDtInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDtInicio.Location = new System.Drawing.Point(269, 17);
            this.txtDtInicio.Mask = "00/00/0000";
            this.txtDtInicio.Name = "txtDtInicio";
            this.txtDtInicio.Size = new System.Drawing.Size(82, 20);
            this.txtDtInicio.TabIndex = 5;
            this.txtDtInicio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
            // 
            // cboModalidades
            // 
            this.cboModalidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboModalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModalidades.FormattingEnabled = true;
            this.cboModalidades.Location = new System.Drawing.Point(445, 17);
            this.cboModalidades.Name = "cboModalidades";
            this.cboModalidades.Size = new System.Drawing.Size(136, 21);
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
            this.btnCancelar.Location = new System.Drawing.Point(87, 10);
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
            this.dgvEquipes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvEquipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipes.Location = new System.Drawing.Point(10, 209);
            this.dgvEquipes.Name = "dgvEquipes";
            this.dgvEquipes.ReadOnly = true;
            this.dgvEquipes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipes.Size = new System.Drawing.Size(710, 155);
            this.dgvEquipes.TabIndex = 5;
            this.dgvEquipes.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEquipes_CellMouseDoubleClick);
            this.dgvEquipes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipes_RowEnter);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(165, 10);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 6;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // tlp2
            // 
            this.tlp2.ColumnCount = 6;
            this.tlp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tlp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tlp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.5F));
            this.tlp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tlp2.Controls.Add(this.txtNumTimes, 0, 1);
            this.tlp2.Controls.Add(this.txtNumGrupos, 1, 1);
            this.tlp2.Controls.Add(this.lblGruposNomeados, 5, 0);
            this.tlp2.Controls.Add(this.cboNomeacaoGrupos, 5, 1);
            this.tlp2.Controls.Add(this.lblFaseFinal, 2, 0);
            this.tlp2.Controls.Add(this.cboFaseFinal, 2, 1);
            this.tlp2.Controls.Add(this.lblNumGrupos, 1, 0);
            this.tlp2.Controls.Add(this.lblNumTimes, 0, 0);
            this.tlp2.Controls.Add(this.chkIdaEVolta, 3, 1);
            this.tlp2.Controls.Add(this.chkIdaEVoltaFaseFinal, 4, 1);
            this.tlp2.Location = new System.Drawing.Point(10, 87);
            this.tlp2.Name = "tlp2";
            this.tlp2.RowCount = 2;
            this.tlp2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tlp2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlp2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp2.Size = new System.Drawing.Size(710, 40);
            this.tlp2.TabIndex = 7;
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
            this.cboNomeacaoGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNomeacaoGrupos.FormattingEnabled = true;
            this.cboNomeacaoGrupos.Location = new System.Drawing.Point(588, 17);
            this.cboNomeacaoGrupos.Name = "cboNomeacaoGrupos";
            this.cboNomeacaoGrupos.Size = new System.Drawing.Size(119, 21);
            this.cboNomeacaoGrupos.TabIndex = 15;
            this.cboNomeacaoGrupos.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // lblFaseFinal
            // 
            this.lblFaseFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFaseFinal.AutoSize = true;
            this.lblFaseFinal.Location = new System.Drawing.Point(109, 0);
            this.lblFaseFinal.Name = "lblFaseFinal";
            this.lblFaseFinal.Size = new System.Drawing.Size(136, 14);
            this.lblFaseFinal.TabIndex = 12;
            this.lblFaseFinal.Text = "Fase final";
            // 
            // cboFaseFinal
            // 
            this.cboFaseFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFaseFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFaseFinal.FormattingEnabled = true;
            this.cboFaseFinal.Location = new System.Drawing.Point(109, 17);
            this.cboFaseFinal.Name = "cboFaseFinal";
            this.cboFaseFinal.Size = new System.Drawing.Size(136, 21);
            this.cboFaseFinal.TabIndex = 11;
            this.cboFaseFinal.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
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
            // chkIdaEVoltaFaseFinal
            // 
            this.chkIdaEVoltaFaseFinal.AutoSize = true;
            this.chkIdaEVoltaFaseFinal.Location = new System.Drawing.Point(393, 17);
            this.chkIdaEVoltaFaseFinal.Name = "chkIdaEVoltaFaseFinal";
            this.chkIdaEVoltaFaseFinal.Size = new System.Drawing.Size(178, 17);
            this.chkIdaEVoltaFaseFinal.TabIndex = 14;
            this.chkIdaEVoltaFaseFinal.Text = "Jogos de ida e volta (Fase Final)";
            this.chkIdaEVoltaFaseFinal.UseVisualStyleBackColor = true;
            this.chkIdaEVoltaFaseFinal.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChange);
            // 
            // tcGrupos
            // 
            this.tcGrupos.Location = new System.Drawing.Point(10, 369);
            this.tcGrupos.Name = "tcGrupos";
            this.tcGrupos.SelectedIndex = 0;
            this.tcGrupos.Size = new System.Drawing.Size(710, 155);
            this.tcGrupos.TabIndex = 8;
            // 
            // btnAvancar
            // 
            this.btnAvancar.Location = new System.Drawing.Point(630, 10);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Size = new System.Drawing.Size(90, 23);
            this.btnAvancar.TabIndex = 9;
            this.btnAvancar.Text = "Avançar";
            this.btnAvancar.UseVisualStyleBackColor = true;
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(243, 13);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(59, 17);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status:";
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(299, 13);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(230, 17);
            this.txtStatus.TabIndex = 11;
            this.txtStatus.Text = "Status:";
            // 
            // btnIncluirEquipes
            // 
            this.btnIncluirEquipes.Location = new System.Drawing.Point(10, 181);
            this.btnIncluirEquipes.Name = "btnIncluirEquipes";
            this.btnIncluirEquipes.Size = new System.Drawing.Size(90, 23);
            this.btnIncluirEquipes.TabIndex = 12;
            this.btnIncluirEquipes.Text = "Incluir equipes";
            this.btnIncluirEquipes.UseVisualStyleBackColor = true;
            this.btnIncluirEquipes.Click += new System.EventHandler(this.btnIncluirEquipes_Click);
            // 
            // btnExcluirEquipe
            // 
            this.btnExcluirEquipe.Location = new System.Drawing.Point(105, 181);
            this.btnExcluirEquipe.Name = "btnExcluirEquipe";
            this.btnExcluirEquipe.Size = new System.Drawing.Size(90, 23);
            this.btnExcluirEquipe.TabIndex = 13;
            this.btnExcluirEquipe.Text = "Excluir equipe";
            this.btnExcluirEquipe.UseVisualStyleBackColor = true;
            this.btnExcluirEquipe.Click += new System.EventHandler(this.btnExcluirEquipe_Click);
            // 
            // btnGerarGrupos
            // 
            this.btnGerarGrupos.Location = new System.Drawing.Point(430, 181);
            this.btnGerarGrupos.Name = "btnGerarGrupos";
            this.btnGerarGrupos.Size = new System.Drawing.Size(90, 23);
            this.btnGerarGrupos.TabIndex = 14;
            this.btnGerarGrupos.Text = "Gerar grupos";
            this.btnGerarGrupos.UseVisualStyleBackColor = true;
            this.btnGerarGrupos.Click += new System.EventHandler(this.btnGerarGrupos_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(534, 10);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(90, 23);
            this.btnVoltar.TabIndex = 15;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnGerarPartidas
            // 
            this.btnGerarPartidas.Location = new System.Drawing.Point(335, 181);
            this.btnGerarPartidas.Name = "btnGerarPartidas";
            this.btnGerarPartidas.Size = new System.Drawing.Size(90, 23);
            this.btnGerarPartidas.TabIndex = 16;
            this.btnGerarPartidas.Text = "Gerar partidas";
            this.btnGerarPartidas.UseVisualStyleBackColor = true;
            this.btnGerarPartidas.Click += new System.EventHandler(this.btnGerarPartidas_Click);
            // 
            // btnVisaoGeral
            // 
            this.btnVisaoGeral.Location = new System.Drawing.Point(545, 181);
            this.btnVisaoGeral.Name = "btnVisaoGeral";
            this.btnVisaoGeral.Size = new System.Drawing.Size(175, 23);
            this.btnVisaoGeral.TabIndex = 17;
            this.btnVisaoGeral.Text = "Visão geral do campeonato";
            this.btnVisaoGeral.UseVisualStyleBackColor = true;
            this.btnVisaoGeral.Click += new System.EventHandler(this.btnVisaoGeral_Click);
            // 
            // btnArbitros
            // 
            this.btnArbitros.Location = new System.Drawing.Point(220, 181);
            this.btnArbitros.Name = "btnArbitros";
            this.btnArbitros.Size = new System.Drawing.Size(90, 23);
            this.btnArbitros.TabIndex = 18;
            this.btnArbitros.Text = "Árbitros";
            this.btnArbitros.UseVisualStyleBackColor = true;
            this.btnArbitros.Click += new System.EventHandler(this.btnArbitros_Click);
            // 
            // tlp3
            // 
            this.tlp3.ColumnCount = 3;
            this.tlp3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.5F));
            this.tlp3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.tlp3.Controls.Add(this.lblSuspensao, 0, 0);
            this.tlp3.Controls.Add(this.cboSuspensao, 0, 1);
            this.tlp3.Controls.Add(this.chkZerarCartoesFaseFinal, 1, 1);
            this.tlp3.Location = new System.Drawing.Point(10, 132);
            this.tlp3.Name = "tlp3";
            this.tlp3.RowCount = 2;
            this.tlp3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tlp3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlp3.Size = new System.Drawing.Size(710, 40);
            this.tlp3.TabIndex = 19;
            // 
            // lblSuspensao
            // 
            this.lblSuspensao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSuspensao.AutoSize = true;
            this.lblSuspensao.Location = new System.Drawing.Point(3, 0);
            this.lblSuspensao.Name = "lblSuspensao";
            this.lblSuspensao.Size = new System.Drawing.Size(224, 14);
            this.lblSuspensao.TabIndex = 17;
            this.lblSuspensao.Text = "Suspensão";
            // 
            // cboSuspensao
            // 
            this.cboSuspensao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSuspensao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSuspensao.FormattingEnabled = true;
            this.cboSuspensao.Location = new System.Drawing.Point(3, 17);
            this.cboSuspensao.Name = "cboSuspensao";
            this.cboSuspensao.Size = new System.Drawing.Size(224, 21);
            this.cboSuspensao.TabIndex = 16;
            this.cboSuspensao.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // chkZerarCartoesFaseFinal
            // 
            this.chkZerarCartoesFaseFinal.AutoSize = true;
            this.chkZerarCartoesFaseFinal.Location = new System.Drawing.Point(233, 17);
            this.chkZerarCartoesFaseFinal.Name = "chkZerarCartoesFaseFinal";
            this.chkZerarCartoesFaseFinal.Size = new System.Drawing.Size(155, 17);
            this.chkZerarCartoesFaseFinal.TabIndex = 15;
            this.chkZerarCartoesFaseFinal.Text = "Zerar cartões na Fase Final";
            this.chkZerarCartoesFaseFinal.UseVisualStyleBackColor = true;
            this.chkZerarCartoesFaseFinal.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChange);
            // 
            // EditCompeticao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 536);
            this.Controls.Add(this.btnArbitros);
            this.Controls.Add(this.btnVisaoGeral);
            this.Controls.Add(this.btnGerarPartidas);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnGerarGrupos);
            this.Controls.Add(this.btnExcluirEquipe);
            this.Controls.Add(this.btnIncluirEquipes);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnAvancar);
            this.Controls.Add(this.dgvEquipes);
            this.Controls.Add(this.tcGrupos);
            this.Controls.Add(this.tlp2);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.tlp1);
            this.Controls.Add(this.tlp3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditCompeticao";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowInTaskbar = false;
            this.Text = "Cadastro de competição";
            this.Load += new System.EventHandler(this.load);
            this.tlp1.ResumeLayout(false);
            this.tlp1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipes)).EndInit();
            this.tlp2.ResumeLayout(false);
            this.tlp2.PerformLayout();
            this.tlp3.ResumeLayout(false);
            this.tlp3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TableLayoutPanel tlp2;
        private System.Windows.Forms.Label lblNumGrupos;
        private System.Windows.Forms.Label lblNumTimes;
        private System.Windows.Forms.Label lblFaseFinal;
        private System.Windows.Forms.CheckBox chkIdaEVolta;
        private System.Windows.Forms.CheckBox chkIdaEVoltaFaseFinal;
        private System.Windows.Forms.TabControl tcGrupos;
        private System.Windows.Forms.ComboBox cboNomeacaoGrupos;
        private System.Windows.Forms.Label lblGruposNomeados;
        private System.Windows.Forms.MaskedTextBox txtNumTimes;
        private System.Windows.Forms.MaskedTextBox txtNumGrupos;
        private System.Windows.Forms.Button btnAvancar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label txtStatus;
        private System.Windows.Forms.Button btnIncluirEquipes;
        private System.Windows.Forms.Button btnExcluirEquipe;
        private System.Windows.Forms.Button btnGerarGrupos;
        private System.Windows.Forms.MaskedTextBox txtNumMinJogadores;
        private System.Windows.Forms.Label lblNumJogadores;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnGerarPartidas;
        private System.Windows.Forms.Button btnVisaoGeral;
        private System.Windows.Forms.Button btnArbitros;
        private System.Windows.Forms.TableLayoutPanel tlp3;
        private System.Windows.Forms.CheckBox chkZerarCartoesFaseFinal;
        private System.Windows.Forms.ComboBox cboSuspensao;
        private System.Windows.Forms.Label lblSuspensao;
        private System.Windows.Forms.ComboBox cboFaseFinal;
    }
}