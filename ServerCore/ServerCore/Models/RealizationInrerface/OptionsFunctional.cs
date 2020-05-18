using Dapper;
using Microsoft.Data.SqlClient;
using ServerCore.Models.Classes;
using ServerCore.Models.Inrerfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ServerCore.Models.RealizationInrerface
{
    class OptionsFunctional : IOptionsFunctional
    {
        string connectionString = null;

        public OptionsFunctional(string con)
        {
            this.connectionString = con;
        }
        public List<Option> GetOptions()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Option>("SELECT * FROM Options").ToList();
            }
        }
        public List<Option> GetOptionsByOneVoting(int VotingID)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Option>("SELECT * FROM Options WHERE VotingID = @VotingID", new { VotingID }).ToList();
            }
        }
        public Option Get(int IdOption)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Option>("SELECT * FROM Options WHERE OptionID = @OptionID", new { IdOption }).FirstOrDefault();
            }
        }
        public void Create(Option option)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Options (VotingID, NameOption) VALUES(@VotingID, @NameOption)";
                db.Execute(sqlQuery, option);

                // если мы хотим получить id добавленного пользователя
                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
            }
        }
    }
}
