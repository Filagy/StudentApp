using StudentASP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentASP.Domain.Services
{
    public interface IGroupService
    {
        Task<Group> Get(int numberGroup);
        Task<List<Group>> Get();
        Task<int> Create(Group group);
        Task<int> Update(Group group);
        Task<string> Delete(int numberGroup);
    }
}
