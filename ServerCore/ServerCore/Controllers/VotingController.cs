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

        // GET <controller>/id
        [HttpGet("{id}")]
        public Voting Get(int id)
        {
            return votingFunctional.Get(id);
        }

        //GET<controller>/id
        [HttpGet("user/{id}")]
        public IEnumerable<List<Voting>> GetUserVotings(int id)
        {
            yield return votingFunctional.GetUserVotings(id);
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
