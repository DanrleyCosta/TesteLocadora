using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsCrud
{
    public partial class Cadastro : Form
    {
        private const string ConnectionString = "Data Source=LAPTOP-HKBV533R\\SQLEXPRESS02;Initial Catalog =groups; Integrated Security=True;";
        

        SqlConnection con = new SqlConnection(ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int ID = 0;

        public Cadastro()
        {
            InitializeComponent();
            ExibirDados();
        }

        private void ExibirDados()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("SELECT * FROM PessoasCadastro", con);
                adapt.Fill(dt);
                dgvCadastro.DataSource = dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        private void LimparDados()
        {
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCelular.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtTipo.Text = "";
            txtCpf.Text = "";
            txtCnpj.Text = "";
            ID = 0;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Sair do programa ?", "Cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                txtNome.Focus();
            }
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Danrley Costa", "Cadastro", MessageBoxButtons.OK,
          MessageBoxIcon.Information);
            txtNome.Focus();
        }

        public string conectar()
        {
            var connstring = ConfigurationManager.ConnectionStrings["conectar"].ConnectionString;

            return connstring;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtEndereco.Text != "" && txtCelular.Text != "" && txtTelefone.Text != "" && txtEmail.Text != "")
            {
                try
                {
                    cmd = new SqlCommand("INSERT INTO PessoasCadastro(nome,endereco,celular,telefone,email,tipo,cpf,cnpj) VALUES(@nome,@endereco,@celular,@telefone,@email,@tipo,@cpf,@cnpj)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@celular", txtCelular.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.ToLower());
                    cmd.Parameters.AddWithValue("@tipo", txtTipo.Text.ToLower());
                    cmd.Parameters.AddWithValue("@cpf", txtCpf.Text.ToLower());
                    cmd.Parameters.AddWithValue("@cnpj", txtCnpj.Text.ToLower());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registro incluído!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                }
                finally
                {
                    con.Close();
                    ExibirDados();
                    LimparDados();
                }
            }
            else
            {
                MessageBox.Show("Informe todos os dados do Usuário");
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtEndereco.Text != "" && txtCelular.Text != "" && txtTelefone.Text != "" && txtEmail.Text != "")
            {
                try
                {
                    cmd = new SqlCommand("UPDATE PessoasCadastro SET nome=@nome, endereco=@endereco, celular=@celular,telefone=@telefone,email=@email,tipo=@tipo,cpf=@cpf,cnpj=@cnpj WHERE id=@id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@celular", txtCelular.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.ToLower());
                    cmd.Parameters.AddWithValue("@tipo", txtTipo.Text.ToLower());
                    cmd.Parameters.AddWithValue("@cpf", txtCpf.Text.ToLower());
                    cmd.Parameters.AddWithValue("@cnpj", txtCnpj.Text.ToLower());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registro atualizado com sucesso...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                }
                finally
                {
                    con.Close();
                    ExibirDados();
                    LimparDados();
                }
            }
            else
            {
                MessageBox.Show("Informe todos os dados requeridos");
            }
        }

        private void dgvCadastro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                ID = Convert.ToInt32(dgvCadastro.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtNome.Text = dgvCadastro.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtEndereco.Text = dgvCadastro.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCelular.Text = dgvCadastro.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtTelefone.Text = dgvCadastro.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtEmail.Text = dgvCadastro.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtTipo.Text = dgvCadastro.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtCpf.Text = dgvCadastro.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtCnpj.Text = dgvCadastro.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            catch { }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCelular.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtTipo.Text = "";
            txtCpf.Text = "";
            txtCnpj.Text = "";
            txtNome.Focus();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                if (MessageBox.Show("Deseja Deletar este registro ?", "Cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        cmd = new SqlCommand("DELETE PessoasCadastro WHERE id=@id", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("registro deletado com sucesso...!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro : " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                        ExibirDados();
                        LimparDados();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma pessoa para deletar");
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTipo_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Text == "f")
            {
                alterarEstado("cpf");
            }
            else if(textBox.Text == "j")
            {
                alterarEstado("cnpj");
            }
            else
            {
                this.txtCnpj.Enabled = true;
                this.txtCpf.Enabled = true;
            }
        }

        public void alterarEstado(string valor)
        {
            if (valor == "cpf")             
                this.txtCnpj.Enabled = false;            
            else if (valor == "cnpj")            
                this.txtCpf.Enabled = false;

        }
    }
}
