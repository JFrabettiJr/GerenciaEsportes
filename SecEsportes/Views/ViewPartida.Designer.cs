namespace SecEsportes.Views
{
    partial class ViewPartida {
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
            this.lblTime1 = new System.Windows.Forms.Label();
            this.lblCompeticao = new System.Windows.Forms.Label();
            this.tlpPartida = new System.Windows.Forms.TableLayoutPanel();
            this.lblPlacarTime2_Penalti = new System.Windows.Forms.Label();
            this.lblPlacarTime1_Penalti = new System.Windows.Forms.Label();
            this.lblRepresentante1 = new System.Windows.Forms.Label();
            this.lblTecnico2 = new System.Windows.Forms.Label();
            this.lblRepresentante2 = new System.Windows.Forms.Label();
            this.lblTecnico1 = new System.Windows.Forms.Label();
            this.lblPlacarTime2 = new System.Windows.Forms.Label();
            this.lblPlacarTime1 = new System.Windows.Forms.Label();
            this.lblTime2 = new System.Windows.Forms.Label();
            this.dgvEquipe1 = new System.Windows.Forms.DataGridView();
            this.dgvEquipe2 = new System.Windows.Forms.DataGridView();
            this.btnEncerrarPartida = new System.Windows.Forms.Button();
            this.btnIniciarPartida = new System.Windows.Forms.Button();
            this.btnDisputaPenaltis = new System.Windows.Forms.Button();
            this.tlpPartida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipe2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTime1
            // 
            this.lblTime1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTime1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime1.Location = new System.Drawing.Point(3, 0);
            this.lblTime1.Name = "lblTime1";
            this.lblTime1.Size = new System.Drawing.Size(267, 34);
            this.lblTime1.TabIndex = 0;
            this.lblTime1.Text = "Casa";
            this.lblTime1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompeticao
            // 
            this.lblCompeticao.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompeticao.Location = new System.Drawing.Point(7, 4);
            this.lblCompeticao.Name = "lblCompeticao";
            this.lblCompeticao.Size = new System.Drawing.Size(689, 34);
            this.lblCompeticao.TabIndex = 1;
            this.lblCompeticao.Text = "Competição";
            this.lblCompeticao.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tlpPartida
            // 
            this.tlpPartida.ColumnCount = 5;
            this.tlpPartida.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpPartida.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tlpPartida.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpPartida.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tlpPartida.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpPartida.Controls.Add(this.lblPlacarTime2_Penalti, 3, 1);
            this.tlpPartida.Controls.Add(this.lblPlacarTime1_Penalti, 1, 1);
            this.tlpPartida.Controls.Add(this.lblRepresentante1, 0, 2);
            this.tlpPartida.Controls.Add(this.lblTecnico2, 4, 1);
            this.tlpPartida.Controls.Add(this.lblRepresentante2, 4, 2);
            this.tlpPartida.Controls.Add(this.lblTecnico1, 0, 1);
            this.tlpPartida.Controls.Add(this.lblPlacarTime2, 3, 0);
            this.tlpPartida.Controls.Add(this.lblPlacarTime1, 1, 0);
            this.tlpPartida.Controls.Add(this.lblTime2, 4, 0);
            this.tlpPartida.Controls.Add(this.lblTime1, 0, 0);
            this.tlpPartida.Location = new System.Drawing.Point(12, 105);
            this.tlpPartida.Name = "tlpPartida";
            this.tlpPartida.RowCount = 3;
            this.tlpPartida.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPartida.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpPartida.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpPartida.Size = new System.Drawing.Size(684, 70);
            this.tlpPartida.TabIndex = 2;
            // 
            // lblPlacarTime2_Penalti
            // 
            this.lblPlacarTime2_Penalti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlacarTime2_Penalti.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlacarTime2_Penalti.Location = new System.Drawing.Point(361, 34);
            this.lblPlacarTime2_Penalti.Name = "lblPlacarTime2_Penalti";
            this.lblPlacarTime2_Penalti.Size = new System.Drawing.Size(45, 18);
            this.lblPlacarTime2_Penalti.TabIndex = 9;
            this.lblPlacarTime2_Penalti.Text = "0";
            this.lblPlacarTime2_Penalti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlacarTime2_Penalti.Visible = false;
            // 
            // lblPlacarTime1_Penalti
            // 
            this.lblPlacarTime1_Penalti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlacarTime1_Penalti.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlacarTime1_Penalti.Location = new System.Drawing.Point(276, 34);
            this.lblPlacarTime1_Penalti.Name = "lblPlacarTime1_Penalti";
            this.lblPlacarTime1_Penalti.Size = new System.Drawing.Size(45, 18);
            this.lblPlacarTime1_Penalti.TabIndex = 8;
            this.lblPlacarTime1_Penalti.Text = "0";
            this.lblPlacarTime1_Penalti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlacarTime1_Penalti.Visible = false;
            // 
            // lblRepresentante1
            // 
            this.lblRepresentante1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRepresentante1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepresentante1.Location = new System.Drawing.Point(3, 52);
            this.lblRepresentante1.Name = "lblRepresentante1";
            this.lblRepresentante1.Size = new System.Drawing.Size(267, 18);
            this.lblRepresentante1.TabIndex = 7;
            this.lblRepresentante1.Text = "Representante: ";
            this.lblRepresentante1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTecnico2
            // 
            this.lblTecnico2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTecnico2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTecnico2.Location = new System.Drawing.Point(412, 34);
            this.lblTecnico2.Name = "lblTecnico2";
            this.lblTecnico2.Size = new System.Drawing.Size(269, 18);
            this.lblTecnico2.TabIndex = 6;
            this.lblTecnico2.Text = "Técnico: ";
            this.lblTecnico2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRepresentante2
            // 
            this.lblRepresentante2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRepresentante2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepresentante2.Location = new System.Drawing.Point(412, 52);
            this.lblRepresentante2.Name = "lblRepresentante2";
            this.lblRepresentante2.Size = new System.Drawing.Size(269, 18);
            this.lblRepresentante2.TabIndex = 5;
            this.lblRepresentante2.Text = "Representante: ";
            this.lblRepresentante2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTecnico1
            // 
            this.lblTecnico1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTecnico1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTecnico1.Location = new System.Drawing.Point(3, 34);
            this.lblTecnico1.Name = "lblTecnico1";
            this.lblTecnico1.Size = new System.Drawing.Size(267, 18);
            this.lblTecnico1.TabIndex = 4;
            this.lblTecnico1.Text = "Técnico: ";
            this.lblTecnico1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlacarTime2
            // 
            this.lblPlacarTime2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlacarTime2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlacarTime2.Location = new System.Drawing.Point(361, 0);
            this.lblPlacarTime2.Name = "lblPlacarTime2";
            this.lblPlacarTime2.Size = new System.Drawing.Size(45, 34);
            this.lblPlacarTime2.TabIndex = 3;
            this.lblPlacarTime2.Text = "0";
            this.lblPlacarTime2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlacarTime1
            // 
            this.lblPlacarTime1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlacarTime1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlacarTime1.Location = new System.Drawing.Point(276, 0);
            this.lblPlacarTime1.Name = "lblPlacarTime1";
            this.lblPlacarTime1.Size = new System.Drawing.Size(45, 34);
            this.lblPlacarTime1.TabIndex = 2;
            this.lblPlacarTime1.Text = "0";
            this.lblPlacarTime1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime2
            // 
            this.lblTime2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTime2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime2.Location = new System.Drawing.Point(412, 0);
            this.lblTime2.Name = "lblTime2";
            this.lblTime2.Size = new System.Drawing.Size(269, 34);
            this.lblTime2.TabIndex = 1;
            this.lblTime2.Text = "Visitante";
            this.lblTime2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvEquipe1
            // 
            this.dgvEquipe1.AllowUserToAddRows = false;
            this.dgvEquipe1.AllowUserToDeleteRows = false;
            this.dgvEquipe1.AllowUserToOrderColumns = true;
            this.dgvEquipe1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipe1.Location = new System.Drawing.Point(12, 181);
            this.dgvEquipe1.MultiSelect = false;
            this.dgvEquipe1.Name = "dgvEquipe1";
            this.dgvEquipe1.ReadOnly = true;
            this.dgvEquipe1.Size = new System.Drawing.Size(321, 320);
            this.dgvEquipe1.TabIndex = 6;
            this.dgvEquipe1.Tag = "1";
            this.dgvEquipe1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEquipe_CellMouseClick);
            // 
            // dgvEquipe2
            // 
            this.dgvEquipe2.AllowUserToAddRows = false;
            this.dgvEquipe2.AllowUserToDeleteRows = false;
            this.dgvEquipe2.AllowUserToOrderColumns = true;
            this.dgvEquipe2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipe2.Location = new System.Drawing.Point(375, 181);
            this.dgvEquipe2.MultiSelect = false;
            this.dgvEquipe2.Name = "dgvEquipe2";
            this.dgvEquipe2.ReadOnly = true;
            this.dgvEquipe2.Size = new System.Drawing.Size(321, 320);
            this.dgvEquipe2.TabIndex = 7;
            this.dgvEquipe2.Tag = "2";
            this.dgvEquipe2.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEquipe_CellMouseClick);
            // 
            // btnEncerrarPartida
            // 
            this.btnEncerrarPartida.Location = new System.Drawing.Point(556, 51);
            this.btnEncerrarPartida.Name = "btnEncerrarPartida";
            this.btnEncerrarPartida.Size = new System.Drawing.Size(140, 23);
            this.btnEncerrarPartida.TabIndex = 16;
            this.btnEncerrarPartida.Text = "Encerrar partida";
            this.btnEncerrarPartida.UseVisualStyleBackColor = true;
            this.btnEncerrarPartida.Click += new System.EventHandler(this.btnEncerrarPartida_Click);
            // 
            // btnIniciarPartida
            // 
            this.btnIniciarPartida.Location = new System.Drawing.Point(410, 51);
            this.btnIniciarPartida.Name = "btnIniciarPartida";
            this.btnIniciarPartida.Size = new System.Drawing.Size(140, 23);
            this.btnIniciarPartida.TabIndex = 17;
            this.btnIniciarPartida.Text = "Iniciar partida";
            this.btnIniciarPartida.UseVisualStyleBackColor = true;
            this.btnIniciarPartida.Click += new System.EventHandler(this.btnIniciarPartida_Click);
            // 
            // btnDisputaPenaltis
            // 
            this.btnDisputaPenaltis.Enabled = false;
            this.btnDisputaPenaltis.Location = new System.Drawing.Point(292, 80);
            this.btnDisputaPenaltis.Name = "btnDisputaPenaltis";
            this.btnDisputaPenaltis.Size = new System.Drawing.Size(126, 23);
            this.btnDisputaPenaltis.TabIndex = 18;
            this.btnDisputaPenaltis.Text = "Disputa de penaltis";
            this.btnDisputaPenaltis.UseVisualStyleBackColor = true;
            this.btnDisputaPenaltis.Click += new System.EventHandler(this.btnDisputaPenaltis_Click);
            // 
            // ViewPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 513);
            this.Controls.Add(this.btnDisputaPenaltis);
            this.Controls.Add(this.btnIniciarPartida);
            this.Controls.Add(this.btnEncerrarPartida);
            this.Controls.Add(this.dgvEquipe2);
            this.Controls.Add(this.dgvEquipe1);
            this.Controls.Add(this.tlpPartida);
            this.Controls.Add(this.lblCompeticao);
            this.Name = "ViewPartida";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Cadastro de competições";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewPartida_FormClosing);
            this.Load += new System.EventHandler(this.load);
            this.tlpPartida.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipe2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTime1;
        private System.Windows.Forms.Label lblCompeticao;
        private System.Windows.Forms.TableLayoutPanel tlpPartida;
        private System.Windows.Forms.Label lblTime2;
        private System.Windows.Forms.Label lblPlacarTime1;
        private System.Windows.Forms.Label lblTecnico1;
        private System.Windows.Forms.Label lblRepresentante2;
        private System.Windows.Forms.Label lblRepresentante1;
        private System.Windows.Forms.Label lblTecnico2;
        private System.Windows.Forms.DataGridView dgvEquipe1;
        private System.Windows.Forms.DataGridView dgvEquipe2;
        private System.Windows.Forms.Button btnEncerrarPartida;
        private System.Windows.Forms.Button btnIniciarPartida;
        private System.Windows.Forms.Label lblPlacarTime2;
        private System.Windows.Forms.Label lblPlacarTime1_Penalti;
        private System.Windows.Forms.Label lblPlacarTime2_Penalti;
        private System.Windows.Forms.Button btnDisputaPenaltis;
    }
}