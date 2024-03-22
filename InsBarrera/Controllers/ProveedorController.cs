using Datos;
using Microsoft.AspNetCore.Mvc;
using Modelo;

namespace InsBarrera.Controllers
{
    [ApiController]
    [Route("proveedor")]
    public class ProveedorController : ControllerBase
    {
        [HttpGet]
        [Route("ListarProveedor")]
        public JsonResult Obtener()
        {
            List<Proveedor> Lista = CD_Proveedor.Instancia.ObtenerProveedor();
            return new JsonResult(new { data = Lista });
        }

        [HttpGet]
        [Route("Listar")]
        public string GetProveedor()
        {
            var proveedorJson = CD_Proveedor.Instancia.ObtenerProveedor();

            return Newtonsoft.Json.JsonConvert.SerializeObject(proveedorJson);
        }
    }
}