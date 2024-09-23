using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace DatosDesdeArchivos
{
    public class AccesoCSV : AccesoADatos
    {
        public override Cadeteria CargarCadeteria(string rutaCadeteria)
        {
            string[] datos = File.ReadAllText(rutaCadeteria).Split(',');
            
            string nombreCadeteria = datos[0];
            string telefonoCadeteria = datos[1];

            var cadeteria = new Cadeteria(nombreCadeteria, telefonoCadeteria);
            
            return cadeteria;
        }

        public override List<Cadete> CargarCadetes(string rutaCadetes)
        {
            var listaCadetes = new List<Cadete>();
            string[] lineasCSV = File.ReadAllLines(rutaCadetes);

            foreach (var linea in lineasCSV)
            {
                string[] datosCadete = linea.Split(',');
                var nuevoCadete = new Cadete(int.Parse(datosCadete[0]), datosCadete[1], datosCadete[2], datosCadete[3]);
                listaCadetes.Add(nuevoCadete);
            }

            return listaCadetes;
        }
    }
}