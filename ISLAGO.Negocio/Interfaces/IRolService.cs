using ISLAGO.Entidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISLAGO.Negocio.Interfaces
{
    public interface IRolService
    {

        Task<List<Rol>> Lista();

    }
}
