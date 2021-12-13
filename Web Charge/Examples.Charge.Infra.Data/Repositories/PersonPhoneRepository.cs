using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> CreatePhoneAsync(PersonPhone personPhone)
        {
            try
            {
                personPhone.BusinessEntityID = await GetUltimoId();
                await _context.PersonPhone.AddAsync(personPhone);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return true;


                return false;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        private async Task<int> GetUltimoId()
        {
            var id = await this._context.PersonPhone.MaxAsync(x => x.BusinessEntityID);

            if (id == 0)
                return 1;

            return id;
        }
        public async Task<bool> DeletePhoneAsync(int personPhoneId)
        {
            try
            {
                var phone = await this.FindIdAsync(personPhoneId);
                if (phone == null)
                    throw new ArgumentNullException(nameof(personPhoneId));

                this._context.PersonPhone.Remove(phone);
                var result = await this._context.SaveChangesAsync();

                if (result > 0)
                    return true;


                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await Task.Run(() => _context.PersonPhone);

        public async Task<PersonPhone> FindIdAsync(int personPhoneId)
        {
            var result = await _context.PersonPhone.Where(x => x.BusinessEntityID == personPhoneId).FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> UpdatePhoneAsync(PersonPhone personPhone)
        {
            try
            {
                var phone = await this.FindIdAsync(personPhone.BusinessEntityID);
                if (phone == null)
                    throw new ArgumentNullException(nameof(personPhone));

                //phone.PhoneNumber = personPhone.PhoneNumber;
                phone.PhoneNumberTypeID = personPhone.PhoneNumberTypeID;

                this._context.PersonPhone.Update(phone);
                var result = await this._context.SaveChangesAsync();

                if (result > 0)
                    return true;


                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
