﻿using Dominio.Shared;

namespace Dominio.AluguelModule
{
    public interface IAluguelRepository : IEntidadeRepository<Aluguel>
    {
        void SalvarRelatorio(EnvioResumoAluguel envio);
    }
}