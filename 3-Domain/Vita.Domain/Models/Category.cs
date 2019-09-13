namespace Vita.Domain.Models
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public bool IsDefault { get; set; }
    }
}
