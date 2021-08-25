namespace TestParkServices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PapaAnimaux")]
    public partial class PapaAnimaux
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PId { get; set; }

        public int AId { get; set; }

        public virtual Animaux Animaux { get; set; }
    }
}
