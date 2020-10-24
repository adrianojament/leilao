using Leilao.Domain.Dtos.User.Standard;
using System;

namespace Leilao.Domain.Dtos.User
{
    public class UserDtoCreateResult : UserDtoResult
    {
        public DateTime CreateAt { get; set; }
    }
}
