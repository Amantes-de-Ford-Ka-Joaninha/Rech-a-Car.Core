﻿using Aplicacao.Shared;
using Dominio.Shared;
using Dominio.VeiculoModule;

namespace Aplicacao.VeiculoModule
{
    public class VeiculoAppServices : EntidadeAppServices<Veiculo>
    {
        public VeiculoAppServices(IEntidadeRepository<Veiculo> repositorio, IEntidadeRepository<Categoria> repositorioCategoria)
        {
            Repositorio = repositorio;
            RepositorioCategoria = repositorioCategoria;
        }

        public override IEntidadeRepository<Veiculo> Repositorio { get; }
        public IEntidadeRepository<Categoria> RepositorioCategoria { get; }
    }
}
