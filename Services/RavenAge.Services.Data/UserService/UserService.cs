﻿namespace RavenAge.Services.UserService.Data
{
    using System.Linq;

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
                Premium = user.Premium,
                Type = user.Type,
            };

            return userViewModel;
        }
    }
}