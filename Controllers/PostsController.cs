using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NETBlog_Thingy.Models;
using NETBlog_Thingy.Repositories;

namespace NETBlog_Thingy.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostsController : ControllerBase
  {

    private readonly PostRepository _Repo;

    public PostsController(PostRepository Repo)
    {
      _Repo = Repo;
    }
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Post>> Get()
    {
      try
      {
        return Ok(_Repo.GetAll());
      }
      catch (Exception e)
      {

        return BadRequest(e);
      }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Post> Get(int id)
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
    public ActionResult<Post> Post([FromBody] Post data)
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
    public ActionResult<Post> Put(int id, [FromBody] Post data)
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
