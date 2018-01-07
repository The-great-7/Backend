namespace LSS.Api.Controllers
{
    using DataModels;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using System;

    [Route("api/courses")]
    public class StudentsController : Controller
    {
        private IStudentService service;

        public StudentsController(IStudentService service)
        {
            this.service = service;
        }

        // GET: api/students
        [HttpGet]
        public IActionResult Get()
        {
            var students = this.service.GetStudents();
            return this.Ok(students);
        }

        // GET: api/Students/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var student = service.StudentById(id);

                return this.Ok(student);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        // POST: api/Students
        [HttpPost]
        public IActionResult Post([FromBody]StudentDto model)
        {
            try
            {
                var student = this.service.AddStudent(model);

                return this.Ok(student);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]StudentDto model)
        {
            try
            {
                var student = new StudentDto
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Grade = model.Grade
                };

                var students = this.service.ReplaceStudent(id, student);

                return this.Ok(students);
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
            this.service.DeleteStudents();

            return this.Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var students = this.service.DeleteStudent(id);

                return this.Ok(students);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
    }
}