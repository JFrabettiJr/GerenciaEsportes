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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditArbitros));
            this.dgvArbitros = new System.Windows.Forms.DataGridView();
            this.btnExcluirArbitro = new System.Windows.Forms.PictureBox();
            this.btnIncluirArbitro = new System.Windows.Forms.PictureBox();
            this.btnAtualizar = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArbitros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcluirArbitro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIncluirArbitro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtualizar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArbitros
            // 
            this.dgvArbitros.AllowUserToAddRows = false;
            this.dgvArbitros.AllowUserToDeleteRows = false;
            this.dgvArbitros.AllowUserToOrderColumns = true;
            this.dgvArbitros.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArbitros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArbitros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArbitros.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvArbitros.Location = new System.Drawing.Point(10, 53);
            this.dgvArbitros.MultiSelect = false;
            this.dgvArbitros.Name = "dgvArbitros";
            this.dgvArbitros.Size = new System.Drawing.Size(560, 355);
            this.dgvArbitros.TabIndex = 5;
            this.dgvArbitros.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArbitros_RowEnter);
            // 
            // btnExcluirArbitro
            // 
            this.btnExcluirArbitro.Image = global::SecEsportes.Properties.Resources.excluir_arbitro;
            this.btnExcluirArbitro.Location = new System.Drawing.Point(535, 12);
            this.btnExcluirArbitro.Name = "btnExcluirArbitro";
            this.btnExcluirArbitro.Size = new System.Drawing.Size(35, 35);
            this.btnExcluirArbitro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnExcluirArbitro.TabIndex = 30;
            this.btnExcluirArbitro.TabStop = false;
            this.btnExcluirArbitro.Tag = "Excluir árbitro da competição";
            this.btnExcluirArbitro.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnExcluirArbitro.Click += new System.EventHandler(this.btnExcluirArbitro_Click);
            // 
            // btnIncluirArbitro
            // 
            this.btnIncluirArbitro.Image = global::SecEsportes.Properties.Resources.adicionar_arbitro;
            this.btnIncluirArbitro.Location = new System.Drawing.Point(494, 12);
            this.btnIncluirArbitro.Name = "btnIncluirArbitro";
            this.btnIncluirArbitro.Size = new System.Drawing.Size(35, 35);
            this.btnIncluirArbitro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnIncluirArbitro.TabIndex = 29;
            this.btnIncluirArbitro.TabStop = false;
            this.btnIncluirArbitro.Tag = "Adicionar árbitros na competição";
            this.btnIncluirArbitro.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnIncluirArbitro.Click += new System.EventHandler(this.btnIncluirArbitro_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Image = global::SecEsportes.Properties.Resources.crud_recarregar;
            this.btnAtualizar.Location = new System.Drawing.Point(10, 12);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(35, 35);
            this.btnAtualizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAtualizar.TabIndex = 28;
            this.btnAtualizar.TabStop = false;
            this.btnAtualizar.Tag = "Recarregar árbitros da competição";
            this.btnAtualizar.EnabledChanged += new System.EventHandler(this.btn_EnableChanged);
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // EditArbitros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 421);
            this.Controls.Add(this.btnExcluirArbitro);
            this.Controls.Add(this.btnIncluirArbitro);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.dgvArbitros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditArbitros";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowInTaskbar = false;
            this.Text = "Inserção de árbitros";
            this.Load += new System.EventHandler(this.load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArbitros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcluirArbitro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIncluirArbitro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtualizar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvArbitros;
        private System.Windows.Forms.PictureBox btnExcluirArbitro;
        private System.Windows.Forms.PictureBox btnIncluirArbitro;
        private System.Windows.Forms.PictureBox btnAtualizar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}