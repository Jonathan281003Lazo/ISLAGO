using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text;
using ISLAGO.Negocio;
using ISLAGO.Datos;
using ISLAGO.Entidad;
using ISLAGO.Negocio.Interfaces;
using ISLAGO.Entidad.Models;
using ISLAGO.Datos.Interfaces;

namespace ISLAGO.Negocio.Implementacion
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IGenericRepository<Usuario> _repo;
        private readonly IBase64IMG _base64;
        private readonly IUsuarioService _uServices;
        private readonly ICorreoService _cservice;
        private readonly IUtilidadesService _utilidades;

        public UsuarioService(

            IGenericRepository<Usuario> repo,
            IBase64IMG base64,
            IUsuarioService uservice,
            ICorreoService cservice,
            IUtilidadesService utilidades

            )
        {
            
            _repo = repo;
            _base64 = base64;
            _uServices = uservice;
            _cservice = cservice;
            _utilidades = utilidades;

        }

        public async Task<List<Usuario>> Lista()
        {

            IQueryable<Usuario> query = await _repo.Consultar();
            return query.Include(r => r.IdRolNavigation).ToList();

        }

        public async Task<Usuario> Crear(Usuario entidad, Stream img = null)
        {

            Usuario usuario_exist = await _repo.Obtener(u => u.Username == entidad.Username);

            if(usuario_exist != null)
            {

                throw new TaskCanceledException("El usuario ya existe");

            }

            try
            {

                string contraseña_generada = _utilidades.GenerarClave();
                entidad.Password = _utilidades.ConvertirSha256(contraseña_generada);

            }
            catch
            {

            }

        }

        public Task<Usuario> Editar(Usuario entidad, Stream img = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GuardarPerfil(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObtenerPorCredenciales(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CambiarClave(int id, string actualPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

    }
}
