using Leilao.Domain.Dtos.PublicSale.Standard;
using System;
using System.ComponentModel.DataAnnotations;

namespace Leilao.Domain.Dtos.PublicSale
{
    public class PublicSaleDtoUpdate : PublicSaleDtoStandardValidation
    {
        [Required(ErrorMessage = "Id é campo obrigatório")]
        public Guid Id { get; set; }
    }
}
