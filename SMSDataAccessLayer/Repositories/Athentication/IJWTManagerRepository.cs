using SMSDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Athentication
{
    public interface IJWTManagerRepository
    {
        Task<Tokens> Authenticate(StudentCredential studentCredential);
    }
}
