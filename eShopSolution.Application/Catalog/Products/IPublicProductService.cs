using eShopSolution.Application.Dtos;
using eShopSolution.ViewModels.Catalog.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategory(GetPublicProductPagingRequest request);
        Task<List<ProductViewModel>> GetAll();
    }
}
