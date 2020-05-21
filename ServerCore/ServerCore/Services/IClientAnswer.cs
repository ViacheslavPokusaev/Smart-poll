using ServerCore.Models;

namespace ServerCore.Services
{
    public interface IClientAnswer
    {
        void Create(ClientAnswer clientAnswer);
        int GetId(int OptionId, int ClientId);
        int CountClientsAnswers(int OptionId);
    }
}
