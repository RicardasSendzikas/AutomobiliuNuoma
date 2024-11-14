using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Services
{
    public interface IDarbuotojasService
    {
        Task<IEnumerable<Darbuotojas>> GetAllDarbuotojai();
        Task<Darbuotojas> GetDarbuotojasById(int id);
        Task AddDarbuotojas(Darbuotojas darbuotojas);
        Task UpdateDarbuotojas(Darbuotojas darbuotojas);
        Task DeleteDarbuotojas(int id);
    }
}