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
            this.lblFase = new System.Windows.Forms.Label();
            this.btnProximaFase = new System.Windows.Forms.Button();
            this.tcPartidas = new System.Windows.Forms.TabControl();
            this.tpClassificacao = new System.Windows.Forms.TabPage();
            this.tcClassificacao = new System.Windows.Forms.TabControl();
            this.tpArtilheiros = new System.Windows.Forms.TabPage();
            this.dgvArtilheiros = new System.Windows.Forms.DataGridView();
            this.tcAbas.SuspendLayout();
            this.tpPartidas.SuspendLayout();
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
            this.tcAbas.Location = new System.Drawing.Point(13, 45);
            this.tcAbas.Name = "tcAbas";
            this.tcAbas.SelectedIndex = 0;
            this.tcAbas.Size = new System.Drawing.Size(713, 481);
            this.tcAbas.TabIndex = 1;
            // 
            // tpPartidas
            // 
            this.tpPartidas.Controls.Add(this.lblFase);
            this.tpPartidas.Controls.Add(this.btnProximaFase);
            this.tpPartidas.Controls.Add(this.tcPartidas);
            this.tpPartidas.Location = new System.Drawing.Point(4, 22);
            this.tpPartidas.Name = "tpPartidas";
            this.tpPartidas.Padding = new System.Windows.Forms.Padding(3);
            this.tpPartidas.Size = new System.Drawing.Size(705, 455);
            this.tpPartidas.TabIndex = 0;
            this.tpPartidas.Text = "Partidas";
            this.tpPartidas.UseVisualStyleBackColor = true;
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
            this.tcPartidas.Location = new System.Drawing.Point(6, 35);
            this.tcPartidas.Name = "tcPartidas";
            this.tcPartidas.SelectedIndex = 0;
            this.tcPartidas.Size = new System.Drawing.Size(693, 412);
            this.tcPartidas.TabIndex = 11;
            // 
            // tpClassificacao
            // 
            this.tpClassificacao.Controls.Add(this.tcClassificacao);
            this.tpClassificacao.Location = new System.Drawing.Point(4, 22);
            this.tpClassificacao.Name = "tpClassificacao";
            this.tpClassificacao.Padding = new System.Windows.Forms.Padding(3);
            this.tpClassificacao.Size = new System.Drawing.Size(705, 455);
            this.tpClassificacao.TabIndex = 1;
            this.tpClassificacao.Text = "Classificação";
            this.tpClassificacao.UseVisualStyleBackColor = true;
            // 
            // tcClassificacao
            // 
            this.tcClassificacao.Location = new System.Drawing.Point(6, 6);
            this.tcClassificacao.Name = "tcClassificacao";
            this.tcClassificacao.SelectedIndex = 0;
            this.tcClassificacao.Size = new System.Drawing.Size(693, 440);
            this.tcClassificacao.TabIndex = 10;
            // 
            // tpArtilheiros
            // 
            this.tpArtilheiros.Controls.Add(this.dgvArtilheiros);
            this.tpArtilheiros.Location = new System.Drawing.Point(4, 22);
            this.tpArtilheiros.Name = "tpArtilheiros";
            this.tpArtilheiros.Padding = new System.Windows.Forms.Padding(3);
            this.tpArtilheiros.Size = new System.Drawing.Size(705, 455);
            this.tpArtilheiros.TabIndex = 2;
            this.tpArtilheiros.Text = "Artilheiros";
            this.tpArtilheiros.UseVisualStyleBackColor = true;
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
            this.dgvArtilheiros.Size = new System.Drawing.Size(693, 440);
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
            this.Name = "ViewCompeticao";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Visão geral da competição";
            this.Load += new System.EventHandler(this.load);
            this.tcAbas.ResumeLayout(false);
            this.tpPartidas.ResumeLayout(false);
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
    }
}