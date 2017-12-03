namespace LearningSupportSystemAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using LearningSupportSystemData.Models;

    [Produces("application/json")]
    [Route("api/Courses")]
    public class CoursesController : Controller
    {
        // GET: api/Courses
        //TODO: This is testing setup. Remove it when the services are ready.
        [HttpGet]
        public IActionResult Get()
        {
            var result = new List<Course>{
                new Course( 1, "Programming Basics"),
                new Course( 2, "DB Fundamentals"),
                new Course( 3, "C# MVC"),
            };
            return Ok(result);
        }

        // GET: api/Courses/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var result = new Course(id, "C# Advanced part " + id);
           
            return Ok(result);
        }
        
        // POST: api/Courses
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
