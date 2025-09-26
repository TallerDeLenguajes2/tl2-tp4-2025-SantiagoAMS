using CadeteriaNS;
using Microsoft.AspNetCore.Mvc;

namespace tl2_tp4_2025_SantiagoAMS.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    public CadeteriaController()
    {
        
    }

    [HttpGet("GetPedidos")]
    public ActionResult GetPedidos()
    {
        return Ok(CadeteriaNS.Cadeteria.Instance.ListarPedidos());
    }

    [HttpGet("GetCadetes")]
    public ActionResult GetCadetes()
    {
        return Ok(CadeteriaNS.Cadeteria.Instance.ListarCadetes());
    }

    [HttpGet("GetInforme")]
    public ActionResult GetInforme()
    {
        return Ok(CadeteriaNS.Cadeteria.Instance.ResumenJornada());
    }

    [HttpGet("AgregarPedido")]
    public ActionResult AgregarPedido(string nombreCliente, string telefonoCliente, string direccion, string detalleDomicilio, string observacionPedido)
    {
        var r = CadeteriaNS.Cadeteria.Instance.AgregarPedido(nombreCliente, telefonoCliente, direccion, detalleDomicilio, observacionPedido);
        return Ok(r);
    }
    [HttpGet("AsignarPedido")]
    public ActionResult AsignarPedido(int idPedido, int idCadete)
    {
        var p = CadeteriaNS.Cadeteria.Instance.ObtenerPedido(idPedido);
        if (p == null)
        {
            return BadRequest("Unexisting pedido");
        }
        var c = CadeteriaNS.Cadeteria.Instance.ObtenerCadete(idCadete);
        if (c == null)
        {
            return BadRequest("Unexisting Cadete");
        }
        p.Asignar(c);
        return Ok();
    }
    [HttpGet("CambiarEstadoPedido")]
    public ActionResult CambiarEstadoPedido(int idPedido, int estado)
    {
         var p = CadeteriaNS.Cadeteria.Instance.ObtenerPedido(idPedido);
        if (p == null)
        {
            return BadRequest("Unexisting pedido");
        }
        p.CambiarEstado((EstadoPedido)estado);
        return Ok();
    }
    [HttpGet("CambiarCadetePedido")]
    public ActionResult CambiarCadetePedido(int idPedido, int idCadete)
    {
        return AsignarPedido(idPedido, idCadete);
    }

}