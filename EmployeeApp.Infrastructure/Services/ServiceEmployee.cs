using Dapper;
using EmployeeApp.Domain;
using EmployeeApp.Infrastructure.AppData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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


        public void AddEmployee(Employee employee)
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

                sqlConnection.ExecuteScalar("EmployeeAdd", param, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception("Unespected Error" + ex.Message);
            }
            finally 
            { 
                //Cerrer conection
                sqlConnection.Close();

                //Liberar recursos
                sqlConnection.Dispose();


            }
        }

        public Employee GetEmployee(string employeeCode)
        {
            SqlConnection sqlConnection = Conection();
            Employee employee = null;
            try
            {
                sqlConnection.Open();
                var param = new DynamicParameters();
                param.Add("@EmployeeCode", employeeCode, DbType.String, ParameterDirection.Input, 4);
              
                employee=  sqlConnection.QueryFirstOrDefault<Employee>("EmployeeGet", param, commandType: CommandType.StoredProcedure);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Unspected Error" + ex.Message);
            }
            finally
            {
                //Close conection
                sqlConnection.Close();
                //Realease resources
                sqlConnection.Dispose();
            }
            return employee;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            SqlConnection sqlConnection = Conection();
            List<Employee> employees = new List<Employee>();
            try
            {
                sqlConnection.Open();
               
                var res = sqlConnection.Query<Employee>("EmployeeGet", commandType: CommandType.StoredProcedure);
                employees= res.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Unspected Error" + ex.Message);
            }
            finally
            {
                //Close conection
                sqlConnection.Close();
                //Liberar recursos
                sqlConnection.Dispose();


            }
            return employees;
        }

        public void UpdateEmployee(Employee employee)
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

                sqlConnection.ExecuteScalar("EmployeeUpdate", param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Unespected Error" + ex.Message);
            }
            finally
            {
                //Cerrer conection
                sqlConnection.Close();
                //Liberar recursos
                sqlConnection.Dispose();
            }
        }

        public Employee DeleteEmployee(string EmployeeCode)
        {
            throw new NotImplementedException();
        }
    }
}
