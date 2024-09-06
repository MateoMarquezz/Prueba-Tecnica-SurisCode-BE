using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica_SurisCode___API.Models;
using Prueba_Tecnica_SurisCode___API.Services;
using System.Text.Json;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba_Tecnica_SurisCode___API.Controllers
{
    /// <summary>
    /// Controlador de los articulos en stock segun su nro de deposito
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly ArticulosService _articulosService; 

        public ArticulosController(ArticulosService articulosService) 
        {
            _articulosService = articulosService;
        }
        /// <summary>
        /// Obtiene la lista de articulos desde un archivo loca JSON.
        /// </summary>
        /// <returns>Una lista de articulos.</returns>
        [HttpGet("listarArticulos")]

        public IActionResult ObtenerArticulos()
        {
            try
            {
                var listaArticulos = _articulosService.ObtenerArticulos();
                return Ok(listaArticulos); 
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Se valida que sea una venta apta 
        /// </summary>
        /// <param name="venta"></param>
        /// <returns>Retorna ok si es una venta valida, caso contrario notifica errores.</returns>
        [HttpPost("validarProducto")]
        public IActionResult ValidarProducto(listaArticulos venta)
        {
            var errores = _articulosService.ValidarProducto(venta);

            if (errores.Count == 0)
            {
                return Ok(new { status = "OK" });
            }

            return BadRequest(new { status = "No paso validaciones" });
        }
    }
}
