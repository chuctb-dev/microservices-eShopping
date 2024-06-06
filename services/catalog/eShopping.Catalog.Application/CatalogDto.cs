namespace eShopping.Catalog.Application
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public ProductBrandDto Brands { get; set; }
        public ProductTypeDto Types { get; set; }
    }

    public class ProductBrandDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductTypeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}