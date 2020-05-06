using Dapper;
using Microsoft.Data.SqlClient;
using ServerCore.Models.Classes;
using ServerCore.Models.Inrerfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ServerCore.Models.RealizationInrerface
{
    class UserAnswerFunctional : IUserAnswerFunctional
    {
        string connectionString = null;

        public UserAnswerFunctional(string con)
        {
            this.connectionString = con;
        }
        public List<UserAnswer> GetUsersAnswers()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<UserAnswer>("SELECT * FROM UsersAnswers").ToList();
            }
        }
        public UserAnswer Get(int IDAnswer)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<UserAnswer>("SELECT * FROM UserAnswer WHERE IDAnswer = @IDAnswer", new { IDAnswer }).FirstOrDefault();
            }
        }
        public void Create(UserAnswer userAnswer)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Voting (Name, Age) VALUES(@Name, @Age)";
                db.Execute(sqlQuery, userAnswer);

                // если мы хотим получить id добавленного пользователя
                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
            }
        }
    }



}
