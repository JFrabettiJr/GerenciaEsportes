namespace SecEsportes.Views
{
    partial class EditArbitros {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditArbitros));
            this.dgvArbitros = new System.Windows.Forms.DataGridView();
            this.btnExcluirArbitro = new System.Windows.Forms.Button();
            this.btnIncluirArbitro = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArbitros)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArbitros
            // 
            this.dgvArbitros.AllowUserToAddRows = false;
            this.dgvArbitros.AllowUserToDeleteRows = false;
            this.dgvArbitros.AllowUserToOrderColumns = true;
            this.dgvArbitros.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvArbitros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArbitros.Location = new System.Drawing.Point(10, 41);
            this.dgvArbitros.MultiSelect = false;
            this.dgvArbitros.Name = "dgvArbitros";
            this.dgvArbitros.Size = new System.Drawing.Size(560, 367);
            this.dgvArbitros.TabIndex = 5;
            this.dgvArbitros.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArbitros_RowEnter);
            // 
            // btnExcluirArbitro
            // 
            this.btnExcluirArbitro.Location = new System.Drawing.Point(447, 12);
            this.btnExcluirArbitro.Name = "btnExcluirArbitro";
            this.btnExcluirArbitro.Size = new System.Drawing.Size(122, 23);
            this.btnExcluirArbitro.TabIndex = 15;
            this.btnExcluirArbitro.Text = "Excluir árbitro";
            this.btnExcluirArbitro.UseVisualStyleBackColor = true;
            this.btnExcluirArbitro.Click += new System.EventHandler(this.btnExcluirArbitro_Click);
            // 
            // btnIncluirArbitro
            // 
            this.btnIncluirArbitro.Location = new System.Drawing.Point(319, 12);
            this.btnIncluirArbitro.Name = "btnIncluirArbitro";
            this.btnIncluirArbitro.Size = new System.Drawing.Size(122, 23);
            this.btnIncluirArbitro.TabIndex = 14;
            this.btnIncluirArbitro.Text = "Incluir árbitros";
            this.btnIncluirArbitro.UseVisualStyleBackColor = true;
            this.btnIncluirArbitro.Click += new System.EventHandler(this.btnIncluirArbitro_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(10, 12);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 19;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // EditArbitros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 421);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnExcluirArbitro);
            this.Controls.Add(this.btnIncluirArbitro);
            this.Controls.Add(this.dgvArbitros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditArbitros";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowInTaskbar = false;
            this.Text = "Inserção de árbitros";
            this.Load += new System.EventHandler(this.load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArbitros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvArbitros;
        private System.Windows.Forms.Button btnExcluirArbitro;
        private System.Windows.Forms.Button btnIncluirArbitro;
        private System.Windows.Forms.Button btnAtualizar;
    }
}