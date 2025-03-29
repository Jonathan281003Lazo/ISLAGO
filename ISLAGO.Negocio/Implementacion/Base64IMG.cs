using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISLAGO.Datos.Interfaces;
using ISLAGO.Entidad.Models;
using ISLAGO.Negocio.Interfaces;
using System.IO;
using System.Runtime;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;

namespace ISLAGO.Negocio.Implementacion
{
    public class Base64IMG : IBase64IMG
    {
        private readonly IGenericRepository<Configuracion> _repo;

        public Base64IMG(IGenericRepository<Configuracion> repo)
        {
            _repo = repo;
        }

        public async Task<string> GuardarImagen(Stream StreamArchivo, string CarpetaDestino, string NombreArchivo)
        {
            string UrlImagen = "";

            try
            {

                // Obtenemos la configuracion de la BD donde recurso sea "imagen"
                IQueryable<Configuracion> query = await _repo.Consultar(c => c.Recurso.Equals("imagen"));

                Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);

                // Obtenemos la ruta desde la bd
                string CarpeDestino = Config["ruta"];
                string TamañoMaximo = Config["tamaño"]; // Esperamos que sea en kb
                string FormatoPermitido = Config["formato"].ToLower();

                // Validacion del tamaño permitido del archivo ( convertir a kb )
                const long MAX_SIZE = 5 * 1024 * 1024;  // 5 MB
                if (StreamArchivo.Length > MAX_SIZE)
                {

                    return "El archivo excede el tamaño máximo permitido.";

                }

                // Validación  de formato por si es necesario 
                string extension = Path.GetExtension(NombreArchivo).TrimStart('.').ToLower();
                if (!FormatoPermitido.Contains(extension))
                {

                    throw new Exception("El formato del archivo no es valido.");

                }

                // Verificamos si la carpeta del archivo existe, sino la creamos.
                if (!Directory.Exists(CarpeDestino))
                {

                    Directory.CreateDirectory(CarpeDestino);

                }

                // Crear ruta del archivo
                string RutaCompleta = Path.Combine(CarpeDestino, NombreArchivo);

                // Guardar el archivo en el disco
                using (var fileStream = new FileStream(RutaCompleta, FileMode.Create, FileAccess.Write))
                {
                    await StreamArchivo.CopyToAsync(fileStream);
                }

                // Retornar la URL de la imagen guardada
                UrlImagen = Path.Combine(CarpetaDestino, NombreArchivo);
                return UrlImagen;

            }
            catch (Exception ex)
            {

                return $"Error al guardar la imagen: {ex.Message}";

            }

        }

        private string ConvertStringToBase64(string filePath)
        {

            byte[] fileBytes = File.ReadAllBytes(filePath);
            return Convert.ToBase64String(fileBytes);

        }

        public async Task<string> ConvertToBase64(string CarpetaDestino, string NombreArchivo)
        {

            try
            {

                // Consultamos la tabla configuración de la ruta base desde la DB
                IQueryable<Configuracion> query = await _repo.Consultar(c => c.Recurso.Equals("imagen"));
                Dictionary<string, string> config = query.ToDictionary(c => c.Propiedad, c => c.Valor);

                //Obtener la ruta desde la configuración
                string RutaBase = config["ruta"];
                string RutaCompleta = Path.Combine(RutaBase, CarpetaDestino, NombreArchivo);

                //Validamos la existencia del archivo
                if (!File.Exists(RutaCompleta))
                {
                    Console.WriteLine("El archivo no existe");
                }

                return ConvertStringToBase64(RutaCompleta);

            }
            catch (Exception ex)
            {
                return $"Error al convertir la imagen a base64: {ex.Message}";
            }
        }

        public async Task<string> EliminarStorage(string CarpetaDestino, string NombreArchivo)
        {

            try
            {

                IQueryable<Configuracion> query = await _repo.Consultar(c => c.Recurso.Equals("imagen"));
                Dictionary<string, string> Config = query.ToDictionary(c => c.Propiedad, c => c.Valor);

                string RutaBase = Config["ruta"];
                string RutaCompleta = Path.Combine(RutaBase, CarpetaDestino, NombreArchivo);

                if(File.Exists(RutaCompleta))
                {
                    File.Delete(RutaCompleta);
                    return "El archivo fue eliminado correctamente";
                }

                return "Error al eliminar el archivio";

            }
            catch (Exception ex)
            {
                return $"Error al eliminar imagen{ex.Message}";
            }

        }

        public async Task<string> ActualizarImagen(Stream StreamArchivo, string CarpetaDestiono, string NombreArchivo)
        {

            try
            {

                // Consultamos la tabla configuración para obtener la ruta de destino desde la BD
                IQueryable<Configuracion> query = await _repo.Consultar(c => c.Recurso.Equals("imagen"));
                Dictionary<string, string> config = query.ToDictionary(c => c.Propiedad, c => c.Valor);

                // Obtener la ruta de destino desde la configuración
                string RutaBase = config["ruta"];
                string RutaCompleta = Path.Combine(RutaBase, CarpetaDestiono, NombreArchivo);

                // Verificar si el archivo existe en la ruta
                if (File.Exists(RutaCompleta))
                {

                    File.Delete(RutaCompleta);

                }

                // Verficar si la carpeta destino existe, si no la crea
                if (!Directory.Exists(Path.GetDirectoryName(RutaCompleta)))
                {

                    Directory.CreateDirectory(Path.GetDirectoryName(RutaCompleta));

                }

                // Guardamos la nueva imagen
                using (var fileStream = new FileStream(RutaCompleta, FileMode.Create, FileAccess.Write))
                {

                    await StreamArchivo.CopyToAsync(fileStream); // Aquí usamos StreamArchivo 

                }

                return $"La imagen {NombreArchivo} se actualizo correctamente.";

            }
            catch (Exception ex)
            {

                return $"Error al actualizar la imagen: {ex.Message}";

            }

        }
    }
}
