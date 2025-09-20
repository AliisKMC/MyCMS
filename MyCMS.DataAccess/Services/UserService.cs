using Microsoft.EntityFrameworkCore;
using MyCMS.DataAccess.Data;
using MyCMS.Models.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.DataAccess.Services
{
    public class UserService : IUserService
    {
        private readonly MyDbContext _context;
        private readonly DbSet<User> tblUser;
        public UserService(MyDbContext context)
        {
            _context=context;
            tblUser = context.Users;
        }
        public int Add(User entity)
        {
           tblUser.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Delete(User entity)
        {
            tblUser.Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var user=GetById(id);
            if (user != null)
            {
                Delete(user);
            }
        }

        public IEnumerable<User> GetAll()
        {
            IQueryable<User> query = tblUser;
            return query.ToList();
        }

        public User GetById(int id)
        {
            return tblUser.Find(id);
        }

        public User GetUserByUsernameOrEmail(string usernameOrEmail)
        {
            return tblUser
                .FirstOrDefault(u => (u.IsDelete == false) && (u.UserName == usernameOrEmail || 
                                                               u.Email == usernameOrEmail));
        }

        public bool IsExistEmail(string email)
        {
            return tblUser.Any(x => x.Email == email);
        }

        public bool IsExistUsername(string userName)
        {
            return tblUser.Any(u => u.UserName == userName);
        }

        public void Update(User entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
