namespace SecEsportes
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tlp2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEquipe = new System.Windows.Forms.Button();
            this.tlp5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCadFuncao = new System.Windows.Forms.Button();
            this.tlp3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPessoas = new System.Windows.Forms.Button();
            this.tlp1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCompeticoes = new System.Windows.Forms.Button();
            this.btnIncluirTestes = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSecEsportes = new System.Windows.Forms.Label();
            this.tlp4 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCadUsuario = new System.Windows.Forms.Button();
            this.tlp2.SuspendLayout();
            this.tlp5.SuspendLayout();
            this.tlp3.SuspendLayout();
            this.tlp1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tlp4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp2
            // 
            this.tlp2.ColumnCount = 1;
            this.tlp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp2.Controls.Add(this.btnEquipe, 0, 0);
            this.tlp2.Location = new System.Drawing.Point(266, 121);
            this.tlp2.Name = "tlp2";
            this.tlp2.RowCount = 1;
            this.tlp2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp2.Size = new System.Drawing.Size(206, 56);
            this.tlp2.TabIndex = 0;
            // 
            // btnEquipe
            // 
            this.btnEquipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEquipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnEquipe.Location = new System.Drawing.Point(3, 3);
            this.btnEquipe.Name = "btnEquipe";
            this.btnEquipe.Size = new System.Drawing.Size(200, 50);
            this.btnEquipe.TabIndex = 1;
            this.btnEquipe.Text = "Cadastro de Equipes";
            this.btnEquipe.UseVisualStyleBackColor = true;
            this.btnEquipe.Click += new System.EventHandler(this.btnCadEquipes_Click);
            // 
            // tlp5
            // 
            this.tlp5.ColumnCount = 1;
            this.tlp5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp5.Controls.Add(this.btnCadUsuario, 0, 1);
            this.tlp5.Controls.Add(this.btnCadFuncao, 0, 0);
            this.tlp5.Location = new System.Drawing.Point(12, 271);
            this.tlp5.Name = "tlp5";
            this.tlp5.RowCount = 2;
            this.tlp5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlp5.Size = new System.Drawing.Size(206, 56);
            this.tlp5.TabIndex = 1;
            // 
            // btnCadFuncao
            // 
            this.btnCadFuncao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCadFuncao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnCadFuncao.Location = new System.Drawing.Point(3, 3);
            this.btnCadFuncao.Name = "btnCadFuncao";
            this.btnCadFuncao.Size = new System.Drawing.Size(200, 1);
            this.btnCadFuncao.TabIndex = 1;
            this.btnCadFuncao.Text = "Cadastro de Funções";
            this.btnCadFuncao.UseVisualStyleBackColor = true;
            this.btnCadFuncao.Click += new System.EventHandler(this.btnCadFuncao_Click);
            // 
            // tlp3
            // 
            this.tlp3.ColumnCount = 1;
            this.tlp3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp3.Controls.Add(this.btnPessoas, 0, 0);
            this.tlp3.Location = new System.Drawing.Point(12, 196);
            this.tlp3.Name = "tlp3";
            this.tlp3.RowCount = 1;
            this.tlp3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlp3.Size = new System.Drawing.Size(206, 56);
            this.tlp3.TabIndex = 2;
            // 
            // btnPessoas
            // 
            this.btnPessoas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPessoas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPessoas.Location = new System.Drawing.Point(3, 3);
            this.btnPessoas.Name = "btnPessoas";
            this.btnPessoas.Size = new System.Drawing.Size(200, 50);
            this.btnPessoas.TabIndex = 1;
            this.btnPessoas.Text = "Cadastro de Pessoas";
            this.btnPessoas.UseVisualStyleBackColor = true;
            this.btnPessoas.Click += new System.EventHandler(this.btnCadPessoa_Click);
            // 
            // tlp1
            // 
            this.tlp1.ColumnCount = 1;
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp1.Controls.Add(this.btnCompeticoes, 0, 0);
            this.tlp1.Location = new System.Drawing.Point(12, 118);
            this.tlp1.Name = "tlp1";
            this.tlp1.RowCount = 1;
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlp1.Size = new System.Drawing.Size(206, 56);
            this.tlp1.TabIndex = 3;
            // 
            // btnCompeticoes
            // 
            this.btnCompeticoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCompeticoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompeticoes.Location = new System.Drawing.Point(3, 3);
            this.btnCompeticoes.Name = "btnCompeticoes";
            this.btnCompeticoes.Size = new System.Drawing.Size(200, 50);
            this.btnCompeticoes.TabIndex = 1;
            this.btnCompeticoes.Text = "Competições";
            this.btnCompeticoes.UseVisualStyleBackColor = true;
            this.btnCompeticoes.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIncluirTestes
            // 
            this.btnIncluirTestes.Location = new System.Drawing.Point(345, 399);
            this.btnIncluirTestes.Name = "btnIncluirTestes";
            this.btnIncluirTestes.Size = new System.Drawing.Size(124, 24);
            this.btnIncluirTestes.TabIndex = 4;
            this.btnIncluirTestes.Text = "Incluir dados de teste";
            this.btnIncluirTestes.UseVisualStyleBackColor = true;
            this.btnIncluirTestes.Click += new System.EventHandler(this.btnIncluirTestes_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SecEsportes.Properties.Resources.trophy;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblSecEsportes
            // 
            this.lblSecEsportes.AutoSize = true;
            this.lblSecEsportes.Font = new System.Drawing.Font("Minion Pro", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecEsportes.Location = new System.Drawing.Point(111, 12);
            this.lblSecEsportes.Name = "lblSecEsportes";
            this.lblSecEsportes.Size = new System.Drawing.Size(361, 40);
            this.lblSecEsportes.TabIndex = 6;
            this.lblSecEsportes.Text = "Gerenciador de competições";
            // 
            // tlp4
            // 
            this.tlp4.ColumnCount = 1;
            this.tlp4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp4.Controls.Add(this.button1, 0, 0);
            this.tlp4.Location = new System.Drawing.Point(272, 202);
            this.tlp4.Name = "tlp4";
            this.tlp4.RowCount = 1;
            this.tlp4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlp4.Size = new System.Drawing.Size(200, 50);
            this.tlp4.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cadastro de Funções";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnCadUsuario
            // 
            this.btnCadUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCadUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnCadUsuario.Location = new System.Drawing.Point(3, 3);
            this.btnCadUsuario.Name = "btnCadUsuario";
            this.btnCadUsuario.Size = new System.Drawing.Size(200, 50);
            this.btnCadUsuario.TabIndex = 2;
            this.btnCadUsuario.Text = "Cadastro de Usuários";
            this.btnCadUsuario.UseVisualStyleBackColor = true;
            this.btnCadUsuario.Click += new System.EventHandler(this.btnCadUsuario_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 433);
            this.Controls.Add(this.tlp4);
            this.Controls.Add(this.lblSecEsportes);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnIncluirTestes);
            this.Controls.Add(this.tlp1);
            this.Controls.Add(this.tlp3);
            this.Controls.Add(this.tlp5);
            this.Controls.Add(this.tlp2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Menu Principal";
            this.tlp2.ResumeLayout(false);
            this.tlp5.ResumeLayout(false);
            this.tlp3.ResumeLayout(false);
            this.tlp1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tlp4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp2;
        private System.Windows.Forms.Button btnEquipe;
        private System.Windows.Forms.TableLayoutPanel tlp5;
        private System.Windows.Forms.Button btnCadFuncao;
        private System.Windows.Forms.TableLayoutPanel tlp3;
        private System.Windows.Forms.Button btnPessoas;
        private System.Windows.Forms.TableLayoutPanel tlp1;
        private System.Windows.Forms.Button btnIncluirTestes;
        private System.Windows.Forms.Button btnCompeticoes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSecEsportes;
        private System.Windows.Forms.Button btnCadUsuario;
        private System.Windows.Forms.TableLayoutPanel tlp4;
        private System.Windows.Forms.Button button1;
    }
}

