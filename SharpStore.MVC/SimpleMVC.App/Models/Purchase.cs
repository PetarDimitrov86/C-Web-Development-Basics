namespace SimpleMVC.App.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DeliveryType DeliveryType { get; set; } 
    }

    public enum DeliveryType
    {
        Express,
        Economy
    }
}