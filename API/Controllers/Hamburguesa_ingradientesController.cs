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

public class Hambuerguesa_IngredientesController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Hambuerguesa_IngredientesController(IUnitOfWork unitOfWork, IMapper mapper)
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
    public async  Task<ActionResult<IEnumerable<Hamburguesa_ingradientesDto>>> Get()
    {
        var hamburguesa_Ingrediente = await _unitOfWork.Hambuerguesa_Ingredientes.GetAllAsync();
        return _mapper.Map<List<Hamburguesa_ingradientesDto>>(hamburguesa_Ingrediente);
    }
    
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<Hamburguesa_ingradientesDto>>> Get11([FromQuery] Params hamburguesa_ingradienteParams)
    {
        var (totalRegistros, registros) = await _unitOfWork.Hambuerguesa_Ingredientes.GetAllAsync(hamburguesa_ingradienteParams.PageIndex,hamburguesa_ingradienteParams.PageSize,hamburguesa_ingradienteParams.Search);
        var lsthamburguesa_ingradienteDto = _mapper.Map<List<Hamburguesa_ingradientesDto>>(registros);
        return new Pager<Hamburguesa_ingradientesDto>(lsthamburguesa_ingradienteDto,totalRegistros,hamburguesa_ingradienteParams.PageIndex,hamburguesa_ingradienteParams.PageSize,hamburguesa_ingradienteParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Hamburguesa_ingradientesDto>> Get(int id)
    {
        var hamburguesa_Ingredientes = await _unitOfWork.Hambuerguesa_Ingredientes.GetByIdAsync(id.ToString());
        if (hamburguesa_Ingredientes == null){
            return NotFound();
        }
        return _mapper.Map<Hamburguesa_ingradientesDto>(hamburguesa_Ingredientes);
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
    public async Task<ActionResult<Categorias>> Post(Hamburguesa_ingradientesDto hamburguesa_IngredientesDto){
        var hamburguesa_Ingrediente = _mapper.Map<Hamburguesa_ingredientes>(hamburguesa_IngredientesDto);
        this._unitOfWork.Hambuerguesa_Ingredientes.Add(hamburguesa_Ingrediente);
        await _unitOfWork.SaveAsync();
        if (hamburguesa_Ingrediente == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= hamburguesa_Ingrediente.Id}, hamburguesa_IngredientesDto);
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
    public async Task<ActionResult<Hamburguesa_ingradientesDto>> Put(int id, [FromBody]Hamburguesa_ingradientesDto hamburguesa_IngredienteDto){
        if(hamburguesa_IngredienteDto == null)
            return NotFound();
        var hamburguesa_Ingredientes = _mapper.Map<Hamburguesa_ingredientes>(hamburguesa_IngredienteDto);
        _unitOfWork.Hambuerguesa_Ingredientes.Update(hamburguesa_Ingredientes);
        await _unitOfWork.SaveAsync();
        return hamburguesa_IngredienteDto;
        
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int  id){
        var hamburguesa_Ingredientes = await _unitOfWork.Hambuerguesa_Ingredientes.GetByIdAsync(id.ToString());
        if(hamburguesa_Ingredientes == null){
            return NotFound();
        }
        _unitOfWork.Hambuerguesa_Ingredientes.Remove(hamburguesa_Ingredientes);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}