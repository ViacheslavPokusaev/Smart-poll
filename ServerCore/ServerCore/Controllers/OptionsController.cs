using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServerCore.Models.Classes;
using ServerCore.Models.Inrerfaces;

namespace ServerCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OptionsController : ControllerBase
    {
        IOptionsFunctional optionsFunctional;
        public OptionsController(IOptionsFunctional optionsFunctional)
        {
            this.optionsFunctional = optionsFunctional;
        }

        //GET: <controller>
        [HttpGet]
        public IEnumerable<List<Option>> Get()
        {
            yield return optionsFunctional.GetOptions();
        }

        // GET <controller>/5
        [HttpGet("{id}")]
        public IEnumerable<List<Option>> GetOptionsByOneVoting(int VotingID)
        {
            yield return optionsFunctional.GetOptionsByOneVoting(VotingID);
        }

        // POST <controller>
        [HttpPost]
        public void Post(Option option)
        {
            if (option == null) { BadRequest(); return; }

            optionsFunctional.Create(option);
        }
    }
}