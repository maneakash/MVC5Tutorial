using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIFundamental.Models;

namespace WebAPIFundamental.Service
{
    public interface IOrderService
    {
        List<Order> GetOrders();
    }
}
