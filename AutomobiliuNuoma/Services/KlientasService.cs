
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Services
{
    public class KlientasService : IKlientasService
    {
        private readonly IKlientasRepository _klientasRepository;

        public KlientasService(IKlientasRepository klientasRepository)
        {
            _klientasRepository = klientasRepository;
        }

        // Gauti visus klientus
        public async Task<IEnumerable<Klientas>> GetAllKlientai()
        {
            return await _klientasRepository.GetAll();
        }

        // Gauti klientą pagal ID
        public async Task<Klientas> GetKlientasById(int id)
        {
            return await _klientasRepository.GetById(id);
        }

        // Pridėti naują klientą
        public async Task AddKlientas(Klientas klientas)
        {
            if (klientas == null)
            {
                throw new ArgumentNullException(nameof(klientas), "Klientas negali būti null.");
            }
            await _klientasRepository.Add(klientas);
        }

        // Atnaujinti esamą klientą
        public async Task UpdateKlientas(Klientas klientas)
        {
            if (klientas == null)
            {
                throw new ArgumentNullException(nameof(klientas), "Klientas negali būti null.");
            }
            await _klientasRepository.Update(klientas);
        }

        // Ištrinti klientą pagal ID
        public async Task DeleteKlientas(int id)
        {
            await _klientasRepository.Delete(id);
        }
    }
}