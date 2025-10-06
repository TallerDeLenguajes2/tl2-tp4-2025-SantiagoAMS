using CadeteriaNS;
using System.Text.Json;
public class AccesoADatosCadeteria
{
    public static AccesoADatosCadeteria Instance = new AccesoADatosCadeteria();

    public Cadeteria Obtener(){
        var text = File.ReadAllText(
            AccesoADatos.archivoCadeteria
        );
        //Console.WriteLine("Cadeteria");
        //Console.WriteLine(text);
        return JsonSerializer.Deserialize<CadeteriaNS.Cadeteria>(text);
    }

}