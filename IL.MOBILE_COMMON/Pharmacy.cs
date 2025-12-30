using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class Pharmacy
    {
        public int PharmacyID { get; set; }
        public string PharmacyName { get; set; }
        public int PharmacyType { get; set; }
        public decimal ShippingCharge { get; set; }
        public decimal Discount { get; set; }
        public int DeliveryMinTime { get; set; }
        public int DeliveryMaxTime { get; set; }
        [Ignore]
        public List<Drug> Drugs { get; set; }
        public string EntityCode { get; set; }
        public decimal WalletAmt { get; set; }
        public decimal BillAmt { get; set; }
        public string EntityKey { get; set; }
        [Ignore]
        public GeoLocation Geolocation { get; set; }
        public string mobileno { get; set; }
        public string address { get; set; }
        public string location { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string pincode { get; set; }

        public string TransactionType { get; set; }
        public Int32 Is_health_check { get; set; }
        public string Entity_ContactNo { get; set; }
        public double GEO_DISTANCE { get; set; }
        public Int32 aggregator_type { get; set; }
        public int onlineOrderFlow { get; set; }
    }


    public class PharmacyRefundUpdate
    {
        
        public string ORDER_ID { get; set; }

        public string USER_ID { get; set; }

        public int ISRECIVED { get; set; }

        public string PayerCode { get; set; }

        public string OneMgOrderId { get; set; }

        public string CREATED_BY { get; set; }

        public string MODIFIED_BY { get; set; }

        public string DEVICEID { get; set; }
        public string VISITORIP { get; set; }


    }

    public class DRL_Product_Info
    {
        public string MedicineCode { get; set; }
        public int Quantity { get; set; }

    }
    public class DRL_DRUG_Data
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public dynamic productInfo { get; set; }

    }
    public class DRL_Medicine_Avail_Req
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public List<DRL_Product_Info> productInfo { get; set; }

    }

    public class ProductInfo
    {
        public string productId { get; set; }
        public string productName { get; set; }
        public string packSize { get; set; }
        public string mrp { get; set; }
        public int availableQty { get; set; }
        public int requestedQty { get; set; }
        public double salePrice { get; set; }
    }

    public class DRL_MedResponse
    {
        public string storeId { get; set; }
        public string eta { get; set; }
        public List<ProductInfo> productInfos { get; set; }
    }

    public class DRL_MedAvailbalityResp
    {
        public string statusCode { get; set; }
        public object message { get; set; }
        public List<DRL_MedResponse> response { get; set; }
    }
}
