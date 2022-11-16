using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UsersAPI.Models;
using UsersDTO;

namespace UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<UserDTO> GetUsers()
        {
            return _context.Users.Select(user => new UserDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                City = user.City,
                Email = user.Email
            });
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public UserDTO GetUser(int id)
        {
            User user = _context.Users.Find(id);

            if (user == null)
            {
                return null;
            }

            return new()
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                City = user.City,
                Email = user.Email
            };
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public UserDTO PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                throw new Exception();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    throw new Exception();
                }
                else
                {
                    throw;
                }
            }

            return null;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public UserDTO PostUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return GetUser(user.Id);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            User user = _context.Users.Find(id);
            if (user == null)
            {
                throw new Exception();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
