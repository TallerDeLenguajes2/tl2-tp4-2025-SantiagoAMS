using Cadeteria;
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
        return Ok(Cadeteria.Cadeteria.Instance.ResumenJornada());
    }

    [HttpGet("AgregarPedido")]
    public ActionResult AgregarPedido(string nombreCliente, string telefonoCliente, string direccion, string detalleDomicilio, string observacionPedido)
    {
        var r = Cadeteria.Cadeteria.Instance.AgregarPedido(nombreCliente, telefonoCliente, direccion, detalleDomicilio, observacionPedido);
        return Ok(r);
    }
    [HttpGet("AsignarPedido")]
    public ActionResult AsignarPedido(int idPedido, int idCadete)
    {
        var p = Cadeteria.Cadeteria.Instance.ObtenerPedido(idPedido);
        if (p == null)
        {
            return BadRequest("Unexisting pedido");
        }
        var c = Cadeteria.Cadeteria.Instance.ObtenerCadete(idCadete);
        if (c == null)
        {
            return BadRequest("Unexisting Cadete");
        }
        p.Asignar(c);
        return Ok();
    }
    [HttpGet("CambiarEstadoPedido")]
    public ActionResult CambiarEstadoPedido(int idPedido)
    {
         var p = Cadeteria.Cadeteria.Instance.ObtenerPedido(idPedido);
        if (p == null)
        {
            return BadRequest("Unexisting pedido");
        }
        p.CambiarEstado(EstadoPedido.Entregado);
        return Ok();
    }
    [HttpGet("CambiarCadetePedido")]
    public ActionResult CambiarCadetePedido(int idPedido, int idCadete)
    {
        return AsignarPedido(idPedido, idCadete);
    }

}