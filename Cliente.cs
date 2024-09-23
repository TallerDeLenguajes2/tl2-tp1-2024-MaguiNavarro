using System;

public class Cliente
{
	private string direccion;
	private string telefono;
	private string datosReferenciaDireccion;
	private string nombre;
	
	public Cliente(string nombres, string direccion, string telefono, string datosReferenciaDireccion)
	{
		this.nombre = nombres;
		this.direccion = direccion;
		this.telefono = telefono;
		this.datosReferenciaDireccion = datosReferenciaDireccion;
	}

	public string VerNombre()
	{
		return nombre;
	}
}