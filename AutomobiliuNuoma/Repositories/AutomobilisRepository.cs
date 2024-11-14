using AutomobiliuNuoma.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AutomobilisRepository : IAutomobilisRepository
{
    private readonly AutomobiliuContext _context;

    public AutomobilisRepository(AutomobiliuContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Automobilis>> GetAll()
    {
        return await _context.Automobiliai.ToListAsync();
    }

    public async Task<Automobilis> GetById(int id)
    {
        return await _context.Automobiliai.FindAsync(id);
    }

    public async Task Add(Automobilis automobilis)
    {
        if (automobilis == null)
        {
            throw new ArgumentNullException(nameof(automobilis), "Automobilis negali būti null.");
        }

        await _context.Automobiliai.AddAsync(automobilis);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Automobilis automobilis)
    {
        if (automobilis == null)
        {
            throw new ArgumentNullException(nameof(automobilis), "Automobilis negali būti null.");
        }

        _context.Automobiliai.Update(automobilis);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var automobilis = await _context.Automobiliai.FindAsync(id);
        if (automobilis != null)
        {
            _context.Automobiliai.Remove(automobilis);
            await _context.SaveChangesAsync();
        }
    }
}