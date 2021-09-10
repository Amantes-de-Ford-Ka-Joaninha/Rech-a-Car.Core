﻿using Dominio.PessoaModule.ClienteModule;

namespace Dominio.PessoaModule
{
    public class MotoristaEmpresa : Condutor
    {
        public MotoristaEmpresa(string nome, string telefone, string endereco, string documento, CNH cnh, ClientePJ empresa)
        {
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
            Documento = documento;
            Cnh = cnh;
            Empresa = empresa;
        }
        public ClientePJ Empresa { get; set; }

        public override string ToString()
        {
            return $"{Nome} | {Telefone}";
        }
    }
}
