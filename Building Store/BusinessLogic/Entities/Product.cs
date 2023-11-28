namespace Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ColorId { get; set; }
        public int Memory { get; set; }
        public int CategoryId { get; set; }
        //Navigation properties
        public Category Category { get; set; }
    }
}