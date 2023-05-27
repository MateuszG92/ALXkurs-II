using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MysqlWebApi.DTO;
using MysqlWebApi.Entities;
using System.Linq;
using System.Net;

namespace MysqlWebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ContextDB _dbContext;
        public UserController(ContextDB contextDB)
        {
            _dbContext = contextDB;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var list = await _dbContext.Users.Select(x => new UserDTO { Id = x.Id, Name = x.Name, Email = x.Email, Password = x.Password, CreatedTs = x.CreatedTs }).ToListAsync();
            return list;
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _dbContext.Users.Select(x => new UserDTO { Id = x.Id, Name = x.Name, Email = x.Email, Password = x.Password, CreatedTs = x.CreatedTs }).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) { return NotFound(); }
            return user;
        }

        [HttpPost("AddUser")]
        public async Task<HttpStatusCode> InsertUser(UserAddDTO user)
        {
            var entity = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                CreatedTs = DateTime.Now
            };
            _dbContext.Users.Add(entity);
            await _dbContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpPut("UpdateUser")]
        public async Task<HttpStatusCode> InsertUser(UserUpdateDTO user)
        {
            var entity =await _dbContext.Users.FirstOrDefaultAsync(u=> u.Id == user.Id);
            if (entity == null)
            {
                return HttpStatusCode.NotFound;
            }
            entity.Name=user.Name;
            entity.Password=user.Password;
            await _dbContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<HttpStatusCode> DeleteUser(int id)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (entity == null)
            {
                return HttpStatusCode.NotFound;
            }
            _dbContext.Users.Remove(entity); 
            await _dbContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
