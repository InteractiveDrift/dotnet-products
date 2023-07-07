using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class ProductDto
{
    public long Id { get; set; }

    [Required]
    public string? Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public decimal Deposit { get; set; }

    public int? VolymInml { get; set; }

    public decimal PricePerLiter { get; set; }

    public DateTime SalesStart { get; set; }

    public bool? Discontinued { get; set; }

    public string? ProductGroupName { get; set; }

    public string? Type { get; set; }

    public string? Style { get; set; }

    public string? Packaging { get; set; }

    public string? SealType { get; set; }

    public string? Origin { get; set; }

    public string? OriginCountryName { get; set; }

    public string? ProducerName { get; set; } = null!;

    public string? SupplierName { get; set; } = null!;

    public int? Vintage { get; set; }

    public decimal AlcoholContent { get; set; }

    public string? AssortmentCode { get; set; }

    public string? AssortmentText { get; set; }

    public bool? Organic { get; set; }

    public bool? Ethical { get; set; }

    public bool? Kosher { get; set; }

    public string? RawMaterialsDescription { get; set; }
}
