public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> pedidos;

    private int cantidadDePedidosCompletados;

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        CantidadDePedidosCompletados = 0;
    }

    public int Id { get => id;}
    public string Nombre { get => nombre; }
    public string Direccion { get => direccion; }
    public string Telefono { get => telefono; }
    public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }
    public int CantidadDePedidosCompletados { get => cantidadDePedidosCompletados; set => cantidadDePedidosCompletados = value; }

    public float JornalACobrar()
    {
        float jornal = 500 * CantidadDePedidosCompletados;
        return jornal;
    }
    
    public void RetirarPedido()
    {

    }
}