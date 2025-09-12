using Microsoft.AspNetCore.Mvc;

namespace tl2_tp4_2025_SantiagoAMS.Controllers;

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
    [HttpGet("GetPedidos")]
    public ActionResult GetPedidos()
    {
        return Ok(Cadeteria.Cadeteria.Instance.ListarPedidos());
    }

    [HttpGet("GetCadetes")]
    public ActionResult GetCadetes()
    {
        return Ok(Cadeteria.Cadeteria.Instance.ListarCadetes());
    }

    [HttpGet("GetInforme")]
    public ActionResult GetInforme()
    {
        return Ok(Cadeteria.Cadeteria.Instance.ListarCadetes());
    }

    [HttpGet("AgregarPedido")]
    public ActionResult AgregarPedido()
    {
        return Ok(Cadeteria.Cadeteria.Instance.ListarCadetes());
    }
    [HttpGet("AsignarPedido")]
    public ActionResult AsignarPedido()
    {
        return Ok(Cadeteria.Cadeteria.Instance.ListarCadetes());
    }
    [HttpGet("CambiarEstadoPedido")]
    public ActionResult CambiarEstadoPedido()
    {
        return Ok(Cadeteria.Cadeteria.Instance.ListarCadetes());
    }
    [HttpGet("CambiarCadetePedido")]
    public ActionResult CambiarCadetePedido()
    {
        return Ok(Cadeteria.Cadeteria.Instance.ListarCadetes());
    }

}