using ISLAGO.Entidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISLAGO.Negocio.Interfaces
{
    public interface IUsuarioService
    {

        Task<List<Usuario>> Lista();
        Task<Usuario> Crear(Usuario entidad, Stream img = null);
        Task<Usuario> Editar(Usuario entidad, Stream img = null);

        Task<bool> Eliminar(int id);
        Task<Usuario> ObtenerPorCredenciales(string username, string password);
        Task<Usuario> ObtenerPorId(int id);
        Task<bool> GuardarPerfil(Usuario entidad);
        Task<bool> CambiarClave(int id, string actualPassword, string newPassword);

    }
}
