using System.Collections.Generic;
using System.Threading.Tasks;

public interface INuomosUzsakymasRepository
{
    Task<IEnumerable<NuomosUzsakymas>> GetAll();
    Task<NuomosUzsakymas> GetById(int id);
    Task Add(NuomosUzsakymas nuomosUzsakymas);
    Task Update(NuomosUzsakymas nuomosUzsakymas);
    Task Delete(int id);
}