namespace ChickenResturantsMVC.Models
{
    public class Restaurant
    {

        public int RestaurantId { get; set; }

        public string? RestaurantName { get; set; }

        public string? Country { get; set; }

        public int Branches { get; set; }

        public float Sales { get; set; }

        public string? Region { get; set; }
    }
}
