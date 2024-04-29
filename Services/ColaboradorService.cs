using GestaoColaboradores.Data;
using GestaoColaboradores.Models.Colaborador;
using Microsoft.EntityFrameworkCore;

namespace GestaoColaboradores.Services
{
    public class ColaboradorService
    {
        private readonly ApplicationDbContext _context;

        public ColaboradorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Colaborador>> GetAllAsync()
        {
            var result = await _context.Colaboradores.Include(c => c.Unidade).Include(c => c.Usuario).ToListAsync();
            return result;
        }

        public void Create(Colaborador colaborador)
        {            
            _context.Colaboradores.Add(colaborador);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var colaborador = _context.Colaboradores.Where(c => c.Id == id).FirstOrDefault();
            if (colaborador != null)
            {
                _context.Colaboradores.Remove(colaborador);
                _context.SaveChanges();
            }
        }
        public void Edit(Guid id, string name, Unidade unidade)
        {
            var colaborador = _context.Colaboradores.Where(c => c.Id == id).FirstOrDefault();
            if (colaborador != null)
            {
                colaborador.Name = name;
                colaborador.Unidade = unidade;
                _context.SaveChanges();
            }
        }
    }
}
