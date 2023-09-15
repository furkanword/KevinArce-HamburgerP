using API.Controllers;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class HambuerguesaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public HambuerguesaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
   /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<Area>>> Get()
    {
        var regiones = await _unitOfWork.Areas.GetAllAsync();
        return Ok(regiones);
    }*/
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<HamburguesaDto>>> Get()
    {
        var hamburguesas = await _unitOfWork.Hamburguesas.GetAllAsync();
        return _mapper.Map<List<HamburguesaDto>>(hamburguesas);
    }

    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<HamburguesaDto>>> Get11([FromQuery] Params hamburguesaParams)
    {
        var (totalRegistros, registros) = await _unitOfWork.Hamburguesas.GetAllAsync(hamburguesaParams.PageIndex,hamburguesaParams.PageSize,hamburguesaParams.Search);
        var lsthamburguesDto = _mapper.Map<List<HamburguesaDto>>(registros);
        return new Pager<HamburguesaDto>(lsthamburguesDto,totalRegistros,hamburguesaParams.PageIndex,hamburguesaParams.PageSize,hamburguesaParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<HamburguesaDto>> Get(int id)
    {
        var hamburguesas = await _unitOfWork.Hamburguesas.GetByIdAsync(id.ToString());
        if (hamburguesas == null){
            return NotFound();
        }
        return _mapper.Map<HamburguesaDto>(hamburguesas);
    }
    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Post(Area area){
        this._unitOfWork.Areas.Add(area);
        await _unitOfWork.SaveAsync();
        if (area == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= area.Id}, area);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HamburguesaDto>> Post(HamburguesaDto hamburguesasDto){
        var hamburguesa = _mapper.Map<Hamburguesas>(hamburguesasDto);
        this._unitOfWork.Hamburguesas.Add(hamburguesa);
        await _unitOfWork.SaveAsync();
        if (hamburguesa == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= hamburguesa.Id}, hamburguesasDto);
    }
    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area area){
        if(area == null)
            return NotFound();
        _unitOfWork.Areas.Update(area);
        await _unitOfWork.SaveAsync();
        return area;
        
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HamburguesaDto>> Put(int id, [FromBody]HamburguesaDto hamburguesaDto){
        if(hamburguesaDto == null)
            return NotFound();
        var hamburguesa = _mapper.Map<Hamburguesas>(hamburguesaDto);
        _unitOfWork.Hamburguesas.Update(hamburguesa);
        await _unitOfWork.SaveAsync();
        return hamburguesaDto;
        
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int  id){
        var hamburguesas = await _unitOfWork.Hamburguesas.GetByIdAsync(id.ToString());
        if(hamburguesas == null){
            return NotFound();
        }
        _unitOfWork.Hamburguesas.Remove(hamburguesas);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}