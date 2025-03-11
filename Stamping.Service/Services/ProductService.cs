using AutoMapper;
using StamingRobot.Repository.Commons;
using StamingRobot.Repository.Entities;
using StamingRobot.Repository.UnitOfWork;
using StamingRobot.Repository.UnitOfWork.Interface;
using StampingRobot.Service.BussinessModels;
using StampingRobot.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateProduct(ProductModel productModel)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var product = _mapper.Map<Product>(productModel);
                await _unitOfWork.ProductRepository.AddAsync(product);
                var result = await _unitOfWork.SaveChanges();
                if (result > 0)
                {
                    await _unitOfWork.CommitTransactionAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw ex;
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
                if (product != null)
                {
                    await _unitOfWork.ProductRepository.SoftDeleteAsync(product);
                    var result = await _unitOfWork.SaveChanges();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                return false;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
                var productModel = _mapper.Map<ProductModel>(product);
                return productModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Pagination<ProductModel>> GetProducts(PaginationParameter paginationParameter, FilterProduct filterProduct)
        {
            var list = await _unitOfWork.ProductRepository.GetByConditionAsync(c => (c.Name.Contains(filterProduct.Name) || filterProduct.Name == null)
                            && (c.Material.Equals(filterProduct.Material) || filterProduct.Material == null)
                            && (c.IsDeleted.Equals(filterProduct.IsDelete) || filterProduct.IsDelete == null));

            var product = list.Skip((paginationParameter.PageIndex - 1) * paginationParameter.PageSize).Take(paginationParameter.PageSize).ToList();

            var count = list.Count();

            var productModel = _mapper.Map<List<ProductModel>>(product);

            return new Pagination<ProductModel>(productModel, count, paginationParameter.PageIndex, paginationParameter.PageSize);
        }

        public async Task<bool> UpdateProduct(ProductModel productModel)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var product = _mapper.Map<Product>(productModel);

                await _unitOfWork.ProductRepository.UpdateAsync(product);
                var resutl = await _unitOfWork.SaveChanges();
                if (resutl > 0)
                {
                    await _unitOfWork.CommitTransactionAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw ex;
            }
        }
    }
}
