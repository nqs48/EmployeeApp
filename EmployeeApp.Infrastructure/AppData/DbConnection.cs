using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Infrastructure.AppData
{
    public class DbConnection
    {
        private string connectionString;

        public string ConnectionString { get => connectionString; }

        public DbConnection(string Connection)
        {
            connectionString= Connection;
        }
    }
}
