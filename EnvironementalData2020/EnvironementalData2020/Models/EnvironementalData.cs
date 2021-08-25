using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnvironementalData2020.Models
{
    
    public class EnvironementalData
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //[BsonElement("Name")]
        public string time_stamp { get; set; }

        public string Data_Type { get; set; }

        public string Enhed_Name { get; set; }

        public string Stof_Name { get; set; }

        public string MeasurePlace_Name { get; set; }
        public string Measurement_Result { get; set; }
        public string Constuction_Code { get; set; }

        public string Aktivity_Id { get; set; }


    }
}
