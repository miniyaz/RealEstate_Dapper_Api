using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;
        public StatisticRepository(Context context)
        {
            _context = context;
        }
        public int AllProductCount()
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

        public int ProductCountByEmployeeId(int id)
        {
            try
            {
                string query = "Select Count(*) From Product Where EmployeeId=@employeeId";
                var parameters = new DynamicParameters();
                parameters.Add("@employeeId",id);
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query,parameters);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            };
        }

        public int ProductCountByStatusFalse(int id)
        {
            try
            {
                string query = "Select Count(*) From Product Where EmployeeId=@employeeId And ProductStatus=0";
                var parameters = new DynamicParameters();
                parameters.Add("@employeeId", id);
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query, parameters);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            };
        }

        public int ProductCountByStatusTrue(int id)
        {
            try
            {
                string query = "Select Count(*) From Product Where EmployeeId=@employeeId And ProductStatus=1";
                var parameters = new DynamicParameters();
                parameters.Add("@employeeId", id);
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query, parameters);
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
