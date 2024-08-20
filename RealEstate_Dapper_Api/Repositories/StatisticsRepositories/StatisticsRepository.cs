using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;
        public StatisticsRepository(Context context)
        {
            _context = context;
        }
        public int ActiveCategoryCount()
        {
            try
            {
                string query = "Select Count(*) From Category Where CategoryStatus=1";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public int ActiveEmployeeCount()
        {
            try
            {
                string query = "Select Count(*) From Employee Where Status=1";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public int ApartmentCount()
        {
            try
            {
                string query = "Select Count(*) From Product Where Title like'%Daire%'";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public decimal AverageProductPriceByRent()
        {
            try
            {
                string query = "Select Avg(Price) From Product Where Type='Kiralık'";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<decimal>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public decimal AverageProductPriceBySale()
        {
            try
            {
                string query = "Select Avg(Price) From Product Where Type='Satılık'";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<decimal>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public int AverageRoomCount()
        {
            try
            {
                string query = "Select Avg(RoomCount) From ProductDetails";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public int CategoryCount()
        {
            try
            {
                string query = "Select Count(*) From Category";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public string CategoryNameByMaxProductCount()
        {
            try
            {
                string query = "Select top(1) CategoryName,Count(*) From Product inner join Category on Product.ProductCategory=Category.CategoryID Group By CategoryName order by Count(*) Desc";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<string>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public string CityNameByMaxProductCount()
        {
            try
            {
                string query = "Select top(1) City,Count(*) as 'product_count'From Product Group By City order by product_count Desc";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<string>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public int DifferentCityCount()
        {
            try
            {
                string query = "Select Count(Distinct(City)) From Product";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public string EmployeeNameByMaxProductCount()//en fazla ilanı olan çalışan
        {
            try
            {
                string query = "Select Name,Count(*) 'product_count' From Product Inner Join Employee On Product.AppUserId=Employee.EmployeeID Group By Name Order By product_count Desc";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<string>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public decimal LastProductPrice()
        {
            try
            {
                string query = "Select Top(1) Price From Product Order By ProductId Desc";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<decimal>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public string NewestBuildingYear()
        {
            try
            {
                string query = "Select Top(1) BuildYear From ProductDetails Order By BuildYear Desc ";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<string>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            };
        }

        public string OldestBuildingYear()
        {
            try
            {
                string query = "Select Top(1) BuildYear From ProductDetails Order By BuildYear Asc";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<string>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            };
        }

        public int PassiveCategoryCount()
        {
            try
            {
                string query = "Select Count(*) From Category Where CategoryStatus=0";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            };
        }

        public int ProductCount()
        {
            try
            {
                string query = "Select Count(*) From Product";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            };
        }
    }
}
