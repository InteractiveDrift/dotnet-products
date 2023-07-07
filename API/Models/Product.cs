using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public partial class Product
{   
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal Deposit { get; set; }
    public int? VolymInml { get; set; }
    public decimal PricePerLiter { get; set; }
    public DateTime SalesStart { get; set; }
    public bool? Discontinued { get; set; }
    public int ProductGroupId { get; set; }
    public string? Type { get; set; }
    public string? Style { get; set; }
    public string? Packaging { get; set; }
    public string? SealType { get; set; }
    public string? Origin { get; set; }
    public string? OriginCountryName { get; set; }
    public int ProducerId { get; set; }
    public int SupplierId { get; set; }
    public int? Vintage { get; set; }
    public decimal AlcoholContent { get; set; }
    public string? AssortmentCode { get; set; }
    public string? AssortmentText { get; set; }
    public bool? Organic { get; set; }
    public bool? Ethical { get; set; }
    public bool? Kosher { get; set; }
    public string? RawMaterialsDescription { get; set; }

    public ProductGroup? ProductGroup { get; set; }
    public Producer? Producer { get; set; }
    public Supplier? Supplier { get; set; }
}
