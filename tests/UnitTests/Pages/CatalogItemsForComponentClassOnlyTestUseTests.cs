using BlazorWebAssemblyApp.Models;
using BlazorWebAssemblyApp.Pages;
using BlazorWebAssemblyApp.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Pages
{
    // NOTE_JBOY: This is a sample unit test which does not access the HTML of the Blazor 
    // compoment and which does not use BUnit
    // LESSON LEARNED (Nov 9, 2020): seems like it's best to just do unit test for UI 
    // by directly accessing the DOM (by using BUnit) instead of also creating another 
    // set of tests which uses only the class for the Blazor component (and which does 
    // not use BUnit); because if you create these two kinds of unit tests, your tests
    // will now become redundant.
    // Just create a separate project for the e2e tests, which should be run with the 
    // backend running, directly accessing databases, etc.
    public class CatalogItemsForComponentClassOnlyTestUseTests
    {
        Mock<ICatalogService> catalogServiceMock = new Mock<ICatalogService>();

        [Fact]
        public void shows_correct_number_of_catalog_items_on_initial_load()
        {
            // arrange
            var pageSize = 5;
            catalogServiceMock.Setup(x => x.ListPagedCatalogItemsAsync(It.IsAny<int>(), pageSize))
                    .Returns(Task.FromResult(new ListPagedCatalogItemResponse()
                    {
                        CatalogItems = generateCatalogItems(pageSize).ToList(),
                        PageCount = 1
                    }));

            // act
            var sut = new CatalogItemsSut(new Mock<IConfiguration>().Object, catalogServiceMock.Object);
            sut.SetPageSize(pageSize);
            sut.Initialize();
            
            // assert
            Assert.Equal(pageSize, sut.PagedCatalogItems.CatalogItems.Count);
        }

        private IEnumerable<CatalogItem> generateCatalogItems(int count)
        {
            for (int i = 0; i < count; i++)
                yield return new CatalogItem
                {
                    Id = i,
                    Name = Faker.Lorem.Words(3).ToString(),
                    Description = Faker.Lorem.Sentence(10),
                };
        }
    }

    internal class CatalogItemsSut : CatalogItemsForComponentClassOnlyTestUse
    {
        internal ListPagedCatalogItemResponse PagedCatalogItems => base.pagedCatalogItems;

        internal CatalogItemsSut(IConfiguration configuration, ICatalogService catalogService)
        {
            base.Configuration = configuration;
            base.CatalogService = catalogService;
        }

        internal async void Initialize()
        {
            await base.OnInitializedAsync();
        }

        internal void SetPageSize(int pageSize)
        {
            base.PageSize = pageSize;
        }
    }
}
