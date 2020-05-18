using Dapper;
using Microsoft.Data.SqlClient;
using ServerCore.Models.Classes;
using ServerCore.Models.Inrerfaces;
using System;
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

                for (int i = 0; i < AllVotings.Length; i++)
                {
                    AllVotings[i].Options = db.Query<Option>("SELECT * FROM Options WHERE VotingID = @VotingID", new { AllVotings[i].VotingID }).ToArray();
                    AllVotings[i].UserName = db.Query<string>("SELECT UserName FROM Users WHERE UserID = @UserID", new { AllVotings[i].UserID }).FirstOrDefault();
                    VotingsWithOptions.Add(AllVotings[i]);
                }
                return VotingsWithOptions;
            }
        }

        /*Votings list*/
        // 0 - public
        // 1 - private
        // 2 - dead
        // any - userVotings
        public List<Voting> GetVotings(int TypeVoting, int UserID = -1)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                List<Voting> VotingsWithOptions = new List<Voting>();
                Voting[] Votings = default;
                DateTime DateToday = DateTime.Today;

                switch (TypeVoting)
                {
                    case 0:
                        {
                            Votings = db.Query<Voting>("SELECT * FROM Voting WHERE PublicOrPrivate = @TypeVoting AND DeadLine > @DateToday", new { TypeVoting, DateToday }).ToArray();
                            break;
                        }
                    case 1:
                        {
                            Votings = db.Query<Voting>("SELECT * FROM Voting WHERE UserID = @UserID AND PublicOrPrivate = @TypeVoting", new { UserID, TypeVoting }).ToArray();
                            break;
                        }
                    case 2:
                        {
                            int Public = 0;
                            Votings = db.Query<Voting>("SELECT * FROM Voting WHERE PublicOrPrivate = @Public AND DeadLine < @DateToday", new { Public, DateToday }).ToArray();
                            break;
                        }
                    default:
                        {
                            Votings = db.Query<Voting>("SELECT * FROM Voting WHERE UserID = @UserID", new { UserID }).ToArray();
                            break;
                        }
                }

                for (int i = 0; i < Votings.Length; i++)
                {
                    Votings[i].Options = db.Query<Option>("SELECT * FROM Options WHERE VotingID = @VotingID", new { Votings[i].VotingID }).ToArray();
                    Votings[i].UserName = db.Query<string>("SELECT UserName FROM Users WHERE UserID = @UserID", new { Votings[i].UserID }).FirstOrDefault();
                    VotingsWithOptions.Add(Votings[i]);
                }
                return VotingsWithOptions;
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
        public void Update(Voting voting)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Voting SET AddNewOptions = @AddNewOptions, " +
                    "MaxOptions = @MaxOptions, " +
                    "MaxVotesByOneUser = @MaxVotesByOneUser, " +
                    "QuestionInVoting = @QuestionInVoting, " +
                    "DeadLine = @DeadLine, " +
                    "PublicOrPrivate = @PublicOrPrivate" +
                    " WHERE VotingID = @VotingID";
                db.Execute(sqlQuery, voting);
            }
        }
        public void DeleteVoting(int VotingID)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Voting WHERE @VotingID = VotingID";
                db.Execute(sqlQuery, new { VotingID });
            }
        }
    }
}
