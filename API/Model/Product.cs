
using System;
using System.ComponentModel.DataAnnotations;

namespace API.Model
{
	public class Product
	{
		public int Id { get; set; }
		[Required]
		public string? Name { get; set; }
		public DateTime Created { get; set; }
		public string? Name2 { get; set; }
		public float Price { get; set; }
		public float Deposit { get; set; }
		public float VolymInml { get; set; }
		public float PricePerLiter { get; set; }
		public float SalesStart { get; set; }
		public bool Discontinued { get; set; }
		public string? ProductGroup { get; set; }
		public string? Stype { get; set; }
		public string? Style { get; set; }
		public string? Packaging { get; set; }
		public string? SealType { get; set; }
		public string? Origin { get; set; }
		public string? OriginCountryName { get; set; }
		public Producer? Producer { get; set; }
		public string? Supplier { get; set; }
		public string? Vintage { get; set; }
		public string? AlcoholContent { get; set; }
		public string? AssortmentCode { get; set; }
		public string? AssortmentText { get; set; }
		public bool Organic { get; set; }
		public bool Ethical { get; set; }
		public bool Kosher { get; set; }
		public bool RawMaterialsDescription { get; set; }
	}
}