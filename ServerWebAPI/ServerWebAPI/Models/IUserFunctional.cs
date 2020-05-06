using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ServerWebAPI.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
    }
    interface IUserFunctional
    {
        void Create(User user);
        User Get(int IdUser);
        List<User> GetUsers();
    }

    class UserFunctional : IUserFunctional
    {
        string connectionString = null;

        public UserFunctional(string con)
        {
            this.connectionString = con;
        }

        public List<User> GetUsers()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT * FROM Users").ToList();
            }
        }

        public User Get(int IdUser)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT * FROM Users WHERE UserID = @UserID", new { IdUser }).FirstOrDefault();
            }
        }

        public void Create(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age)";
                db.Execute(sqlQuery, user);

                // если мы хотим получить id добавленного пользователя
                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
            }
        }
    }
}
