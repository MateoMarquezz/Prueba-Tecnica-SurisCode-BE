using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica_SurisCode___API.Models;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Prueba_Tecnica_SurisCode___API.Services
{
    public class ArticulosService
    {
        private readonly string _rutaJson;

        public ArticulosService()
        {
            _rutaJson = Path.Combine(Directory.GetCurrentDirectory(), "articulos.json");
        }



        public List<Articulos> ObtenerArticulos()
        {
            if (!File.Exists(_rutaJson))
            {
                throw new FileNotFoundException("No se encontraron los articulos.");
            }

            var leerJson = File.ReadAllText(_rutaJson);

            var listaArticulos = JsonSerializer.Deserialize<listaArticulos>(leerJson);

            if (listaArticulos == null)
            {
                throw new Exception("Error al deserializar los articulos.");
            }

            return listaArticulos.articulos;
        }

        public List<string> ValidarProducto(listaArticulos venta)
        {
            var errores = new List<string>();
            var caracteresEspeciales = new Regex("^[a-zA-Z0-9 ]*$");

            foreach (var item in venta.articulos)
            {
                if (item.precio <= 0)
                {
                    errores.Add($"El articulo con codigo {item.codigo} tiene un precio no valido: {item.precio}");
                }

                if (!caracteresEspeciales.IsMatch(item.descripcion))
                {
                    errores.Add($"El articulo con código {item.codigo} tiene una descripcion con caracteres especiales: {item.descripcion}");
                }

                if (item.deposito != 1)
                {
                    errores.Add($"El articulo con codigo {item.codigo} no esta en el deposito 1 (Deposito actual: {item.deposito})");
                }
            }

            return errores;
        }
    }
}

