using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Vue.NETBlog_Thingy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly UserRepository _Repo;

        public UsersController(UserRepository Repo)
        {
            _Repo = Repo;
        }
        // // GET api/values
        // [HttpGet]
        // public ActionResult<IEnumerable<User>> Get()
        // {
        // }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            try
            {
                return Ok(_Repo.GetById(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<User> Post([FromBody] User data)
        {
            try
            {
                return Ok(_Repo.Create(data));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] object data)
        {
            return Ok(_Repo.Update(data));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                _Repo.Delete(id);
                return "Account deleted!";
            }
            catch (Exception e)
            {

                return $"Error Message{e.Message}";
            }

        }
    }
}
