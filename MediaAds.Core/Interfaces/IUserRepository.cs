using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaAds.Core.Models;

namespace MediaAds.Core.Interfaces
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetUserByCredentials(string username, string password);
    }
}
