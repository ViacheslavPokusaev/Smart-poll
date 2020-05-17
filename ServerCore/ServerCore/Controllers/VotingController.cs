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

        // GET: <controller>/smt
        [HttpGet("smt")]
        public int GetSmt()
        {
            return 1;
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

        // GET <controller>/id
        //[HttpGet("{id}")]
        //public Voting Get(int id)
        //{
        //    return votingFunctional.Get(id);
        //}

        // POST <controller>
        [HttpPost]
        public void Post(Voting voting)
        {
            if (voting == null) {BadRequest(); return; }

            votingFunctional.Create(voting);
        }

        // PUT <controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE <controller>/5
        [HttpDelete("{id}")]
        public void Delete(int VotingID) => votingFunctional.DeleteVoting(VotingID);
    }
}
