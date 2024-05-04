﻿using SMSDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDataAccessLayer.Contracts
{
    public interface IStudentManagementServices
    {
        Task<bool> AddStudents(AddStudentsRequest addStudentsRequest);
    }
}