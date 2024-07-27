namespace Domain
{
    public sealed class Category : Entity
    {
        public Category(string name)
            => ValidateDomain(name);
        public Category(int id, string name)
        {
            ValidateDomain(name);
            DomainExceptionValidation.When(id < 0, "Invalid Category.Id value.");
            this.Id = id;
        }
        public string? Name { get; private set; }
        public ICollection<Product>? Products { get; private set; }
        public void Update(string name)
            => ValidateDomain(name);
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Category.Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Category.Name minimum length is 3.");

            Name = name;
        }
    }
}
