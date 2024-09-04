using System;

public class Cadete
{
    private int id;
    private string direccion;
    private string telefono;
    private string nombre;

    public List<Pedidos> ListaPedidos { get; set; }

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        ListaPedidos = new List<Pedidos>();
    }
    
    public int VerId()
    {
        return id;
    }

    public string VerNombre()
    {
        return nombre;
    }

    public void AñadirPedido(Pedidos pedido)
    {
        ListaPedidos.Add(pedido);
    }
}