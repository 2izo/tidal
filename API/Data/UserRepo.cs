using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly DataContext db;

       public UserRepo(DataContext db){
            this.db = db;
        }

        public async Task AddUserAsync(AppUser user)
        {
            await db.Users.AddAsync(user);
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await db.Users.SingleOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<AppUser> GetUserByUserNameAsync(string username)
        {
            return await db.Users.SingleOrDefaultAsync(x=>x.Username==username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await db.Users.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await db.SaveChangesAsync() > 0;
        }
        public void Update(AppUser user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public  void DeleteUser(AppUser user)
        {
            db.Users.Remove(user);
        }

        
    }
}