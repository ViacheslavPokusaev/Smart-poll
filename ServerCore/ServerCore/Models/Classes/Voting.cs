using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCore.Models.Classes
{
    public class Voting
    {
        public int VotingID { get; set; }
        public int UserID { get; set; }
        public bool AddNewOptins { get; set; }
        public int MaxOptions { get; set; }
        public int MaxOptionsByOneUser { get; set; }
        public int QuestionsInVoting { get; set; }
        public DateTime DeadLine { get; set; }
        public bool PublicOrPrivate { get; set; }
    }
}
