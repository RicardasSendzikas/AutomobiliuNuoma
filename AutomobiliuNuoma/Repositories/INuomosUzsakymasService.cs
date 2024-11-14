using System.Collections.Generic;
using System.Threading.Tasks;

public interface INuomosUzsakymasService
{
    Task<IEnumerable<NuomosUzsakymas>> GetAllNuomosUzsakymai();
    Task<NuomosUzsakymas> GetNuomosUzsakymasById(int id);
    Task AddNuomosUzsakymas(NuomosUzsakymas nuomosUzsakymas);
    Task UpdateNuomosUzsakymas(NuomosUzsakymas nuomosUzsakymas);
    Task DeleteNuomosUzsakymas(int id);
}