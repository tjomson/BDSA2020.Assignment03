using BDSA2020.Assignment03.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

namespace BDSA2020.Assignment03
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddUserSecrets(typeof(Program).Assembly).Build();
            var connectionString = configuration.GetConnectionString("ConnectionString");
            //Server=(localdb)\MSSQLLocalDB;Database=Kanban;Trusted_Connection=True

            using var connection = new SqlConnection(connectionString);

            //var optionsBuilder = new DbContextOptionsBuilder<KanbanContext>();
            //optionsBuilder.UseSqlite("Data Source=kanban.db");

            /*using (var db = new KanbanContext())
            {
                db.SaveChanges();
            }*/
        }
    }
}
