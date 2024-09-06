using System;

public enum Estado
{
    Cancelado,
    Pendiente,
    Entregado
};

public class Pedidos
{
    private string observacion;
    private Estado estado;
    private int numero;
    private int idCadete;
    private Cliente cliente;


    public Pedidos(string observacion, string nombre, string direccion, string telefono, string datosReferenciaDireccion)
    {
        this.numero = new Random().Next(0, 100000); //simulo una eleccion de numero unico para el pedido, ya se que puede repetirse pero bueno
        this.observacion = observacion;
        this.estado = Estado.Pendiente;

        cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
    }

    public Estado VerEstado()
    {
        return estado;
    }

    public int VerNumero()
    {
        return numero;
    }

    public Cliente VerCliente()
    {
        return cliente;
    }

    public void CambiarEstado(Estado estado)
    {
        this.estado = estado;
    }

     public int VerIdCadete(){
        return idCadete;
    }
    public void AsignarCadete(int idCadete)
    {
        this.idCadete = idCadete;
    }
}