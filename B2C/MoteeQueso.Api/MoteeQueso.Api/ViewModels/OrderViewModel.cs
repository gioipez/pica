using System;

namespace MoteeQueso.Api.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int Number { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public int StatusId { get; set; }

        public string Comments { get; set; }
    }
}