﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace la_mia_pizzeria_static.Models
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]

        public List<Pizza>? Pizzas { get; set; }
        public Category()
        {

        }
    }
}
