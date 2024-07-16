using Application.DTO.Cinema;
using Application.DTO.Sessao;
using Application.Interface;
using Application.Service;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController : ControllerBase
{
    private readonly ISessaoService _sessaoService;
    private readonly IMapper _mapper;

    public SessaoController(ISessaoService sessaoService, IMapper mapper)
    {
        _sessaoService = sessaoService;
    }

    [HttpPost]
    public async Task<IActionResult> CadastraSessao([FromBody] CreateSessaoDTO createSessaoDTO)
    {
        if (createSessaoDTO == null)
        {
            return BadRequest();
        }

        Sessao sessao = _mapper.Map<Sessao>(createSessaoDTO);

        await _sessaoService.Add(sessao);

        return CreatedAtAction(nameof(ObtemSessao), new { id = sessao }, sessao);
    }

    [HttpGet]
    public async Task<IActionResult> ObtemSessoes(int skip, int take = 10)
    {
        IEnumerable<Sessao> sessoes = await _sessaoService.GetSessoesAsync();

        IEnumerable<ReadSessaoDTO> sessoesDTO = _mapper.Map<List<ReadSessaoDTO>>(sessoes.Skip(skip).Take(take)).ToList();

        return Ok(sessoesDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtemSessao(int id)
    {
        if (id <= 0)
        {
            return NotFound();
        }

        Sessao sessao = await _sessaoService.GetSessaoByIdAsync(id);

        ReadSessaoDTO readSessaoDTO = _mapper.Map<ReadSessaoDTO>(sessao);

        return Ok(readSessaoDTO);
    }
}
