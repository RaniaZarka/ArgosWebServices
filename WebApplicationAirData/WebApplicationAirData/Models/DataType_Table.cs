//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationAirData.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DataType_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DataType_Table()
        {
            this.Measurement_Table = new HashSet<Measurement_Table>();
        }
    
        public int DataTypeId { get; set; }
        public string DataTypeNavn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Measurement_Table> Measurement_Table { get; set; }
    }
}
