using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class DataSeeder
{
    private readonly ProductsContext _dbContext;

    public DataSeeder(ProductsContext dbContext)
    {
        _dbContext = dbContext;
    }

   public void SeedProductsFromCsv(string csvFilePath)
    {
        string[] lines = File.ReadAllLines(csvFilePath);

        IEnumerable<string> dataLines = GetCsvDataLines(lines);

        // foreach (string line in dataLines.FirstOrDefault())
        var line = dataLines.FirstOrDefault();
        
            string[] values = line.Split(',');

            string name = values[0];
            string description = values[1];
            decimal price = ParseDecimalValue(values[2]);
            decimal deposit = ParseDecimalValue(values[3]);
            int volymInMl = ParseIntValue(values[4]);
            decimal pricePerLiter = ParseDecimalValue(values[5]);
            DateTime salesStart = ParseDateTimeValue(values[6]);
            bool discontinued = ParseBoolValue(values[7]);
            string productGroupName = values[8];
            string type = values[9];
            string style = values[10];
            string packaging = values[11];
            string sealType = values[12];
            string origin = values[13];
            string originCountryName = values[14];
            string producerName = values[15];
            string supplierName = values[16];
            int? vintage = string.IsNullOrEmpty(values[17]) ? null : ParseIntValue(values[17]);
            decimal alcoholContent = ParseDecimalValue(values[18]);
            string assortmentCode = values[19];
            string assortmentText = values[20];
            bool organic = ParseBoolValue(values[21]);
            bool ethical = ParseBoolValue(values[22]);
            bool kosher = ParseBoolValue(values[23]);
            string rawMaterialsDescription = values[24];

            // Get the IDs of the associated entities
            int productGroupId = _dbContext.ProductGroups
                .Where(pg => pg.Name == productGroupName)
                .Select(pg => pg.Id)
                .FirstOrDefault();

            int supplierId = _dbContext.Suppliers
                .Where(s => s.Name == supplierName)
                .Select(s => s.Id)
                .FirstOrDefault();

            int producerId = _dbContext.Producers
                .Where(p => p.Name == producerName)
                .Select(p => p.Id)
                .FirstOrDefault();

            // Create the product entity and set the properties
            Product product = new Product
            {
                Name = name,
                Description = description,
                Price = price,
                Deposit = deposit,
                VolymInml = volymInMl,
                PricePerLiter = pricePerLiter,
                SalesStart = salesStart,
                Discontinued = discontinued,
                ProductGroupId = productGroupId,
                Type = type,
                Style = style,
                Packaging = packaging,
                SealType = sealType,
                Origin = origin,
                OriginCountryName = originCountryName,
                ProducerId = producerId,
                SupplierId = supplierId,
                Vintage = vintage,
                AlcoholContent = alcoholContent,
                AssortmentCode = assortmentCode,
                AssortmentText = assortmentText,
                Organic = organic,
                Ethical = ethical,
                Kosher = kosher,
                RawMaterialsDescription = rawMaterialsDescription
            };

            _dbContext.Products.Add(product);
        

        _dbContext.SaveChanges();
    }

    public void SeedProductGroupsFromCsv(string csvFilePath)
    {
        // Read all lines from the CSV file
        string[] lines = File.ReadAllLines(csvFilePath);

        // Skip the header line
        IEnumerable<string> dataLines = GetCsvDataLines(lines);

        foreach (string line in dataLines)
        {
            // Split the line into individual values
            string[] values = line.Split(',');

            // Map the values to the ProductGroup entity properties
            ProductGroup productGroup = new()
            {
                Name = values[0]
            };

             // Check if a record with the same key already exists
            bool recordExists = _dbContext.ProductGroups
                .Any(pg => pg.Name == productGroup.Name);

            if (!recordExists)
            {
                _dbContext.ProductGroups.Add(productGroup);
            }
        }

        _dbContext.SaveChanges();
    }

    public void SeedSuppliersFromCsv(string csvFilePath)
    {
        // Read all lines from the CSV file
        string[] lines = File.ReadAllLines(csvFilePath);

        // Skip the header line
        IEnumerable<string> dataLines = GetCsvDataLines(lines);

        foreach (string line in dataLines)
        {
            // Split the line into individual values
            string[] values = line.Split(',');

            // Map the values to the Supplier entity properties
            Supplier supplier = new Supplier
            {
                Name = values[0]
            };

            // Check if a record with the same key already exists
            bool recordExists = _dbContext.Suppliers
                .Any(s => s.Name == supplier.Name);

            if (!recordExists)
            {
                _dbContext.Suppliers.Add(supplier);
            }
        }

        _dbContext.SaveChanges();
    }

    public void SeedProducersFromCsv(string csvFilePath)
    {
        // Read all lines from the CSV file
        string[] lines = File.ReadAllLines(csvFilePath);

        // Skip the header line
        IEnumerable<string> dataLines = GetCsvDataLines(lines);

        foreach (string line in dataLines)
        {
            // Split the line into individual values
            string[] values = line.Split(',');

            // Map the values to the Producer entity properties
            Producer producer = new Producer
            {
                Name = values[0]
            };

            // Check if a record with the same key already exists
            bool recordExists = _dbContext.Producers
                .Any(p => p.Name == producer.Name);

            if (!recordExists)
            {
                _dbContext.Producers.Add(producer);
            }
        }

        _dbContext.SaveChanges();
    }

    private IEnumerable<string> GetCsvDataLines(string[] lines)
    {
        // Skip the header line
        for (int i = 1; i < lines.Length; i++)
        {
            yield return lines[i];
        }
    }

    private decimal ParseDecimalValue(string value)
    {
        if (decimal.TryParse(value, out decimal result))
        {
            return result;
        }
        return 0m; // Default value
    }

    private int ParseIntValue(string value)
    {
        if (int.TryParse(value, out int result))
        {
            return result;
        }
        return 0; // Default value
    }

    private DateTime ParseDateTimeValue(string value)
    {
        if (DateTime.TryParse(value, out DateTime result))
        {
            return result;
        }
        return DateTime.MinValue; // Default value
    }

    private DateTime? ParseNullableDateTimeValue(string value)
    {
        if (!string.IsNullOrEmpty(value) && DateTime.TryParse(value, out DateTime result))
        {
            return result;
        }
        return null; // Default value
    }

    private int? ParseNullableIntValue(string value)
    {
        if (!string.IsNullOrEmpty(value) && int.TryParse(value, out int result))
        {
            return result;
        }
        return null; // Default value
    }

    private bool ParseBoolValue(string value)
    {
        if (bool.TryParse(value, out bool result))
        {
            return result;
        }
        return false; // Default value
    }
}
