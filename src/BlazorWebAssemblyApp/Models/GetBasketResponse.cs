using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssemblyApp.Models
{
	public class GetBasketResponse
    {
        public int Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public string BuyerId { get; set; }

        public decimal Total()
        {
            return Math.Round(Items.Sum(x => x.UnitPrice * x.Quantity), 2);
        }
    }
}
