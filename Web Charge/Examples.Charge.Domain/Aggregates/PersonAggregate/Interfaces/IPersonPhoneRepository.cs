using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonPhone>> FindAllAsync();
        Task<PersonPhone> FindIdAsync(int personPhoneId);
        Task<bool> CreatePhoneAsync(PersonPhone personPhone);
        Task<bool> UpdatePhoneAsync(PersonPhone personPhone);
        Task<bool> DeletePhoneAsync(int personPhoneId);

    }
}
