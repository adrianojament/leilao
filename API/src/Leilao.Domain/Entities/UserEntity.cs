using Leilao.Domain.Entities.Standard;
using System.Collections.Generic;

namespace Leilao.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public IEnumerable<PublicSaleEntity> PublicSales { get; set; }
    }
}
