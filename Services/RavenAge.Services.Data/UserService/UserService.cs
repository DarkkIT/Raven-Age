﻿namespace RavenAge.Services.UserService.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models;
    using RavenAge.Web.ViewModels.User;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public UserService(IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserViewModel GetUserInfo(string userId)
        {
            var user = this.userRepository.All().FirstOrDefault(x => x.Id == userId);

            var userViewModel = new UserViewModel
            {
                Name = user.Name,
                AttackRune = user.AttackRune,
                DefenseRune = user.DefenseRune,
                HealthRune = user.HealthRune,
                Avatar = user.Avatar,
            };

            return userViewModel;
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            return await this.userRepository.All().FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}
