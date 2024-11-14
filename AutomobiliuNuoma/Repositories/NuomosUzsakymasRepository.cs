using AutomobiliuNuoma.Data; // Atitinkamai atnaujinkite namespace

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class NuomosUzsakymasRepository : INuomosUzsakymasRepository
{
    private readonly AutomobiliuContext _context;

    public NuomosUzsakymasRepository(AutomobiliuContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<NuomosUzsakymas>> GetAll()
    {
        return await _context.NuomosUzsakymai
                             .Include(n => n.Klientas)
                             .Include(n => n.Automobilis)
                             .ToListAsync();
    }

    public async Task<NuomosUzsakymas> GetById(int id)
    {
        return await _context.NuomosUzsakymai
                             .Include(n => n.Klientas)
                             .Include(n => n.Automobilis)
                             .FirstOrDefaultAsync(n => n.Id == id);
    }

    public async Task Add(NuomosUzsakymas nuomosUzsakymas)
    {
        await _context.NuomosUzsakymai.AddAsync(nuomosUzsakymas);
        await _context.SaveChangesAsync();
    }

    public async Task Update(NuomosUzsakymas nuomosUzsakymas)
    {
        _context.NuomosUzsakymai.Update(nuomosUzsakymas);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var nuomosUzsakymas = await _context.NuomosUzsakymai.FindAsync(id);
        if (nuomosUzsakymas != null)
        {
            _context.NuomosUzsakymai.Remove(nuomosUzsakymas);
            await _context.SaveChangesAsync();
        }
    }
}