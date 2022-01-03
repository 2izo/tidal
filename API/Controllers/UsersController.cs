using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Console;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        public IMapper Map { get; }
        private readonly IUserRepo _userRepo;
        public UsersController(IMapper map, IUserRepo userRepo)
        {
            _userRepo = userRepo;
            Map = map;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _userRepo.GetUsersAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user =  await _userRepo.GetUserByIdAsync(id);
            return Ok(user);
        }
        [HttpPost("register")]
        public async Task<ActionResult<bool>> SetUser(UserDto udt)
        {
            var user = Map.Map<AppUser>(udt);
            if (user == null) return NoContent();
            await _userRepo.AddUserAsync(user);
            return await _userRepo.SaveAllAsync();
        }
        [HttpDelete("deleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(int id){
            
            var user = await _userRepo.GetUserByIdAsync(id);
            if (user == null) return NoContent();
            _userRepo.DeleteUser(user);
            return Ok(await _userRepo.SaveAllAsync());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, UserDto customer)
        {
            AppUser userBefore = await _userRepo.GetUserByIdAsync(id);
            Map.Map(customer,userBefore);
            _userRepo.Update(userBefore);
            if(await _userRepo.SaveAllAsync()){
                return NoContent();
            }
            return BadRequest("Couldnt update");

        }

    }



}