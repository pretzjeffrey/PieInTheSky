using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieInTheSky.Persistence
{
    public class PizzaPriceRepository
    {
        public static DTO.PizzaPriceDTO GetPizzaPrices()
        {
            var db = new PieInTheSkyDbEntities();
            var priceList = db.PizzaPrices.First();
            var dto = ConvertToDTO(priceList);
            return dto;
        }

        private static DTO.PizzaPriceDTO ConvertToDTO(PizzaPrice priceList)
        {
            var dto = new DTO.PizzaPriceDTO();

            dto.SmallSizeCost = priceList.SmallSizeCost;
            dto.MediumSizeCost = priceList.MediumSizeCost;
            dto.LargeSizeCost = priceList.LargeSizeCost;
            dto.ThinCrustCost = priceList.ThinCrustCost;
            dto.RegularCrustCost = priceList.RegularCrustCost;
            dto.ThickCrustCost = priceList.ThickCrustCost;
            dto.SausageCost = priceList.SausageCost;
            dto.PepperoniCost = priceList.PepperoniCost;
            dto.OnionsCost = priceList.OnionsCost;
            dto.GreenPeppersCost = priceList.GreenPeppersCost;
            return dto;
        }
    }
}
