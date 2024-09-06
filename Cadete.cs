using System;

public class Cadete
{
    private int id;
    private string direccion;
    private string telefono;
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

   
}