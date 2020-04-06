using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public static class myConnection
    {
        //Scaffold-DbContext "Data Source=DESKTOP\\SQLEXPRESS;Initial Catalog=Flights;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer
        public static string connectionString = "Data Source=DESKTOP\\SQLEXPRESS;Initial Catalog=Flights;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
