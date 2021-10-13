﻿using Dominio.PessoaModule;
using Dominio.VeiculoModule;
using FluentAssertions;
using Infra.DAO.ORM.Repositories;
using Infra.DAO.Shared;
using IntegrationTests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.VeiculoModule
{
    [TestClass]
    public class VeiculoORMTests
    {
        Veiculo veiculo1;
        VeiculoORM VeiculoORM = new();

        [TestInitialize]
        public void Inserir_Veiculo()
        {
            var imagem = Properties.Resources.focus_gay;
            var categoria = new Categoria("Economico", 100, 10, 400, 800, TipoCNH.B);
            veiculo1 = new Veiculo("Ka", "Ford", 2001, "ABC1024", 50000, 4, 4, "ASDFGHJKLQWERTYUI", 0, 50, imagem, false, categoria, TipoCombustivel.Gasolina);
            new CategoriaORM().Inserir(categoria);
            VeiculoORM.Inserir(veiculo1);
        }

        [TestMethod]
        public void Deve_inserir_veiculo()
        {
            veiculo1.Id.Should().NotBe(0);
        }

        [TestMethod]
        public void Deve_editar_marca_veiculo()
        {
            string marcaOriginal = veiculo1.Marca;

            veiculo1.Marca = "Marca diferente";
            VeiculoORM.Editar(veiculo1.Id, veiculo1);

            VeiculoORM.GetById(veiculo1.Id).Marca.Should().NotBe(marcaOriginal);
        }

        [TestMethod]
        public void Deve_editar_ano_veiculo()
        {
            int anoOriginal = veiculo1.Ano;

            veiculo1.Ano = 2017;

            VeiculoORM.Editar(veiculo1.Id, veiculo1);

            VeiculoORM.GetById(veiculo1.Id).Ano.Should().NotBe(anoOriginal);
        }

        [TestMethod]
        public void Deve_remover_veiculo()
        {
            VeiculoORM.Excluir(veiculo1.Id);
            VeiculoORM.Existe(veiculo1.Id).Should().BeFalse();
        }

        [TestMethod]
        public void Deve_retornar_todos_os_veiculos()
        {
            VeiculoORM.Registros.Count.Should().Be(1);
        }

        [TestCleanup]
        public void LimparTestes()
        {
            Db.Delete(TestExtensions.ResetId("TBVeiculo"));
        }
    }
}
