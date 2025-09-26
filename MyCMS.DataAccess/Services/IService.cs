using MyCMS.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.DataAccess.Services
{
    public interface IService<T> where T:class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllUsers(int pageId, int pageSize);        
        T GetById(int? id);
        int Add(T entity);
        void Update(T entity);
        void DeleteById(int id);
        void Delete(T entity);
        int PageCount(int pageSize);

    }
}
