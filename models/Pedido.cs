using System.Text;

namespace Cadeteria;

public enum EstadoPedido
{
    Pendiente, Entregado
}

public class Pedido
{
    private static int IdIncremental { get; set; }

    public int Nro { get; private set; }
    public string Obs { get; private set; }
    public Cliente Cliente { get; private set; }
    public EstadoPedido Estado { get; private set; } = EstadoPedido.Pendiente;
    public int IdCadete { get; private set; } = -1;
    public Cadete Cadete { get { return Cadeteria.Instance.ObtenerCadete(IdCadete); } }

    //              A       B                   C               D                   E                   F             G             H
    public Pedido(int n, string obs, string cliNombre, string cliDomicilio, string cliTelefono, string cliObs, int estado, int idCadete)
    {
        Nro = n;
        Obs = obs;
        Cliente = new Cliente(cliNombre, cliDomicilio, cliTelefono, cliObs);
        Estado = (EstadoPedido)estado;
        IdCadete = idCadete;
    }

    public Pedido(Cliente cliente, string obs)
    {
        Nro = ++IdIncremental;
        Obs = obs;
        this.Cliente = cliente;
        Estado = EstadoPedido.Pendiente;
        IdCadete = -1;
    }

    public string Listar()
    {
        StringBuilder s = new();
        s.Append($"Pedido N° {this.Nro.ToString("D5")}\n");
        s.Append(VerDatosCliente());
        s.Append(VerDireccionCliente());
        return s.ToString();
    }

    public void Asignar(int idCadete)
    {
        IdCadete = idCadete;
    }
    public void Asignar(Cadete c)
    {
        IdCadete = c.Id;
    }

    public bool EstaAsignado()
    {
        return this.Cadete != null;
    }
    public bool EstaAsignado(Cadete c)
    {
        return this.Cadete == c;
    }
    public bool EstaAsignado(int idCadete)
    {
        return EstaAsignado() && Cadete.Id == idCadete;
    }

    public bool EstaEntregado()
    {
        return this.Estado == EstadoPedido.Entregado;
    }

    public string VerDireccionCliente()
    {
        return ($" Direccion: \"{Cliente.Direccion}\" Referencia: \"{Cliente.DatosReferenciaDomicilio}\"");
    }
    public string VerDatosCliente()
    {
        return ($" Cliente: {Cliente.Nombre} (Tel: {Cliente.Telefono})");
    }

}