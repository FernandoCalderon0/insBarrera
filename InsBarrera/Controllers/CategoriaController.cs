using Microsoft.AspNetCore.Mvc;
using Modelo;
using Datos;

namespace InsBarrera.Controllers
{
    [ApiController]
    [Route("categoria")]
    public class CategoriaController : ControllerBase
    {
        public readonly CD_Categoria? _Categoria;

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

     //   [HttpPost]
       // [Route("AgregarCategorias")]
      //  public string PostCategoria(Categoria nuevaCategoria)
      //  {
            //Categoria newCategoria = .RegistrarCategoria(nuevaCategoria);
            //  Categoria newCategoria = CD_Categoria.Instancia.RegistrarCategoria(nuevaCategoria);

      //      _ = _Categoria.RegistrarCategoria(nuevaCategoria);

            // return Newtonsoft.Json.JsonConvert.SerializeObject(newCategoria);

          //  return Ok( nuevaCategoria);
        }


    }
