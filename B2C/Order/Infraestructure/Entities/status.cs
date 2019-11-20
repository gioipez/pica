namespace MoteeQueso.B2C.Order.Infraestructure.Entities
{
    public class status
    {
        public int id { get; set; }

        public string description { get; set; }

        public order order { get; set; }
    }
}