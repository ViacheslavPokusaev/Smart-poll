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

        public void Create(ClientAnswer clientAnswer)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO ClientAnswer (OptionId, ClientId) VALUES(@OptionId, @ClientId)";
                db.Execute(sqlQuery, clientAnswer);
            }
        }
    }
}
