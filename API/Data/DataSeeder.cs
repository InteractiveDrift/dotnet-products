using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace API.Data;

public class DataSeeder
{
    private readonly ProductsContext _dbContext;

    public DataSeeder(ProductsContext dbContext)
    {
        _dbContext = dbContext;
    }

//    public void SeedProductsFromCsv(string csvFilePath)
//     {
//         string[] lines = File.ReadAllLines(csvFilePath);

//         IEnumerable<string> dataLines = GetCsvDataLines(lines);

//         foreach (string line in dataLines) {
//             // string line = dataLines.FirstOrDefault();
        
//             string[] values = line.Split(',');
//             string name = values[0];
//             string description = values[1];
//             string price = values[2];
//             string deposit = values[3];
//             int volymInMl = ParseIntValue(values[4]);
//             string pricePerLiter = values[5];
//             string salesStart = values[6];
//             long discontinued = ParseLongValue(values[7]);
//             string productGroupName = values[8];
//             string type = values[9];
//             string style = values[10];
//             string packaging = values[11];
//             string sealType = values[12];
//             string origin = values[13];
//             string originCountryName = values[14];
//             string producerName = values[15];
//             string supplierName = values[16];
//             long vintage = ParseLongValue(values[17]);
//             string alcoholContent = values[18];
//             string assortmentCode = values[19];
//             string assortmentText = values[20];
//             long organic = ParseLongValue(values[21]);
//             long ethical = ParseLongValue(values[22]);
//             long kosher = ParseLongValue(values[23]);
//             string rawMaterialsDescription = values[24];

//             // Get the IDs of the associated entities
//             long productGroupId = _dbContext.ProductGroups
//                 .Where(pg => pg.Name == productGroupName)
//                 .Select(pg => pg.Id)
//                 .FirstOrDefault();

//             long supplierId = _dbContext.Suppliers
//                 .Where(s => s.Name == supplierName)
//                 .Select(s => s.Id)
//                 .FirstOrDefault();

//             long producerId = _dbContext.Producers
//                 .Where(p => p.Name == producerName)
//                 .Select(p => p.Id)
//                 .FirstOrDefault();

//             // Create the product entity and set the properties
//             Product product = new()
//             {
//                 Name = name,
//                 Description = description,
//                 Price = price,
//                 Deposit = deposit,
//                 VolymInml = volymInMl,
//                 PricePerLiter = pricePerLiter,
//                 SalesStart = salesStart,
//                 Discontinued = discontinued,
//                 ProductGroupId = productGroupId,
//                 Type = type,
//                 Style = style,
//                 Packaging = packaging,
//                 SealType = sealType,
//                 Origin = origin,
//                 OriginCountryName = originCountryName,
//                 ProducerId = producerId,
//                 SupplierId = supplierId,
//                 Vintage = vintage,
//                 AlcoholContent = alcoholContent,
//                 AssortmentCode = assortmentCode,
//                 AssortmentText = assortmentText,
//                 Organic = organic,
//                 Ethical = ethical,
//                 Kosher = kosher,
//                 RawMaterialsDescription = rawMaterialsDescription
//             };

//             _dbContext.Products.Add(product);
//         }

//         _dbContext.SaveChanges();
//     }

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
            Supplier supplier = new()
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
            Producer producer = new()
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

    private static int ParseIntValue(string value)
    {
        if (int.TryParse(value, out int result))
        {
            return result;
        }
        return 0; // Default value
    }

    private static int? ParseNullableIntValue(string value)
    {
        if (!string.IsNullOrEmpty(value) && int.TryParse(value, out int result))
        {
            return result;
        }
        return null; // Default value
    }

    private static long ParseLongValue(string value)
    {
        if (long.TryParse(value, out long result))
        {
            return result;
        }
        return -1; // Default value
    }
}
