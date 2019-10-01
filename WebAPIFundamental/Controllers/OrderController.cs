using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using WebAPIFundamental.Filters;
using WebAPIFundamental.Models;
using WebAPIFundamental.Service;

namespace WebAPIFundamental.Controllers
{
    public class OrderController : ApiController
    {
        readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }
        public List<Order> Get()
        {
            return _orderService.GetOrders();
        }

        [HttpPost]
        public HttpResponseMessage Post(Order order)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
