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

            CarregarListaUsuarios();

            ShowBtnCadastro();

            txtSenha.PasswordChar = '*';

            txtEmail.Text = "lincon@gmail.com";
            txtSenha.Text = "123";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if(!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(senha))
            {
                var usuario = Global.ListaUsuarios.Find(user => user.email == email && user.senha == senha);
                if(usuario != null)
                {
                    ListaUsuarios listaUsuarios = new ListaUsuarios();
                    listaUsuarios.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Email ou senha invalidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Informe seu e-mail e senha para proseguir", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrimeiroCadastro_Click(object sender, EventArgs e)
        {
            PrimeiroCadastro cadastro = new PrimeiroCadastro(this, btnLogin, btnPrimeiroCadastro, btnMudarSenha);
            cadastro.Show();
            this.Visible = false;
        }

        private void btnMudarSenha_Click(object sender, EventArgs e)
        {
            TrocarSenha senha = new TrocarSenha(this);
            senha.Show();
            this.Visible = false;
        }

        private void ShowBtnCadastro()
        {
            if (Global.ListaUsuarios.Count == 0)
                btnPrimeiroCadastro.Visible = true;
            else
            {
                btnPrimeiroCadastro.Visible = false;
                btnMudarSenha.Visible = true;
                btnLogin.Location = new Point(220, 239);
            }
        }

        private void CarregarListaUsuarios()
        {
            Global.ListaUsuarios.Add(
                new Usuarios { id = 1, nome = "Lincon", email = "lincon@gmail.com", senha = "123", telefone = "(12) 98745-1245", imagem = string.Empty });
            Global.ListaUsuarios.Add(
                new Usuarios
                {
                    id = 2,
                    nome = "Miriã",
                    email = "miri@gmail.com",
                    senha = "123",
                    telefone = "(12) 98745-1245",
                    imagem = @"C:\Users\Lincon\source\repos\ProjetoMemoriaPrincipal-AlunosFatec\ProjetoMemoriaPrincipal-AlunosFatec\Resources\logo02.png"
                });
            Global.ListaUsuarios.Add(
                new Usuarios
                {
                    id = 3,
                    nome = "Heitor",
                    email = "heitor@gmail.com",
                    senha = "123",
                    telefone = "(12) 98745-1245",
                    imagem = @"C:\Users\Lincon\source\repos\ProjetoMemoriaPrincipal-AlunosFatec\ProjetoMemoriaPrincipal-AlunosFatec\Resources\logo01.png"
                });
        }
    }
}
