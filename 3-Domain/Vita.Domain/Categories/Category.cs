namespace Vita.Domain.Categories
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public bool IsDefault { get; set; }
    }
}
