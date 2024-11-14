using AutomobiliuNuoma.Data; // Atitinkamai atnaujinkite namespace

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class KlientasRepository : IKlientasRepository
{
    private readonly AutomobiliuContext _context;

    public KlientasRepository(AutomobiliuContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Klientas>> GetAll()
    {
        return await _context.Klientai.ToListAsync();
    }

    public async Task<Klientas> GetById(int id)
    {
        return await _context.Klientai.FindAsync(id);
    }

    public async Task Add(Klientas klientas)
    {
        await _context.Klientai.AddAsync(klientas);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Klientas klientas)
    {
        _context.Klientai.Update(klientas);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var klientas = await _context.Klientai.FindAsync(id);
        if (klientas != null)
        {
            _context.Klientai.Remove(klientas);
            await _context.SaveChangesAsync();
        }
    }
}