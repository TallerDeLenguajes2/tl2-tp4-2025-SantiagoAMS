using Cadeteria;

public class AccesoADatosCSV : IAccesoADatos
{

    public static readonly AccesoADatosCSV Instance = new AccesoADatosCSV();

    private AccesoADatosCSV()
    {

    }

    public List<Pedido> CargaPedidos(string ruta)
    {

        List<Pedido> ret = [];

        foreach (var p in _GetLines(ruta))
        {
            var ped = new Pedido(
                int.Parse(p[0]), //n
                p[1], //obs
                p[2], //cliNombre
                p[3], //cliDomi
                p[4], //cliTelefono
                p[5], //cliObs
                int.Parse(p[6]), //estado
                int.Parse(p[7]) //idCadete
            );

            //(int n, string obs, string cliNombre, string cliDomicilio, string cliTelefono, string cliObs, int estado, int idCadete){
            ret.Add(ped);
        }
        return ret;
    }

    public List<Cadete> CargaCadetes(string ruta)
    {
        List<Cadete> ret = [];
        foreach (var l in _GetLines(ruta))
        {
            var cad = new Cadete(
                    int.Parse(l[0]), //id
                    l[1], //nombre
                    l[2], //direccion
                    l[3] //telefono
                );
            ret.Add(cad);
        }
        return ret;
    }

    public Cadeteria.Cadeteria CargaCadeteria(string nombre)
    {
        try
        {
            var t = File.ReadAllLines(nombre);
            return new Cadeteria.Cadeteria(t[0], t[1]);
        }
        catch (Exception e)
        {
            Utilidades.PrintError($"Error con el archivo \"{nombre}\": "+e.Data);
        }
        return null;
    }

    private static List<string[]> _GetLines(string nombre)
    {
        List<string[]> ret = [];
        try
        {
            var t = File.ReadAllLines(nombre);
            if (t == null)
            {
                Utilidades.PrintError($"El archivo \"{nombre}\" esta vacio");
                return null;
            }
            foreach (var line in t)
            {
                var arr = line.Split(";");
                ret.Add(arr);
            }
        }
        catch
        {
            Utilidades.PrintError($"Error con el archivo \"{nombre}\"");
            return ret;
        }
        return ret;

    }

    
}