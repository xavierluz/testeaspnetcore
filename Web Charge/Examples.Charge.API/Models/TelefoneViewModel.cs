using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.API.Models
{
    public class TelefoneViewModel
    {
        public int Id { get; set; }
        public string Telefone { get; set; }
        public string TipoTelefone { get; set; }
        public bool Delete { get; set; }

        public PersonPhone Get()
        {
            return new PersonPhone()
            {
                BusinessEntityID = Id,
                PhoneNumber = Telefone,
                PhoneNumberTypeID = this.TipoTelefone == "Residencial" ? 1 : 2
            };
        }

        public  static TelefoneViewModel Get(PersonPhone personPhone)
        {
            return new TelefoneViewModel()
            {
                Id = personPhone.BusinessEntityID,
                Telefone = personPhone.PhoneNumber,
                TipoTelefone = personPhone.PhoneNumberTypeID == 1 ? "Residencial" : "Comercial",
                Delete = false
            };
        }
    }
}
