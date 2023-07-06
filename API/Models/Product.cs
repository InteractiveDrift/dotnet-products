using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Price { get; set; } = null!;

    public string Deposit { get; set; } = null!;

    public long? VolymInml { get; set; }

    public string PricePerLiter { get; set; } = null!;

    public string SalesStart { get; set; } = null!;

    public long? Discontinued { get; set; }

    public long ProductGroupId { get; set; }

    public string? Type { get; set; }

    public string? Style { get; set; }

    public string? Packaging { get; set; }

    public string? SealType { get; set; }

    public string? Origin { get; set; }

    public string? OriginCountryName { get; set; }

    public long ProducerId { get; set; }

    public long SupplierId { get; set; }

    public long? Vintage { get; set; }

    public string AlcoholContent { get; set; } = null!;

    public string? AssortmentCode { get; set; }

    public string? AssortmentText { get; set; }

    public long? Organic { get; set; }

    public long? Ethical { get; set; }

    public long? Kosher { get; set; }

    public string? RawMaterialsDescription { get; set; }

    public virtual Producer Producer { get; set; } = null!;

    public virtual ProductGroup ProductGroup { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
