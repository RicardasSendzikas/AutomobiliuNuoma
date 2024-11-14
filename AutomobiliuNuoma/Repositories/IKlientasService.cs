using System.Collections.Generic;
using System.Threading.Tasks;

public interface IKlientasService
{
    Task<IEnumerable<Klientas>> GetAllKlientai();
    Task<Klientas> GetKlientasById(int id);
    Task AddKlientas(Klientas klientas);
    Task UpdateKlientas(Klientas klientas);
    Task DeleteKlientas(int id);
}