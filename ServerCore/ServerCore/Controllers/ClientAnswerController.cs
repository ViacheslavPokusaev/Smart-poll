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

        // POST <controller>
        [HttpPost]
        public void Post(ClientAnswer clientAnswer)
        {
            if (clientAnswer == null) { BadRequest(); return; }

            clientAnswerService.Create(clientAnswer);
        }
    }
}