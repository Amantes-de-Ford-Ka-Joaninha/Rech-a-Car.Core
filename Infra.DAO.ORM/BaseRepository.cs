﻿using Dominio.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.DAO.ORM
{
    public class BaseRepository<T> : IRepository<T> where T : Entidade
    {
        protected rech_a_carDbContext Context;

        public List<T> Registros => Context.Set<T>().ToList();

        public void Editar(int id, T entidade)
        {
            Context.Update(entidade);
            Context.SaveChanges();
        }

        public void Excluir(int id, Type tipo = null)
        {
            var entidade = GetById(id);
            Context.Remove(entidade);
            Context.SaveChanges();
        }

        public bool Existe(int id, Type tipo = null)
        {
            return Context.Set<T>().Where(x => x.Id == id).Count() != 0;
        }
        public List<T> FiltroGenerico(string filtro)
        {
            var palavras = filtro.Split(' ');
            return Context.Set<T>().AsNoTracking().Where(i => palavras.Any(p => i.ToString().IndexOf(p, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();
        }
        public T GetById(int id, Type tipo = null)
        {
            return Context.Set<T>().Find(id);
        }
        public void Inserir(T entidade)
        {
            Context.Set<T>().Add(entidade);
            Context.SaveChanges();
        }
    }
}
