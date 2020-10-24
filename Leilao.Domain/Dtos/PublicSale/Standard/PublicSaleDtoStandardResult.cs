﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Leilao.Domain.Dtos.PublicSale.Standard
{
    public class PublicSaleDtoStandardResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double InitalValue { get; set; }
        public bool Used { get; set; }
        public Guid IdResponsibleUser { get; set; }
    }
}
