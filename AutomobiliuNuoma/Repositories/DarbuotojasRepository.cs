using AutomobiliuNuoma.Data; // Atitinkamai atnaujinkite namespace

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DarbuotojasRepository : IDarbuotojasRepository
{
    private readonly AutomobiliuContext _context;

    public DarbuotojasRepository(AutomobiliuContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Darbuotojas>> GetAll()
    {
        return await _context.Darbuotojai.ToListAsync();
    }

    public async Task<Darbuotojas> GetById(int id)
    {
        return await _context.Darbuotojai.FindAsync(id);
    }

    public async Task Add(Darbuotojas darbuotojas)
    {
        await _context.Darbuotojai.AddAsync(darbuotojas);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Darbuotojas darbuotojas)
    {
        _context.Darbuotojai.Update(darbuotojas);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var darbuotojas = await _context.Darbuotojai.FindAsync(id);
        if (darbuotojas != null)
        {
            _context.Darbuotojai.Remove(darbuotojas);
            await _context.SaveChangesAsync();
        }
    }
}