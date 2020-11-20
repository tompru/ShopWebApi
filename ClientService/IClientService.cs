using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClientService
{
    [ServiceContract]
    public interface IClientService
    {
        [OperationContract]
        List<PurchasedProductInfo> GetClientPurchasedProducts(ClientInfoRequest clientInfoRequest);
    }

    [DataContract]
    public class ClientInfoRequest
    {
        [DataMember]
        public int ClientId { get; set; }
    }

    [DataContract]
    public class PurchasedProductInfo
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int PurchasedProductsQuantity { get; set; }
    }
}
