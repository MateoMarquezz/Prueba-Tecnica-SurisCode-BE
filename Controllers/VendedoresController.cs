using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica_SurisCode___API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba_Tecnica_SurisCode___API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedoresController : ControllerBase
    {
        private readonly VendedoresService _vendedoresService;

        public VendedoresController(VendedoresService vendedorService)
        {
            _vendedoresService = vendedorService;
        }

        /// <summary>
        /// Muestra la lista de todos los vendedores
        /// </summary>
        /// <returns>retorna lista de vendedores.</returns>
        [HttpGet("listarVendedores")]

        public IActionResult ObtenerVendedores()
        {
            try
            {
                var listaArticulos = _vendedoresService.ObtenerVendedores();
                return Ok(listaArticulos);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
