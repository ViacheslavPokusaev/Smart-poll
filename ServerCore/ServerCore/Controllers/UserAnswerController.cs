using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServerCore.Models.Classes;
using ServerCore.Models.Inrerfaces;

namespace ServerCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAnswerController : ControllerBase
    {
        IUserAnswerFunctional UserAnswerFunctional;
        public UserAnswerController(IUserAnswerFunctional UserAnswerFunctional)
        {
            this.UserAnswerFunctional = UserAnswerFunctional;
        }

        //GET: <controller>
        [HttpGet]
        public IEnumerable<List<UserAnswer>> Get()
        {
            yield return UserAnswerFunctional.GetUsersAnswers();
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