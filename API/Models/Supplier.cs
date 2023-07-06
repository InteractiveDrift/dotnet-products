﻿using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Supplier
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}