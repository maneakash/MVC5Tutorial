using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIFundamental.Validators;

namespace WebAPIFundamental.Models
{
    [Validator(typeof(OrderValidator))]
    public class Order
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }

        public string UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPayable { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }

        public List<OrderLine> OrderLines { get; set; }
    }
}