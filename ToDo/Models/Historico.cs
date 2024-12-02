using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class Historico
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string ProductCode { get; set; }
        public decimal ProductPrice { get; set; }
    }
}