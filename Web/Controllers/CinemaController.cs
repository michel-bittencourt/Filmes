using Application.DTO.Cinema;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    #region Properties
    private readonly ICinemaService _cinemaService;
    private readonly IMapper _mapper;

    #endregion

    #region Constructor
    public CinemaController(ICinemaService cinemaService, IMapper mapper)
    {
        _cinemaService = cinemaService;
        _mapper = mapper;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Adiciona um cinema ao banco de dados
    /// </summary>
    /// <param name="cinemaDTO">Objeto com os campos necessários para criação de um cinema</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso a inserção seja realizada com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CadastraCinema([FromBody] CreateCinemaDTO cinemaDTO)
    {
        if (cinemaDTO == null)
        {
            return BadRequest();
        }

        // Cria uma novo objeto a partir da DTO
        Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);

        await _cinemaService.Add(cinema);

        return CreatedAtAction(nameof(ObtemCinema), new { id = cinema }, cinema);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizaCinema(int id, [FromBody] UpdateCinemaDTO cinemaDTO)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        Cinema cinema = await _cinemaService.GetCinemaByIdAsync(id);

        if (cinema == null)
        {
            return BadRequest();
        }

        // Atualiza uma objeto existente com as propriedades da DTO
        _mapper.Map(cinemaDTO, cinema);

        await _cinemaService.Update(cinema);

        return NoContent();
    }

    // Esse método pode atualizar parcialmente informações do objeto, não sendo necessário passar o objeto completo como no Put
    [HttpPatch("{id}")]
    public async Task<IActionResult> AtualizaCinemaParcial(int id, JsonPatchDocument<UpdateCinemaDTO> patch)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        Cinema cinema = await _cinemaService.GetCinemaByIdAsync(id);

        if (cinema == null)
        {
            return BadRequest();
        }

        // Converte o filme obtido para DTO
        UpdateCinemaDTO cinemaDTO = _mapper.Map<UpdateCinemaDTO>(cinema);

        // Tenta aplicar a mudança
        patch.ApplyTo(cinemaDTO, ModelState);

        // Se não conseguir validar o modelo filmeDTO, não passa desse if
        if (!TryValidateModel(cinemaDTO))
        {
            return ValidationProblem(ModelState);
        }

        // Se chegou aqui, atualiza um objeto existente com as propriedades da DTO
        _mapper.Map(cinemaDTO, cinema);

        await _cinemaService.Update(cinema);

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> ObtemCinemas(int skip, int take = 10)
    {
        IEnumerable<Cinema> cinemas = await _cinemaService.GetCinemasAsync();

        IEnumerable<ReadCinemaDTO> cinemaDTO = _mapper.Map<List<ReadCinemaDTO>>(cinemas.Skip(skip).Take(take)).ToList();

        return Ok(cinemaDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtemCinema(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        Cinema cinema = await _cinemaService.GetCinemaByIdAsync(id);

        ReadCinemaDTO readCinemaDTO = _mapper.Map<ReadCinemaDTO>(cinema);

        return Ok(readCinemaDTO);
    }

    #endregion
}
