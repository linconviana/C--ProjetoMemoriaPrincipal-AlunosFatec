using ProjetoMemoriaPrincipal_AlunosFatec.utils;
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
    public partial class PrimeiroCadastro : Form
    {
        private Form login;
        private Button primeiroCadastro;
        private Button mudarSenha;
        private Button btnLogin;

        public PrimeiroCadastro()
        {
            InitializeComponent();
        }

        public PrimeiroCadastro(Form login, Button btnLogin, Button primeiroCadastro, Button mudarSenha)
        {
            InitializeComponent();

            this.login = login;
            this.primeiroCadastro = primeiroCadastro;
            this.mudarSenha = mudarSenha;
            this.btnLogin = btnLogin;

            txtSenha.PasswordChar = '*';
        }

        private void PrimeiroCadastro_FormClosed(object sender, FormClosedEventArgs e)
        {
            FecharJanelas.CloseSystem();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtNome.Text) && !String.IsNullOrEmpty(txtEmail.Text) && !String.IsNullOrEmpty(txtSenha.Text))
            {
                Usuarios usuario = new Usuarios();
                usuario.id = 1;
                usuario.nome = txtNome.Text.Trim();
                usuario.email = txtEmail.Text.Trim();
                usuario.senha = txtSenha.Text.Trim();
                usuario.telefone = txtTelefone.Text.Trim();
                usuario.imagem = string.Empty;

                Global.ListaUsuarios.Add(usuario);

                MessageBox.Show("Usuario salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.login.Visible = true;
                this.primeiroCadastro.Visible = false;
                this.mudarSenha.Visible = true;
                this.btnLogin.Location = new Point(220, 239);
                this.Close();
            }
            else
            {
                if (String.IsNullOrEmpty(txtNome.Text))
                    MessageBox.Show("Nome do usuario é obrigatorio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (String.IsNullOrEmpty(txtEmail.Text))
                    MessageBox.Show("Email do usuario é obrigatorio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (String.IsNullOrEmpty(txtSenha.Text))
                    MessageBox.Show("Senha do usuario é obrigatorio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
