using Leilao.Domain.Entities.Standard;
using System;

namespace Leilao.Domain.Entities
{
    public class PublicSaleEntity : BaseEntity
    {
        public string Name { get; set; }
        public double InitalValue { get; set; }
        public bool Used { get; set; }
        public Guid ResponsibleUserId { get; set; }
        public UserEntity ResponsibleUser { get; set; }
    }
}
