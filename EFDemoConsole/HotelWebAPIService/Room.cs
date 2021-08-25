namespace HotelWebAPIService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Room")]
    public partial class Room
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Room_No { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Hotel_No { get; set; }

        [StringLength(1)]
        public string Types { get; set; }

        public double? Price { get; set; }

        public virtual Hotel Hotel { get; set; }

        public override string ToString()
        {
            return $"Room type is  {Types}, and price is {Price}, from hotel No {Hotel_No}, and room No {Room_No}";
        }
    }
}
