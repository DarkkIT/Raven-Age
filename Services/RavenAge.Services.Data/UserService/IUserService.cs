namespace RavenAge.Services.UserService.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using RavenAge.Data.Models;
    using RavenAge.Web.ViewModels.User;

    public interface IUserService
    {
        UserViewModel GetUserInfo(string userId);
        Task<ApplicationUser> GetUserById(string userId);
    }
}
