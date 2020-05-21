using Dapper;
using Microsoft.Data.SqlClient;
using ServerCore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCore.Services
{
    public class PollRealization : IPoll
    {
        string connectionString = null;

        public PollRealization(string con)
        {
            this.connectionString = con;
        }
        public void Create(Poll poll)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Poll (ClientId, IsPossibleToAddOption, MaxOptionsInPoll, MaxVotesByOneClient, " +
                    "DeadLine, QuestionText, IsPrivate) VALUES(" +
                    "@ClientId, @IsPossibleToAddOption, @MaxOptionsInPoll, @MaxVotesByOneClient, " +
                    "@DeadLine, @QuestionText, @IsPrivate)";
                db.Execute(sqlQuery, poll);
            }
        }

        public void Update(Poll poll)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Poll SET IsPossibleToAddOption = @IsPossibleToAddOption, " +
                    "MaxOptionsInPoll = @MaxOptionsInPoll, " +
                    "MaxVotesByOneClient = @MaxVotesByOneClient, " +
                    "QuestionText = @QuestionText, " +
                    "DeadLine = @DeadLine, " +
                    "IsPrivate = @IsPrivate" +
                    " WHERE Id = @Id";
                db.Execute(sqlQuery, poll);
            }
        }

        public void DeletePoll(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Poll WHERE @Id = Id";
                db.Execute(sqlQuery, new { Id });
            }
        }

        /*Pull list*/
        // 0 - public
        // 1 - private
        // 2 - dead
        // 3 - client publish list pull (public + dead)
        // 4 - client take part (public + dead)
        public List<Poll> GetListPoll(int TypePoll, int ClientId = -1)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                List<Poll> ListPollWithOptionsAndAnswers = new List<Poll>();
                Poll[] ListPoll = default;
                DateTime Today = DateTime.Today;
                int Public = 0; int Private = 1;
                //string Today = DateTime.Today.ToString();
                //Today = Today.Substring(0, 10).Trim();

                switch (TypePoll)
                {
                    case 0:
                        {
                            ListPoll = db.Query<Poll>(
                                "SELECT * FROM Poll WHERE Id NOT IN " +
                                "(SELECT OptionPoll.PollId From ClientAnswer " +
                                "INNER JOIN OptionPoll ON ClientAnswer.OptionId = OptionPoll.Id " +
                                "WHERE ClientAnswer.ClientId = @ClientId " +
                                "GROUP BY OptionPoll.PollId) " +
                                "AND IsPrivate = @Public AND DeadLine > @Today",
                                new { ClientId, Public, Today }).ToArray();

                            break;
                        }
                    case 1:
                        {
                            ListPoll = db.Query<Poll>("SELECT * FROM Poll WHERE ClientId = @ClientId AND IsPrivate = @Private", new { ClientId, Private }).ToArray();
                            break;
                        }
                    case 2:
                        {
                            ListPoll = db.Query<Poll>("SELECT * FROM Poll WHERE IsPrivate = @Public AND DeadLine < @Today", new { Public, Today }).ToArray();
                            break;
                        }
                    case 3:
                        {
                            ListPoll = db.Query<Poll>("SELECT * FROM Poll WHERE ClientId = @ClientId AND IsPrivate = @Public", new { Public, ClientId }).ToArray();
                            break;
                        }
                    default:
                        {
                            ListPoll = db.Query<Poll>(
                                "SELECT * FROM Poll WHERE Id IN " +
                                "(SELECT OptionPoll.PollId From ClientAnswer " +
                                "INNER JOIN OptionPoll ON ClientAnswer.OptionId = OptionPoll.Id " +
                                "WHERE ClientAnswer.ClientId = @ClientId " +
                                "GROUP BY OptionPoll.PollId) " +
                                "AND IsPrivate = @Public",
                                new { ClientId, Public }).ToArray();
                            break;
                        }
                }

                

                for (int i = 0; i < ListPoll.Length; i++)
                {
                    ListPoll[i].OptionsPoll = db.Query<OptionPoll>("SELECT * FROM OptionPoll WHERE PollId = @Id", new { ListPoll[i].Id }).ToArray();

                    if (TypePoll != 1)
                    {
                        ListPoll[i].ClientsAnswers = new List<ClientAnswer[]>();
                        foreach (OptionPoll option in ListPoll[i].OptionsPoll)
                        {
                            int OptionId = option.Id;
                            ListPoll[i].ClientsAnswers.Add(db.Query<ClientAnswer>("SELECT * FROM ClientAnswer WHERE OptionId = @OptionId", new { OptionId }).ToArray());
                        }
                    }

                    ListPoll[i].NameAuthorPoll = db.Query<string>("SELECT FirstName FROM Client WHERE Id = @ClientId", new { ListPoll[i].ClientId }).FirstOrDefault();
                    ListPollWithOptionsAndAnswers.Add(ListPoll[i]);
                }
                return ListPollWithOptionsAndAnswers;
            }
        }

        public void AddOptions(OptionPoll[] options)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                for (int i = 0; i < options.Length; i++)
                {
                    var sqlQuery = "INSERT INTO OptionPoll (PollId, TextOption) VALUES(" +
                    "@PollId, @TextOption)";
                    db.Execute(sqlQuery, new {options[i].PollId, options[i].TextOption });
                }             
            }
        }
    }
}
