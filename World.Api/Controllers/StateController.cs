using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using World.Api.Data;
using World.Api.DTO.State;
using World.Api.Model;
using World.Api.Repository.IRepository;

namespace World.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStateRepository _stateRepository;

        public StateController(IMapper mapper, IStateRepository stateRepository)
        {
            _mapper = mapper;
            _stateRepository = stateRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<State>> Create([FromBody] CreateStateDto stateDto)
        {
            var result = _stateRepository.IsRecordExists(x=> x.Name == stateDto.Name);
            if (result)
            {
                return Conflict("State Already exists in database");
            }
            var state = _mapper.Map<State>(stateDto);
            await _stateRepository.Create(state);
            return CreatedAtAction("GetById", new { id = state.Id }, state);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<StateDto>>> GetAll()
        {
            var states = await _stateRepository.GetAll();

            var statesDto = _mapper.Map<List<StateDto>>(states);

            if (statesDto == null)
            {
                return NoContent();
            }

            return Ok(statesDto);

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<StateDto>> GetById(int id)
        {
            var state = await _stateRepository.Get(id);

            var stateDto = _mapper.Map<StateDto>(state);
            if (stateDto == null)
            {
                return NoContent();
            }

            return Ok(stateDto);
        }

        [HttpPut("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<State>> Update(int id, [FromBody] UpdateStateDto stateDto)
        {
            if (stateDto == null || id != stateDto.Id)
            {
                return BadRequest();
            }

            var state = _mapper.Map<State>(stateDto);
            await _stateRepository.Update(state);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var state = await _stateRepository.Get(id);
            if (state == null)
            {
                return NotFound();
            }
            await _stateRepository.Delete(state);
            return Ok();
        }
    }
}
