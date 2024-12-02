using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Code { get; set; }
    }
}