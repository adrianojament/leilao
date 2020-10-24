using System;
using System.ComponentModel.DataAnnotations;

namespace Leilao.Domain.Dtos.PublicSale.Standard
{
    public class PublicSaleDtoStandardValidation
    {

        [Required(ErrorMessage = "Nome é campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Valor Inicial do item é campo obrigatório")]
        public double InitalValue { get; set; }

        [Required(ErrorMessage = "Item usado é campo obrigatório")]
        public bool Used { get; set; }

        [Required(ErrorMessage = "Usuario é campo obrigatório")]
        public Guid IdResponsibleUser { get; set; }
    }
}
