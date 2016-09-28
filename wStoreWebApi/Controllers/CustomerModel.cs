using System;

namespace wStoreWebApi.Controllers
{
    public class CustomerModel
    {
        public string Address { get; set; }
        public int Contact { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}