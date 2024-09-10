using System;
using System.Text.Json.Serialization;
public class Cadete
{
   [JsonInclude]
    private int id;
    [JsonInclude]
    private string direccion;
    [JsonInclude]
    private string telefono;
    [JsonInclude]
    private string nombre;


    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    
    }
    
    public int VerId()
    {
        return id;
    }

    public string VerNombre()
    {
        return nombre;
    }
      public string VerDireccion()
    {
        return direccion;
    }
       public string VerTelefono()
    {
        return telefono;
    }
}