namespace Vita.API.Categories
{
    public class CategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public bool IsDefaultCategory { get; set; }
    }
}