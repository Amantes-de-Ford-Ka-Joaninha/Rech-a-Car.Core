﻿// <auto-generated />
using System;
using Infra.DAO.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.DAO.ORM.Migrations
{
    [DbContext(typeof(rech_a_carDbContext))]
    [Migration("20211013062051_agora_vai")]
    partial class agora_vai
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.AluguelModule.Aluguel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("CondutorId")
                        .HasColumnType("int");

                    b.Property<int?>("CupomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAluguel")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("DATE");

                    b.Property<int?>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<int>("TipoPlano")
                        .HasColumnType("int");

                    b.Property<int?>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("CondutorId");

                    b.HasIndex("CupomId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("TBAluguel");
                });

            modelBuilder.Entity("Dominio.AluguelModule.RelatorioAluguel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AluguelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataEnvio")
                        .IsRequired()
                        .HasColumnType("DATE");

                    b.Property<byte[]>("StreamAttachment")
                        .IsRequired()
                        .HasColumnType("VARBINARY(MAX)");

                    b.HasKey("Id");

                    b.HasIndex("AluguelId");

                    b.ToTable("TBEmail");
                });

            modelBuilder.Entity("Dominio.CupomModule.Cupom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("DATE");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<int?>("ParceiroId")
                        .HasColumnType("int");

                    b.Property<int>("Usos")
                        .HasColumnType("INT");

                    b.Property<double>("ValorFixo")
                        .HasColumnType("FLOAT");

                    b.Property<double>("ValorMinimo")
                        .HasColumnType("FLOAT");

                    b.Property<int>("ValorPercentual")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("ParceiroId");

                    b.ToTable("TBCupom");
                });

            modelBuilder.Entity("Dominio.Entities.PessoaModule.ClienteModule.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Dominio.Entities.PessoaModule.Senha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("STRING");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("BINARY(16)");

                    b.HasKey("Id");

                    b.ToTable("TBSenha");
                });

            modelBuilder.Entity("Dominio.ParceiroModule.Parceiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.HasKey("Id");

                    b.ToTable("TBParceiro");
                });

            modelBuilder.Entity("Dominio.PessoaModule.CNH", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NumeroCnh")
                        .IsRequired()
                        .HasColumnType("CHAR(11)");

                    b.Property<string>("TipoCnh")
                        .IsRequired()
                        .HasColumnType("VARCHAR(2)");

                    b.HasKey("Id");

                    b.ToTable("TBCnh");
                });

            modelBuilder.Entity("Dominio.PessoaModule.ClienteModule.ClientePJ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("CHAR(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("CHAR(11)");

                    b.HasKey("Id");

                    b.ToTable("TBClientePJ");
                });

            modelBuilder.Entity("Dominio.PessoaModule.Condutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CnhId")
                        .HasColumnType("int");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("CHAR(11)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("CHAR(11)");

                    b.HasKey("Id");

                    b.HasIndex("CnhId");

                    b.ToTable("Condutor");
                });

            modelBuilder.Entity("Dominio.PessoaModule.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cargo")
                        .HasColumnType("int");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("CHAR(11)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("VARCHAR(40)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("CHAR(11)");

                    b.HasKey("Id");

                    b.ToTable("TBFuncionario");
                });

            modelBuilder.Entity("Dominio.ServicoModule.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AluguelId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.Property<double>("Taxa")
                        .HasColumnType("FLOAT");

                    b.HasKey("Id");

                    b.HasIndex("AluguelId");

                    b.ToTable("TBServico");
                });

            modelBuilder.Entity("Dominio.VeiculoModule.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.Property<double>("PrecoDiaria")
                        .HasColumnType("FLOAT");

                    b.Property<double>("PrecoKm")
                        .HasColumnType("FLOAT");

                    b.Property<double>("PrecoLivre")
                        .HasColumnType("FLOAT");

                    b.Property<int>("QuilometragemFranquia")
                        .HasColumnType("INT");

                    b.Property<string>("TipoDeCnh")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.HasKey("Id");

                    b.ToTable("TBCategoria");
                });

            modelBuilder.Entity("Dominio.VeiculoModule.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano")
                        .HasColumnType("INT");

                    b.Property<bool>("Automatico")
                        .HasColumnType("BIT");

                    b.Property<int>("Capacidade")
                        .HasColumnType("INT");

                    b.Property<int>("CapacidadeTanque")
                        .HasColumnType("INT");

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Chassi")
                        .IsRequired()
                        .HasColumnType("CHAR(17)");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("CHAR(8)");

                    b.Property<int>("Porta_malas")
                        .HasColumnType("INT");

                    b.Property<int>("Portas")
                        .HasColumnType("INT");

                    b.Property<int>("Quilometragem")
                        .HasColumnType("INT");

                    b.Property<int>("TipoDeCombustivel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("TBVeiculo");
                });

            modelBuilder.Entity("Dominio.PessoaModule.ClienteModule.ClientePF", b =>
                {
                    b.HasBaseType("Dominio.PessoaModule.Condutor");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.ToTable("TBClientePF");
                });

            modelBuilder.Entity("Dominio.PessoaModule.Motorista", b =>
                {
                    b.HasBaseType("Dominio.PessoaModule.Condutor");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.HasIndex("EmpresaId");

                    b.ToTable("TBMotorista");
                });

            modelBuilder.Entity("Dominio.AluguelModule.Aluguel", b =>
                {
                    b.HasOne("Dominio.Entities.PessoaModule.ClienteModule.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("Dominio.PessoaModule.Condutor", "Condutor")
                        .WithMany()
                        .HasForeignKey("CondutorId");

                    b.HasOne("Dominio.CupomModule.Cupom", "Cupom")
                        .WithMany()
                        .HasForeignKey("CupomId");

                    b.HasOne("Dominio.PessoaModule.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId");

                    b.HasOne("Dominio.VeiculoModule.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId");

                    b.Navigation("Cliente");

                    b.Navigation("Condutor");

                    b.Navigation("Cupom");

                    b.Navigation("Funcionario");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("Dominio.AluguelModule.RelatorioAluguel", b =>
                {
                    b.HasOne("Dominio.AluguelModule.Aluguel", "Aluguel")
                        .WithMany()
                        .HasForeignKey("AluguelId");

                    b.Navigation("Aluguel");
                });

            modelBuilder.Entity("Dominio.CupomModule.Cupom", b =>
                {
                    b.HasOne("Dominio.ParceiroModule.Parceiro", "Parceiro")
                        .WithMany()
                        .HasForeignKey("ParceiroId");

                    b.Navigation("Parceiro");
                });

            modelBuilder.Entity("Dominio.PessoaModule.Condutor", b =>
                {
                    b.HasOne("Dominio.PessoaModule.CNH", "Cnh")
                        .WithMany()
                        .HasForeignKey("CnhId");

                    b.Navigation("Cnh");
                });

            modelBuilder.Entity("Dominio.ServicoModule.Servico", b =>
                {
                    b.HasOne("Dominio.AluguelModule.Aluguel", "Aluguel")
                        .WithMany("Servicos")
                        .HasForeignKey("AluguelId");

                    b.Navigation("Aluguel");
                });

            modelBuilder.Entity("Dominio.VeiculoModule.Veiculo", b =>
                {
                    b.HasOne("Dominio.VeiculoModule.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Dominio.PessoaModule.ClienteModule.ClientePF", b =>
                {
                    b.HasOne("Dominio.PessoaModule.Condutor", null)
                        .WithOne()
                        .HasForeignKey("Dominio.PessoaModule.ClienteModule.ClientePF", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.PessoaModule.Motorista", b =>
                {
                    b.HasOne("Dominio.PessoaModule.ClienteModule.ClientePJ", "Empresa")
                        .WithMany("Motoristas")
                        .HasForeignKey("EmpresaId");

                    b.HasOne("Dominio.PessoaModule.Condutor", null)
                        .WithOne()
                        .HasForeignKey("Dominio.PessoaModule.Motorista", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Dominio.AluguelModule.Aluguel", b =>
                {
                    b.Navigation("Servicos");
                });

            modelBuilder.Entity("Dominio.PessoaModule.ClienteModule.ClientePJ", b =>
                {
                    b.Navigation("Motoristas");
                });
#pragma warning restore 612, 618
        }
    }
}
