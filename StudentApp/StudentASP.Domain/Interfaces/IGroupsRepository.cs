using StudentASP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentASP.Domain.Interfaces
{
    public interface IGroupsRepository
    {
        Task<List<Group>> GetGroupsAsync();
    }
}
