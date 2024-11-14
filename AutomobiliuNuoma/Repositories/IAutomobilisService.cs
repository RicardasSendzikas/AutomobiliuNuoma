using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Services
{
    public interface IAutomobilisService
    {
        Task<IEnumerable<Automobilis>> GetAllAutomobiliai();
        Task<Automobilis> GetAutomobilisById(int id);
        Task AddAutomobilis(Automobilis automobilis);
        Task UpdateAutomobilis(Automobilis automobilis);
        Task DeleteAutomobilis(int id);
    }
}