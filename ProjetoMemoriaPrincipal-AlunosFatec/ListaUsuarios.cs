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
    public partial class ListaUsuarios : Form
    {
        private Usuarios usuario;

        public ListaUsuarios()
        {
            InitializeComponent();

            ListarUsuarios();

        }

        private void ListaUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            FecharJanelas.CloseSystem();
        }

        private void ListarUsuarios()
        {
            tabelaUsuarios.DataSource = Global.ListaUsuarios;
            AlterarCabecalhotabela();
        }

        private void AlterarCabecalhotabela()
        {
            tabelaUsuarios.Columns[0].HeaderText = "";
            tabelaUsuarios.Columns[1].HeaderText = "Codigo";
            tabelaUsuarios.Columns[2].HeaderText = "Nome";
            tabelaUsuarios.Columns[3].HeaderText = "E-mail";
            tabelaUsuarios.Columns[4].HeaderText = "Senha";
            tabelaUsuarios.Columns[5].HeaderText = "Telefone";
            tabelaUsuarios.Columns[6].HeaderText = "Imagem";

            tabelaUsuarios.Columns[1].Visible = false;
            tabelaUsuarios.Columns[4].Visible = false;
            tabelaUsuarios.Columns[6].Visible = false;

            tabelaUsuarios.Columns[0].Width = 30;
            tabelaUsuarios.Columns[2].Width = 200;
            tabelaUsuarios.Columns[3].Width = 300;
            tabelaUsuarios.Columns[5].Width = 100;
        }

        private void tabelaUsuarios_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SelecionarDadosTabela();
        }

        private void SelecionarDadosTabela()
        {
            string nome = tabelaUsuarios.CurrentRow.Cells[2].Value.ToString();
            string email = tabelaUsuarios.CurrentRow.Cells[3].Value.ToString();
            string telefone = tabelaUsuarios.CurrentRow.Cells[5].Value.ToString();
            string imagem = tabelaUsuarios.CurrentRow.Cells[6].Value.ToString();

            txtNome.Text = nome;
            txtEmail.Text = email;
            txtTelefone.Text = telefone;

            usuario = new Usuarios();
            usuario.id = Convert.ToInt32(tabelaUsuarios.CurrentRow.Cells[1].Value.ToString());
            usuario.nome = nome;
            usuario.email = email;
            usuario.telefone = telefone;
            usuario.senha = tabelaUsuarios.CurrentRow.Cells[4].Value.ToString();
            usuario.imagem = imagem;

            if (!String.IsNullOrEmpty(imagem))
                pictureImagem.Image = Image.FromFile(imagem);
            else
                pictureImagem.Image = Image.FromFile(Environment.CurrentDirectory + @"\..\..\imagens\avatar.png");
        }
    }
}
