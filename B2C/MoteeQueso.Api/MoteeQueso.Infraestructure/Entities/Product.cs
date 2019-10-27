﻿using System;

namespace MoteeQueso.Infraestructure.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        public string City { get; set; }
    }
}