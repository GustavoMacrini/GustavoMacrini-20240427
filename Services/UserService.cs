using GestaoColaboradores.Data;
using GestaoColaboradores.Models.User;
using Microsoft.EntityFrameworkCore;

namespace GestaoColaboradores.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync(bool? active)
        {

            var users = await _context.Users.Where(u => active == null || u.Active == active).ToListAsync();
            return users;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return _context.Users.Where(u => u.Id ==  id).FirstOrDefault();  
        }

        public void Create(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public void Edit(User userEdit)
        {
            User user = _context.Users.Where(u => u.Id == userEdit.Id).FirstOrDefault();
            user.Password = userEdit.Password;
            user.Active = userEdit.Active;
            _context.SaveChanges();
        }

    }
}

