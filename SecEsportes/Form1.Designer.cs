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
            this.btnCadFuncoes = new System.Windows.Forms.Button();
            this.lblCadFuncao = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnCadFuncoes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCadFuncao, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 400);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCadFuncoes
            // 
            this.btnCadFuncoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCadFuncoes.Location = new System.Drawing.Point(3, 38);
            this.btnCadFuncoes.Name = "btnCadFuncoes";
            this.btnCadFuncoes.Size = new System.Drawing.Size(244, 109);
            this.btnCadFuncoes.TabIndex = 1;
            this.btnCadFuncoes.Text = "button1";
            this.btnCadFuncoes.UseVisualStyleBackColor = true;
            this.btnCadFuncoes.Click += new System.EventHandler(this.btnCadFuncoes_Click);
            // 
            // lblCadFuncao
            // 
            this.lblCadFuncao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCadFuncao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblCadFuncao.Location = new System.Drawing.Point(3, 0);
            this.lblCadFuncao.Name = "lblCadFuncao";
            this.lblCadFuncao.Size = new System.Drawing.Size(244, 35);
            this.lblCadFuncao.TabIndex = 1;
            this.lblCadFuncao.Text = "Cadastro de funções";
            this.lblCadFuncao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblCadFuncao;
        private System.Windows.Forms.Button btnCadFuncoes;
    }
}

