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
    public partial class TrocarSenha : Form
    {
        private Form login;

        public TrocarSenha()
        {
            InitializeComponent();
        }

        public TrocarSenha(Form login)
        {
            InitializeComponent();

            this.login = login;
        }

        private void TrocarSenha_FormClosed(object sender, FormClosedEventArgs e)
        {
            FecharJanelas.CloseSystem();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Email enviado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.login.Visible = true;
            this.Close();
        }
    }
}
