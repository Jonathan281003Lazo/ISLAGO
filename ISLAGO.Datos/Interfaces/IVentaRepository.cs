using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ISLAGO.Entidad;
using ISLAGO.Entidad.Models;

namespace ISLAGO.Datos.Interfaces
{
    public interface IVentaRepository : IGenericRepository<Factura>
    {

        Task<Factura> Registrar(Factura entidad);
        Task<List<Detfactura>> Reporte(DateTime FechaInicio, DateTime FechaFin);

    }
}
