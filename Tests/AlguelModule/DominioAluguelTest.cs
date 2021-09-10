﻿using Dominio.AluguelModule;
using Dominio.PessoaModule;
using Dominio.PessoaModule.ClienteModule;
using Dominio.ServicoModule;
using Dominio.VeiculoModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tests.Tests.AlguelModule
{
    [TestClass]
    public class DominioAluguelTest
    {
        Aluguel aluguel;
        AluguelFechado aluguelFechado;
        Veiculo veiculo;
        CNH cnh;
        MotoristaEmpresa motoristaEmpresa;
        ClientePF clientepf;
        ClientePJ clientepj;
        Image imagemVeiculo = Image.FromFile(@"..\..\Resources\ford_ka_gay.jpg");
        Image imagemFuncionario = Image.FromFile(@"..\..\Resources\rech.png");
        Categoria categoria;
        List<Servico> servicos;
        Funcionario funcionario;


        [TestInitialize]
        public void InicializaAluguel()
        {
            categoria = new Categoria("nome", 2, 2, 2, 2, TipoCNH.A);
            veiculo = new Veiculo("modelo", "marca", 1, "ASD1234", 1, 1, 1, "123456789123", 2, 50, imagemVeiculo, true, categoria, TipoCombustivel.Diesel);
            servicos = new List<Servico>() { new Servico("1", 1), new Servico("2", 2) };
            cnh = new CNH("numero", TipoCNH.A);
            clientepj = new ClientePJ("nome", "4999915522", "endereço", "0131038190371", "email@teste.com");
            motoristaEmpresa = new MotoristaEmpresa("nome", "123123123", "endereço", "d12398127", cnh, clientepj);
            funcionario = new Funcionario("nome", "49999155922", "endereco", "01308174983", Cargo.SysAdmin, imagemFuncionario, "usuario");
            aluguel = new Aluguel(veiculo, servicos, Plano.diario, DateTime.Today.AddDays(10), clientepj, funcionario, DateTime.Today.AddDays(15), motoristaEmpresa);
        }

        [TestMethod]
        public void Deve_retornar_aluguel_clientePF_valido()
        {
            clientepf = new ClientePF("nome", "49999155922", "endereço", "013108478983", cnh, new DateTime(2001, 09, 10), "email@teste.com");
            aluguel.Cliente = clientepf;

            aluguel.Validar().Should().Be(string.Empty);
        }
        [TestMethod]
        public void Deve_retornar_aluguel_clientePJ_valido()
        {
            aluguel.Validar().Should().Be(string.Empty);
        }
        [TestMethod]
        public void Deve_retornar_aluguel_invalido()
        {
            aluguel = new Aluguel(null, null, Plano.controlado, new DateTime(), null, null, new DateTime());

            aluguel.Validar().Should().NotBe(string.Empty);
        }
        [TestMethod]
        public void Deve_retornar_aluguel_pf_fechado_valido()
        {
            servicos = new List<Servico>() { new Servico("1", 1), new Servico("2", 2) };
            aluguelFechado = aluguel.Fechar(200, 0.5, servicos);
            aluguelFechado.Validar().Should().Be(string.Empty);
        }
    }
}
