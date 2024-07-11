using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesStore.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "O campo Confirmar Senha é obrigatório")]
        public string ConfirmPassword { get; set; }
    }
}
