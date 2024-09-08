using System;
using System.Reflection;
using System.Linq;

Console.Clear();

var Cadeteria = new Cadeteria();
Cadeteria.(@"C:\Users\Magui Navarro\Desktop\Facultad\Taller2\TP1\tl2-tp1-2024-MaguiNavarro\ArchivosCsv\Cadeteria.csv", @"C:\Users\Magui Navarro\Desktop\Facultad\Taller2\TP1\tl2-tp1-2024-MaguiNavarro\ArchivosCsv\Cadetes.csv");


int opcion = 0;


while (true)
{
    Console.WriteLine("----- MENU -----");
    Console.WriteLine("1- Dar de alta pedidos");
    Console.WriteLine("2- Asignar pedido a cadete");
    Console.WriteLine("3- Cambiar estado del pedido");
    Console.WriteLine("4- Asignar pedido a otro cadete");
    Console.WriteLine("5- Mostrar Informe");
    Console.Write("Opcion: ");
    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:

            Console.WriteLine("Datos del cliente que tomará el pedido");
            Console.Write("Nombre: ");
            string Nombre = Console.ReadLine();

            Console.WriteLine("Direccion: ");
            string Direccion = Console.ReadLine();

            Console.WriteLine("Telefono: ");
            string Telefono = Console.ReadLine();

            Console.WriteLine("Datos de referencia de tu domicilio: ");
            string DatosRef = Console.ReadLine();

            Console.WriteLine("Alguna observacion? (si no tiene ninguna dejar en blanco): ");
            string Observacion = Console.ReadLine();

            Pedidos NuevoPedido = new Pedidos(Observacion, Nombre, Direccion, Telefono, DatosRef);


            break;
        case 2:
            var idCadete = Cadeteria.IdCadeteAleatorio();
            var idPedido = Cadeteria.IdPedidoPendiente();

            if (idPedido != -1)
            {
                Cadeteria.AsignarCadeteAPedido(idCadete, idPedido);
                Console.WriteLine("Pedido asignado con exito");
            }
            else
            {
                Console.WriteLine("No existen pedidos para ser asignados");
            }
            break;
        case 3:
            Console.WriteLine("Pedidos pendientes restantes: ");
            Cadeteria.MostrarPedidosPendientes();

            Cadeteria.AsignarCadeteAPedido;

            break;
        case 4:
            Console.WriteLine("Pedidos pendientes restantes: ");
            Cadeteria.MostrarPedidosPendientes();

            Console.Write("Ingrese el numero del pedido:");
            NroPedido = int.Parse(Console.ReadLine());

            pedido = Cadeteria.AsignarCadeteAPedido(NroPedido);
            if (pedido != null)
            {
                Console.WriteLine("Elija el cadete que tendrá el pedido: ");
                Cadeteria.MostrarCadetes();

            }
            else
            {
                Console.WriteLine("Pedido no encontrado");
            }

            break;
        case 5:
            GenerarInformeJornal();
            break;
    }
}
void GenerarInformeJornal()
{
    Console.WriteLine("--- Informe jornal ---");

    //creo lo que se llama un tipo anonimo, en el que encapsulo una serie de propiedades en un objeto sin definir un tipo explicitamente.
    var InformeQuery = from cadete in Cadeteria.ListaCadetes
                       select new
                       {
                           Nombre = cadete.VerNombre(),
                           EnviosCompletados = cadete.ListaPedidos.Count(p => p.VerEstado() == Estado.Entregado), //cuento la cant de envios completados que tiene
                           MontoRecaudado = cadete.ListaPedidos.Where(p => p.VerEstado() == Estado.Entregado) //filtro los pedidos para quedarme solo con los que fueron entregados
                                                           .Sum(p => 500)
                       };

    foreach (var cadete in InformeQuery)
    {
        Console.WriteLine($"Cadete: {cadete.Nombre} | Envios completados: {cadete.EnviosCompletados} | Monto recaudado: {cadete.MontoRecaudado}");
    }

    var TotalRecuadado = InformeQuery.Sum(c => c.MontoRecaudado);
    var EnviosTotales = InformeQuery.Sum(c => c.EnviosCompletados);
    var EnviosPromedio = InformeQuery.Average(c => c.EnviosCompletados);

    Console.WriteLine($"Total recaudado entre todos los cadetes: {TotalRecuadado}");
    Console.WriteLine($"Envios totales: {EnviosTotales}");
    Console.WriteLine($"Envios en promedio por cadete: {EnviosPromedio}");
}
