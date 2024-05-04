
using SMSDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.repository
{
    public interface IStudentRepository
    {
        Task<bool> CreateStudent(Student student);
        Task<Student> GetByUserName(string userName);
    }
}
