using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Context;

namespace TaskManagement.Infrastructure.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly TMContext _tmContext;
        public UserRepository(TMContext tmContext)
        {
            _tmContext = tmContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _tmContext.Users.ToListAsync();

        }
    }
}
