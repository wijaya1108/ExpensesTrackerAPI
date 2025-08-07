using ExpensesTracker.Application.DTO.User;
using ExpensesTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.Mappers
{
    public static class UserMapper
    {
        public static User MapToUser(this CreateUserRequest request)
        {
            return new User
            {
                UID = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                Email = request.Email,
                Password = request.Password,
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false
            };
        }

        public static UserResponse MapToUserResponse(this User user)
        {
            return new UserResponse(user.UID, user.FirstName, user.LastName, user.Address, user.Email, user.CreatedDate);
        }
    }
}
