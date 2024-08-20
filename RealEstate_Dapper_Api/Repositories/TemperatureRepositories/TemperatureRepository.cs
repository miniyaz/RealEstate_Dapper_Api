using Dapper;
using RealEstate_Dapper_Api.Dtos.TemperatureDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.TemperatureRepositories;

namespace RealEstate_Dapper_Api.Repositoriesi.TemperatureRepositories
{
    public class TemperatureRepository : ITemperatureRepository
    {
        private readonly Context _context;
        public TemperatureRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultTemperatureDto>> GetAllTemperatureAsync()
        {
            string query = "Select * From Temperature";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTemperatureDto>(query);
                return values.ToList();
            }
        }
        public async Task CreateTemperature(CreateTemperatureDto createTemperatureDto)
        {
            string query = "INSERT INTO Temperature (TemperatureName, Value, Unit, Status) VALUES (@TemperatureName, @Value, @Unit, @Status)";
            var parameters = new DynamicParameters();
            parameters.Add("@TemperatureName", createTemperatureDto.TemperatureName);
            parameters.Add("@Value", createTemperatureDto.Value);
            parameters.Add("@Unit", createTemperatureDto.Unit);
            parameters.Add("@Status", createTemperatureDto.Status);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        
        public async Task DeleteTemperature(Guid id)
        {
            string query = "Delete From Temperature Where TemperatureID=@TemperatureID";
            var parameters = new DynamicParameters();
            parameters.Add("@TemperatureID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateTemperature(UpdateTemperatureDto updateTemperatureDto)
        {
            string query = "Update Temperature Set TemperatureName=@TemperatureName,Value=@Value,Unit=@Unit,Status=@Status Where TemperatureID=@TemperatureID ";
            var parameters = new DynamicParameters();
            parameters.Add("@TemperatureID", updateTemperatureDto.TemperatureID);
            parameters.Add("@TemperatureName", updateTemperatureDto.TemperatureName);
            parameters.Add("@Value", updateTemperatureDto.Value);
            parameters.Add("@Unit", updateTemperatureDto.Unit);
            parameters.Add("@Status", updateTemperatureDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        // AKTİF SICAKLIK SAYISI
        public int ActiveTemperatureCount()
        {
            try
            {
                string query = "Select COUNT(*) From Temperature Where Status=1";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                   // tüm satırları çekip saymak yerine doğruda sayması için
                   // executeScalerAsync ifadesini kullandım
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        // PASİF SICAKLIK SAYISI
        public int PassiveTemperatureCount()
        {
            try
            {
                string query = "Select COUNT(*) From Temperature Where Status=0";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                   // tüm satırları çekip saymak yerine doğruda sayması için
                   // executeScalerAsync ifadesini kullandım
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        // ORTALAMA SICAKLIK SAYISI
        public int AverageTemperatureCount()
        {
            try
            {
                string query = "Select AVG(Value) From Temperature";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                   // tüm satırları çekip saymak yerine doğruda sayması için
                  //  executeScalerAsync ifadesini kullandım
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        // EN YÜKSEK SICAKLIK DEĞERİ
        public int HighTemperature()
        {
            try
            {
                string query = "Select MAX(Value) AS MaxTemperature FROM Temperature";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                   // tüm satırları çekip saymak yerine doğruda sayması için
                   // executeScalerAsync ifadesini kullandım
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        // EN DÜŞÜK SICAKLIK DEĞERİ
        public int LowTemperature()
        {
            try
            {
                string query = "Select MIN(Value) AS MinTemperature FROM Temperature";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                  // tüm satırları çekip saymak yerine doğruda sayması için
                  // executeScalerAsync ifadesini kullandım
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        // İLK EKLENEN SICAKLIK DEĞERİ
        public int NewTemperature()
        {
            try
            {
                string query = "Select Top(1) Value From Temperature";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                 // tüm satırları çekip saymak yerine doğruda sayması için
                 //   executeScalerAsync ifadesini kullandım
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        // SON EKLENEN SICAKLIK DEĞERİ
        public int LastTemperature()
        {
            try
            {
                string query = "Select Top(1) Value From Temperature Order By TemperatureID Desc";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                 // tüm satırları çekip saymak yerine doğruda sayması için
                 // executeScalerAsync ifadesini kullandım
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        // EN ÇOK SICAKLIK VERİSİ GİRİLEN İSİM
        public string TemperatureNameMax()
        {
            try
            {
                string query = "Select Top (1) TemperatureName FROM Temperature GROUP BY TemperatureName ORDER BY COUNT(*) DESC";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<string>(query);
                 // tüm satırları çekip saymak yerine doğruda sayması için
                 //  executeScalerAsync ifadesini kullandım
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        // EN AZ SICAKLIK VERİSİ GİRİLEN İSİM
        public string TemperatureNameMin()
        {
            try
            {
                string query = "SELECT TOP (1) TemperatureName FROM Temperature GROUP BY TemperatureName ORDER BY COUNT(*) ASC";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<string>(query);
                //  tüm satırları çekip saymak yerine doğruda sayması için
                //  executeScalerAsync ifadesini kullandım
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        // EN YÜKSEK VE EN DÜŞÜK SICAKLIK ARASINDAKİ FARK
        public int TemperatureDifference()
        {
            try
            {
                string query = "Select MAX(Value) - MIN(Value) As Difference From Temperature";
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                //  tüm satırları çekip saymak yerine doğruda sayması için
                //  executeScalerAsync ifadesini kullandım
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
