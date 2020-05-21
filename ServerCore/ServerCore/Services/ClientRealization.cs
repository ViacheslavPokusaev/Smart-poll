using Dapper;
using Microsoft.Data.SqlClient;
using ServerCore.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ServerCore.Services
{
    public class ClientRealization : IClient
    {
        string connectionString = null;

        public ClientRealization(string con)
        {
            this.connectionString = con;
        }

        public int Create(Client client)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                //var sqlQuery = "INSERT INTO Users (Email, UserPassword, UserName, Age) VALUES(@Email, @UserPassword, @UserName, @Age)";
                //db.Execute(sqlQuery, user);

                // если мы хотим получить id добавленного пользователя
                var sqlQuery = "INSERT INTO Client (Email, Passw, FirstName, Age) VALUES(@Email, @Passw, @FirstName, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? clientId = db.Query<int>(sqlQuery, client).FirstOrDefault();
                return clientId.Value;
            }
        }

        public List<Client> GetClients()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Client>("SELECT * FROM Client").ToList();
            }
        }

        public int GetId(Client client)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<int>("SELECT Id FROM Client WHERE Email = @Email AND Passw = @Passw", new { client.Email, client.Passw }).FirstOrDefault();
            }
        }
    }
}
