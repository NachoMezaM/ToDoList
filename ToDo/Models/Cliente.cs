using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class Cliente
    {

       public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

    }
}