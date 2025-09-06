using System.Text.Json;

namespace Cadeteria;

public class Program
{

    private static Cadeteria _local = Cadeteria.Instance; // Alias
    private static string Inicializar()
    {
        
        try
        {
            var ca = AccesoADatos.CargarCadeteria(2);
            if (ca == null)
            {
                return "No se pudo cargar datos de la cadeteria...";
            }
            _local.Nombre = ca.Nombre;
            _local.Telefono = ca.Telefono;

            var cadetes = AccesoADatos.CargarCadetes(2);
            foreach (var c in cadetes)
            {
                Cadeteria.Instance.AgregarCadete(c);
            }

            var pedidos = AccesoADatos.CargarPedidos(2);
            foreach (var p in pedidos)
            {
                _local.AgregarPedido(p);
            }

            return "Carga exitosa";
        }
        catch (Exception e)
        {
            return $"Ocurrio este error al cargar datos: \"{e.Message}\""; // Seria mejor ocultar el mensaje de error
        }
        
    }

    /*public static void Main()
    {
        if (!Inicializar())
        {
            Utilidades.PrintError("Error al cargar datos de la cadeteria...");
            return;
        }

        int opc = 0;
        while (opc != 5)
        {
            Console.Clear();
            Utilidades.WriteColoredLine($"  {local.Nombre}", ConsoleColor.Cyan);
            Utilidades.WriteColoredLine($"  {local.Telefono}", ConsoleColor.Cyan);
            Console.WriteLine("---------- Cadeteria --------");
            Console.WriteLine(" 1 - Nuevo Pedido");
            Console.WriteLine(" 2 - Asignar cadete a pedidos");
            Console.WriteLine(" 3 - Cambiar estado de pedidos");
            Console.WriteLine(" 4 - Reasignar pedidos");
            Console.WriteLine(" 5 - Finalizar jornada");

            Console.WriteLine("-----------------------------");

            opc = Utilidades.LeerEntero("Ingresa una opción:");
            Console.WriteLine();
            switch (opc)
            {
                case 1:
                    NuevoPedido();
                    break;
                case 2:
                    AsignarCadete();
                    break;
                case 3:
                    CambiarEstado();
                    break;
                case 4:
                    ReasignarPedidos();
                    break;
                case 5:
                    if (Utilidades.LeerBooleano("¿Finalizar jornada?"))
                    {
                        continue;
                    }
                    opc = 0;
                    break;
                default:
                    Utilidades.PrintError("Opción invalida...");
                    break;
            }

            if (opc < 5)
            {
                Utilidades.Pausa();
            }

        }

        Abandonar();

    }

    ///////// CASO 1
    public static void NuevoPedido()
    {
        var nombre = Utilidades.LeerString("Nombre del cliente:");
        var direccion = Utilidades.LeerString("Direccion del cliente:");
        var telef = Utilidades.LeerString("Telefono del cliente:");
        var referencia = Utilidades.LeerString("Referencia del domicilio de entrega:");

        var obs = Utilidades.LeerString("Observaciones del pedido:");
        Cliente c = new(nombre, direccion, telef, referencia);
        Pedido p = new Pedido(obs, c);

        local.AgregarPedido(p);
        Utilidades.PrintSuccess($"Pedido \"{p.Nro}\" agregado.");
        //Asignar
    }

    ///////// CASO 2
    public static void AsignarCadete()
    {
        if (local.CantidadCadetes() == 0)
        {
            Utilidades.PrintError("No hay cadetes, no se puede asignar...");
            return;
        }

        var p = _obtenerPedidoSinAsignar();
        if (p == null)
        {
            return;
        }
        var c = _obtenerCadete();
        if (c == null)
        {
            return;
        }

        if (!Utilidades.LeerBooleano($"¿Asignar pedido \"{p.Nro.ToString("D5")}\" al cadete \"{c.Nombre}\"?"))
        {
            return;
        }
        local.AsignarCadeteAPedido(c, p);
        Utilidades.PrintSuccess("Pedido reasignado");

    }

    ///////// CASO 3
    public static void CambiarEstado()
    {
        var p = _obtenerPedidoAsignado(Pedido.EstadoPedido.Pendiente);
        if (p == null)
        {
            return;
        }
        if (p.EstaEntregado())
        {
            Utilidades.PrintError($"El Pedido \"{p.Nro:D5}\" ya fue entregado...");
            return;
        }
        if (!Utilidades.LeerBooleano($"¿Cambiar Pedido \"{p.Nro:D5}\" a estado Entregado?"))
        {
            return;
        }
        p.Estado = Pedido.EstadoPedido.Entregado;
        Utilidades.PrintSuccess($"Pedido \"{p.Nro:D5}\" Entregado");
    }

    ///////// CASO 4
    public static void ReasignarPedidos()
    {
        //local.ListarPedidosAsignados(Pedido.EstadoPedido.Pendiente);
        var p = _obtenerPedidoAsignado(Pedido.EstadoPedido.Pendiente);
        if (p == null)
        {
            return;
        }
        if (!p.EstaAsignado())
        {
            Utilidades.PrintError("Este pedido no esta asignado...");
            return;
        }
        if (p.EstaEntregado())
        {
            Utilidades.PrintError("Este pedido ya fue entregado...");
            return;
        }


        var c = _obtenerCadete();
        if (c == null)
        {
            return;
        }
        if (p.EstaAsignado(c))
        {
            Utilidades.PrintError("Este cadete ya tiene este pedido...");
            return;
        }

        var cadeteOrigen = p.Cadete;

        if (!Utilidades.LeerBooleano($"\n\n - Cadete Anterior: \"{cadeteOrigen.Nombre}\"\n - Cadete Nuevo:    \"{c.Nombre}\"\n¿Confirmar reasignacion del Pedido \"{p.Nro:D5}\"?"))
        {
            return;
        }
        p.Asignar(c);
        Utilidades.PrintSuccess("Pedido reasignado");
    }

    //////////////
    public static void Abandonar()
    {
        Console.Clear();
        var c = local.ContarPedidos(Pedido.EstadoPedido.Entregado);
        var prom = (double)(c / local.CantidadCadetes());
        var jorn = local.TotalJornales();

        Utilidades.PrintSuccess("----- Informe de la jornada -----\n\n");
        Console.WriteLine($"- Pedidos entregados:          {c}");
        Console.WriteLine($"- Pedidos promedio por cadete: {prom}");
        local.ListarCantidadEnviosCadetes();
        Console.WriteLine($"- Jornales a abonar:           ${jorn}");

        Utilidades.Pausa();
    }*/

