using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsCrud
{
    public partial class telaPrincipal : Form
    {
        public telaPrincipal()
        {
            InitializeComponent();

            btn_cadastrar.Text = "Cadastrar";
            btn_sair.Text = "Sair";

        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            var cadastro = new Cadastro();
            cadastro.ShowDialog();

        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
