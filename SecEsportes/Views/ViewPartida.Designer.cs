﻿namespace SecEsportes.Views
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewPartida));
            this.lblTime1 = new System.Windows.Forms.Label();
            this.lblCompeticao = new System.Windows.Forms.Label();
            this.tlpPartida = new System.Windows.Forms.TableLayoutPanel();
            this.lblGols2 = new System.Windows.Forms.Label();
            this.lblGols1 = new System.Windows.Forms.Label();
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
            this.logoEquipe1 = new System.Windows.Forms.PictureBox();
            this.logoEquipe2 = new System.Windows.Forms.PictureBox();
            this.btnDisputaPenaltis = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tlpPartida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipe2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoEquipe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoEquipe2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDisputaPenaltis)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTime1
            // 
            this.lblTime1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTime1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime1.Location = new System.Drawing.Point(3, 0);
            this.lblTime1.Name = "lblTime1";
            this.lblTime1.Size = new System.Drawing.Size(279, 26);
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
            this.tlpPartida.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.tlpPartida.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpPartida.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpPartida.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpPartida.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.tlpPartida.Controls.Add(this.lblGols2, 4, 4);
            this.tlpPartida.Controls.Add(this.lblGols1, 0, 4);
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
            this.tlpPartida.Location = new System.Drawing.Point(12, 100);
            this.tlpPartida.Name = "tlpPartida";
            this.tlpPartida.RowCount = 5;
            this.tlpPartida.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpPartida.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpPartida.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpPartida.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpPartida.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpPartida.Size = new System.Drawing.Size(684, 112);
            this.tlpPartida.TabIndex = 2;
            // 
            // lblGols2
            // 
            this.lblGols2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGols2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGols2.Location = new System.Drawing.Point(402, 67);
            this.lblGols2.Name = "lblGols2";
            this.lblGols2.Size = new System.Drawing.Size(279, 45);
            this.lblGols2.TabIndex = 11;
            this.lblGols2.Text = "Gols:";
            this.lblGols2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblGols1
            // 
            this.lblGols1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGols1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGols1.Location = new System.Drawing.Point(3, 67);
            this.lblGols1.Name = "lblGols1";
            this.lblGols1.Size = new System.Drawing.Size(279, 45);
            this.lblGols1.TabIndex = 10;
            this.lblGols1.Text = "Gols: ";
            // 
            // lblPlacarTime2_Penalti
            // 
            this.lblPlacarTime2_Penalti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlacarTime2_Penalti.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlacarTime2_Penalti.Location = new System.Drawing.Point(357, 26);
            this.lblPlacarTime2_Penalti.Name = "lblPlacarTime2_Penalti";
            this.lblPlacarTime2_Penalti.Size = new System.Drawing.Size(39, 18);
            this.lblPlacarTime2_Penalti.TabIndex = 9;
            this.lblPlacarTime2_Penalti.Text = "0";
            this.lblPlacarTime2_Penalti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlacarTime2_Penalti.Visible = false;
            // 
            // lblPlacarTime1_Penalti
            // 
            this.lblPlacarTime1_Penalti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlacarTime1_Penalti.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlacarTime1_Penalti.Location = new System.Drawing.Point(288, 26);
            this.lblPlacarTime1_Penalti.Name = "lblPlacarTime1_Penalti";
            this.lblPlacarTime1_Penalti.Size = new System.Drawing.Size(39, 18);
            this.lblPlacarTime1_Penalti.TabIndex = 8;
            this.lblPlacarTime1_Penalti.Text = "0";
            this.lblPlacarTime1_Penalti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlacarTime1_Penalti.Visible = false;
            // 
            // lblRepresentante1
            // 
            this.lblRepresentante1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRepresentante1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepresentante1.Location = new System.Drawing.Point(3, 44);
            this.lblRepresentante1.Name = "lblRepresentante1";
            this.lblRepresentante1.Size = new System.Drawing.Size(279, 18);
            this.lblRepresentante1.TabIndex = 7;
            this.lblRepresentante1.Text = "Representante: ";
            this.lblRepresentante1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTecnico2
            // 
            this.lblTecnico2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTecnico2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTecnico2.Location = new System.Drawing.Point(402, 26);
            this.lblTecnico2.Name = "lblTecnico2";
            this.lblTecnico2.Size = new System.Drawing.Size(279, 18);
            this.lblTecnico2.TabIndex = 6;
            this.lblTecnico2.Text = "Técnico: ";
            this.lblTecnico2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRepresentante2
            // 
            this.lblRepresentante2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRepresentante2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepresentante2.Location = new System.Drawing.Point(402, 44);
            this.lblRepresentante2.Name = "lblRepresentante2";
            this.lblRepresentante2.Size = new System.Drawing.Size(279, 18);
            this.lblRepresentante2.TabIndex = 5;
            this.lblRepresentante2.Text = "Representante: ";
            this.lblRepresentante2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTecnico1
            // 
            this.lblTecnico1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTecnico1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTecnico1.Location = new System.Drawing.Point(3, 26);
            this.lblTecnico1.Name = "lblTecnico1";
            this.lblTecnico1.Size = new System.Drawing.Size(279, 18);
            this.lblTecnico1.TabIndex = 4;
            this.lblTecnico1.Text = "Técnico: ";
            this.lblTecnico1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlacarTime2
            // 
            this.lblPlacarTime2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlacarTime2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlacarTime2.Location = new System.Drawing.Point(357, 0);
            this.lblPlacarTime2.Name = "lblPlacarTime2";
            this.lblPlacarTime2.Size = new System.Drawing.Size(39, 26);
            this.lblPlacarTime2.TabIndex = 3;
            this.lblPlacarTime2.Text = "0";
            this.lblPlacarTime2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlacarTime1
            // 
            this.lblPlacarTime1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlacarTime1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlacarTime1.Location = new System.Drawing.Point(288, 0);
            this.lblPlacarTime1.Name = "lblPlacarTime1";
            this.lblPlacarTime1.Size = new System.Drawing.Size(39, 26);
            this.lblPlacarTime1.TabIndex = 2;
            this.lblPlacarTime1.Text = "0";
            this.lblPlacarTime1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime2
            // 
            this.lblTime2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTime2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime2.Location = new System.Drawing.Point(402, 0);
            this.lblTime2.Name = "lblTime2";
            this.lblTime2.Size = new System.Drawing.Size(279, 26);
            this.lblTime2.TabIndex = 1;
            this.lblTime2.Text = "Visitante";
            this.lblTime2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvEquipe1
            // 
            this.dgvEquipe1.AllowUserToAddRows = false;
            this.dgvEquipe1.AllowUserToDeleteRows = false;
            this.dgvEquipe1.AllowUserToOrderColumns = true;
            this.dgvEquipe1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvEquipe1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipe1.Location = new System.Drawing.Point(12, 217);
            this.dgvEquipe1.MultiSelect = false;
            this.dgvEquipe1.Name = "dgvEquipe1";
            this.dgvEquipe1.ReadOnly = true;
            this.dgvEquipe1.Size = new System.Drawing.Size(321, 290);
            this.dgvEquipe1.TabIndex = 6;
            this.dgvEquipe1.Tag = "1";
            this.dgvEquipe1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEquipe_CellMouseClick);
            // 
            // dgvEquipe2
            // 
            this.dgvEquipe2.AllowUserToAddRows = false;
            this.dgvEquipe2.AllowUserToDeleteRows = false;
            this.dgvEquipe2.AllowUserToOrderColumns = true;
            this.dgvEquipe2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvEquipe2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipe2.Location = new System.Drawing.Point(375, 217);
            this.dgvEquipe2.MultiSelect = false;
            this.dgvEquipe2.Name = "dgvEquipe2";
            this.dgvEquipe2.ReadOnly = true;
            this.dgvEquipe2.Size = new System.Drawing.Size(321, 290);
            this.dgvEquipe2.TabIndex = 7;
            this.dgvEquipe2.Tag = "2";
            this.dgvEquipe2.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEquipe_CellMouseClick);
            // 
            // btnEncerrarPartida
            // 
            this.btnEncerrarPartida.Location = new System.Drawing.Point(603, 41);
            this.btnEncerrarPartida.Name = "btnEncerrarPartida";
            this.btnEncerrarPartida.Size = new System.Drawing.Size(87, 23);
            this.btnEncerrarPartida.TabIndex = 16;
            this.btnEncerrarPartida.Text = "Encerrar partida";
            this.btnEncerrarPartida.UseVisualStyleBackColor = true;
            this.btnEncerrarPartida.Click += new System.EventHandler(this.btnEncerrarPartida_Click);
            // 
            // btnIniciarPartida
            // 
            this.btnIniciarPartida.Location = new System.Drawing.Point(510, 41);
            this.btnIniciarPartida.Name = "btnIniciarPartida";
            this.btnIniciarPartida.Size = new System.Drawing.Size(87, 23);
            this.btnIniciarPartida.TabIndex = 17;
            this.btnIniciarPartida.Text = "Iniciar partida";
            this.btnIniciarPartida.UseVisualStyleBackColor = true;
            this.btnIniciarPartida.Click += new System.EventHandler(this.btnIniciarPartida_Click);
            // 
            // logoEquipe1
            // 
            this.logoEquipe1.Location = new System.Drawing.Point(12, 48);
            this.logoEquipe1.Margin = new System.Windows.Forms.Padding(0);
            this.logoEquipe1.Name = "logoEquipe1";
            this.logoEquipe1.Size = new System.Drawing.Size(50, 50);
            this.logoEquipe1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoEquipe1.TabIndex = 19;
            this.logoEquipe1.TabStop = false;
            // 
            // logoEquipe2
            // 
            this.logoEquipe2.Location = new System.Drawing.Point(646, 48);
            this.logoEquipe2.Margin = new System.Windows.Forms.Padding(0);
            this.logoEquipe2.Name = "logoEquipe2";
            this.logoEquipe2.Size = new System.Drawing.Size(50, 50);
            this.logoEquipe2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoEquipe2.TabIndex = 20;
            this.logoEquipe2.TabStop = false;
            // 
            // btnDisputaPenaltis
            // 
            this.btnDisputaPenaltis.Image = global::SecEsportes.Properties.Resources.penaltis;
            this.btnDisputaPenaltis.Location = new System.Drawing.Point(330, 50);
            this.btnDisputaPenaltis.Name = "btnDisputaPenaltis";
            this.btnDisputaPenaltis.Size = new System.Drawing.Size(50, 50);
            this.btnDisputaPenaltis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDisputaPenaltis.TabIndex = 21;
            this.btnDisputaPenaltis.TabStop = false;
            this.btnDisputaPenaltis.Tag = "Iniciar disputa de pênaltis";
            this.btnDisputaPenaltis.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnDisputaPenaltis.Click += new System.EventHandler(this.btnDisputaPenaltis_Click);
            // 
            // ViewPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 513);
            this.Controls.Add(this.btnDisputaPenaltis);
            this.Controls.Add(this.logoEquipe2);
            this.Controls.Add(this.logoEquipe1);
            this.Controls.Add(this.btnIniciarPartida);
            this.Controls.Add(this.btnEncerrarPartida);
            this.Controls.Add(this.dgvEquipe2);
            this.Controls.Add(this.dgvEquipe1);
            this.Controls.Add(this.tlpPartida);
            this.Controls.Add(this.lblCompeticao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ViewPartida";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowInTaskbar = false;
            this.Text = "Partida";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewPartida_FormClosing);
            this.Load += new System.EventHandler(this.load);
            this.tlpPartida.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipe2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoEquipe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoEquipe2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDisputaPenaltis)).EndInit();
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
        private System.Windows.Forms.Label lblGols2;
        private System.Windows.Forms.Label lblGols1;
        private System.Windows.Forms.PictureBox logoEquipe1;
        private System.Windows.Forms.PictureBox logoEquipe2;
        private System.Windows.Forms.PictureBox btnDisputaPenaltis;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}