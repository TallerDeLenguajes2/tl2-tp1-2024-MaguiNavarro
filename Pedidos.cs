public class Pedido
{
    public int Numero { get; set; }
    public string Observacion { get; set; }

    private Cliente cliente;

    public Pedido(int nro, string obs, Estados estado, string nombre, string direcc, string telefono, string referencias)
    {
        Numero = nro;
        Observacion = obs;
        cliente = new Cliente(nombre, direcc, telefono, referencias);
    }

    public Estados Estado {get;set;}

    

    public void VerDireccionCliente()
    {

    }
    public void VerDatosCliente()
    {

    }
}