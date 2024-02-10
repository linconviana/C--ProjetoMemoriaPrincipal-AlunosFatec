using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMemoriaPrincipal_AlunosFatec
{
    public class Usuarios
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string telefone { get; set; }
        public string imagem { get; set; }

        public Usuarios() { }

        public Usuarios(int id, string nome, string email, string senha, string telefone, string imagem) 
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.imagem = imagem;
        }
    }
}
