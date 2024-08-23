using System.Runtime.Intrinsics.X86;

public class Cadeteria
{
    private string nombre;

    private string telefono;
    private List<Cadete> cadetes;


    public string Nombre { get => nombre;}

    public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }
    public string Telefono { get => telefono;}

    public Cadeteria(string nombre, string telefono, List<Cadete> cadetes)
    {
        this.nombre = nombre;
        this.nombre = telefono;
        this.cadetes = cadetes;
        cadetes.OrderDescending();
    }

    public void AsignarPedidos(Pedido pedido)
    {
        cadetes[cadetes.Count-1].Pedidos.Add(pedido);
        cadetes.OrderDescending();
        
    }

    public void MostrarJornalesYEnvios()
    {
        int totalEnvios = 0;
        foreach (var cadete in cadetes)
        {
            float pago = cadete.JornalACobrar();
            Console.WriteLine($"{cadete.Nombre}-${pago}-{cadete.CantidadDePedidosCompletados}");
            totalEnvios += cadete.CantidadDePedidosCompletados;
        }
        Console.WriteLine($"Total-Envios: {totalEnvios}");
        
    }

}