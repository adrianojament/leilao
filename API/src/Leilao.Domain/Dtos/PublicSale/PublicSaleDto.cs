using Leilao.Domain.Dtos.User;
using System;

namespace Leilao.Domain.Dtos.PublicSale
{
    public class PublicSaleDto
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Name { get; set; }
        public double InitalValue { get; set; }
        public bool Used { get; set; }
        public Guid ResponsibleUserId { get; set; }
        public UserDto ResponsibleUser { get; set; }
    }
}
