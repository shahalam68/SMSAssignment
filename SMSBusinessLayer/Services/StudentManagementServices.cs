using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using SMSDataAccessLayer.Models;
using StudenMangementSystem.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using SMSDataAccessLayer.Contacts;
using SMSDataAccessLayer.Contracts;

namespace SMSBusinessLayer.Services
{
    public class StudentManagementServices: IStudentManagementServices
    {
        private readonly IMapper _mapper;
        StudentAPIDbContext _context;
        ILoggerManager _loggerManager;
        IStudentRepository _studentRepository;
        public StudentManagementServices(
            IMapper mapper, 
            StudentAPIDbContext context, 
            ILoggerManager loggerManager, 
            IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _context = context;
            _loggerManager = loggerManager;
            _studentRepository = studentRepository;
        }

        public async Task<bool> AddStudents(AddStudentsRequest addStudentsRequest)
        {
            try
            {
                _loggerManager.LogInfo("started added new enty");
                _loggerManager.LogInfo(JsonSerializer.Serialize(addStudentsRequest));

                var student = _mapper.Map<Student>(addStudentsRequest);

                student.Id = Guid.NewGuid();

                await _studentRepository.CreateStudent(student);
                _loggerManager.LogInfo("successfully added new entry");
                return true;
            } catch(Exception ex)
            {
                _loggerManager.LogError(ex.ToString());
                return false;
            }

            
        }
    }
}
