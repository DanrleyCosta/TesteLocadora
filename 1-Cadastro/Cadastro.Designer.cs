
namespace _1_Cadastro
{
    public partial class Cadastro
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
            this.btn_salvar = new System.Windows.Forms.Button();
            this.lb_titulo = new System.Windows.Forms.Label();
            this.lb_nome = new System.Windows.Forms.Label();
            this.btn_voltar = new System.Windows.Forms.Button();
            this.lb_cpf = new System.Windows.Forms.Label();
            this.lb_endereco = new System.Windows.Forms.Label();
            this.tb_nome = new System.Windows.Forms.TextBox();
            this.tb_cpf = new System.Windows.Forms.TextBox();
            this.tb_endereco = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_salvar
            // 
            this.btn_salvar.Location = new System.Drawing.Point(39, 249);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(75, 23);
            this.btn_salvar.TabIndex = 0;
            this.btn_salvar.Text = "button1";
            this.btn_salvar.UseVisualStyleBackColor = true;
            // 
            // lb_titulo
            // 
            this.lb_titulo.AutoSize = true;
            this.lb_titulo.Location = new System.Drawing.Point(161, 9);
            this.lb_titulo.Name = "lb_titulo";
            this.lb_titulo.Size = new System.Drawing.Size(38, 15);
            this.lb_titulo.TabIndex = 1;
            this.lb_titulo.Text = "label1";
            // 
            // lb_nome
            // 
            this.lb_nome.AutoSize = true;
            this.lb_nome.Location = new System.Drawing.Point(39, 44);
            this.lb_nome.Name = "lb_nome";
            this.lb_nome.Size = new System.Drawing.Size(38, 15);
            this.lb_nome.TabIndex = 2;
            this.lb_nome.Text = "label2";
            // 
            // btn_voltar
            // 
            this.btn_voltar.Location = new System.Drawing.Point(245, 249);
            this.btn_voltar.Name = "btn_voltar";
            this.btn_voltar.Size = new System.Drawing.Size(75, 23);
            this.btn_voltar.TabIndex = 3;
            this.btn_voltar.Text = "button2";
            this.btn_voltar.UseVisualStyleBackColor = true;
            // 
            // lb_cpf
            // 
            this.lb_cpf.AutoSize = true;
            this.lb_cpf.Location = new System.Drawing.Point(39, 92);
            this.lb_cpf.Name = "lb_cpf";
            this.lb_cpf.Size = new System.Drawing.Size(38, 15);
            this.lb_cpf.TabIndex = 4;
            this.lb_cpf.Text = "label3";
            // 
            // lb_endereco
            // 
            this.lb_endereco.AutoSize = true;
            this.lb_endereco.Location = new System.Drawing.Point(39, 140);
            this.lb_endereco.Name = "lb_endereco";
            this.lb_endereco.Size = new System.Drawing.Size(38, 15);
            this.lb_endereco.TabIndex = 5;
            this.lb_endereco.Text = "label4";
            // 
            // tb_nome
            // 
            this.tb_nome.Location = new System.Drawing.Point(39, 62);
            this.tb_nome.Name = "tb_nome";
            this.tb_nome.Size = new System.Drawing.Size(281, 23);
            this.tb_nome.TabIndex = 6;
            // 
            // tb_cpf
            // 
            this.tb_cpf.Location = new System.Drawing.Point(39, 110);
            this.tb_cpf.Name = "tb_cpf";
            this.tb_cpf.Size = new System.Drawing.Size(281, 23);
            this.tb_cpf.TabIndex = 7;
            // 
            // tb_endereco
            // 
            this.tb_endereco.Location = new System.Drawing.Point(39, 158);
            this.tb_endereco.Name = "tb_endereco";
            this.tb_endereco.Size = new System.Drawing.Size(281, 23);
            this.tb_endereco.TabIndex = 8;
            // 
            // Cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 326);
            this.Controls.Add(this.tb_endereco);
            this.Controls.Add(this.tb_cpf);
            this.Controls.Add(this.tb_nome);
            this.Controls.Add(this.lb_endereco);
            this.Controls.Add(this.lb_cpf);
            this.Controls.Add(this.btn_voltar);
            this.Controls.Add(this.lb_nome);
            this.Controls.Add(this.lb_titulo);
            this.Controls.Add(this.btn_salvar);
            this.Name = "Cadastro";
            this.Text = "Cadastro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_salvar;
        private System.Windows.Forms.Label lb_titulo;
        private System.Windows.Forms.Label lb_nome;
        private System.Windows.Forms.Button btn_voltar;
        private System.Windows.Forms.Label lb_cpf;
        private System.Windows.Forms.Label lb_endereco;
        private System.Windows.Forms.TextBox tb_nome;
        private System.Windows.Forms.TextBox tb_cpf;
        private System.Windows.Forms.TextBox tb_endereco;
    }
}