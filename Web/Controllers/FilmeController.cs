using Application.DTO.Filme;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    #region Properties
    private readonly IFilmeService _filmeService;
    private readonly IMapper _mapper;

    #endregion

    #region Constructor
    public FilmeController(IFilmeService filmeService, IMapper mapper)
    {
        _filmeService = filmeService;
        _mapper = mapper;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDTO">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso a inserção seja realizada com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CadastraFilme([FromBody] CreateFilmeDTO filmeDTO)
    {
        if (filmeDTO == null)
        {
            return BadRequest();
        }

        // Cria uma novo objeto a partir da DTO
        Filme filme = _mapper.Map<Filme>(filmeDTO);

        await _filmeService.Add(filme);

        return CreatedAtAction(nameof(ObtemFilme), new { id = filme }, filme);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizaFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        Filme filme = await _filmeService.GetFilmeIdAsync(id);

        if (filme == null)
        {
            return BadRequest();
        }

        // Atualiza uma objeto existente com as propriedades da DTO
        _mapper.Map(filmeDTO, filme);

        await _filmeService.Update(filme);

        return NoContent();
    }

    // Esse método pode atualizar parcialmente informações do objeto, não sendo necessário passar o objeto completo como no Put
    [HttpPatch("{id}")]
    public async Task<IActionResult> AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDTO> patch)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        Filme filme = await _filmeService.GetFilmeIdAsync(id);

        if (filme == null)
        {
            return BadRequest();
        }

        // Converte o filme obtido para DTO
        UpdateFilmeDTO filmeDTO = _mapper.Map<UpdateFilmeDTO>(filme);

        // Tenta aplicar a mudança
        patch.ApplyTo(filmeDTO, ModelState);

        // Se não conseguir validar o modelo filmeDTO, não passa desse if
        if (!TryValidateModel(filmeDTO))
        {
            return ValidationProblem(ModelState);
        }

        // Se chegou aqui, atualiza um objeto existente com as propriedades da DTO
        _mapper.Map(filmeDTO, filme);

        await _filmeService.Update(filme);

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> ObtemFilmes(int skip, int take = 10)
    {
        IEnumerable<Filme> filmes = await _filmeService.GetFilmesAsync();

        IEnumerable<ReadFilmeDTO> filmesDTO = _mapper.Map<List<ReadFilmeDTO>>(filmes.Skip(skip).Take(take));

        return Ok(filmesDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtemFilme(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        Filme filme = await _filmeService.GetFilmeIdAsync(id);

        ReadFilmeDTO readFilmeDTO = _mapper.Map<ReadFilmeDTO>(filme);

        return Ok(readFilmeDTO);
    }

    #endregion
}
