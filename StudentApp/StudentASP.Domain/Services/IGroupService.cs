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
        Task<IEnumerable<Group>> Get();
        Task<string> Create(Group group);
        Task<string> Update();
        Task<string> Delete(int numberGroup);
    }
}
