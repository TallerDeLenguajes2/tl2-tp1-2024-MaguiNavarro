using System;
using System.Reflection;
using System.Linq;
using DatosDesdeArchivos;
Console.Clear();


Cadeteria Cadeteria = null;

Console.WriteLine("Que tipo de acceso quiere usar? 0 = CSV, 1 = JSON");
int opcionAcceso = int.Parse(Console.ReadLine());
switch (opcionAcceso)
{
    case 0:
        var accesoDatosCSV = new AccesoCSV();
        Cadeteria = accesoDatosCSV.CargarCadeteria(@"C:\Users\Magui Navarro\Desktop\Facultad\Taller2\TP1\tl2-tp1-2024-MaguiNavarro\ArchivosCsv\Cadeteria.csv");
        foreach (var cadete in accesoDatosCSV.CargarCadetes(@"C:\Users\Magui Navarro\Desktop\Facultad\Taller2\TP1\tl2-tp1-2024-MaguiNavarro\ArchivosCsv\Cadetes.csv"))
        {
            Cadeteria.AgregarCadete(cadete.VerId(), cadete.VerNombre(), cadete.VerDireccion(), cadete.VerTelefono());
        }
        break;
    case 1:
        var accesoDatosJSON = new AccesoJson();
        Cadeteria = accesoDatosJSON.CargarCadeteria(@"C:\Users\Magui Navarro\Desktop\Facultad\Taller2\TP1\tl2-tp1-2024-MaguiNavarro\ArchivosJson\Cadeteria.json");
        foreach (var cadete in accesoDatosJSON.CargarCadetes(@"C:\Users\Magui Navarro\Desktop\Facultad\Taller2\TP1\tl2-tp1-2024-MaguiNavarro\ArchivosJson\Cadetes.json"))
        {
            Cadeteria.AgregarCadete(cadete.VerId(), cadete.VerNombre(), cadete.VerDireccion(), cadete.VerTelefono());
        }
        break;
}



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
            Cadeteria.AgregarPedido(NuevoPedido);

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
             string[] arregloPedidosPendientes = Cadeteria.ObtenerPedidosPendientes();

            foreach (var cadete in arregloPedidosPendientes)
            {
                Console.WriteLine(cadete);
            }

            Console.WriteLine("A qué pedido le quiere cambiar el estado? Ingrese su numero: ");
            int NumeroPedido = int.Parse(Console.ReadLine());

            if (Cadeteria.ExistePedido(NumeroPedido))
            {
                Console.WriteLine($"Cual será el nuevo estado del pedido?");
                Console.WriteLine("0 = Cancelado");
                Console.WriteLine("1 = Entregado");
                Console.Write("Opcion: ");
                int EstadoElegido = int.Parse(Console.ReadLine());

                Cadeteria.CambiarEstadoPedido(NumeroPedido, EstadoElegido);
            }
            else
            {
                Console.WriteLine("El numero ingresado no corresponde a ningun pedido");
            }

            break;

        case 4:
             arregloPedidosPendientes = Cadeteria.ObtenerPedidosPendientes();

            foreach(var cadete in arregloPedidosPendientes)
            {
                Console.WriteLine(cadete);
            }

            Console.WriteLine("Elija numero del pedido a reasignar: ");
    

            NumeroPedido = int.Parse(Console.ReadLine());

            if (Cadeteria.ExistePedido(NumeroPedido))
            {
                string [] arregloCadetes = Cadeteria.ObtenerCadetes();

                foreach (var cadete in arregloCadetes)
                {
                    Console.WriteLine(cadete);
                }

                Console.WriteLine("A que cadete le quiere asignar el pedido? Ingresar su Id: ");
                int IdCadete = int.Parse(Console.ReadLine());

                if (Cadeteria.ExisteCadete(IdCadete))
                {
                    Cadeteria.ReasignarPedido(NumeroPedido, IdCadete);
                }
                else
                {
                    Console.WriteLine("El id ingresado no corresponde a ningun cadete");
                }
            }
            else
            {
                Console.WriteLine("El numero ingresado no corresponde a ningun pedido");
            }

            break;

    }
}
// void GenerarInformeJornal()
// {
//     Console.WriteLine("--- Informe jornal ---");

//     //creo lo que se llama un tipo anonimo, en el que encapsulo una serie de propiedades en un objeto sin definir un tipo explicitamente.
//     var InformeQuery = from cadete in Cadeteria.ListaCadetes
//                        select new
//                        {
//                            Nombre = cadete.VerNombre(),
//                            EnviosCompletados = cadete.ListaPedidos.Count(p => p.VerEstado() == Estado.Entregado), //cuento la cant de envios completados que tiene
//                            MontoRecaudado = cadete.ListaPedidos.Where(p => p.VerEstado() == Estado.Entregado) //filtro los pedidos para quedarme solo con los que fueron entregados
//                                                            .Sum(p => 500)
//                        };

//     foreach (var cadete in InformeQuery)
//     {
//         Console.WriteLine($"Cadete: {cadete.Nombre} | Envios completados: {cadete.EnviosCompletados} | Monto recaudado: {cadete.MontoRecaudado}");
//     }

//     var TotalRecuadado = InformeQuery.Sum(c => c.MontoRecaudado);
//     var EnviosTotales = InformeQuery.Sum(c => c.EnviosCompletados);
//     var EnviosPromedio = InformeQuery.Average(c => c.EnviosCompletados);

//     Console.WriteLine($"Total recaudado entre todos los cadetes: {TotalRecuadado}");
//     Console.WriteLine($"Envios totales: {EnviosTotales}");
//     Console.WriteLine($"Envios en promedio por cadete: {EnviosPromedio}");
// }
