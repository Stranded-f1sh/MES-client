using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Model
{
    [DataContract(Name = "ProductOrders")]
    public class ProductOrder
    {
        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public string OrderNo { get; set; }

        [DataMember]
        public int SaleOrderId { get; set; }

        [DataMember]
        public string CompanyFullName { get; set; }

        [DataMember]
        public string DeviceModel { get; set; }

        [DataMember]
        public int BuyNumber { get; set; }
    }
}
