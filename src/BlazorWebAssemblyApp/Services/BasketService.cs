using BlazorWebAssemblyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssemblyApp.Services
{
    public interface IBasketService
    {
        Task<GetBasketResponse> GetBasket();
        Task AddItemToBasket(int catalogItemId);
    }

    public class BasketService : IBasketService
    {
        private IHttpService _httpService;

        public BasketService(IHttpService httpService)
        {
            _httpService = httpService;
        }

		public async Task<GetBasketResponse> GetBasket()
        {
            var basket = await _httpService.Get<GetBasketResponse>($"/api/basket");
            return basket;
        }

        public async Task AddItemToBasket(int catalogItemId)
        {
            await _httpService.Post<AddItemToBasketRequest>($"/api/basket", new { catalogItemId });
        }
    }
}
