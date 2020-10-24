using Leilao.Domain.Dtos.User.Standard;
using System;

namespace Leilao.Domain.Dtos.User
{
    public class UserDtoUpdateResult : UserDtoResult
    {
        public DateTime UpdateAt { get; set; }
    }
}
