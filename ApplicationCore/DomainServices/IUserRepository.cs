using ApplicationCore.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DomainServices
{
    public interface IUserRepository
    {
        User GetUser(string username, string password);
    }
}
