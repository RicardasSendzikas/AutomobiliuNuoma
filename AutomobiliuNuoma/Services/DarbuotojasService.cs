using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Services
{
    public class DarbuotojasService : IDarbuotojasService
    {
        private readonly IDarbuotojasRepository _darbuotojasRepository;

        public DarbuotojasService(IDarbuotojasRepository darbuotojasRepository)
        {
            _darbuotojasRepository = darbuotojasRepository ?? throw new ArgumentNullException(nameof(darbuotojasRepository), "DarbuotojasRepository negali būti null.");
        }

        // Gauti visus darbuotojus
        public async Task<IEnumerable<Darbuotojas>> GetAllDarbuotojai()
        {
            return await _darbuotojasRepository.GetAll();
        }

        // Gauti darbuotoją pagal ID
        public async Task<Darbuotojas> GetDarbuotojasById(int id)
        {
            return await _darbuotojasRepository.GetById(id);
        }

        // Pridėti naują darbuotoją
        public async Task AddDarbuotojas(Darbuotojas darbuotojas)
        {
            if (darbuotojas == null)
            {
                throw new ArgumentNullException(nameof(darbuotojas), "Darbuotojas negali būti null.");
            }
            await _darbuotojasRepository.Add(darbuotojas);
        }

        // Atnaujinti esamą darbuotoją
        public async Task UpdateDarbuotojas(Darbuotojas darbuotojas)
        {
            if (darbuotojas == null)
            {
                throw new ArgumentNullException(nameof(darbuotojas), "Darbuotojas negali būti null.");
            }
            await _darbuotojasRepository.Update(darbuotojas);
        }

        // Ištrinti darbuotoją pagal ID
        public async Task DeleteDarbuotojas(int id)
        {
            await _darbuotojasRepository.Delete(id);
        }
    }
}