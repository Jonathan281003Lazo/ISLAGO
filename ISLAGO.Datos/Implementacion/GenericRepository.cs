using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ISLAGO.Datos.DBContext;
using ISLAGO.Datos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ISLAGO.Datos.Implementacion
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository()
        {
            
        }

        public Task<TEntity> Obtener(Expression<Func<TEntity, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Crear(TEntity entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(TEntity entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(TEntity entidad)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> Consultar(Expression<Func<TEntity, bool>> filtro = null)
        {
            throw new NotImplementedException();
        }

    }
}
