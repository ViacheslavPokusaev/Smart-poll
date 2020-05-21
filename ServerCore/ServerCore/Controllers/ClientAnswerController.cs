using Microsoft.AspNetCore.Mvc;
using ServerCore.Models;
using ServerCore.Services;

namespace ServerCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientAnswerController : ControllerBase
    {
        IClientAnswer clientAnswerService;
        public ClientAnswerController(IClientAnswer clientAnswerService)
        {
            this.clientAnswerService = clientAnswerService;
        }

        // GET <controller>/countanswer/5
        [HttpGet("countanswer/{optionid}")]
        public int CountVotesByOneOption(int OptionId)
        {
            return clientAnswerService.CountClientsAnswers(OptionId);
        }

        // POST <controller>/answerid
        [HttpPost("answerid")]
        public int GetAnswerId(int OptionId, int ClientId)
        {
            return clientAnswerService.GetId(OptionId, ClientId);
        }

        // POST <controller>
        [HttpPost]
        public void Post(ClientAnswer clientAnswer)
        {
            if (clientAnswer == null) { BadRequest(); return; }

            clientAnswerService.Create(clientAnswer);
        }
    }
}