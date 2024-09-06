namespace Prueba_Tecnica_SurisCode___API.Models
{
    public class Articulos
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int deposito { get; set; }
    }

    public class listaArticulos
    {
        public List<Articulos> articulos { get; set; }
    }
}

