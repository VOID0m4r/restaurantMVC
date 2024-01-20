using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace REST_API
{

    [Table("resturants")]
    public class restaurant
    {
        [Key]
        [Column("resturant_id")]
        public int RestaurantId { get; set; }

        [Column("resturant_name")]
        public string? RestaurantName { get; set; }

        [Column("country")]
        public string? Country { get; set; }

        [Column("branches")]
        public int Branches { get; set; }

        [Column("sales")]
        public float Sales { get; set; }

        [Column("region")]
        public string? Region { get; set; }
    }
}
