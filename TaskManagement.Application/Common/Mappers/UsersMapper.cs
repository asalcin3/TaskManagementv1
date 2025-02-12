using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Common.DTOs;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Common.Mappers
{
    public static class UsersMapper
    {
        public static UserDTO ToDto(this User entity)
        {
            return new UserDTO
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Email = entity.Email
            };
        }
    }
}
