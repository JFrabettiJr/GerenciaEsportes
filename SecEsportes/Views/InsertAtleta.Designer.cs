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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertAtleta));
            this.btnInserir = new System.Windows.Forms.Button();
            this.dgvAtletas = new System.Windows.Forms.DataGridView();
            this.btnMarcarTudo = new System.Windows.Forms.Button();
            this.btnDesmarcarTudo = new System.Windows.Forms.Button();
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
            this.dgvAtletas.Size = new System.Drawing.Size(410, 340);
            this.dgvAtletas.TabIndex = 5;
            // 
            // btnMarcarTudo
            // 
            this.btnMarcarTudo.Location = new System.Drawing.Point(10, 385);
            this.btnMarcarTudo.Name = "btnMarcarTudo";
            this.btnMarcarTudo.Size = new System.Drawing.Size(91, 23);
            this.btnMarcarTudo.TabIndex = 6;
            this.btnMarcarTudo.Text = "Marcar tudo";
            this.btnMarcarTudo.UseVisualStyleBackColor = true;
            this.btnMarcarTudo.Click += new System.EventHandler(this.btnMarcarTudo_Click);
            // 
            // btnDesmarcarTudo
            // 
            this.btnDesmarcarTudo.Location = new System.Drawing.Point(107, 385);
            this.btnDesmarcarTudo.Name = "btnDesmarcarTudo";
            this.btnDesmarcarTudo.Size = new System.Drawing.Size(91, 23);
            this.btnDesmarcarTudo.TabIndex = 7;
            this.btnDesmarcarTudo.Text = "Desmarcar tudo";
            this.btnDesmarcarTudo.UseVisualStyleBackColor = true;
            this.btnDesmarcarTudo.Click += new System.EventHandler(this.btnDesmarcarTudo_Click);
            // 
            // InsertAtleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 421);
            this.Controls.Add(this.btnDesmarcarTudo);
            this.Controls.Add(this.btnMarcarTudo);
            this.Controls.Add(this.dgvAtletas);
            this.Controls.Add(this.btnInserir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Button btnMarcarTudo;
        private System.Windows.Forms.Button btnDesmarcarTudo;
    }
}