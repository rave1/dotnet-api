namespace restaurant_api.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public string? Picture { get; set; }
    }
}
