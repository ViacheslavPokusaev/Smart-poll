using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServerCore.Models.Classes;
using ServerCore.Models.Inrerfaces;

namespace ServerCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VotingController : ControllerBase
    {

        private IVotingFunctional votingFunctional;
        public VotingController(IVotingFunctional votingFunctional)
        {
            this.votingFunctional = votingFunctional;
        }

        // GET: <controller>
        [HttpGet]
        public IEnumerable<List<Voting>> Get()
        {
            yield return votingFunctional.GetAllVotings();
        }

        //GET<controller>/common/public
        [HttpGet("common/public")]
        public IEnumerable<List<Voting>> GetCommonVotings()
        {
            yield return votingFunctional.GetVotings(0);
        }

        //GET<controller>/common/deadline
        [HttpGet("common/deadline")]
        public IEnumerable<List<Voting>> GetDeadlineVotings()
        {
            yield return votingFunctional.GetVotings(2);
        }

        //GET<controller>/private/UserID
        [HttpGet("privatevotings/{userid}")]
        public IEnumerable<List<Voting>> GetPrivateVotings(int UserID)
        {
            yield return votingFunctional.GetVotings(1, UserID);
        }

        //GET<controller>/uservotings/UserID
        [HttpGet("uservotings/{userid}")]
        public IEnumerable<List<Voting>> GetUserVotings(int UserID)
        {
            yield return votingFunctional.GetVotings(3, UserID);
        }

        // POST <controller>
        [HttpPost]
        public void Post(Voting voting)
        {
            if (voting == null) { BadRequest(); return; }

            votingFunctional.Create(voting);
            Ok();
        }

        // POST <controller>/delete
        [HttpPost("delete")]
        public void Delete(Voting voting)
        { 
            votingFunctional.DeleteVoting(voting.VotingID);
            Ok();
        }

        // POST <controller>/update
        [HttpPost("update")]
        public void Update(Voting voting)
        {
            votingFunctional.Update(voting);
            Ok();
        }
    }
}
