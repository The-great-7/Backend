namespace LSS.Api.Controllers
{
    using DataModels;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using System;

    [Route("api/courses")]
    public class CoursesController : Controller
    {
        private ICourseService courses;

        public CoursesController(ICourseService courses)
        {
            this.courses = courses;
        }

        // GET: api/courses
        //TODO: This is testing setup. Remove it when the services are ready.
        [HttpGet]
        public IActionResult Get()
        {
            var courses = this.courses.All();

            return this.Ok(courses);
        }

        // GET: api/courses/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var course = courses.ById(id);

                return this.Ok(course);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
        
        // POST: api/courses
        [HttpPost]
        public IActionResult Post([FromBody]CourseDto model)
        {
            try
            {
                var value = model.Name;

                var course = this.courses.Add(value);

                return this.Ok(course);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
        
        // PUT: api/courses/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CourseDto model)
        {
            try
            {
                var course = new CourseDto { Name = model.Name };

                var courses = this.courses.Replace(id, course);

                return this.Ok(courses);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/
        [HttpDelete]
        public IActionResult Delete()
        {
            this.courses.DeleteAll();

            return this.Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var courses = this.courses.Delete(id);

                return this.Ok(courses);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
    }
}