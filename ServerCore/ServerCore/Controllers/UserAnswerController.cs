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

        // GET <controller>/useranswer/5
        [HttpGet("useranswer/{id}")]
        public UserAnswer Get(int IDAnswer)
        {
            return UserAnswerFunctional.Get(IDAnswer);
        }

        // GET <controller>/count/5
        [HttpGet("count/{id}")]
        public int GetCountUsersAnswers(int OptionID)
        {
            return UserAnswerFunctional.GetCountUsersAnswers(OptionID);
        }

        // POST <controller>
        [HttpPost]
        public void Post(UserAnswer userAnswer)
        {
            if (userAnswer == null) { BadRequest(); return; }

            UserAnswerFunctional.Create(userAnswer);
        }

        // PUT <controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE <controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}