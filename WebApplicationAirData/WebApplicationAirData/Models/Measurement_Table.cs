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
    
    public partial class Measurement_Table
    {
        public Nullable<double> RaaResultat { get; set; }
        public int StofId { get; set; }
        public int DataTypeId { get; set; }
        public int InstruksId { get; set; }
        public int EnhedId { get; set; }
        public Nullable<double> AKorrektion { get; set; }
        public Nullable<double> BKorrektion { get; set; }
        public int ProduktId { get; set; }
    
        public virtual DataType_Table DataType_Table { get; set; }
        public virtual Enhed_Table Enhed_Table { get; set; }
        public virtual Product_Table Product_Table { get; set; }
    }
}
