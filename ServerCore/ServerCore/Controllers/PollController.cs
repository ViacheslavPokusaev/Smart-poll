using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServerCore.Models;
using ServerCore.Services;

namespace ServerCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PollController : ControllerBase
    {

        private IPoll pollService;
        public PollController(IPoll pollService)
        {
            this.pollService = pollService;
        }

        //GET<controller>/common/public
        [HttpGet("common/public/{clientid}")]
        public List<Poll> GetCommonListPoll(int ClientId)
        {
            return pollService.GetListPoll(0, ClientId);
        }

        //GET<controller>/common/deadline
        [HttpGet("common/deadline")]
        public List<Poll> GetDeadlineListPoll()
        {
            return pollService.GetListPoll(2);
        }

        //GET<controller>/private/clientid
        [HttpGet("private/{clientid}")]
        public List<Poll> GetPrivateListPoll(int ClientId)
        {
            return pollService.GetListPoll(1, ClientId);
        }

        //GET<controller>/client/clientid
        [HttpGet("client/{clientid}")]
        public List<Poll> GetClientListPoll(int ClientId)
        {
            return pollService.GetListPoll(3, ClientId);
        }

        //GET<controller>/takepart/clientid
        [HttpGet("takepart/{clientid}")]
        public List<Poll> GetClienTakePartListPoll(int ClientId)
        {
            return pollService.GetListPoll(4, ClientId);
        }

        //GET<controller>/getidoption
        [HttpPost("getidoption")]
        public int GetIdOption(int PollId, string TextOption)
        {
            return pollService.GetIdOption(PollId, TextOption);
        }

        // POST <controller>
        [HttpPost]
        public Poll Post(Poll poll)
        {
            return pollService.Create(poll);
        }

        // POST <controller>/delete
        [HttpPost("delete/{id}")]
        public void Delete(int Id)
        {
            pollService.DeletePoll(Id);
            Ok();
        }

        // POST <controller>/delete
        [HttpPost("deleteall/{id}")]
        public void DeleteAll(int Id)
        {
            pollService.DeleteAllFromPoll(Id);
            Ok();
        }

        // POST <controller>/deleteoption
        [HttpPost("deleteoption/{id}")]
        public void DeleteOption(int Id)
        {
            pollService.DeleteOption(Id);
            Ok();
        }

        // POST <controller>/update
        [HttpPost("update")]
        public void Update(Poll poll)
        {
            pollService.Update(poll);
            Ok();
        }

        // POST <controller>/addOptions
        [HttpPost("addoptions")]
        public void AppOptions(OptionPoll[] options)
        {
            pollService.AddOptions(options);
            Ok();
        }

        // POST <controller>/addOption
        [HttpPost("addoption")]
        public OptionPoll AppOption(OptionPoll option)
        {
            return pollService.AddOption(option);
        }
    }
}
