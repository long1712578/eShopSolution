using eShopSolution.Application.Dtos;
using eShopSolution.ViewModels.Catalog.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productId);
        Task<List<ProductViewModel>> GetAll();
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        //Task<int> AddImage(int productId, ProductImageCreateRequest request);

        //
       // Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        //Task<ProductImageViewModel> GetImageById(int imageId);

        //Task<List<ProductImageViewModel>> GetListImages(int productId);
    }
}
