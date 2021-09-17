﻿using Aplicacao.Shared;
using Dominio.ServicoModule;
using Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.ServicosModule
{
    public class ServicosAppServices : EntidadeAppServices<Servico>
    {
        public override IEntidadeRepository<Servico> Repositorio { get; }

        public ServicosAppServices(IEntidadeRepository<Servico> repositorio)
        {
            Repositorio = repositorio;
        }
    }
}