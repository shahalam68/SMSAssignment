using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMSDataAccessLayer.Models;
using StudenMangementSystem.Data.Data;

namespace SMSAssignmentPresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentAPIDbContext dbContext;

        public StudentsController(StudentAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await dbContext.Students.ToListAsync();
            return Ok(students);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetStudent([FromRoute] Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudents(AddStudentsRequest addStudentsRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Name = addStudentsRequest.Name,
                Email = addStudentsRequest.Email,
                EnrolmentDate  = addStudentsRequest.EnrolmentDate,
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return Ok(student);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateStudentRequest updateStudentRequest)
        {
            var student = await dbContext.Students.FindAsync(id);
            if (student != null)
            {
                student.Name = updateStudentRequest.Name;
                student.Email = updateStudentRequest.Email;
                student.EnrolmentDate = updateStudentRequest.EnrolmentDate;
                await dbContext.SaveChangesAsync();
                return Ok(student);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            if (student != null)
            {
                 dbContext.Remove(student);
                await dbContext.SaveChangesAsync();
                return Ok(student);
            }
            return NotFound();


        }
    }

    
}
