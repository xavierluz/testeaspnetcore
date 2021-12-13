using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;

     

        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;
        }

        public async Task<bool> CreatePhoneAsync(PersonPhone personPhone)
        {
           var result = await _personPhoneRepository.CreatePhoneAsync(personPhone);
            return result;
        }

        public async Task<bool> DeletePhoneAsync(int personPhoneId)
        {
           var result= await _personPhoneRepository.DeletePhoneAsync(personPhoneId);
            return result;
        }

 

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();
        public async Task<PersonPhone> FindIdAsync(int personPhoneId) => (await _personPhoneRepository.FindIdAsync(personPhoneId));


        public async  Task<bool> UpdatePhoneAsync(PersonPhone personPhone)
        {
            var result = await _personPhoneRepository.UpdatePhoneAsync(personPhone);
            return result;
        }
    }
}
