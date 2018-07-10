namespace SecEsportes.Views
{
    partial class ViewCompeticao {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewCompeticao));
            this.lblCompeticao = new System.Windows.Forms.Label();
            this.tcAbas = new System.Windows.Forms.TabControl();
            this.tpPartidas = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboCamposBusca = new System.Windows.Forms.ComboBox();
            this.lblBuscarPor = new System.Windows.Forms.Label();
            this.lblBusca = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.lblFase = new System.Windows.Forms.Label();
            this.btnProximaFase = new System.Windows.Forms.Button();
            this.tcPartidas = new System.Windows.Forms.TabControl();
            this.tpClassificacao = new System.Windows.Forms.TabPage();
            this.btnGerarHTML_Classificacao = new System.Windows.Forms.Button();
            this.tcClassificacao = new System.Windows.Forms.TabControl();
            this.tpArtilheiros = new System.Windows.Forms.TabPage();
            this.btnGerarHTML_Artilheiros = new System.Windows.Forms.Button();
            this.dgvArtilheiros = new System.Windows.Forms.DataGridView();
            this.tcAbas.SuspendLayout();
            this.tpPartidas.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tpClassificacao.SuspendLayout();
            this.tpArtilheiros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtilheiros)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCompeticao
            // 
            this.lblCompeticao.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompeticao.Location = new System.Drawing.Point(13, 8);
            this.lblCompeticao.Name = "lblCompeticao";
            this.lblCompeticao.Size = new System.Drawing.Size(709, 34);
            this.lblCompeticao.TabIndex = 0;
            this.lblCompeticao.Text = "Competição";
            this.lblCompeticao.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tcAbas
            // 
            this.tcAbas.Controls.Add(this.tpPartidas);
            this.tcAbas.Controls.Add(this.tpClassificacao);
            this.tcAbas.Controls.Add(this.tpArtilheiros);
            this.tcAbas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAbas.Location = new System.Drawing.Point(13, 45);
            this.tcAbas.Name = "tcAbas";
            this.tcAbas.SelectedIndex = 0;
            this.tcAbas.Size = new System.Drawing.Size(713, 481);
            this.tcAbas.TabIndex = 1;
            // 
            // tpPartidas
            // 
            this.tpPartidas.Controls.Add(this.tableLayoutPanel1);
            this.tpPartidas.Controls.Add(this.lblFase);
            this.tpPartidas.Controls.Add(this.btnProximaFase);
            this.tpPartidas.Controls.Add(this.tcPartidas);
            this.tpPartidas.Location = new System.Drawing.Point(4, 24);
            this.tpPartidas.Name = "tpPartidas";
            this.tpPartidas.Padding = new System.Windows.Forms.Padding(3);
            this.tpPartidas.Size = new System.Drawing.Size(705, 453);
            this.tpPartidas.TabIndex = 0;
            this.tpPartidas.Text = "Partidas";
            this.tpPartidas.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 410);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(693, 40);
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
            this.cboCamposBusca.Location = new System.Drawing.Point(522, 17);
            this.cboCamposBusca.Name = "cboCamposBusca";
            this.cboCamposBusca.Size = new System.Drawing.Size(168, 23);
            this.cboCamposBusca.TabIndex = 10;
            // 
            // lblBuscarPor
            // 
            this.lblBuscarPor.AutoSize = true;
            this.lblBuscarPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarPor.Location = new System.Drawing.Point(522, 0);
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
            this.txtBusca.Size = new System.Drawing.Size(513, 21);
            this.txtBusca.TabIndex = 2;
            this.txtBusca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusca_KeyDown);
            // 
            // lblFase
            // 
            this.lblFase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFase.Location = new System.Drawing.Point(6, 9);
            this.lblFase.Name = "lblFase";
            this.lblFase.Size = new System.Drawing.Size(577, 23);
            this.lblFase.TabIndex = 2;
            this.lblFase.Text = "Fase atual";
            this.lblFase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnProximaFase
            // 
            this.btnProximaFase.Location = new System.Drawing.Point(589, 6);
            this.btnProximaFase.Name = "btnProximaFase";
            this.btnProximaFase.Size = new System.Drawing.Size(110, 23);
            this.btnProximaFase.TabIndex = 12;
            this.btnProximaFase.Text = "Próxima Fase";
            this.btnProximaFase.UseVisualStyleBackColor = true;
            this.btnProximaFase.Click += new System.EventHandler(this.btnProximaFase_Click);
            // 
            // tcPartidas
            // 
            this.tcPartidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcPartidas.Location = new System.Drawing.Point(6, 35);
            this.tcPartidas.Name = "tcPartidas";
            this.tcPartidas.SelectedIndex = 0;
            this.tcPartidas.Size = new System.Drawing.Size(693, 362);
            this.tcPartidas.TabIndex = 11;
            // 
            // tpClassificacao
            // 
            this.tpClassificacao.Controls.Add(this.btnGerarHTML_Classificacao);
            this.tpClassificacao.Controls.Add(this.tcClassificacao);
            this.tpClassificacao.Location = new System.Drawing.Point(4, 24);
            this.tpClassificacao.Name = "tpClassificacao";
            this.tpClassificacao.Padding = new System.Windows.Forms.Padding(3);
            this.tpClassificacao.Size = new System.Drawing.Size(705, 453);
            this.tpClassificacao.TabIndex = 1;
            this.tpClassificacao.Text = "Classificação";
            this.tpClassificacao.UseVisualStyleBackColor = true;
            // 
            // btnGerarHTML_Classificacao
            // 
            this.btnGerarHTML_Classificacao.Location = new System.Drawing.Point(6, 426);
            this.btnGerarHTML_Classificacao.Name = "btnGerarHTML_Classificacao";
            this.btnGerarHTML_Classificacao.Size = new System.Drawing.Size(91, 23);
            this.btnGerarHTML_Classificacao.TabIndex = 11;
            this.btnGerarHTML_Classificacao.Text = "Gerar HTML";
            this.btnGerarHTML_Classificacao.UseVisualStyleBackColor = true;
            this.btnGerarHTML_Classificacao.Click += new System.EventHandler(this.btnGerarHTML_Classificacao_Click);
            // 
            // tcClassificacao
            // 
            this.tcClassificacao.Location = new System.Drawing.Point(6, 6);
            this.tcClassificacao.Name = "tcClassificacao";
            this.tcClassificacao.SelectedIndex = 0;
            this.tcClassificacao.Size = new System.Drawing.Size(693, 410);
            this.tcClassificacao.TabIndex = 10;
            // 
            // tpArtilheiros
            // 
            this.tpArtilheiros.Controls.Add(this.btnGerarHTML_Artilheiros);
            this.tpArtilheiros.Controls.Add(this.dgvArtilheiros);
            this.tpArtilheiros.Location = new System.Drawing.Point(4, 24);
            this.tpArtilheiros.Name = "tpArtilheiros";
            this.tpArtilheiros.Padding = new System.Windows.Forms.Padding(3);
            this.tpArtilheiros.Size = new System.Drawing.Size(705, 453);
            this.tpArtilheiros.TabIndex = 2;
            this.tpArtilheiros.Text = "Artilheiros";
            this.tpArtilheiros.UseVisualStyleBackColor = true;
            // 
            // btnGerarHTML_Artilheiros
            // 
            this.btnGerarHTML_Artilheiros.Location = new System.Drawing.Point(6, 426);
            this.btnGerarHTML_Artilheiros.Name = "btnGerarHTML_Artilheiros";
            this.btnGerarHTML_Artilheiros.Size = new System.Drawing.Size(91, 23);
            this.btnGerarHTML_Artilheiros.TabIndex = 12;
            this.btnGerarHTML_Artilheiros.Text = "Gerar HTML";
            this.btnGerarHTML_Artilheiros.UseVisualStyleBackColor = true;
            this.btnGerarHTML_Artilheiros.Click += new System.EventHandler(this.btnGerarHTML_Artilheiros_Click);
            // 
            // dgvArtilheiros
            // 
            this.dgvArtilheiros.AllowUserToAddRows = false;
            this.dgvArtilheiros.AllowUserToDeleteRows = false;
            this.dgvArtilheiros.AllowUserToOrderColumns = true;
            this.dgvArtilheiros.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvArtilheiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArtilheiros.Location = new System.Drawing.Point(6, 6);
            this.dgvArtilheiros.MultiSelect = false;
            this.dgvArtilheiros.Name = "dgvArtilheiros";
            this.dgvArtilheiros.ReadOnly = true;
            this.dgvArtilheiros.Size = new System.Drawing.Size(693, 410);
            this.dgvArtilheiros.TabIndex = 7;
            this.dgvArtilheiros.Tag = "1";
            // 
            // ViewCompeticao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 536);
            this.Controls.Add(this.tcAbas);
            this.Controls.Add(this.lblCompeticao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ViewCompeticao";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowInTaskbar = false;
            this.Text = "Visão geral da competição";
            this.Load += new System.EventHandler(this.load);
            this.tcAbas.ResumeLayout(false);
            this.tpPartidas.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tpClassificacao.ResumeLayout(false);
            this.tpArtilheiros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtilheiros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCompeticao;
        private System.Windows.Forms.TabControl tcAbas;
        private System.Windows.Forms.TabPage tpPartidas;
        private System.Windows.Forms.TabPage tpClassificacao;
        private System.Windows.Forms.TabPage tpArtilheiros;
        private System.Windows.Forms.TabControl tcClassificacao;
        private System.Windows.Forms.TabControl tcPartidas;
        private System.Windows.Forms.Button btnProximaFase;
        private System.Windows.Forms.Label lblFase;
        private System.Windows.Forms.DataGridView dgvArtilheiros;
        private System.Windows.Forms.Button btnGerarHTML_Classificacao;
        private System.Windows.Forms.Button btnGerarHTML_Artilheiros;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cboCamposBusca;
        private System.Windows.Forms.Label lblBuscarPor;
        private System.Windows.Forms.Label lblBusca;
        private System.Windows.Forms.TextBox txtBusca;
    }
}