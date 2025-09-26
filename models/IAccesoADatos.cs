using CadeteriaNS;

public interface IAccesoADatos
{
    public List<Pedido> CargaPedidos(string ruta);
    public List<Cadete> CargaCadetes(string ruta);
    public CadeteriaNS.Cadeteria CargaCadeteria(string ruta);
}