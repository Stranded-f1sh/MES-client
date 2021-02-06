using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Model
{
    [DataContract(Name = "ObjectDetectionCatalogItem")]
    public class ObjectDetectionCatalogItem
    {
        [DataMember]
        [Description("id")]
        public int id { get; set; } // Item Id

        [DataMember]
        [Description("Name")]
        public String Name { get; set; } // Item String

        [DataMember]
        [Description("Score")]
        public float Score { get; set; } // detection Score

        [DataMember]
        [Description("xMin")]
        public float XMin { get; set; } // point x min

        [DataMember]
        [Description("xMax")]
        public float XMax { get; set; } // point x max

        [DataMember]
        [Description("yMin")]
        public float YMin { get; set; } // point y min

        [DataMember]
        [Description("yMax")]
        public float YMax { get; set; } // point y max
    }


    public class CatalogItemList
    {
        public List<ObjectDetectionCatalogItem> catalogItemList { get; set; }
    }
}
