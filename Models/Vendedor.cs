namespace Prueba_Tecnica_SurisCode___API.Models
{
    public class Vendedor
    {
        public int id { get; set; } 
        public string descripcion { get; set; }
	}

    public class listaVendedores
    {
        public List<Vendedor> vendedores { get; set; }
    }
}
