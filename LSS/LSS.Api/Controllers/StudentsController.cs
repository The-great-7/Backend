namespace LSS.Api.Controllers
{
    using DataModels;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using System;

    [Route("api/students")]
    public class StudentsController : Controller
    {
        private IStudentService students;

        public StudentsController(IStudentService students)
        {
            this.students = students;
        }

        // GET: api/students
        [HttpGet]
        public IActionResult Get()
        {
            var students = this.students.All();
            return this.Ok(students);
        }

        // GET: api/students/5
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                var student = students.ById(id);
                return this.Ok(student);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        // POST: api/students
        [HttpPost]
        public IActionResult Post([FromBody]StudentDto model)
        {
            try
            {
                var student = this.students.Add(model);
                return this.Ok(student);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        // PUT: api/students/5
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

                var students = this.students.Replace(id, student);

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
            this.students.DeleteAll();
            return this.Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var students = this.students.Delete(id);
                return this.Ok(students);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
    }
}