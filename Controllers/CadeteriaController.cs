namespace tl2_tp4_2025_SantiagoAMS.Controllers;

using Cadeteria.Cadeteria;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    /*
        [Get] GetPedidos() => Retorna una lista de Pedidos  
        [Get] GetCadetes() => Retorna una lista de Cadetes  
        [Get] GetInforme() => Retorna un objeto Informe  
        [Post] AgregarPedido(Pedido pedido)  
        [Put] AsignarPedido(int idPedido, int idCadete) 
        [Put] CambiarEstadoPedido(int idPedido,int NuevoEstado)  
        [Put] CambiarCadetePedido(int idPedido,int idNuevoCadete)
    */
    [HttpGet(Name="GetPedidos")]
    public IActionResponse GetPedidos(){
        return null;//Cadeteria.Instance.;
    }
}