using Application.DTO.Cinema;
using Application.DTO.Endereco;
using Application.Interface;
using Application.Service;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private readonly IEnderecoService _enderecoService;
    private readonly IMapper _mapper;

    public EnderecoController(IEnderecoService enderecoService, IMapper mapper)
    {
        _enderecoService = enderecoService;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CadastraEndereco([FromBody] CreateEnderecoDTO createEnderecoDTO)
    {
        if (createEnderecoDTO == null)
        {
            return BadRequest();
        }

        // Cria uma novo objeto a partir da DTO
        Endereco endereco = _mapper.Map<Endereco>(createEnderecoDTO);

        await _enderecoService.Add(endereco);

        return CreatedAtAction(nameof(ObtemEndereco), new { id = endereco }, endereco);
    }

    [HttpGet]
    public async Task<IActionResult> ObtemEnderecos(int skip, int take = 10)
    {
        IEnumerable<Endereco> enderecos = await _enderecoService.GetEnderecosAsync();

        IEnumerable<ReadEnderecoDTO> readEnderecoDTOs = _mapper.Map<List<ReadEnderecoDTO>>(enderecos.Skip(skip).Take(take));

        return Ok(readEnderecoDTOs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtemEndereco(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        Endereco endereco = await _enderecoService.GetEnderecoByIdAsync(id);

        ReadEnderecoDTO readEnderecoDTO = _mapper.Map<ReadEnderecoDTO>(endereco);

        return Ok(readEnderecoDTO);
    }
}
