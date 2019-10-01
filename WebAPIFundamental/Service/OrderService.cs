using System;
using System.Collections.Generic;
using WebAPIFundamental.Models;

namespace WebAPIFundamental.Service
{
    class OrderService : IOrderService
    {
        List<Order> Orders;


        public OrderService()
        {
            Orders = new List<Order>()
            {
                new Order()
                {
                    OrderId =1,
                    Status = OrderStatus.AUTHORIZED,
                    UserId = new Guid().ToString(),
                    TotalAmount = 100,
                    AmountPayable = 90,
                    ShippingAddress = new Address(){ Id = 1, FirstName="ShipFName", LastName = "ShipLName",Country ="IN", State ="MH", City ="Kolhapur", Zip ="416220"},
                    BillingAddress = new Address(){ Id = 1, FirstName="BillFName", LastName = "BillLName",Country ="IN", State ="MH", City ="Kolhapur", Zip ="416220"},
                    OrderLines = new List<OrderLine>(){ new OrderLine(){ OrderLineId =1, SKU ="SKU-1", ProductPrice =100, Quantity=4} }
                }


            };
        }

        public List<Order> GetOrders()
        {
            return Orders;
        }
    }
}
