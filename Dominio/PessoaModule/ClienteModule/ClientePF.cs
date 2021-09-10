﻿using System;
using System.Text.RegularExpressions;

namespace Dominio.PessoaModule.ClienteModule
{
    public class ClientePF : Condutor, ICliente
    {
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }

        public ClientePF(string nome, string telefone, string endereco, string documento, CNH cnh, DateTime dataNascimento, string email)
        {
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
            Documento = documento;
            Cnh = cnh;
            DataNascimento = dataNascimento;
            Email = email;
        }
        public int GetIdade()
        {
            return (DateTime.Now - DataNascimento).Days / 365;
        }

        public override string Validar()
        {
            string validacao = base.Validar();

            Regex ValidarEmail = new Regex(@"[a-z0-9.]+@[a-z0-9.]+\.[a-z0-9.]+[a-z]+", RegexOptions.IgnoreCase);

            if (!ValidarEmail.IsMatch(Email))
                validacao += "Email inválido\n";

            if (GetIdade() < 18)
                validacao += "Idade mínima para dirigir é de 18 anos.\n";

            return validacao;
        }
    }
}