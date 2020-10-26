using Leilao.Domain.Dtos.PublicSale.Standard;
using System;

namespace Leilao.Domain.Dtos.PublicSale
{
    public class PublicSaleDtoUpdateResult : PublicSaleDtoStandardResult
    {        
        public DateTime UpdateAt { get; set; }
    }
}
