using Leilao.Domain.Dtos.PublicSale.Standard;
using System;

namespace Leilao.Domain.Dtos.PublicSale
{
    public class PublicSaleDtoCreateResult : PublicSaleDtoStandardResult
    {
        public DateTime CreateAt { get; set; }
    }
}
