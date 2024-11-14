using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDarbuotojasRepository
{
    Task<IEnumerable<Darbuotojas>> GetAll();
    Task<Darbuotojas> GetById(int id);
    Task Add(Darbuotojas darbuotojas);
    Task Update(Darbuotojas darbuotojas);
    Task Delete(int id);
}