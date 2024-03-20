using Microsoft.AspNetCore.Mvc;
using Modelo;
using Datos;

namespace InsBarrera.Controllers
{
    [ApiController]
    [Route("categoria")]
    public class CategoriaController : ControllerBase
    {
        // public object Newtonsoft { get; private set; }

        [HttpGet]
        [Route("ListarCategorias")]
        public JsonResult Obtener()
        {
            List<Categoria> Lista = CD_Categoria.Instancia.ObtenerCategoria();
            return new JsonResult(new { data = Lista });
        }

        [HttpGet]
        [Route("Listar")]
        public string GetCategoria()
        {
            var categoriasJson = CD_Categoria.Instancia.ObtenerCategoria();

            return Newtonsoft.Json.JsonConvert.SerializeObject(categoriasJson);
        }
    }
}
