namespace MoteeQueso.B2C.Order.Api.ViewModels
{
    public class ItemViewModel
    {
        public int id { get; set; }

        public int product_id { get; set; }

        public string product_name { get; set; }

        public decimal price { get; set; }

        public int quantity { get; set; }

        public int product_type_id { get; set; }

        public int product_integreation_type_id { get; set; }
    }
}