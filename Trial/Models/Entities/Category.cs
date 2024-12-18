﻿using System.Text.Json.Serialization;

namespace Trial.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}