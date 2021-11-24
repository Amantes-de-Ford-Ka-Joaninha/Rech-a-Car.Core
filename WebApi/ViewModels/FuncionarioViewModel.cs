using Dominio.PessoaModule;
using System.Drawing;

namespace WebApi.ViewModels
{
    public class FuncionarioListViewModel
    {
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public int Cargo { get; set; }
    }
    public class FuncionarioDetailsViewModel
    {
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public int Cargo { get; set; }

        public string Documento { get; set; }

        public string Usuario { get; set; } 
    }
    public class FuncionarioCreateViewModel
    {
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public int Cargo { get; set; }

        public string Documento { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public string Foto { get; set; }


    }
    public class FuncionarioEditViewModel
    {
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public int Cargo { get; set; }

        public string Documento { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }
    }

}
