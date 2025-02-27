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

                    Numerocorrelativo correlativo = _dbContext.Numerocorrelativos.Where(n => n.Gestion == "venta").First();

                    correlativo.Ultimonumero = correlativo.Ultimonumero + 1;
                    correlativo.Fechaactualizacion = DateTime.Now;

                    _dbContext.Numerocorrelativos.Update(correlativo);
                    await _dbContext.SaveChangesAsync();

                    string ceros = string.Concat(Enumerable.Repeat("0", correlativo.Cantidaddigitos.Value));
                    string numeroventa = ceros + correlativo.Ultimonumero.ToString();
                    numeroventa = numeroventa.Substring(numeroventa.Length - correlativo.Cantidaddigitos.Value, correlativo.Cantidaddigitos.Value);

                    entidad.Numeroventa = numeroventa;

                    await _dbContext.Factura.AddAsync(entidad);
                    await _dbContext.SaveChangesAsync();

                    FacturaGenerada = entidad;

                    transition.Commit();

                }
                catch (Exception ex)
                {

                    transition.Rollback();
                    throw ex;

                }

            }

            return FacturaGenerada;
           
        }

        public async Task<List<Detfactura>> Reporte(DateTime FechaInicio, DateTime FechaFin)
        {

            //throw new NotImplementedException();
            List<Detfactura> listaResumen = await _dbContext.Detfacturas
                .Include(f => f.IdfacturaNavigation)
                .ThenInclude(U => U.IdusuarioNavigation)
                .Include(f => f.IdfacturaNavigation)
                .ThenInclude(tdfv => tdfv.IdTipoDocumentoNavigation)
                .Where(df => df.IdfacturaNavigation.Fecha.Date >= FechaInicio.Date && 
                    df.IdfacturaNavigation.Fecha.Date <= FechaFin.Date    
                ).ToListAsync();

            return listaResumen;
        }
    }
}
