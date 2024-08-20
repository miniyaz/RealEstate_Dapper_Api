﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;
        public EmployeeRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            try
            {
                string query = "insert into Employee (Name,Title,Mail,PhoneNumber,ImageUrl,Status) values (@name,@title,@mail,@phoneNumber,@imageUrl,@status) ";
                var parameters = new DynamicParameters();
                parameters.Add("@name",createEmployeeDto.Name);
                parameters.Add("@title", createEmployeeDto.Title);
                parameters.Add("@mail", createEmployeeDto.Mail);
                parameters.Add("@phoneNumber", createEmployeeDto.PhoneNumber);
                parameters.Add("@imageUrl", createEmployeeDto.ImageUrl);
                parameters.Add("@status", true);
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

        public async Task DeleteEmployee(int id)
        {
            try
            {
                String query = "Delete From Employee Where EmployeeID=@employeeID";
                var parameters = new DynamicParameters();
                parameters.Add("@employeeID", id);
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

        public async Task<List<ResultEmployeeDto>> GetAllEmployee()
        {
            try
            {
                string query = "Select * From Employee";
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                    return values.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<GetByIDEmployeeDto> GetEmployee(int id)
        {
            try
            {
                string query = "Select * From Employee Where EmployeeID=@EmployeeID";
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeID", id);
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryFirstOrDefaultAsync<GetByIDEmployeeDto>(query, parameters);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            try
            {
                string query = "Update Employee set Name=@name,Title=@title,Mail=@mail,PhoneNumber=@phoneNumber,ImageUrl=@imageUrl,Status=@status where EmployeeID = @employeeId ";
                var parameters = new DynamicParameters();
                parameters.Add("@name", updateEmployeeDto.Name);
                parameters.Add("@title", updateEmployeeDto.Title);
                parameters.Add("@mail", updateEmployeeDto.Mail);
                parameters.Add("@phoneNumber", updateEmployeeDto.PhoneNumber);
                parameters.Add("@imageUrl", updateEmployeeDto.ImageUrl);
                parameters.Add("@status", updateEmployeeDto.Status);
                parameters.Add("@employeeId", updateEmployeeDto.EmployeeID);
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
    }
}