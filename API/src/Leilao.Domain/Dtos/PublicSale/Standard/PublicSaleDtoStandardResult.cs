using System;

namespace Leilao.Domain.Dtos.PublicSale.Standard
{
    public class PublicSaleDtoStandardResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double InitalValue { get; set; }
        public bool Used { get; set; }
        public Guid ResponsibleUserId { get; set; }
    }
}
