using CadeteriaNS;
using System.Text.Json;
public class AccesoADatosCadetes
{
    public static AccesoADatosCadetes Instance = new AccesoADatosCadetes();

    public List<Cadete> Obtener()
    {
        var text = File.ReadAllText(AccesoADatos.archivoCadetes);
        Console.WriteLine("Archivo cadetes:");
        Console.WriteLine(text);
        return JsonSerializer.Deserialize<List<Cadete>>(text);
    }
    
}