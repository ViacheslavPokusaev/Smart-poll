using Dapper;
using Microsoft.Data.SqlClient;
using ServerCore.Models.Classes;
using ServerCore.Models.Inrerfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ServerCore.Models.RealizationInrerface
{
    class VotingFunctional : IVotingFunctional
    {
        string connectionString = null;

        public VotingFunctional(string con)
        {
            this.connectionString = con;
        }
        public List<Voting> GetVotings()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Voting>("SELECT * FROM Voting").ToList();
            }
        }
        public Voting Get(int IdVoting)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Voting>("SELECT * FROM Voting WHERE VotingID = @VotingID", new { IdVoting }).FirstOrDefault();
            }
        }
        public void Create(Voting voting)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Voting (Name, Age) VALUES(@Name, @Age)";
                db.Execute(sqlQuery, voting);

                // если мы хотим получить id добавленного пользователя
                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
            }
        }
    }
}
