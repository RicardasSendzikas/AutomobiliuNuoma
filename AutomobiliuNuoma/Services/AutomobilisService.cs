
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Services
{
    public class AutomobilisService : IAutomobilisService
    {
        private readonly IAutomobilisRepository _automobilisRepository;

        public AutomobilisService(IAutomobilisRepository automobilisRepository)
        {
            _automobilisRepository = automobilisRepository;
        }

        // Gauti visus automobilius
        public async Task<IEnumerable<Automobilis>> GetAllAutomobiliai()
        {
            return await _automobilisRepository.GetAll();
        }

        // Gauti automobilį pagal ID
        public async Task<Automobilis> GetAutomobilisById(int id)
        {
            return await _automobilisRepository.GetById(id);
        }

        // Pridėti naują automobilį
        public async Task AddAutomobilis(Automobilis automobilis)
        {
            if (automobilis == null)
            {
                throw new ArgumentNullException(nameof(automobilis), "Automobilis negali būti null.");
            }
            await _automobilisRepository.Add(automobilis);
        }

        // Atnaujinti esamą automobilį
        public async Task UpdateAutomobilis(Automobilis automobilis)
        {
            if (automobilis == null)
            {
                throw new ArgumentNullException(nameof(automobilis), "Automobilis negali būti null.");
            }
            await _automobilisRepository.Update(automobilis);
        }

        // Ištrinti automobilį pagal ID
        public async Task DeleteAutomobilis(int id)
        {
            await _automobilisRepository.Delete(id);
        }
    }
}