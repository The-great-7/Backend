namespace LSS.Api.Controllers
{
    using DataModels;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using System;

    [Route("api/courses")]
    public class CoursesController : Controller
    {
        private ICourseService service;

        public CoursesController(ICourseService service)
        {
            this.service = service;
        }

        // GET: api/Courses
        //TODO: This is testing setup. Remove it when the services are ready.
        [HttpGet]
        public IActionResult Get()
        {
            var courses = this.service.GetCourses();
            return this.Ok(courses);
        }

        // GET: api/Courses/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var course = service.CourseById(id);
                return this.Ok(course);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
        
        // POST: api/Courses
        [HttpPost]
        public IActionResult Post([FromBody]CourseDto model)
        {
            try
            {
                var value = model.Name;
                var course = this.service.AddCourse(value);

                return this.Ok(course);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
        
        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CourseDto model)
        {
            try
            {
                var course = new CourseDto { Name = model.Name };
                var courses = this.service.ReplaceCourse(id, course);

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
            this.service.DeleteCourses();
            return this.Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var courses = this.service.DeleteCourse(id);
                return this.Ok(courses);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
    }
}