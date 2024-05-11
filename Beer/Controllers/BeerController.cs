using BeerCollection.Interface;
using BeerCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BeerCollection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerController : ControllerBase
    {
        private readonly IBeerRepository _beerRepository;

        public BeerController(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        [HttpPost]
        public IActionResult AddBeer([FromBody] Beers beerObj)
        {
            if (beerObj.Rating < 1 || beerObj.Rating > 5)
                return BadRequest("Invalid parameters.");

            _beerRepository.AddBeer(beerObj);

            return Ok("Beer added successfully.");
        }

        [HttpGet]
        public IActionResult Beers()
        {
            var result = _beerRepository.Beers();

            if (result.IsNullOrEmpty())
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("search")]
        public IActionResult Search(string name)
        {
            var result = _beerRepository.Search(name);

            if (result.IsNullOrEmpty())
                return NotFound();

            return Ok(result);
        }


        [HttpPut]
        public IActionResult UpdateRating(int beerId)
        {
            var result = _beerRepository.UpdateRating(beerId);

            if (!result)
                return NotFound();

            return Ok($"Beer with Id: {beerId} updated rate successfully.");
        }
    }
}