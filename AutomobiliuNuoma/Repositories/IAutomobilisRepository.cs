using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAutomobilisRepository
{
    Task<IEnumerable<Automobilis>> GetAll();
    Task<Automobilis> GetById(int id);
    Task Add(Automobilis automobilis);
    Task Update(Automobilis automobilis);
    Task Delete(int id);
}