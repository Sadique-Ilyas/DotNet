﻿using System;
using System.Collections.Generic;

namespace EntityFrameworkCore_DatabaseFirst.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
