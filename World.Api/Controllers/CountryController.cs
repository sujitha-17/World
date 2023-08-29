using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using World.Api.Data;
using World.Api.DTO.Country;
using World.Api.Model;
using World.Api.Repository.IRepository;

namespace World.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<CountryController> _logger;

        public CountryController(IMapper mapper, ICountryRepository countryRepository, ILogger<CountryController> logger)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict )]
        public async Task<ActionResult<Country>> Create([FromBody] CreateCountryDto countryDto)
        {
            var result = _countryRepository.IsCountryExists(countryDto.Name);
            if(result)
            {
                return Conflict("Country Already exists in database");
            }
            var country = _mapper.Map<Country>(countryDto);
            await _countryRepository.Create(country);
            return CreatedAtAction("GetById", new { id = country.Id }, country);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<CountryDto>>> GetAll()  
        {
            var countries = await _countryRepository.GetAll();

            var countriesDto = _mapper.Map<List<CountryDto>>(countries);
            
            if (countriesDto == null)
            {
                return NoContent();
            }

            return Ok(countriesDto);

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<CountryDto>> GetById(int id)
        {
            var country = await _countryRepository.GetById(id);

            var countryDto = _mapper.Map<CountryDto>(country);
            if (countryDto == null)
            {
                return NoContent();
            }

            return Ok(countryDto);
        }

        [HttpPut("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Country>> Update(int id, [FromBody] UpdateCountryDto countryDto)
        {
              if (countryDto == null || id!= countryDto.Id) {
                return BadRequest();
            }

            var country  = _mapper.Map<Country>(countryDto);
            await _countryRepository.Update(country);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteById(int id)
        {
            if(id==0)
            {
                return BadRequest();    
            }
            var country = await _countryRepository.GetById(id);
            if (country == null)
            {
                return NotFound();
            }
            await _countryRepository.Delete(country);
            return Ok();
        }
    }
}
