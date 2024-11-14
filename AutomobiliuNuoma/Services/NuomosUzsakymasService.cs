
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Services
{
    public class NuomosUzsakymasService : INuomosUzsakymasService
    {
        private readonly INuomosUzsakymasRepository _nuomosUzsakymasRepository;

        public NuomosUzsakymasService(INuomosUzsakymasRepository nuomosUzsakymasRepository)
        {
            _nuomosUzsakymasRepository = nuomosUzsakymasRepository;
        }

        // Gauti visus nuomos užsakymus
        public async Task<IEnumerable<NuomosUzsakymas>> GetAllNuomosUzsakymai()
        {
            return await _nuomosUzsakymasRepository.GetAll();
        }

        // Gauti nuomos užsakymą pagal ID
        public async Task<NuomosUzsakymas> GetNuomosUzsakymasById(int id)
        {
            return await _nuomosUzsakymasRepository.GetById(id);
        }

        // Pridėti naują nuomos užsakymą
        public async Task AddNuomosUzsakymas(NuomosUzsakymas nuomosUzsakymas)
        {
            if (nuomosUzsakymas == null)
            {
                throw new ArgumentNullException(nameof(nuomosUzsakymas), "Nuomos užsakymas negali būti null.");
            }
            await _nuomosUzsakymasRepository.Add(nuomosUzsakymas);
        }

        // Atnaujinti esamą nuomos užsakymą
        public async Task UpdateNuomosUzsakymas(NuomosUzsakymas nuomosUzsakymas)
        {
            if (nuomosUzsakymas == null)
            {
                throw new ArgumentNullException(nameof(nuomosUzsakymas), "Nuomos užsakymas negali būti null.");
            }
            await _nuomosUzsakymasRepository.Update(nuomosUzsakymas);
        }

        // Ištrinti nuomos užsakymą pagal ID
        public async Task DeleteNuomosUzsakymas(int id)
        {
            await _nuomosUzsakymasRepository.Delete(id);
        }
    }
}