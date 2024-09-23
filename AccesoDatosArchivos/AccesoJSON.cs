using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace DatosDesdeArchivos
{
    public class AccesoJson : AccesoADatos
    {
        public override Cadeteria CargarCadeteria(string rutaCadeteria)
        {
            var stringJson = new HelperJson().AbrirArchivo(rutaCadeteria);

            var nuevaCadeteria = JsonSerializer.Deserialize<Cadeteria>(stringJson);

            return nuevaCadeteria;
        }

        public override List<Cadete> CargarCadetes(string rutaCadetes)
        {
            var listaCadetes = new List<Cadete>();

            var stringJson = new HelperJson().AbrirArchivo(rutaCadetes);

            listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(stringJson);

            return listaCadetes;
        }
    }
}