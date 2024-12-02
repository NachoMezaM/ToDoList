using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class Cliente
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = String.Empty;

         [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; } = String.Empty;

    }
}