using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using CreateProductDetailDto = RealEstate_Dapper_Api.Dtos.ProductDtos.CreateProductDetailDto;
using UpdateProductDetailDto = RealEstate_Dapper_Api.Dtos.ProductDtos.UpdateProductDetailDto;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id);
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id);
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task ProductDealOfTheDayStatusChangeToTrue(int id);
        Task ProductDealOfTheDayStatusChangeToFalse(int id);
        Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync();
        Task<List<ResultLast3ProductWithCategoryDto>> GetLast3ProductAsync();
        Task CreateProduct(CreateProductDto createProductDto);
        Task DeleteProduct(int id);
        Task UpdateProduct(UpdateProductDto updateProductDto);
        Task<GetProductByProductIdDto> GetProductByProductId(int id);
        ////////////////////////////
        Task<GetProductDetailByIdDto> GetProductDetailByProductId(int id);
        Task CreateProductDetail(CreateProductDetailDto createProductDetailDto);
        Task DeleteProductDetail(int id);
        Task UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto);
        /////////////////////////////
        Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue,int propertyCategoryId, string city);
        Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategoryAsync();
    }
}
