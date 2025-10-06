using System.Text;

namespace CadeteriaNS;

public class Cadeteria
{
    public static readonly Cadeteria Instance = AccesoADatosCadeteria.Instance.Obtener();
    public static readonly int JORNAL_POR_ENTREGA = 500;
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    private List<Cadete> _listadoCadetes;
    private List<Pedido> _listadoPedidos;

    public Cadeteria(string nombre, string telefono)
    {
        this.Nombre = nombre;
        this.Telefono = telefono;
        _listadoCadetes = [];
        _listadoPedidos = [];
    }

    public string ResumenJornada()
    {

        var c = ContarPedidosPorEstado(EstadoPedido.Entregado);
        var prom = (double)(c / CantidadCadetes());
        var jorn = TotalJornales();

        StringBuilder s = new();
        s.Append("----- Informe de la jornada -----\n\n");
        s.Append($"- Pedidos entregados:          {c}");
        s.Append($"- Pedidos promedio por cadete: {prom}");
        s.Append(ListarCantidadEnviosCadetes());
        s.Append($"- Jornales a abonar:           ${jorn}");

        return s.ToString();
    }

    /////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////// CADETES


    public void AgregarCadete(Cadete c)
    {
        _listadoCadetes.Add(c);
    }
    public void AgregarCadetes(List<Cadete> cadetes)
    {
        foreach (var c in cadetes)
        {
            _listadoCadetes.Add(c);
        }
    }

    public int CantidadCadetes()
    {
        return _listadoCadetes.Count;
    }

    public Cadete ObtenerCadete(int id)
    {
        return _listadoCadetes.FirstOrDefault(c => c.Id == id);
    }

    public double JornalACobrar(int idCadete)
    {
        return JornalACobrar(ObtenerCadete(idCadete));
    }
    public double JornalACobrar(Cadete c)
    {
        return c == null ? 0 : _listadoPedidos.Count(p => p.EstaEntregado() && p.EstaAsignado(c)) * JORNAL_POR_ENTREGA;
    }

    public double TotalJornales()
    {
        return ContarPedidosPorEstado(EstadoPedido.Entregado) * JORNAL_POR_ENTREGA;
    }

    public string ListarCadetes()
    {
        StringBuilder sb = new();
        sb.Append($" ID    | Nombre{"",29} | Telefono\n");
        foreach (var c in _listadoCadetes)
        {
            sb.Append($" {c.IdConFormato()} | {c.Nombre,35} | {c.Telefono}\n");
        }
        return sb.ToString();
    }

    public string ListarCantidadEnviosCadetes()
    {
        StringBuilder sb = new();
        foreach (var c in _listadoCadetes)
        {
            sb.Append($" {c.IdConFormato()} | {c.Nombre,35} | {ContarPedidosDeCadete(c, EstadoPedido.Entregado)}\n");
        }
        return sb.ToString();
    }

    /////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////// PEDIDOS

    public int ObtenerNroPedidoMaximo(){
        return _listadoPedidos.Max(p => p.Nro);
    }

    public int AgregarPedido(Pedido p)
    {
        _listadoPedidos.Add(p);
        return p.Nro;
    }

    public void AgregarPedidos(List<Pedido> pedidos)
    {
        foreach (var p in pedidos)
        {
            _listadoPedidos.Add(p);
        }
    }
    public Pedido AgregarPedido(string nombre, string telefono, string direccion, string referencia, string observacion)
    {
        var p = new Pedido(new Cliente(nombre, direccion, telefono, referencia), observacion);
        _listadoPedidos.Add(p);
        return p;
    }

    public Pedido ObtenerPedido(int num)
    {
        return _listadoPedidos.FirstOrDefault(p => p.Nro == num);
    }

    public int ContarPedidos()
    {
        return _listadoPedidos.Count();
    }
    public int ContarPedidos(int idCadete)
    {
        return _listadoPedidos.Count(p => p.EstaAsignado(idCadete));
    }
    ///
    public int ContarPedidosPorEstado(int estado)
    {
        return ContarPedidosPorEstado((EstadoPedido)estado);
    }
    public int ContarPedidosPorEstado(EstadoPedido estado)
    {
        return _listadoPedidos.Count(c => c.Estado == estado);
    }
    ///
    public int ContarPedidosDeCadete(int idCadete, int estado)
    {
        return ContarPedidosDeCadete(ObtenerCadete(idCadete), (EstadoPedido)estado);
    }
    public int ContarPedidosDeCadete(int idCadete, EstadoPedido e)
    {
        return ContarPedidosDeCadete(ObtenerCadete(idCadete), e);
    }
    public int ContarPedidosDeCadete(Cadete c, EstadoPedido e)
    {
        return c == null ? 0 : _listadoPedidos.Count(p => p.Estado == e && p.EstaAsignado(c));
    }
    ///

    public string ListarPedidos()
    {
        StringBuilder s = new();
        s.Append(ListarPedidosSinAsignar());
        s.Append(ListarPedidosAsignados());
        return s.ToString();
    }
    public string ListarPedidosAsignados(EstadoPedido? estado = null, bool nombreCadete = true)
    {
        StringBuilder s = new();
        foreach (var p in _listadoPedidos.Where(p => p.EstaAsignado() && estado == null ? true : p.Estado == estado))
        {
            if (nombreCadete)
            {
                s.Append($" {p.Cadete.Nombre}:");
            }
            s.Append(p.Listar());
        }
        return s.ToString();
    }

    public string ListarPedidosSinAsignar()
    {
        StringBuilder s = new();
        foreach (Pedido p in _listadoPedidos.Where(p => !p.EstaAsignado()))
        {
            s.Append(p.Listar());
        }
        return s.ToString();
    }

    public void GuardarPedidos(){
        AccesoADatosPedidos.Instance.Guardar(_listadoPedidos);
    }
    
}