    /////////////////////////////////////////////////////////////////////
    /// Funciones reutilizables

    /*private static Pedido _obtenerPedidoSinAsignar()
    {
        return _obtenerPedido(false);
    }

    private static Pedido _obtenerPedidoAsignado(Pedido.EstadoPedido? estado = null)
    {
        return _obtenerPedido(true, estado);
    }

    private static Pedido _obtenerPedido(bool asignado, Pedido.EstadoPedido? estado = null)
    {
        if (asignado)
        {
            local.ListarPedidosAsignados(estado, false);
        }
        else
        {
            local.ListarPedidosSinAsignar(); //Porque no tiene sentido preguntar por estado
            // Si el pedido no esta asignado es IMPOSIBLE que haya cambiado de estado
        }

        int num = Utilidades.LeerEntero("\nIngresa el numero del pedido");
        var p = local.ObtenerPedido(num);

        if (p == null)
        {
            Utilidades.PrintError($"Pedido N° \"{num.ToString("D5")}\" no encontrado...");
            return null;
        }
        if (asignado != p.EstaAsignado())
        {
            Utilidades.PrintError($"El Pedido N° \"{num.ToString("D5")}\" {(p.EstaAsignado() ? "ya" : "no")} esta asignado...");
            return null;
        }
        return p;
    }

    private static Cadete _obtenerCadete()
    {
        local.ListarCadetes();
        int id = Utilidades.LeerEntero("Ingresa el ID del cadete");
        var c = local.ObtenerCadete(id);

        if (c == null)
        {
            Utilidades.PrintError($"Cadete con ID {id} no encontrado...");
            return null;
        }
        return c;
    }
    */

}