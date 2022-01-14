using StudentASP.Domain.Models;
using StudentASP.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentASP.DataAccess.MSSQL.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<int> Create(User obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(User obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
