using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Manage;
using eShopSolution.Application.Dtos;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace eShopSolution.Application.Catalog.Products
{
    public class PublicProductService:IPublicProductService
    {

        private readonly EShopDBContext _context;
        public PublicProductService(EShopDBContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<ProductViewModel>> GetAllByCategory(Dtos.Public.GetProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            //if(request.categoryId.V
            query = query.Where(x => x.pic.CategoryId == request.categoryId);
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                                   .Take(request.PageSize)
                                   .Select(x => new ProductViewModel()
                                   {
                                       Id = x.p.Id,
                                       Name = x.pt.Name,
                                       DateCreated = x.p.DataCreated,
                                       Description = x.pt.Description,
                                       Details = x.pt.Details,
                                       LanguageId = x.pt.LanguageId,
                                       OriginalPrice = x.p.OriginalPrice,
                                       Price = x.p.Price,
                                       SeoAlias = x.pt.SeoAlias,
                                       SeoDescription = x.pt.SeoDescription,
                                       SeoTitle = x.pt.SeoTitle,
                                       Stock = x.p.Stock,
                                       ViewCount = x.p.ViewCount
                                   }).ToListAsync();
            var pageResult = new PagedResult<ProductViewModel>
            {
                items = data,
                TotalRecord = totalRow
            };
            return pageResult;
        }
    }
}
