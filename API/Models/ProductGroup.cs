﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public partial class ProductGroup
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string? Name { get; set; }

    public List<Product>? Products { get; set; }
}
