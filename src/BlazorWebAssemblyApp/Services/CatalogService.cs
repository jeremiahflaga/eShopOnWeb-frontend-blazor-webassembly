using BlazorWebAssemblyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssemblyApp.Services
{
    public interface ICatalogService
    {
        Task<GetCatalogItemResponse> GetCatalogItemAsync(int id);
        Task<ListPagedCatalogItemResponse> ListPagedCatalogItemsAsync(int pageSize = 10, int pageIndex = 0);
    }

    public class CatalogService : ICatalogService
    {
        private IHttpService _httpService;

        public CatalogService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<GetCatalogItemResponse> GetCatalogItemAsync(int id)
        {
            var item = await _httpService.Get<GetCatalogItemResponse>($"/api/catalog-items/{id}");
            return item;
        }

        public async Task<ListPagedCatalogItemResponse> ListPagedCatalogItemsAsync(int pageSize = 10, int pageIndex = 0)
        {
            try
            {
                var result = await _httpService.Get<ListPagedCatalogItemResponse>($"/api/catalog-items?PageSize={pageSize}&PageIndex={pageIndex}");
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
