using StamingRobot.Repository.Commons;
using StampingRobot.Service.BussinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.Services.Interface
{
    public interface IProductService
    {
        Task<Pagination<ProductModel>> GetProducts(PaginationParameter paginationParameter, FilterProduct filterProduct);
        Task<ProductModel> GetProductById(int id);
        Task<bool> CreateProduct(ProductModel productModel);
        Task<bool> UpdateProduct(ProductModel productModel);
        Task<bool> DeleteProduct(int id);
    }
}
