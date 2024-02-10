using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoMemoriaPrincipal_AlunosFatec
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if(!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(senha))
            {
                ListaUsuarios listaUsuarios = new ListaUsuarios();
                listaUsuarios.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Informe seu e-mail e senha para proseguir", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrimeiroCadastro_Click(object sender, EventArgs e)
        {
            PrimeiroCadastro cadastro = new PrimeiroCadastro(this);
            cadastro.Show();
            this.Visible = false;
        }

        private void btnMudarSenha_Click(object sender, EventArgs e)
        {
            TrocarSenha senha = new TrocarSenha(this);
            senha.Show();
            this.Visible = false;
        }
    }
}
