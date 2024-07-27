namespace Domain
{
    public sealed class Product : Entity
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string? Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
            => ValidateDomain(name, description, price, stock, image);

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
            DomainExceptionValidation.When(id < 0, "Invalid Product.Id value.");
            this.Id = id;
        }
        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            this.CategoryId = categoryId;
        }
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Product.Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Product.Name minimum length is 3.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description), "Product.Description is required.");
            DomainExceptionValidation.When(description.Length < 5, "Product.Description minimum length is 5.");
            DomainExceptionValidation.When(price < 0, "Invalid Product.Price value.");
            DomainExceptionValidation.When(stock < 0, "Invalid Product.Stock value.");
            DomainExceptionValidation.When(image?.Length > 250, "Product.Image maximum length is 250.");

            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
            this.Image = image;
        }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
