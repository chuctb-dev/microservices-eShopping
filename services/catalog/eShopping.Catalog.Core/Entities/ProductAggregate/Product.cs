using eShopping.SharedKernel.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eShopping.Catalog.Core.Entities.ProductAggregate
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public ProductBrand Brands { get; set; }
        public ProductType Types { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
    }

    public class ProductBrand : EntityBase
    {
        [BsonElement("Name")]
        public string Name { get; set; }
    }

    public class ProductType : EntityBase
    {
        [BsonElement("Name")]
        public string Name { get; set; }
    }
}