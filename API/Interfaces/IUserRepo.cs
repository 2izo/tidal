using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepo
    {
        void Update(AppUser user);
        Task<AppUser> GetUserByIdAsync(int id);
        Task AddUserAsync(AppUser user); 
        Task<AppUser> GetUserByUserNameAsync(string username);
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<bool> SaveAllAsync();
        void DeleteUser(AppUser user);
    }
}