using System;

namespace Leilao.Domain.Dtos.User.Standard
{
    public class UserDtoResult
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
