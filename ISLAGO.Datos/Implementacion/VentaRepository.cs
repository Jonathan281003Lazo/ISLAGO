using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using ISLAGO.Datos.DBContext;
using ISLAGO.Datos.Interfaces;
using ISLAGO.Entidad;
using ISLAGO.Entidad.Models;
using System.Linq.Expressions;

namespace ISLAGO.Datos.Implementacion
{
    public class VentaRepository : GenericRepository<Factura>, IVentaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VentaRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<IQueryable<Factura>> Consultar(Expression<Func<Factura, bool>> filtro = null)
        {
            throw new NotImplementedException();
        }

        public Task<Factura> Crear(Factura entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(Factura entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(Factura entidad)
        {
            throw new NotImplementedException();
        }

        public Task<Factura> Obtener(Expression<Func<Factura, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public async Task<Factura> Registrar(Factura entidad)
        {

            Factura FacturaGenerada = new Factura();

            using (var transition = _dbContext.Database.BeginTransaction())
            {

                try
                {

                    foreach(Detfactura df in entidad.Detfacturas)
                    {

                        Articulo Articulo_Encontrado = _dbContext.Articulos.Where(p => p.Id == df.Id).First();
                        Articulo_Encontrado.Existencia = Articulo_Encontrado.Existencia - df.Cantidad;
                        _dbContext.Articulos.Update(Articulo_Encontrado);

                    }

                    await _dbContext.SaveChangesAsync();

                    //NumeroCorrelativo

                }
                catch (Exception ex)
                {

                    transition.Rollback();
                    throw ex;

                }

            }
           
        }

        public Task<List<Factura>> Reporte(DateTime FechaInicio, DateTime FechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
