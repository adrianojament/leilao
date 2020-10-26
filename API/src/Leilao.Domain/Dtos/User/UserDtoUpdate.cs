using Leilao.Domain.Dtos.User.Standard;
using System;
using System.ComponentModel.DataAnnotations;

namespace Leilao.Domain.Dtos.User
{
    public class UserDtoUpdate : UserDtoValidation
    {
        [Required(ErrorMessage = "Id é campo obrigatório")]
        public Guid Id { get; set; }

    }
}
