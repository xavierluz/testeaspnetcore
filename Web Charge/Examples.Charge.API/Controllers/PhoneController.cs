using Examples.Charge.API.Models;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private IPersonPhoneService _personPhoneService;
        public PhoneController(IPersonPhoneService  personPhoneService)
        {
            this._personPhoneService = personPhoneService;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetTelefones()
        {
            var result = await this._personPhoneService.FindAllAsync();

            var retorno = result.ConvertAll(new Converter<PersonPhone, TelefoneViewModel>(TelefoneViewModel.Get));
            return Ok(retorno);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTelefones(int id)
        {
            var result = await this._personPhoneService.FindIdAsync(id);

            var retorno = TelefoneViewModel.Get(result);
            return Ok(retorno);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TelefoneViewModel personPhone)
        {
            var phone = personPhone.Get();
            var resul = await this._personPhoneService.CreatePhoneAsync(phone);

            return Ok(resul);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] TelefoneViewModel personPhone)
        {
            if (id < 1)
                return NotFound("Id do telefone está vazio");

            var phone = personPhone.Get();
            phone.BusinessEntityID = id;
            var resul = await this._personPhoneService.UpdatePhoneAsync(phone);

            return Ok(resul);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return NotFound("Id do telefone está vazio");

           
            var deletado = await this._personPhoneService.DeletePhoneAsync(id);

            var result = await this._personPhoneService.FindAllAsync();

            var retorno = result.ConvertAll(new Converter<PersonPhone, TelefoneViewModel>(TelefoneViewModel.Get));
            return Ok(retorno);
        }
    }
}
