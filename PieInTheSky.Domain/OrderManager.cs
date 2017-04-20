using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieInTheSky.Domain
{
    public class OrderManager
    {
        public static void CreateOrder(DTO.OrderDTO orderDTO)
        {
            Persistence.OrderRepository.CreateOrder(orderDTO);
        }

        private decimal calculateTotalCost()
        {
            decimal totalCost = 0;

            return totalCost;
        }

        public static object GetOrders()
        {
            
            return Persistence.OrderRepository.GetOrders();
        }

        public static void CompleteOrder(Guid orderId)
        {
            Persistence.OrderRepository.CompleteOrder(orderId);
        }
    }
}
