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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dgvEquipes = new System.Windows.Forms.DataGridView();
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.Label();
            this.tlp3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSuspensao = new System.Windows.Forms.Label();
            this.cboSuspensao = new System.Windows.Forms.ComboBox();
            this.chkZerarCartoesFaseFinal = new System.Windows.Forms.CheckBox();
            this.btnAtualizar = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.PictureBox();
            this.btnSalvar = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnExcluirEquipe = new System.Windows.Forms.PictureBox();
            this.btnIncluirEquipes = new System.Windows.Forms.PictureBox();
            this.btnArbitros = new System.Windows.Forms.PictureBox();
            this.btnVisaoGeral = new System.Windows.Forms.PictureBox();
            this.btnGerarGrupos = new System.Windows.Forms.PictureBox();
            this.btnGerarPartidas = new System.Windows.Forms.PictureBox();
            this.btnAvancar = new System.Windows.Forms.PictureBox();
            this.btnVoltar = new System.Windows.Forms.PictureBox();
            this.tlp1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipes)).BeginInit();
            this.tlp2.SuspendLayout();
            this.tlp3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtualizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalvar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcluirEquipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIncluirEquipes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnArbitros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVisaoGeral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGerarGrupos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGerarPartidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAvancar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoltar)).BeginInit();
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
            this.tlp1.Location = new System.Drawing.Point(10, 54);
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
            this.lblNumJogadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumJogadores.Location = new System.Drawing.Point(587, 0);
            this.lblNumJogadores.Name = "lblNumJogadores";
            this.lblNumJogadores.Size = new System.Drawing.Size(120, 14);
            this.lblNumJogadores.TabIndex = 20;
            this.lblNumJogadores.Text = "Mín. de jogadores";
            // 
            // txtNumMinJogadores
            // 
            this.txtNumMinJogadores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumMinJogadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumMinJogadores.Location = new System.Drawing.Point(587, 17);
            this.txtNumMinJogadores.Mask = "00";
            this.txtNumMinJogadores.Name = "txtNumMinJogadores";
            this.txtNumMinJogadores.PromptChar = ' ';
            this.txtNumMinJogadores.Size = new System.Drawing.Size(120, 21);
            this.txtNumMinJogadores.TabIndex = 19;
            this.txtNumMinJogadores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.txtDtFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDtFim.Location = new System.Drawing.Point(357, 17);
            this.txtDtFim.Mask = "00/00/0000";
            this.txtDtFim.Name = "txtDtFim";
            this.txtDtFim.Size = new System.Drawing.Size(82, 21);
            this.txtDtFim.TabIndex = 7;
            this.txtDtFim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
            // 
            // lblFim
            // 
            this.lblFim.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFim.AutoSize = true;
            this.lblFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(3, 17);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(260, 21);
            this.txtNome.TabIndex = 3;
            this.txtNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
            // 
            // lblNome
            // 
            this.lblNome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.txtDtInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDtInicio.Location = new System.Drawing.Point(269, 17);
            this.txtDtInicio.Mask = "00/00/0000";
            this.txtDtInicio.Name = "txtDtInicio";
            this.txtDtInicio.Size = new System.Drawing.Size(82, 21);
            this.txtDtInicio.TabIndex = 5;
            this.txtDtInicio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
            // 
            // cboModalidades
            // 
            this.cboModalidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboModalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModalidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModalidades.FormattingEnabled = true;
            this.cboModalidades.Location = new System.Drawing.Point(445, 17);
            this.cboModalidades.Name = "cboModalidades";
            this.cboModalidades.Size = new System.Drawing.Size(136, 23);
            this.cboModalidades.TabIndex = 9;
            this.cboModalidades.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // dgvEquipes
            // 
            this.dgvEquipes.AllowUserToAddRows = false;
            this.dgvEquipes.AllowUserToDeleteRows = false;
            this.dgvEquipes.AllowUserToOrderColumns = true;
            this.dgvEquipes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEquipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEquipes.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEquipes.Location = new System.Drawing.Point(10, 224);
            this.dgvEquipes.Name = "dgvEquipes";
            this.dgvEquipes.ReadOnly = true;
            this.dgvEquipes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipes.Size = new System.Drawing.Size(710, 155);
            this.dgvEquipes.TabIndex = 5;
            this.dgvEquipes.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEquipes_CellMouseDoubleClick);
            this.dgvEquipes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipes_RowEnter);
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
            this.tlp2.Location = new System.Drawing.Point(10, 94);
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
            this.txtNumTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumTimes.Location = new System.Drawing.Point(3, 17);
            this.txtNumTimes.Mask = "00";
            this.txtNumTimes.Name = "txtNumTimes";
            this.txtNumTimes.PromptChar = ' ';
            this.txtNumTimes.Size = new System.Drawing.Size(47, 21);
            this.txtNumTimes.TabIndex = 18;
            this.txtNumTimes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
            // 
            // txtNumGrupos
            // 
            this.txtNumGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumGrupos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumGrupos.Location = new System.Drawing.Point(56, 17);
            this.txtNumGrupos.Mask = "00";
            this.txtNumGrupos.Name = "txtNumGrupos";
            this.txtNumGrupos.PromptChar = ' ';
            this.txtNumGrupos.Size = new System.Drawing.Size(47, 21);
            this.txtNumGrupos.TabIndex = 17;
            this.txtNumGrupos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fields_KeyDown);
            // 
            // lblGruposNomeados
            // 
            this.lblGruposNomeados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGruposNomeados.AutoSize = true;
            this.lblGruposNomeados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cboNomeacaoGrupos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNomeacaoGrupos.FormattingEnabled = true;
            this.cboNomeacaoGrupos.Location = new System.Drawing.Point(588, 17);
            this.cboNomeacaoGrupos.Name = "cboNomeacaoGrupos";
            this.cboNomeacaoGrupos.Size = new System.Drawing.Size(119, 23);
            this.cboNomeacaoGrupos.TabIndex = 15;
            this.cboNomeacaoGrupos.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // lblFaseFinal
            // 
            this.lblFaseFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFaseFinal.AutoSize = true;
            this.lblFaseFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cboFaseFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFaseFinal.FormattingEnabled = true;
            this.cboFaseFinal.Location = new System.Drawing.Point(109, 17);
            this.cboFaseFinal.Name = "cboFaseFinal";
            this.cboFaseFinal.Size = new System.Drawing.Size(136, 23);
            this.cboFaseFinal.TabIndex = 11;
            this.cboFaseFinal.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // lblNumGrupos
            // 
            this.lblNumGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumGrupos.AutoSize = true;
            this.lblNumGrupos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblNumTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumTimes.Location = new System.Drawing.Point(3, 0);
            this.lblNumTimes.Name = "lblNumTimes";
            this.lblNumTimes.Size = new System.Drawing.Size(47, 14);
            this.lblNumTimes.TabIndex = 1;
            this.lblNumTimes.Text = "Times";
            // 
            // chkIdaEVolta
            // 
            this.chkIdaEVolta.AutoSize = true;
            this.chkIdaEVolta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIdaEVolta.Location = new System.Drawing.Point(251, 17);
            this.chkIdaEVolta.Name = "chkIdaEVolta";
            this.chkIdaEVolta.Size = new System.Drawing.Size(107, 19);
            this.chkIdaEVolta.TabIndex = 13;
            this.chkIdaEVolta.Text = "Jogos ida/volta";
            this.chkIdaEVolta.UseVisualStyleBackColor = true;
            this.chkIdaEVolta.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChange);
            // 
            // chkIdaEVoltaFaseFinal
            // 
            this.chkIdaEVoltaFaseFinal.AutoSize = true;
            this.chkIdaEVoltaFaseFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIdaEVoltaFaseFinal.Location = new System.Drawing.Point(393, 17);
            this.chkIdaEVoltaFaseFinal.Name = "chkIdaEVoltaFaseFinal";
            this.chkIdaEVoltaFaseFinal.Size = new System.Drawing.Size(175, 19);
            this.chkIdaEVoltaFaseFinal.TabIndex = 14;
            this.chkIdaEVoltaFaseFinal.Text = "Jogos ida/volta (Fase Final)";
            this.chkIdaEVoltaFaseFinal.UseVisualStyleBackColor = true;
            this.chkIdaEVoltaFaseFinal.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChange);
            // 
            // tcGrupos
            // 
            this.tcGrupos.Location = new System.Drawing.Point(10, 384);
            this.tcGrupos.Name = "tcGrupos";
            this.tcGrupos.SelectedIndex = 0;
            this.tcGrupos.Size = new System.Drawing.Size(710, 155);
            this.tcGrupos.TabIndex = 8;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(133, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(59, 17);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status:";
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(189, 10);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(230, 17);
            this.txtStatus.TabIndex = 11;
            this.txtStatus.Text = "Status:";
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
            this.tlp3.Location = new System.Drawing.Point(10, 139);
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
            this.lblSuspensao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cboSuspensao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSuspensao.FormattingEnabled = true;
            this.cboSuspensao.Location = new System.Drawing.Point(3, 17);
            this.cboSuspensao.Name = "cboSuspensao";
            this.cboSuspensao.Size = new System.Drawing.Size(224, 23);
            this.cboSuspensao.TabIndex = 16;
            this.cboSuspensao.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // chkZerarCartoesFaseFinal
            // 
            this.chkZerarCartoesFaseFinal.AutoSize = true;
            this.chkZerarCartoesFaseFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkZerarCartoesFaseFinal.Location = new System.Drawing.Point(233, 17);
            this.chkZerarCartoesFaseFinal.Name = "chkZerarCartoesFaseFinal";
            this.chkZerarCartoesFaseFinal.Size = new System.Drawing.Size(171, 19);
            this.chkZerarCartoesFaseFinal.TabIndex = 15;
            this.chkZerarCartoesFaseFinal.Text = "Zerar cartões na Fase Final";
            this.chkZerarCartoesFaseFinal.UseVisualStyleBackColor = true;
            this.chkZerarCartoesFaseFinal.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChange);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.Image")));
            this.btnAtualizar.Location = new System.Drawing.Point(92, 10);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(35, 35);
            this.btnAtualizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAtualizar.TabIndex = 27;
            this.btnAtualizar.TabStop = false;
            this.btnAtualizar.Tag = "Recarregar informações da competição";
            this.btnAtualizar.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(51, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(35, 35);
            this.btnCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Tag = "Descartar alterações da competição";
            this.btnCancelar.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.Location = new System.Drawing.Point(10, 10);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(35, 35);
            this.btnSalvar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSalvar.TabIndex = 24;
            this.btnSalvar.TabStop = false;
            this.btnSalvar.Tag = "Salvar alterações da competição";
            this.btnSalvar.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnExcluirEquipe
            // 
            this.btnExcluirEquipe.Image = global::SecEsportes.Properties.Resources.excluir_equipe;
            this.btnExcluirEquipe.Location = new System.Drawing.Point(51, 184);
            this.btnExcluirEquipe.Name = "btnExcluirEquipe";
            this.btnExcluirEquipe.Size = new System.Drawing.Size(35, 35);
            this.btnExcluirEquipe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnExcluirEquipe.TabIndex = 29;
            this.btnExcluirEquipe.TabStop = false;
            this.btnExcluirEquipe.Tag = "Excluir a equipe da competição";
            this.btnExcluirEquipe.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnExcluirEquipe.Click += new System.EventHandler(this.btnExcluirEquipe_Click);
            // 
            // btnIncluirEquipes
            // 
            this.btnIncluirEquipes.Image = global::SecEsportes.Properties.Resources.adicionar_equipe;
            this.btnIncluirEquipes.Location = new System.Drawing.Point(10, 184);
            this.btnIncluirEquipes.Name = "btnIncluirEquipes";
            this.btnIncluirEquipes.Size = new System.Drawing.Size(35, 35);
            this.btnIncluirEquipes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnIncluirEquipes.TabIndex = 28;
            this.btnIncluirEquipes.TabStop = false;
            this.btnIncluirEquipes.Tag = "Incluir equipes na competição";
            this.btnIncluirEquipes.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnIncluirEquipes.Click += new System.EventHandler(this.btnIncluirEquipes_Click);
            // 
            // btnArbitros
            // 
            this.btnArbitros.Image = global::SecEsportes.Properties.Resources.arbitro;
            this.btnArbitros.Location = new System.Drawing.Point(133, 184);
            this.btnArbitros.Name = "btnArbitros";
            this.btnArbitros.Size = new System.Drawing.Size(35, 35);
            this.btnArbitros.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnArbitros.TabIndex = 30;
            this.btnArbitros.TabStop = false;
            this.btnArbitros.Tag = "Incluir e visualizar árbitros da competição";
            this.btnArbitros.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnArbitros.Click += new System.EventHandler(this.btnArbitros_Click);
            // 
            // btnVisaoGeral
            // 
            this.btnVisaoGeral.Image = global::SecEsportes.Properties.Resources.visao_geral;
            this.btnVisaoGeral.Location = new System.Drawing.Point(685, 184);
            this.btnVisaoGeral.Name = "btnVisaoGeral";
            this.btnVisaoGeral.Size = new System.Drawing.Size(35, 35);
            this.btnVisaoGeral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnVisaoGeral.TabIndex = 31;
            this.btnVisaoGeral.TabStop = false;
            this.btnVisaoGeral.Tag = "Visão geral da competição";
            this.btnVisaoGeral.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnVisaoGeral.Click += new System.EventHandler(this.btnVisaoGeral_Click);
            // 
            // btnGerarGrupos
            // 
            this.btnGerarGrupos.Image = global::SecEsportes.Properties.Resources.grupos;
            this.btnGerarGrupos.Location = new System.Drawing.Point(215, 184);
            this.btnGerarGrupos.Name = "btnGerarGrupos";
            this.btnGerarGrupos.Size = new System.Drawing.Size(79, 35);
            this.btnGerarGrupos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnGerarGrupos.TabIndex = 32;
            this.btnGerarGrupos.TabStop = false;
            this.btnGerarGrupos.Tag = "Gerar os grupos aleatóriamente";
            this.btnGerarGrupos.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnGerarGrupos.Click += new System.EventHandler(this.btnGerarGrupos_Click);
            // 
            // btnGerarPartidas
            // 
            this.btnGerarPartidas.Image = ((System.Drawing.Image)(resources.GetObject("btnGerarPartidas.Image")));
            this.btnGerarPartidas.Location = new System.Drawing.Point(300, 184);
            this.btnGerarPartidas.Name = "btnGerarPartidas";
            this.btnGerarPartidas.Size = new System.Drawing.Size(35, 35);
            this.btnGerarPartidas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnGerarPartidas.TabIndex = 33;
            this.btnGerarPartidas.TabStop = false;
            this.btnGerarPartidas.Tag = "Gerar as partidas aleatóriamente";
            this.btnGerarPartidas.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnGerarPartidas.Click += new System.EventHandler(this.btnGerarPartidas_Click);
            // 
            // btnAvancar
            // 
            this.btnAvancar.Image = global::SecEsportes.Properties.Resources.avancar;
            this.btnAvancar.Location = new System.Drawing.Point(685, 10);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Size = new System.Drawing.Size(35, 35);
            this.btnAvancar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAvancar.TabIndex = 35;
            this.btnAvancar.TabStop = false;
            this.btnAvancar.Tag = "Avança para a próxima etapa da competição";
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Image = global::SecEsportes.Properties.Resources.voltar;
            this.btnVoltar.Location = new System.Drawing.Point(644, 10);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(35, 35);
            this.btnVoltar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnVoltar.TabIndex = 34;
            this.btnVoltar.TabStop = false;
            this.btnVoltar.Tag = "Retrocede à etapa anterior da competição";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // EditCompeticao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 546);
            this.Controls.Add(this.btnAvancar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnGerarPartidas);
            this.Controls.Add(this.btnGerarGrupos);
            this.Controls.Add(this.btnVisaoGeral);
            this.Controls.Add(this.btnArbitros);
            this.Controls.Add(this.btnExcluirEquipe);
            this.Controls.Add(this.btnIncluirEquipes);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dgvEquipes);
            this.Controls.Add(this.tcGrupos);
            this.Controls.Add(this.tlp2);
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
            ((System.ComponentModel.ISupportInitialize)(this.btnAtualizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalvar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcluirEquipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIncluirEquipes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnArbitros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVisaoGeral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGerarGrupos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGerarPartidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAvancar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoltar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp1;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.DataGridView dgvEquipes;
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
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label txtStatus;
        private System.Windows.Forms.MaskedTextBox txtNumMinJogadores;
        private System.Windows.Forms.Label lblNumJogadores;
        private System.Windows.Forms.TableLayoutPanel tlp3;
        private System.Windows.Forms.CheckBox chkZerarCartoesFaseFinal;
        private System.Windows.Forms.ComboBox cboSuspensao;
        private System.Windows.Forms.Label lblSuspensao;
        private System.Windows.Forms.ComboBox cboFaseFinal;
        private System.Windows.Forms.PictureBox btnAtualizar;
        private System.Windows.Forms.PictureBox btnSalvar;
        private System.Windows.Forms.PictureBox btnCancelar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox btnExcluirEquipe;
        private System.Windows.Forms.PictureBox btnIncluirEquipes;
        private System.Windows.Forms.PictureBox btnArbitros;
        private System.Windows.Forms.PictureBox btnVisaoGeral;
        private System.Windows.Forms.PictureBox btnGerarGrupos;
        private System.Windows.Forms.PictureBox btnGerarPartidas;
        private System.Windows.Forms.PictureBox btnAvancar;
        private System.Windows.Forms.PictureBox btnVoltar;
    }
}