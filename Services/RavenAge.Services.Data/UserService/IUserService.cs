namespace RavenAge.Services.UserService.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Web.ViewModels.User;

    public interface IUserService
    {
        UserViewModel GetUserInfo(string userId);
    }
}
