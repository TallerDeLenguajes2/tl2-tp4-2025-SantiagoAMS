namespace Cadeteria;

public class Cliente
{

    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string DatosReferenciaDomicilio { get; set; }
    public Cliente(string nombre, string direccion, string telefono, string referencia)
    {
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        DatosReferenciaDomicilio = referencia;
    }

}
