﻿using Catalog.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }

        public ICollection<VariantDto> Variants { get; set; }
        public ICollection<ProductModifierDto> Modifiers { get; set; }
        public ICollection<ProductModifierGroupDto> ModifierGroups { get; set; }
        public ICollection<PhotoDto> Photos { get; set; }
    }
}
