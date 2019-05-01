using System;

namespace Catalog.Contract
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
    }
}
