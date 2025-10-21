using Microsoft.EntityFrameworkCore;
using MyCMS.DataAccess.Data;
using MyCMS.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.DataAccess.Services
{
    public class PageGroupService : IPageGroupService
    {
        private readonly MyDbContext _Context;
        private readonly DbSet<PageGroup> tblPageGroups;
        public PageGroupService(MyDbContext Context)
        {
             _Context=Context;
            tblPageGroups= Context.PageGroups;
        }

        public int Add(PageGroup entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(PageGroup entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PageGroup> GetAll()
        {
            IQueryable<PageGroup> query = tblPageGroups;
            return query.ToList();
        }

        public IEnumerable<PageGroup> GetAllUsers(int pageId, int pageSize)
        {
            throw new NotImplementedException();
        }

        public PageGroup GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public int PageCount(int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Update(PageGroup entity)
        {
            throw new NotImplementedException();
        }
    }
}
