﻿using ProjetoMemoriaPrincipal_AlunosFatec.utils;
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
        public ListaUsuarios()
        {
            InitializeComponent();
        }

        private void ListaUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            FecharJanelas.CloseSystem();
        }
    }
}
