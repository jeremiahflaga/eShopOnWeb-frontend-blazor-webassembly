using System;
using System.Collections.Generic;

namespace BlazorWebAssemblyApp.Models
{
    public class ListPagedCatalogItemResponse
    {
        public List<CatalogItem> CatalogItems { get; set; } = new List<CatalogItem>();
        public int PageCount { get; set; }
    }
}
