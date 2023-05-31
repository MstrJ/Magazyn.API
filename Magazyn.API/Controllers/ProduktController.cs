using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Magazyn.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Magazyn.API.Controllers
{
    [Route("api/Produkty")]
    [ApiController]
    public class ProduktController : ControllerBase
    {
        private readonly IProduktService _produktService;
        public ProduktController(IProduktService produktService)
        {
            _produktService = produktService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Produkt>>> GetProdukts()
        {
            return Ok(await _produktService.GetProdukts());
        }

        [HttpPatch()]
        public async Task<ActionResult<IEnumerable<Produkt>>> ChangeIlosc(string kod,int ilosc)
        {
            return Ok(await _produktService.ChangeIlosc(kod,ilosc));
        }
        [HttpPost()]
        public async Task<ActionResult<IEnumerable<Produkt>>> AddProdukt(ProduktDTO produktDTO)
        {
            return Ok(await _produktService.AddProdukt(produktDTO));
        }
    }

}
