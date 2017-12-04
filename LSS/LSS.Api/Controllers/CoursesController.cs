namespace LSS.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("api/courses")]
    public class CoursesController : Controller
    {
        // GET: api/Courses
        //TODO: This is testing setup. Remove it when the services are ready.
        [HttpGet]
        public IActionResult Get()
        {
            // TODO - Services work :) 
            return null;
        }

        // GET: api/Courses/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return null;
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