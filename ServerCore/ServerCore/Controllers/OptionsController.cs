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
        public string Get(int id)
        {
            return "value";
        }

        // POST <controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT <controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE <controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}