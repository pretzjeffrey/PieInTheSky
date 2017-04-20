using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieInTheSky.Domain
{
    public class PriceListManager
    {
        public static decimal CalculateOrderTotal(DTO.OrderDTO orderDTO)
        {
            decimal cost = 0.0M;
            var prices = GetPizzaPriceList();
            cost += calculateSizeCost(orderDTO, prices);
            cost += calculateCrustCost(orderDTO, prices);
            cost += calculateIngredientCost(orderDTO, prices);
            return cost;
        }

        private static decimal calculateSizeCost(DTO.OrderDTO order, DTO.PizzaPriceDTO prices)
        {
            decimal cost = 0.0M;
            switch (order.Size)
            {
                case DTO.Enums.SizeType.Small:
                    cost = prices.SmallSizeCost;
                    break;
                case DTO.Enums.SizeType.Medium:
                    cost = prices.MediumSizeCost;
                    break;
                case DTO.Enums.SizeType.Large:
                    cost = prices.LargeSizeCost;
                    break;
                default:
                    break;
            }
            return cost;
        }

        private static decimal calculateCrustCost(DTO.OrderDTO order, DTO.PizzaPriceDTO prices)
        {
            decimal cost = 0.0M;
            switch (order.Crust)
            {
                case DTO.Enums.CrustType.Thin:
                    cost = prices.ThinCrustCost;
                    break;
                case DTO.Enums.CrustType.Regular:
                    cost = prices.RegularCrustCost;
                    break;
                case DTO.Enums.CrustType.Thick:
                    cost = prices.ThickCrustCost;
                    break;
                default:
                    break;
            }
            return cost;
        }

        private static decimal calculateIngredientCost(DTO.OrderDTO order, DTO.PizzaPriceDTO prices)
        {
            decimal cost = 0.0M;
            cost += (order.Sausage) ? prices.SausageCost : 0;
            cost += (order.Pepperoni) ? prices.PepperoniCost : 0;
            cost += (order.Onions) ? prices.OnionsCost : 0;
            cost += (order.GreenPeppers) ? prices.GreenPeppersCost : 0;
            return cost;
        }

        private static DTO.PizzaPriceDTO GetPizzaPriceList()
        {
            var priceList = Persistence.PizzaPriceRepository.GetPizzaPrices();

            return priceList;
        }
    }
}
