using CadeteriaNS;
using Microsoft.AspNetCore.Mvc;

namespace tl2_tp4_2025_SantiagoAMS.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    public CadeteriaController()
    {
        Cadeteria.Instance.AgregarCadetes(AccesoADatosCadetes.Instance.Obtener());
        Cadeteria.Instance.AgregarPedidos(AccesoADatosPedidos.Instance.Obtener());
    }

    [HttpGet("GetPedidos")]
    public ActionResult GetPedidos()
    {
        return Ok(Cadeteria.Instance.ListarPedidos());
    }

    [HttpGet("GetCadetes")]
    public ActionResult GetCadetes()
    {
        return Ok(Cadeteria.Instance.ListarCadetes());
    }

    [HttpGet("GetInforme")]
    public ActionResult GetInforme()
    {
        return Ok(Cadeteria.Instance.ResumenJornada());
    }

    [HttpGet("AgregarPedido")]
    public ActionResult AgregarPedido(string nombreCliente, string telefonoCliente, string direccion, string detalleDomicilio, string observacionPedido)
    {
        if (string.IsNullOrWhiteSpace(nombreCliente)) return BadRequest("Nombre de cliente invalido");

        var r = Cadeteria.Instance.AgregarPedido(nombreCliente, telefonoCliente, direccion, detalleDomicilio, observacionPedido);
        Cadeteria.Instance.GuardarPedidos();
        return Created();
    }
    [HttpGet("AsignarPedido")]
    public ActionResult AsignarPedido(int idPedido, int idCadete)
    {
        var p = Cadeteria.Instance.ObtenerPedido(idPedido);
        if (p == null)
        {
            return BadRequest("Unexisting pedido");
        }
        var c = Cadeteria.Instance.ObtenerCadete(idCadete);
        if (c == null)
        {
            return BadRequest("Unexisting Cadete");
        }
        p.Asignar(c);
        Cadeteria.Instance.GuardarPedidos();

        return Ok();
    }
    [HttpGet("CambiarEstadoPedido")]
    public ActionResult CambiarEstadoPedido(int idPedido, int estado)
    {
         var p = Cadeteria.Instance.ObtenerPedido(idPedido);
        if (p == null)
        {
            return BadRequest("Unexisting pedido");
        }
        p.CambiarEstado((EstadoPedido)estado);
        Cadeteria.Instance.GuardarPedidos();
        return Ok();
    }
    [HttpGet("CambiarCadetePedido")]
    public ActionResult CambiarCadetePedido(int idPedido, int idCadete)
    {
        return AsignarPedido(idPedido, idCadete);
    }

}