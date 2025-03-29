using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISLAGO.Negocio.Interfaces
{
    public interface IBase64IMG
    {

        Task<string> GuardarImagen(Stream StreamArchivo, string CarpetaDestino, string NombreArchivo);
        Task<string> ConvertToBase64(string CarpetaDestino, string NombreArchivo);
        Task<string> ActualizarImagen(Stream StreamArchivo, string CarpetaDestiono, string NombreArchivo);
        Task<string> EliminarStorage(string CarpetaDestino, string NombreArchivo);

    }
}
