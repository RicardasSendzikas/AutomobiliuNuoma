using System.Collections.Generic;
using System.Threading.Tasks;

public interface IKlientasRepository
{
    Task<IEnumerable<Klientas>> GetAll();
    Task<Klientas> GetById(int id);
    Task Add(Klientas klientas);
    Task Update(Klientas klientas);
    Task Delete(int id);
}