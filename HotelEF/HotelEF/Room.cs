namespace HotelEF
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
            return $" Room Number  is: {Room_No},  Hotel Number is : {Hotel_No}, room type  is: {Types} and room price is: {Price}";
        }
    }
}
