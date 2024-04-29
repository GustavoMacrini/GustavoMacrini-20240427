using GestaoColaboradores.Data;
using GestaoColaboradores.Models.Colaborador;
using GestaoColaboradores.Models.User;
using Microsoft.EntityFrameworkCore;

namespace GestaoColaboradores.Services
{
    public class UnidadeService
    {
        private readonly ApplicationDbContext _context;

        public UnidadeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Unidade>> GetAllAsync(bool? active)
        {
            var result = await _context.Unidades.Where(u => active == null || u.Active == active).ToListAsync();

            return result;
        }

        public async Task<Unidade> GetByIdAsync(Guid id)
        {
            return _context.Unidades.Where(u => u.Id == id).FirstOrDefault();
        }

        public void Create(Unidade unidade)
        {
            _context.Unidades.Add(unidade);
            _context.SaveChanges();
        }

        public void Update(Guid id, bool active)
        {
            var unidade = _context.Unidades.FirstOrDefault(u => u.Id == id);
            unidade.Active = active;
            _context.SaveChanges();
        }

    }
}
