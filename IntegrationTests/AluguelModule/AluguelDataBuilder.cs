﻿using Dominio.AluguelModule;
using Dominio.CupomModule;
using Dominio.Entities.PessoaModule.ClienteModule;
using Dominio.ParceiroModule;
using Dominio.PessoaModule;
using Dominio.PessoaModule.ClienteModule;
using Dominio.ServicoModule;
using Dominio.VeiculoModule;
using IntegrationTests.Properties;
using System;
using System.Collections.Generic;

namespace IntegrationTests.Shared
{
    class AluguelDataBuilder
    {
        Aluguel aluguel = new();

        public AluguelDataBuilder DeVeiculo(Veiculo veiculo = null)
        {
            var imagem = Resources.focus_gay;
            var categoria = new Categoria("Economico", 100, 10, 400, 800, TipoCNH.B);
            veiculo ??= new Veiculo("Ka", "Ford", 2001, "ABC1024", 50000, 4, 4, "ASDFGHJKLQWERTYUI", 0, 50, imagem, false, categoria, TipoCombustivel.Gasolina);
            aluguel.Veiculo = veiculo;

            return this;
        }

        public AluguelDataBuilder ParaCliente(ICliente cliente = null)
        {
            cliente ??= new ClientePF("Cliente 1", "999999", "endereco", "9999990", new CNH("99999", TipoCNH.AB), new DateTime(2001, 10, 10), "aaaaaa@aaa.com");
            aluguel.Cliente = new Cliente(cliente);

            return this;
        }

        public AluguelDataBuilder PorFuncionario(Funcionario funcionario = null)
        {
            funcionario ??= new Funcionario("Funcionario 1", "99999", "endereco", "999999", Cargo.SysAdmin, Resources.ford_ka_gay, "user");
            aluguel.Funcionario = funcionario;

            return this;
        }

        public AluguelDataBuilder NaData(DateTime dataAluguel = default)
        {
            dataAluguel = dataAluguel != DateTime.MinValue ? dataAluguel : DateTime.Today;
            aluguel.DataAluguel = dataAluguel;

            return this;
        }

        public AluguelDataBuilder ParaDevolver(DateTime dataDevolucao = default)
        {
            dataDevolucao = dataDevolucao != DateTime.MinValue ? dataDevolucao : DateTime.Today.AddDays(7);

            aluguel.DataDevolucao = dataDevolucao;

            return this;
        }

        public AluguelDataBuilder NoPlano(Plano tipoPlano = Plano.Diário)
        {
            aluguel.TipoPlano = tipoPlano;

            return this;
        }

        public AluguelDataBuilder ParaCondutor(Condutor condutor = null)
        {
            condutor ??= (aluguel.Cliente._Cliente is ClientePF pF ? pF : new Motorista("Motorista 1", "99999999", "endereço", "999999", new CNH("7546456", TipoCNH.AB), (ClientePJ)aluguel.Cliente._Cliente));
            aluguel.Condutor = condutor;

            return this;
        }

        public AluguelDataBuilder ComServicos(List<Servico> servicos = null)
        {
            servicos ??= new List<Servico>() { new Servico("Servico 1", 100, aluguel), new Servico("Servico 2", 250, aluguel) };

            aluguel.Servicos = servicos;

            return this;
        }

        public AluguelDataBuilder ComCupom(Cupom cupom = null)
        {
            cupom ??= new Cupom("cupom10", 10, 100, DateTime.Today, new Parceiro("Parceiro 1"), 1000, 0);
            aluguel.Cupom = cupom;

            return this;
        }
        public Aluguel Padrao => ComCupom().ComServicos().DeVeiculo().NaData().NoPlano().ParaCliente().ParaCondutor().ParaDevolver().PorFuncionario().Build();

        public Aluguel Build()
        {
            return aluguel;
        }
    }
}