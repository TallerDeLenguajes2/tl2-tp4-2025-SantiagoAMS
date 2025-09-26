using CadeteriaNS;
using System.Text.Json;
public class AccesoADatosCadeteria
{
    public static AccesoADatosCadeteria Instance = new AccesoADatosCadeteria();

    public Cadeteria Obtener(){
        return JsonSerializer.Deserialize<CadeteriaNS.Cadeteria>(File.ReadAllText(
            AccesoADatos.archivoCadeteria
        ));
    }

}