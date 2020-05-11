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
        public List<Voting> GetAllVotings()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                List<Voting> VotingsWithOptions = new List<Voting>();
                var AllVotings = db.Query<Voting>("SELECT * FROM Voting").ToArray();
                //var AllOptions = db.Query<Voting>("SELECT * FROM Voting").ToList();
                for (int i = 0; i < AllVotings.Length; i++)
                {
                    AllVotings[i].Options = db.Query<Option>("SELECT * FROM Options WHERE VotingID = @VotingID", new { AllVotings[i].VotingID }).ToArray();
                    VotingsWithOptions.Add(AllVotings[i]);
                }
                return VotingsWithOptions;
            }
        }
        public List<Voting> GetUserVotings(int UserID)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Voting>("SELECT * FROM Voting WHERE UserID = @UserID", new { UserID }).ToList();
            }
        }       
        public Voting Get(int VotingID)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Voting>("SELECT * FROM Voting WHERE VotingID = @VotingID", new { VotingID }).FirstOrDefault();
            }
        }
        public void Create(Voting voting)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Voting (UserID, AddNewOptions, MaxOptions, MaxVotesByOneUser, " +
                    "DeadLine, QuestionInVoting, PublicOrPrivate) VALUES(" +
                    "@UserID, @AddNewOptions, @MaxOptions, @MaxVotesByOneUser, " +
                    "@DeadLine, @QuestionInVoting, @PublicOrPrivate)";
                db.Execute(sqlQuery, voting);

                // если мы хотим получить id добавленного пользователя
                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
            }
        }
        public void DeleteVoting(int VotingID)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Voting WHERE @VotingID = VotingID";
                db.Execute(sqlQuery, VotingID);
            }
        }
    }
}
