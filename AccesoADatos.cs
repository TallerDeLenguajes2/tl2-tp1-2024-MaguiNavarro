using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

public abstract class AccesoADatos
{
	public abstract Cadeteria CargarCadeteria(string rutaCadeteria);
    public abstract List<Cadete> CargarCadetes(string rutaCadetes);
}
public class AccesoCSV : AccesoADatos
{
public override Cadeteria CargarCadeteria(string rutaCadeteria)
    {
        string[] datos = File.ReadAllText(rutaCadeteria).Split(',');
        var cadeteria = new Cadeteria(datos[0], datos[1]);
        
        return cadeteria;
    }

    public override List<Cadete> CargarCadetes(string rutaCadetes)
    {
        var listaCadetes = new List<Cadete>();
        string[] lineas = File.ReadAllLines(rutaCadetes);
        foreach (var linea in lineas)
        {
            string[] datos = linea.Split(',');
            var cadete = new Cadete(int.Parse(datos[0]), datos[1], datos[2], datos[3]);
            listaCadetes.Add(cadete);    
        }
        return  listaCadetes;
    }

 }

 public class AccesoJson : AccesoADatos
{
    public override Cadeteria CargarCadeteria(string rutaCadeteria)
    {
        var stringJson = new HelperJson().AbrirArchivo(rutaCadeteria);

        var cadeteria = JsonSerializer.Deserialize<Cadeteria>(stringJson);

        return cadeteria;
    }

    public override List<Cadete> CargarCadetes(string rutaCadetes)
    {
        var listaCadetes = new List<Cadete>();

        var stringJson = new HelperJson().AbrirArchivo(rutaCadetes);

        listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(stringJson);

        return listaCadetes;
    }
}