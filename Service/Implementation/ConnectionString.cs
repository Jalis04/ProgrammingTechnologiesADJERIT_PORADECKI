using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    internal static class ConnectionString
    {
        public static string GetConnectionString()
        {
            string _projectRootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string _DBRelativePath = @"DataLayer\Instrumentation\CoffeeShopDB.mdf";
            string _DBPath = Path.Combine(_projectRootDir, _DBRelativePath);
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";
            return connectionString;
        }
    }
}
