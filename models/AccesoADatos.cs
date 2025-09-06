using Cadeteria;

public class AccesoADatos
{
    private static readonly string rc = "./../"; //Ruta carpeta, para abreviar
    private static readonly string archivoPedidos = $"{rc}pedidos";
    private static readonly string archivoCadetes = $"{rc}cadetes";
    private static readonly string archivoCadeteria = $"{rc}cadeteria";


    /*public static List<Pedido> CargarPedidos()
    {
        Console.WriteLine("Cargar pedidos desde:");
        Console.WriteLine(" 1: pedidos.json");
        Console.WriteLine(" 2: pedidos.csv");
        int o = 0;
        while (o < 1 || o > 2)
        {
            o = Utilidades.LeerEntero("Ingresa la opción:");
        }

        switch (o)
        {
            case 1:
                return AccesoADatosJSON.Instance.CargaPedidos($"{archivoPedidos}.json");

            case 2:
                return AccesoADatosCSV.Instance.CargaPedidos($"{archivoPedidos}.csv");

        }
        return [];
    }*/
    public static List<Pedido> CargarPedidos(int fuente)
    {
        switch (fuente)
        {
            case 1: //JSON
                return AccesoADatosJSON.Instance.CargaPedidos($"{archivoPedidos}.json");
            case 2: //CSV
                return AccesoADatosCSV.Instance.CargaPedidos($"{archivoPedidos}.csv");
        }
        return [];
    }

    /*public static List<Cadete> CargarCadetes()
    {
        Console.WriteLine("Cargar cadetes desde:");
        Console.WriteLine(" 1: cadetes.json");
        Console.WriteLine(" 2: cadetes.csv");
        var o = 0;
        while (o < 1 || o > 2)
        {
            o = Utilidades.LeerEntero("Ingresa la opción:");
        }

        switch (o)
        {
            case 1:
                return AccesoADatosJSON.Instance.CargaCadetes($"{archivoCadetes}.json");
            case 2:
                return AccesoADatosCSV.Instance.CargaCadetes($"{archivoCadetes}.csv");
        }
        return [];
    }*/

    public static List<Cadete> CargarCadetes(int fuente)
    {
        switch (fuente)
        {
            case 1: //JSON
                return AccesoADatosJSON.Instance.CargaCadetes($"{archivoCadetes}.json");
            case 2: //CSV
                return AccesoADatosCSV.Instance.CargaCadetes($"{archivoCadetes}.csv");
        }
        return [];
    }


    /*public static Cadeteria.Cadeteria CargarCadeteria()
    {
        Console.WriteLine("Cargar datos de la cadeteria desde:");
        Console.WriteLine(" 1: cadeteria.json");
        Console.WriteLine(" 2: cadeteria.csv");
        var o = 0;
        while (o < 1 || o > 2)
        {
            o = Utilidades.LeerEntero("Ingresa la opción:");
        }
        return CargarCadeteria(o);
    }*/
    public static Cadeteria.Cadeteria CargarCadeteria(int fuente)
    {
        //Console.WriteLine($"Cargando desde: \"{archivoCadeteria}.{(o == 1 ? "json" : "csv")}\"");
        switch (fuente)
        {
            case 1: //JSON
                return AccesoADatosJSON.Instance.CargaCadeteria($"{archivoCadeteria}.json");
            case 2: //CSV
                return AccesoADatosCSV.Instance.CargaCadeteria($"{archivoCadeteria}.csv");
        }
        return null;
    }
}
