using System.Text.Json;
using Cadeteria;
public class AccesoADatosJSON : IAccesoADatos
{

    public static readonly AccesoADatosJSON Instance = new AccesoADatosJSON();

    private AccesoADatosJSON()
    {

    }

    public List<Pedido> CargaPedidos(string ruta)
    {
        return JsonSerializer.Deserialize<List<Pedido>>(File.ReadAllText(ruta));
    }
    public List<Cadete> CargaCadetes(string ruta)
    {
        return JsonSerializer.Deserialize<List<Cadete>>(File.ReadAllText(ruta));
    }

    public Cadeteria.Cadeteria CargaCadeteria(string ruta)
    {
        return JsonSerializer.Deserialize<Cadeteria.Cadeteria>(File.ReadAllText(ruta));
    }

}
