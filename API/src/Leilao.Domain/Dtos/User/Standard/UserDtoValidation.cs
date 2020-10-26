using System.ComponentModel.DataAnnotations;

namespace Leilao.Domain.Dtos.User.Standard
{
    public class UserDtoValidation
    {
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "e-Mail é campo obrigatório")]
        public string Email { get; set; }

        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Nome é campo obrigatório")]
        public string Name { get; set; }

        [StringLength(20, ErrorMessage = "Senha deve ter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Senha é campo obrigatório")]
        public string Password { get; set; }
    }
}
