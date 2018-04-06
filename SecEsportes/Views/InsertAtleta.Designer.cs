namespace SecEsportes.Views
{
    partial class InsertAtleta
    {
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
            this.btnInserir = new System.Windows.Forms.Button();
            this.dgvAtletas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtletas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(10, 10);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(410, 23);
            this.btnInserir.TabIndex = 2;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // dgvAtletas
            // 
            this.dgvAtletas.AllowUserToAddRows = false;
            this.dgvAtletas.AllowUserToDeleteRows = false;
            this.dgvAtletas.AllowUserToOrderColumns = true;
            this.dgvAtletas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAtletas.Location = new System.Drawing.Point(10, 39);
            this.dgvAtletas.MultiSelect = false;
            this.dgvAtletas.Name = "dgvAtletas";
            this.dgvAtletas.Size = new System.Drawing.Size(410, 363);
            this.dgvAtletas.TabIndex = 5;
            // 
            // InsertAtleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 421);
            this.Controls.Add(this.dgvAtletas);
            this.Controls.Add(this.btnInserir);
            this.Name = "InsertAtleta";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Inserir atletas na equipe";
            this.Load += new System.EventHandler(this.InsertAtleta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtletas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.DataGridView dgvAtletas;
    }
}