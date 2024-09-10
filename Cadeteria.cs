using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;
public class Cadeteria
{
      [JsonInclude]
    private string nombre;
    [JsonInclude]
    private string telefono;

     private List<Cadete> listaCadetes;
    private List<Pedidos> listaPedidos; 

    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        listaCadetes = new List<Cadete>();
        listaPedidos = new List<Pedidos>();
    }

   public int JornalACobrar(int idCadete)
    {
        int cont = 0;
        var cadete = listaCadetes.Find(c => c.VerId() == idCadete);
        
        foreach(var pedido in listaPedidos)
        {
            if(pedido.VerIdCadete() == idCadete)
            {
                if(pedido.VerEstado() == Estado.Entregado)
                {
                    cont += 500;
                }
            }
        }

        return cont;
    }
   public void AsignarCadeteAPedido(int idCadete, int idPedido)
    {
        var pedido = listaPedidos.Find(p => p.VerNumero() == idPedido);
        pedido.AsignarCadete(idCadete);
    }

      public void AgregarCadete(int id, string nombre, string direccion, string telefono)
    {
        var nuevoCadete = new Cadete(id, nombre, direccion, telefono);
        listaCadetes.Add(nuevoCadete);
    }
      public void AgregarPedido(Pedidos pedido)
    {
        listaPedidos.Add(pedido);
    }


    private Cadete CadeteAleatorio()
    {
        var indexRandom = new Random().Next(listaCadetes.Count);
        var cadete = listaCadetes[indexRandom];
        return cadete;
    }

    public int IdCadeteAleatorio()
    {
        var cadete = CadeteAleatorio();
        return cadete.VerId();
    }
     public int IdPedidoPendiente()
    {
        var pedidoPendiente = listaPedidos.FirstOrDefault(p => p.VerEstado() == Estado.Pendiente);

        if(pedidoPendiente != null)
        {
            return pedidoPendiente.VerNumero();
        }
        else
        {
            return -1;
        }
    }

    public void ReasignarPedido(int numeroPedido, int idCadete)
    {
        var pedido = listaPedidos.Find(p => p.VerNumero() == numeroPedido);
        pedido.AsignarCadete(idCadete);
    }

    public void CambiarEstadoPedido(int numero)
    {
        var pedido = listaPedidos.Find(p => p.VerNumero() == numero);

        Console.WriteLine($"Su estado actual es {pedido.VerEstado()}, cual será su nuevo estado?");
        Console.WriteLine("0 = Cancelado");
        Console.WriteLine("1 = Entregado");
        Console.Write("Opcion: ");
        int opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 0:
                pedido.CambiarEstado(Estado.Cancelado);
                break;
            case 1:
                pedido.CambiarEstado(Estado.Entregado);
                break;
        }
    }

    public bool ExistePedido(int numero)
    {
        return listaPedidos.Any(p => p.VerNumero() == numero);
    }

    public bool ExisteCadete(int id)
    {
        return listaCadetes.Any(c => c.VerId() == id);
    }

    public void MostrarPedidosPendientes()
    {
        foreach (var pedido in listaPedidos)
        {
            if (pedido.VerEstado() == Estado.Pendiente)
            {
                Console.WriteLine($"Numero: {pedido.VerNumero()}, Cliente: {pedido.VerCliente().VerNombre()} | " +
                    $"Cadete: {(pedido.VerIdCadete() != null ? "Asignado" : "Sin Asignar")}");
            }
        } 
    }

    public void MostrarCadetes()
    {
        foreach(var cadete in listaCadetes)
        {
            Console.WriteLine($"{cadete.VerId()} | {cadete.VerNombre()}");
        }
    }

   
}