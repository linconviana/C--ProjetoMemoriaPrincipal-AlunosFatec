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

        public PrimeiroCadastro()
        {
            InitializeComponent();
        }

        public PrimeiroCadastro(Form login)
        {
            InitializeComponent();

            this.login = login;
        }

        private void PrimeiroCadastro_FormClosed(object sender, FormClosedEventArgs e)
        {
            FecharJanelas.CloseSystem();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Usuario salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.login.Visible = true;
            this.Close();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
