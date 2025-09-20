using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCMS.Models.Model;

namespace MyCMS.DataAccess.Services
{
    public interface IUserService:IService<User>
    {
        bool IsExistEmail(string email);
        bool IsExistUsername(string userName);
        User GetUserByUsernameOrEmail(string usernameOrEmail);
    }
}
