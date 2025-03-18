using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public User GetUserById(Guid userId, bool trackChanges)
        {
            var user = _userManager.FindByIdAsync(userId.ToString()).Result;  // .Result to block until the result is available
            return user;
        }

        public bool IsUserCustomer(Guid userId)
        {
            var user = _userManager.FindByIdAsync(userId.ToString()).Result;  // .Result to block
            var roles = _userManager.GetRolesAsync(user).Result;  // .Result to block
            return roles.Contains("Customer");
        }
    }

}
