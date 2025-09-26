using CadeteriaNS;
using System.Text.Json;
public class AccesoADatosCadetes
{
    public static AccesoADatosCadetes Instance = new AccesoADatosCadetes();

    public List<Cadete> Obtener()
    {
        return JsonSerializer.Deserialize<List<Cadete>>(File.ReadAllText(AccesoADatos.archivoCadetes));
    }
    
}