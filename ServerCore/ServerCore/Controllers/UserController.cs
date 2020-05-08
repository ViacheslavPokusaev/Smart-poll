using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServerCore.Models.Classes;
using ServerCore.Models.Inrerfaces;

namespace ServerCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IUserFunctional UserFunctional;
        public UserController(IUserFunctional UserFunctional)
        {
            this.UserFunctional = UserFunctional;
        }

        //GET: <controller>
        [HttpGet]
        public IEnumerable<List<User>> Get()
        {
            yield return UserFunctional.GetUsers();
        }

        // GET <controller>/5
        [HttpGet("{id}")]
        public User Get(int UserID)
        {
            return UserFunctional.Get(UserID);
        }

        // POST <controller>
        [HttpPost]
        public void Post(User user)
        {
            if (user == null) BadRequest();

            UserFunctional.Create(user);
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