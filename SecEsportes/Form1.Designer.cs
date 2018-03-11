namespace SecEsportes
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCadEquipe = new System.Windows.Forms.Button();
            this.lblCadFuncao = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCadFuncao = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCadPessoa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnCadEquipe, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCadFuncao, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 400);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCadEquipe
            // 
            this.btnCadEquipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCadEquipe.Location = new System.Drawing.Point(3, 38);
            this.btnCadEquipe.Name = "btnCadEquipe";
            this.btnCadEquipe.Size = new System.Drawing.Size(244, 109);
            this.btnCadEquipe.TabIndex = 1;
            this.btnCadEquipe.Text = "button1";
            this.btnCadEquipe.UseVisualStyleBackColor = true;
            this.btnCadEquipe.Click += new System.EventHandler(this.btnCadEquipes_Click);
            // 
            // lblCadFuncao
            // 
            this.lblCadFuncao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCadFuncao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblCadFuncao.Location = new System.Drawing.Point(3, 0);
            this.lblCadFuncao.Name = "lblCadFuncao";
            this.lblCadFuncao.Size = new System.Drawing.Size(244, 35);
            this.lblCadFuncao.TabIndex = 1;
            this.lblCadFuncao.Text = "Cadastro de equipes";
            this.lblCadFuncao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnCadFuncao, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(266, 400);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(250, 150);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnCadFuncao
            // 
            this.btnCadFuncao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCadFuncao.Location = new System.Drawing.Point(3, 38);
            this.btnCadFuncao.Name = "btnCadFuncao";
            this.btnCadFuncao.Size = new System.Drawing.Size(244, 109);
            this.btnCadFuncao.TabIndex = 1;
            this.btnCadFuncao.Text = "button1";
            this.btnCadFuncao.UseVisualStyleBackColor = true;
            this.btnCadFuncao.Click += new System.EventHandler(this.btnCadFuncao_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cadastro de funções";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btnCadPessoa, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(267, 205);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(250, 150);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btnCadPessoa
            // 
            this.btnCadPessoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCadPessoa.Location = new System.Drawing.Point(3, 38);
            this.btnCadPessoa.Name = "btnCadPessoa";
            this.btnCadPessoa.Size = new System.Drawing.Size(244, 109);
            this.btnCadPessoa.TabIndex = 1;
            this.btnCadPessoa.Text = "button2";
            this.btnCadPessoa.UseVisualStyleBackColor = true;
            this.btnCadPessoa.Click += new System.EventHandler(this.btnCadPessoa_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cadastro de pessoas";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblCadFuncao;
        private System.Windows.Forms.Button btnCadEquipe;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnCadFuncao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnCadPessoa;
        private System.Windows.Forms.Label label2;
    }
}

