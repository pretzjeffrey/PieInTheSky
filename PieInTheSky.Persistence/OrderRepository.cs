using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieInTheSky.Persistence
{
    public class OrderRepository
    {
        public static void CreateOrder(DTO.OrderDTO orderDTO)
        {
            var db = new PieInTheSkyDbEntities();
            var order = new Order();
            order = ConvertOrderDtoToEntity(orderDTO);
            try
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = string.Concat(ex.Message, "Validation errors occurred when saving to the database: ", fullErrorMessage);

                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }

        }

        public static void CompleteOrder(Guid orderId)
        {
            var db = new PieInTheSkyDbEntities();
            var order = db.Orders.FirstOrDefault(x => x.Completed == false);
            order.Completed = true;
            db.SaveChanges();
        }

        public static List<DTO.OrderDTO> GetOrders()
        {
            var db = new PieInTheSkyDbEntities();
            var orders = db.Orders.Where(p => p.Completed == false).ToList();
            var ordersDTO = convertToDTO(orders);
            return ordersDTO;
        }

        private static List<DTO.OrderDTO> convertToDTO(List<Order> orders)
        {
            var ordersDTO = new List<DTO.OrderDTO>();
            foreach (var order in orders)
            {
                var orderDTO = new DTO.OrderDTO();
                orderDTO.Id = order.Id;
                orderDTO.Name = order.Name;
                orderDTO.Address = order.Address;
                orderDTO.Zip = order.Zip;
                orderDTO.Phone = order.Phone;
                orderDTO.Sausage = order.Sausage;
                orderDTO.Pepperoni = order.Pepperoni;
                orderDTO.Onions = order.Onions;
                orderDTO.GreenPeppers = order.GreenPeppers;
                orderDTO.PaymentType = order.PaymentType;
                orderDTO.TotalCost = order.TotalCost;
                orderDTO.Completed = order.Completed;
                ordersDTO.Add(orderDTO);
            }
            return ordersDTO;
        }

        private static Order ConvertOrderDtoToEntity(DTO.OrderDTO orderDTO)
        {
            var order = new Order();
            order.Id = orderDTO.Id;
            order.Size = orderDTO.Size;
            order.Crust = orderDTO.Crust;
            order.Sausage = orderDTO.Sausage;
            order.Pepperoni = orderDTO.Pepperoni;
            order.Onions = orderDTO.Onions;
            order.GreenPeppers = orderDTO.GreenPeppers;
            order.Name = orderDTO.Name;
            order.Address = orderDTO.Address;
            order.Zip = orderDTO.Zip;
            order.Phone = orderDTO.Phone;
            order.PaymentType = orderDTO.PaymentType;
            order.Completed = orderDTO.Completed;
            order.TotalCost = orderDTO.TotalCost;

            return order;
        }


    }
}
