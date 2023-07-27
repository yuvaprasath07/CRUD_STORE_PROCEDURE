using EntityDb;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using System.Transactions;

namespace DataLayerClass
{
    public class DataLayer : IDataLayer
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;


        public DataLayer(EmployeeDbContext employeeDbContext, IConfiguration configuration)
        {
            _employeeDbContext = employeeDbContext;
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("Students");
        }

        public object getEmploye()
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();  
                using (SqlCommand command = new SqlCommand("sp_GetEmployeDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<EmployeeModel> data = new List<EmployeeModel>();
                        while (reader.Read())
                        {
                            EmployeeModel employee = new EmployeeModel()
                            {
                                EmployeID = reader.GetInt32("EmployeID"),
                                EmployeName = reader.GetString("EmployeName"),
                                EmployeAge = reader.GetInt32("EmployeAge"),
                                EmployeSalery = reader.GetInt32("EmployeSalery")
                            };
                            data.Add(employee);
                        }
                        return data;
                    }
                }
            }
        }


        public object addEmployee(PostEmployee postDatas)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_InsertEmployeDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", postDatas.EmployeName);
                    command.Parameters.AddWithValue("@Age", postDatas.EmployeAge);
                    command.Parameters.AddWithValue("@Salary", postDatas.EmployeSalery);
                    command.ExecuteNonQuery();
                    return "Data Successfully Inserted";

                }
            }
        }

        public object UpdateEmployee(EmployeeModel updateemployee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdateEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", updateemployee.EmployeID);
                    command.Parameters.AddWithValue("@Name", updateemployee.EmployeName);
                    command.Parameters.AddWithValue("@Age", updateemployee.EmployeAge);
                    command.Parameters.AddWithValue("@Salary", updateemployee.EmployeSalery);
                    command.ExecuteNonQueryAsync();
                    return "Data Successfully Update ";
                }
            }
        }
        public object DeleteEmploye(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_DeleteEmploye", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeIDToDelete", id);
                    command.ExecuteNonQueryAsync();
                    return "Deleted Successfully";
                }
            }
        }
        public List<EmployeeModel> getAll()
        {
            var data = _employeeDbContext.EmployeDetails.ToList();
            return data;
        }

 
    }
}