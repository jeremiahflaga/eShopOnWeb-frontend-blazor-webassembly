using BlazorWebAssemblyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssemblyApp.Services
{
    public interface ICatalogService
    {
        Task<ListPagedCatalogItemResponse> ListPaged(int pageSize = 10, int pageIndex = 0);
    }

    public class CatalogService : ICatalogService
    {
        private IHttpService _httpService;

        public CatalogService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<ListPagedCatalogItemResponse> ListPaged(int pageSize = 10, int pageIndex = 0)
        {
            return await _httpService.Get<ListPagedCatalogItemResponse>($"/api/catalog-items?PageSize={pageSize}&PageIndex={pageIndex}");
        }
    }
}
