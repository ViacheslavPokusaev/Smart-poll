namespace ServerCore.Models
{
    public class OptionPoll
    {
        public int Id { get; set; }
        public int PollId { get; set; }
        public string TextOption { get; set; }
        public int CountAnswer { get; set; }
    }
}
