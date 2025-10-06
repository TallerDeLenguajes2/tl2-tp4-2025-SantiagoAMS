using CadeteriaNS;
using System.Text.Json;

public class AccesoADatosPedidos
{
    public static AccesoADatosPedidos Instance = new AccesoADatosPedidos();

    public List<Pedido> Obtener()
    {
        return JsonSerializer.Deserialize<List<Pedido>>(File.ReadAllText(
            AccesoADatos.archivoPedidos
        ));
        
    }

    public void Guardar(List<Pedido> pedidos)
    {
        var t = JsonSerializer.Serialize(pedidos);
        File.WriteAllText(AccesoADatos.archivoPedidos,t);
    }
}