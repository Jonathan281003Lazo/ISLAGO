
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ISLAGO.Negocio.Interfaces;
using ISLAGO.Datos.Interfaces;
using ISLAGO.Entidad;
using ISLAGO.Entidad.Models;

namespace ISLAGO.Negocio.Implementacion
{
    public class RolService : IRolService
    {
        private readonly IGenericRepository<Rol> _repo;

        public RolService(IGenericRepository<Rol> repo)
        {
            _repo = repo;
        }

        public async Task<List<Rol>> Lista()
        {

            IQueryable<Rol> query = await _repo.Consultar();

            return query.ToList();

        }
    }
}
