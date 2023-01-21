using Dapper;
using EmployeeApp.Domain;
using EmployeeApp.Infrastructure.AppData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeApp.Infrastructure.Services
{
    public class ServiceEmployee : IServiceEmployee
    {
        private string ConnString;

        public ServiceEmployee(DbConnection conection) {
            ConnString = conection.ConnectionString;
        }

        private SqlConnection Conection()
        {
            return new SqlConnection(ConnString);
        }


        public async Task AddEmployee(Employee employee)
        {
            SqlConnection sqlConnection = Conection();
            try
            {
                sqlConnection.Open();
                var param = new DynamicParameters();
                param.Add("@Name", employee.Name, DbType.String, ParameterDirection.Input, 100);
                param.Add("@EmployeeCode", employee.EmployeeCode, DbType.String, ParameterDirection.Input, 4);
                param.Add("@UrlPhoto", employee.UrlPhoto, DbType.String, ParameterDirection.Input);
                param.Add("@Email", employee.Email, DbType.String, ParameterDirection.Input, 100);
                param.Add("@Age", employee.Age, DbType.Int32, ParameterDirection.Input);
                param.Add("@HireDate", employee.HireDate, DbType.DateTime, ParameterDirection.Input);

                await sqlConnection.ExecuteScalarAsync("EmployeeAdd", param, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception("An error occurred while adding the employee" + ex.Message);
            }
            finally 
            { 
                //Close conection
                sqlConnection.Close();
                //Liberar recursos
                sqlConnection.Dispose();
            }
        }

        public async Task<Employee> GetEmployee(string employeeCode)
        {
            SqlConnection sqlConnection = Conection();
            Employee employee = null;
            try
            {
                sqlConnection.Open();
                var param = new DynamicParameters();
                param.Add("@EmployeeCode", employeeCode, DbType.String, ParameterDirection.Input, 4);
              
                employee=  await sqlConnection.QueryFirstOrDefaultAsync<Employee>("EmployeeGet", param, commandType: CommandType.StoredProcedure);
                
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while get the employee" + ex.Message);
            }
            finally
            {
                //Close connection
                sqlConnection.Close();
                //Realease resources
                sqlConnection.Dispose();
            }
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            SqlConnection sqlConnection = Conection();
            List<Employee> employees = new List<Employee>();
            try
            {
                sqlConnection.Open();
               
                var res = await sqlConnection.QueryAsync<Employee>("EmployeeGet", commandType: CommandType.StoredProcedure);
                employees= res.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting the employees" + ex.Message);
            }
            finally
            {
                //Close connection
                sqlConnection.Close();
                //Liberar recursos
                sqlConnection.Dispose();


            }
            return employees;
        }

        public async Task UpdateEmployee(Employee employee)
        {
            SqlConnection sqlConnection = Conection();
            try
            {
                sqlConnection.Open();
                var param = new DynamicParameters();
                param.Add("@Name", employee.Name, DbType.String, ParameterDirection.Input, 100);
                param.Add("@EmployeeCode", employee.EmployeeCode, DbType.String, ParameterDirection.Input, 4);
                param.Add("@UrlPhoto", employee.UrlPhoto, DbType.String, ParameterDirection.Input);
                param.Add("@Email", employee.Email, DbType.String, ParameterDirection.Input, 100);
                param.Add("@Age", employee.Age, DbType.Int32, ParameterDirection.Input);

                await sqlConnection.ExecuteScalarAsync("EmployeeUpdate", param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the employee" + ex.Message);
            }
            finally
            {
                //Close connection
                sqlConnection.Close();
                //Liberar recursos
                sqlConnection.Dispose();
            }
        }

        public async Task DeleteEmployee(string employeeCode)
        {
            SqlConnection sqlConnection = Conection();
            try
            {
                sqlConnection.Open();
                var param = new DynamicParameters();
                param.Add("@EmployeeCode", employeeCode, DbType.String, ParameterDirection.Input, 4);

                await sqlConnection.ExecuteScalarAsync("EmployeeDelete", param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the employee" + ex.Message);
            }
            finally
            {
                //Close connection
                sqlConnection.Close();
                //Liberar recursos
                sqlConnection.Dispose();
            }
        }
    }
}
