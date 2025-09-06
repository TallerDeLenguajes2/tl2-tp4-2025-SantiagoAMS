using Cadeteria;

public interface IAccesoADatos
{
    public List<Pedido> CargaPedidos(string ruta);
    public List<Cadete> CargaCadetes(string ruta);
    public Cadeteria.Cadeteria CargaCadeteria(string ruta);
}