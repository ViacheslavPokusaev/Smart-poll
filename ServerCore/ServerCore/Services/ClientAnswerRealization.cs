using Dapper;
using Microsoft.Data.SqlClient;
using ServerCore.Models;
using System.Data;
using System.Linq;

namespace ServerCore.Services
{
    public class ClientAnswerRealization : IClientAnswer
    {
        string connectionString = null;

        public ClientAnswerRealization(string con)
        {
            this.connectionString = con;
        }
        public int CountClientsAnswers(int OptionId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<int>("SELECT OptionId FROM ClientAnswer WHERE OptionId = @OptionId", new { OptionId }).ToList().Count;
            }
        }

        public void Create(ClientAnswer clientAnswer)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO ClientAnswer (OptionId, ClientId) VALUES(@OptionId, @ClientId)";
                db.Execute(sqlQuery, clientAnswer);
            }
        }

        public int GetId(int OptionId, int ClientId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<int>("SELECT Id FROM ClientAnswer WHERE OptionId = @OptionId AND ClientId = @ClientId", new { OptionId, ClientId }).FirstOrDefault();
            }
        }
    }
}
