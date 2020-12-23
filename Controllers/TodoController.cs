using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly Model _todoDbContext;

        public TodoController(Model model)
        {
            _todoDbContext = model;
        }

        
        // GET: api/<TodoController>
        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return _todoDbContext.Todos.ToArray();
            //return new string[] { "value1", "value2" };
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TodoController>
        [HttpPost]
        public ActionResult<Todo> Post([FromBody]Todo todo)
        {
            try
            {
                _todoDbContext.Todos.AddRange(todo);
                _todoDbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return new ContentResult
                {
                    Content = $"error :- {ex.Message}",
                    ContentType = "application/json",
                    StatusCode = HttpStatusCode.InternalServerError.GetHashCode()
                };
            }
        }


        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
