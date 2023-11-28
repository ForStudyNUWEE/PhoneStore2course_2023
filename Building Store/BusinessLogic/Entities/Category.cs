﻿namespace Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Navigation properties
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}