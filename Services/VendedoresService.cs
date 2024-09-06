using Prueba_Tecnica_SurisCode___API.Models;
using System.Text.Json;

namespace Prueba_Tecnica_SurisCode___API.Services
{
    public class VendedoresService
    {
        private readonly string _rutaJson;


        public VendedoresService()
        {
            _rutaJson = Path.Combine(Directory.GetCurrentDirectory(), "vendedores.json");
        }

        public List<Vendedor>ObtenerVendedores()
        {
            if (!File.Exists(_rutaJson))
            {
                throw new FileNotFoundException("No se encontraron los articulos.");
            }

            var leerJson = File.ReadAllText(_rutaJson);

            var listaVendedores = JsonSerializer.Deserialize<listaVendedores>(leerJson);

            if (listaVendedores == null)
            {
                throw new Exception("Error al deserializar los articulos.");
            }

            return listaVendedores.vendedores;
        }
    }
}
