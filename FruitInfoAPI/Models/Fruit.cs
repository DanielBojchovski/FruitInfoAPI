namespace FruitInfoAPI.Models
{
    public class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Family { get; set; } = string.Empty;
        public string Genus { get; set; } = string.Empty;
        public string Order { get; set; } = string.Empty;
        public Nutrition Nutritions { get; set; } = new();
        public string Metadata { get; set; } = string.Empty;
    }
}
