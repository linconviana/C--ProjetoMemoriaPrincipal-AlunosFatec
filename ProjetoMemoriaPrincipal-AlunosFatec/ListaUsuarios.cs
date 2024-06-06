using ProjetoMemoriaPrincipal_AlunosFatec.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoMemoriaPrincipal_AlunosFatec
{
    public partial class ListaUsuarios : Form
    {
        private Usuarios usuario;
        private string pathImagem = string.Empty;

        public ListaUsuarios()
        {
            InitializeComponent();

            ListarUsuarios();

            txtSenha.PasswordChar = '*';
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

            btnAtualizar.Enabled = true;
            btnExcluir.Enabled = true;
            btnCadastrar.Enabled = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private void LimparFormulario()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            txtTelefone.Clear();

            txtNome.Select();
            txtNome.Focus();

            btnAtualizar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCadastrar.Enabled = true;

            string imagemPadrao = Environment.CurrentDirectory + @"\..\..\imagens\avatar.png";
            pictureImagem.Image = Image.FromFile(imagemPadrao);
            usuario = new Usuarios();
            pathImagem = string.Empty;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirUsuario();
        }

        private void ExcluirUsuario()
        {
            DialogResult confirma = MessageBox.Show("Deseja Excluir este usuario?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if(confirma.ToString().ToUpper() == "YES")
            {
                var index = Global.ListaUsuarios.FindIndex(x => x.id == usuario.id);
                Global.ListaUsuarios.RemoveAt(index);

                MessageBox.Show("Usuario excluido com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                tabelaUsuarios.DataSource = null;
                ListarUsuarios();
                LimparFormulario();
            }
        }

        private void btnImagem_Click(object sender, EventArgs e)
        {
            SelecionarImagem();
        }

        private void SelecionarImagem()
        {
            var anexo = new OpenFileDialog();

            anexo.Multiselect = false;
            anexo.Title = "Anexar Imagem de Usuário";
            anexo.Filter = "imagens (*.jpg; *.png) | *.jpg; *.png";

            if(anexo.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(anexo.FileName);

                if(extension.ToLower() == ".jpg" || extension.ToLower() == ".png")
                {
                    if (anexo.FileName != null)
                    {
                        pictureImagem.Image = Image.FromFile(anexo.FileName);
                        pathImagem = anexo.FileName;
                    }
                }
                else
                {
                    var titulo = "Arquivo inválido";
                    var mensagem = "Somente é possivel adicionar imagens no formato PNG ou JPG";

                    MessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CadastrarUsuario();
        }

        private void CadastrarUsuario()
        {
            DialogResult confirma = MessageBox.Show("Deseja Cadastrar este usuário?", "Confirmação?", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if(confirma.ToString().ToUpper() == "YES")
            {
                if(!String.IsNullOrEmpty(txtNome.Text)
                    && !String.IsNullOrEmpty(txtEmail.Text)
                    && ((!String.IsNullOrEmpty(txtSenha.Text) && usuario == null))
                    || (!String.IsNullOrEmpty(txtSenha.Text) && usuario != null))
                {

                    int id = (Global.ListaUsuarios.FindLast(x => x.id > 0).id) + 1;

                    usuario = new Usuarios();
                    usuario.id = id;
                    usuario.nome = txtNome.Text;
                    usuario.email = txtEmail.Text;
                    usuario.telefone = txtTelefone.Text;
                    usuario.senha = txtSenha.Text;
                    usuario.imagem = pathImagem != string.Empty ? SalvarImagem(id.ToString()) : string.Empty;

                    Global.ListaUsuarios.Add(usuario);

                    MessageBox.Show("Usuario cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tabelaUsuarios.DataSource = null;
                    ListarUsuarios();
                    LimparFormulario();

                }
                else
                {
                    if (String.IsNullOrEmpty(txtNome.Text))
                        MessageBox.Show("Campo Nome não foi preenchido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (String.IsNullOrEmpty(txtEmail.Text))
                        MessageBox.Show("Campo Email não foi preenchido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (String.IsNullOrEmpty(txtSenha.Text))
                        MessageBox.Show("Campo Senha não foi preenchido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private string SalvarImagem(string id)
        {
            Random randNum = new Random();
            string imgName = $"logo-{randNum.Next(1000)}-" + id;
            string extension = Path.GetExtension(pathImagem);
            var rootPath = Environment.CurrentDirectory + @"\..\..\imagens\";
            /// :: Caminho da nova imagem da logo
            var newImagemPath = rootPath + imgName + extension;

            try
            {
                /// :: Verefica se existe o arquivo
                if (File.Exists(newImagemPath))
                    File.Delete(newImagemPath);

                /// :: Cria copia do arquivo na pasta do programa.
                File.Copy(pathImagem, newImagemPath, true);
            }
            catch (Exception) { }

            return newImagemPath;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarUsuario();
        }

        private void AtualizarUsuario()
        {
            DialogResult confirma = MessageBox.Show("Deseja Atualizar este usuário?", "Confirmação?",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (confirma.ToString().ToUpper() == "YES")
            {
                var index = Global.ListaUsuarios.FindIndex(x => x.id == usuario.id);

                Global.ListaUsuarios[index].nome = txtNome.Text.Trim();
                Global.ListaUsuarios[index].email = txtEmail.Text.Trim();
                Global.ListaUsuarios[index].senha = txtSenha.Text.Trim();
                Global.ListaUsuarios[index].telefone = txtTelefone.Text.Trim();
                Global.ListaUsuarios[index].imagem = pathImagem != string.Empty ?
                    SalvarImagem(usuario.id.ToString()) : usuario.imagem;

                MessageBox.Show("Usuario atualizado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                tabelaUsuarios.DataSource = null;
                ListarUsuarios();
                LimparFormulario();
            }
        }

        private void tabelaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(tabelaUsuarios.Rows[e.RowIndex].Cells["id"].Value.ToString());

                if(tabelaUsuarios.Columns[e.ColumnIndex] == tabelaUsuarios.Columns["detalhes"])
                {
                    DialogResult confirm = MessageBox.Show("Deseja ver as informações deste usuario?",
                        "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if(confirm.ToString().ToUpper() == "YES")
                    {
                        DadosUsuario dados = new DadosUsuario(id);
                        //DadosUsuario dados1 = new DadosUsuario(usuario);
                        dados.Show();
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
