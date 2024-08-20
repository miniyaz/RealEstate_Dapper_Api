using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            string query = "insert into Product (Title, Price, City, District, CoverImage, Address, Description,Type,DealOfTheDay, AdvertisementDate,ProductStatus,ProductCategory,AppUserId) values (@Title, @Price, @City, @District,@CoverImage,@Address,@Description,@Type,@DealOfTheDay, @AdvertisementDate, @ProductStatus, @ProductCategory, @AppUserId) ";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createProductDto.Title);
            parameters.Add("@Price", createProductDto.Price);
            parameters.Add("@City", createProductDto.City);
            parameters.Add("@District", createProductDto.District);
            parameters.Add("@CoverImage", createProductDto.CoverImage);
            parameters.Add("@Address", createProductDto.Address);
            parameters.Add("@Description", createProductDto.Description);
            parameters.Add("@Type", createProductDto.Type);
            parameters.Add("@DealOfTheDay", createProductDto.DealOfTheDay);
            parameters.Add("@AdvertisementDate", createProductDto.AdvertisementDate);
            parameters.Add("@ProductStatus", createProductDto.ProductStatus);
            parameters.Add("@ProductCategory", createProductDto.ProductCategory);
            parameters.Add("@AppUserId", createProductDto.AppUserId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteProduct(int id)
        {
            string query = "Delete From Product Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
        public async Task UpdateProduct(UpdateProductDto updateProductDto)
        {
            try
            {
                string query = "Update Product Set Title=@Title, Price=@Price, City=@City, District=@District, CoverImage=@CoverImage, Address=@Address, Description=@Description, Type=@Type, DealOfTheDay=@DealOfTheDay, AdvertisementDate=@AdvertisementDate, ProductStatus=@ProductStatus, ProductCategory=@ProductCategory, AppUserId=@AppUserId Where ProductID=@productID";
                var parameters = new DynamicParameters();
                parameters.Add("@Title", updateProductDto.Title);
                parameters.Add("@Price", updateProductDto.Price);
                parameters.Add("@City", updateProductDto.City);
                parameters.Add("@District", updateProductDto.District);
                parameters.Add("@CoverImage", updateProductDto.CoverImage);
                parameters.Add("@Address", updateProductDto.Address);
                parameters.Add("@Description", updateProductDto.Description);
                parameters.Add("@Type", updateProductDto.Type);
                parameters.Add("@DealOfTheDay", updateProductDto.DealOfTheDay);
                parameters.Add("@AdvertisementDate", updateProductDto.AdvertisementDate);
                parameters.Add("@ProductStatus", updateProductDto.ProductStatus);
                parameters.Add("@ProductCategory", updateProductDto.ProductCategory);
                parameters.Add("@AppUserId", updateProductDto.AppUserId);
                parameters.Add("@productID", updateProductDto.ProductID);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }
        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID, Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay,SlugUrl " +
                " From Product inner join Category on Product.ProductCategory= Category.CategoryID ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
        public async Task<List<ResultLast3ProductWithCategoryDto>> GetLast3ProductAsync()
        {
            string query = "Select Top(3) ProductID,Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate,CoverImage,Description From Product Inner Join Category On Product.ProductCategory=Category.CategoryID Order By ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast3ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "Select Top(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate From Product Inner Join Category On Product.ProductCategory=Category.CategoryID where Type='Kiralık' Order By ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id)
        {
            string query = "Select ProductID, Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay" +
            " From Product inner join Category on Product.ProductCategory= Category.CategoryID where EmployeeId=@employeeId and ProductStatus=0";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }
        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id)
        {
            string query = "Select ProductID, Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay" +
            " From Product inner join Category on Product.ProductCategory= Category.CategoryID where EmployeeId=@employeeId and ProductStatus=1";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }
        public async Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategoryAsync()
        {
            string query = "Select ProductID, Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay" +
                " From Product inner join Category on Product.ProductCategory= Category.CategoryID where DealOfTheDay=1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
        public async Task<GetProductByProductIdDto> GetProductByProductId(int id)
        {
            try
            {
                string query = "Select ProductID, Title,Price,City,District,Description,CategoryName,CoverImage,Type,Address,DealOfTheDay,AdvertisementDate,SlugUrl" +
               " From Product inner join Category on Product.ProductCategory= Category.CategoryID where ProductId=@productId";
                var parameters = new DynamicParameters();
                parameters.Add("@productID", id);
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<GetProductByProductIdDto>(query, parameters);
                    return values.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task<GetProductDetailByIdDto> GetProductDetailByProductId(int id)
        {
            try
            {
                string query = "Select * From ProductDetails where ProductId=@productId";
                var parameters = new DynamicParameters();
                parameters.Add("@productID", id);
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<GetProductDetailByIdDto>(query, parameters);
                    return values.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            try
            {
                string query = "Update Product set DealOfTheDay=0 where ProductID = @productID ";
                var parameters = new DynamicParameters();
                parameters.Add("@productID", id);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            try
            {
                string query = "Update Product set DealOfTheDay=1 where ProductID = @productID ";
                var parameters = new DynamicParameters();
                parameters.Add("@productID", id);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            try
            {
                string query = "Select * From Product Where Title like '%" + searchKeyValue + "%' And ProductCategory=@propertyCategoryId And City=@city";
                var parameters = new DynamicParameters();
                //parameters.Add("@searchKeyValue", searchKeyValue);
                parameters.Add("@propertyCategoryId", propertyCategoryId);
                parameters.Add("@city", city);
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultProductWithSearchListDto>(query, parameters);
                    return values.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task CreateProductDetail(Dtos.ProductDtos.CreateProductDetailDto createProductDetailDto)
        {
            string query = "insert into ProductDetails (ProductSize,BedRoomCount,BathCount,RoomCount,GarageSize,BuildYear,Price,Location,VideoUrl,ProductID) Values (@ProductSize,@BedRoomCount,@BathCount,@RoomCount,@GarageSize,@BuildYear,@Price,@Location,@VideoUrl,@ProductID) ";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductSize", createProductDetailDto.ProductSize);
            parameters.Add("@BedRoomCount", createProductDetailDto.BedRoomCount);
            parameters.Add("@BathCount", createProductDetailDto.BathCount);
            parameters.Add("@RoomCount", createProductDetailDto.RoomCount);
            parameters.Add("@GarageSize", createProductDetailDto.GarageSize);
            parameters.Add("@BuildYear", createProductDetailDto.BuildYear);
            parameters.Add("@Price", createProductDetailDto.Price);
            parameters.Add("@Location", createProductDetailDto.Location);
            parameters.Add("@VideoUrl", createProductDetailDto.VideoUrl);
            parameters.Add("@ProductID", createProductDetailDto.ProductId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteProductDetail(int id)
        {
            string query = "Delete From ProductDetails Where ProductDetailID=@ProductDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateProductDetail(Dtos.ProductDtos.UpdateProductDetailDto updateProductDetailDto)
        {
            try
            {
                string query = "Update ProductDetails Set ProductSize=@ProductSize,BedRoomCount=@BedRoomCount,BathCount=@BathCount,RoomCount=@RoomCount,GarageSize=@GarageSize,BuildYear=@BuildYear,Price=@Price,Location=@Location,VideoUrl=@VideoUrl,ProductId=@ProductId Where ProductDetailID=@ProductDetailID";
                var parameters = new DynamicParameters();
                parameters.Add("@ProductSize", updateProductDetailDto.ProductSize);
                parameters.Add("@BedRoomCount", updateProductDetailDto.BedRoomCount);
                parameters.Add("@BathCount", updateProductDetailDto.BathCount);
                parameters.Add("@RoomCount", updateProductDetailDto.RoomCount);
                parameters.Add("@GarageSize", updateProductDetailDto.GarageSize);
                parameters.Add("@BuildYear", updateProductDetailDto.BuildYear);
                parameters.Add("@Price", updateProductDetailDto.Price);
                parameters.Add("@Location", updateProductDetailDto.Location);
                parameters.Add("@VideoUrl", updateProductDetailDto.VideoUrl);
                parameters.Add("@ProductId", updateProductDetailDto.ProductId);
                parameters.Add("@ProductDetailID", updateProductDetailDto.ProductDetailId);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
            }
        }
    }   
}
