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
    public partial class DadosUsuario : Form
    {
        public DadosUsuario()
        {
            InitializeComponent();
        }

        public DadosUsuario(int id)
        {
            InitializeComponent();

            Usuarios user = Global.ListaUsuarios.Find(x => x.id == id);

            VerUsuario(user);      
        }

        public DadosUsuario(Usuarios usuario)
        {
            InitializeComponent();

            VerUsuario(usuario);
        }

        private void VerUsuario(Usuarios user)
        {
            lblNome.Text = user.nome;
            lblEmail.Text = user.email;
            lblTelefone.Text = user.telefone;
            lblSenha.Text = user.senha;

            if (!String.IsNullOrEmpty(user.imagem))
                pictureImagem.Image = Image.FromFile(user.imagem);
            else
                pictureImagem.Image = Image.FromFile(Environment.CurrentDirectory + @"\..\..\imagens\avatar.png");
        }

        private void DadosUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            FecharJanelas.CloseSystem();
        }
    }
}
