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

public class IngredienteController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public IngredienteController(IUnitOfWork unitOfWork, IMapper mapper)
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
    public async  Task<ActionResult<IEnumerable<IngredientesDto>>> Get()
    {
        var ingredientes = await _unitOfWork.Ingredientes.GetAllAsync();
        return _mapper.Map<List<IngredientesDto>>(ingredientes);
    }
    
    
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<IngredientesDto>>> Get11([FromQuery] Params ingredienteParams)
    {
        var (totalRegistros, registros) = await _unitOfWork.Ingredientes.GetAllAsync(ingredienteParams.PageIndex,ingredienteParams.PageSize,ingredienteParams.Search);
        var lstIngredientesDto = _mapper.Map<List<IngredientesDto>>(registros);
        return new Pager<IngredientesDto>(lstIngredientesDto,totalRegistros,ingredienteParams.PageIndex,ingredienteParams.PageSize,ingredienteParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IngredientesDto>> Get(int id)
    {
        var ingrediente = await _unitOfWork.Ingredientes.GetByIdAsync(id.ToString());
        if (ingrediente == null){
            return NotFound();
        }
        return _mapper.Map<IngredientesDto>(ingrediente);
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
    public async Task<ActionResult<IngredientesDto>> Post(IngredientesDto ingredientesDto){
        var ingrediente = _mapper.Map<Ingredientes>(ingredientesDto);
        this._unitOfWork.Ingredientes.Add(ingrediente);
        await _unitOfWork.SaveAsync();
        if (ingrediente == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= ingrediente.Id}, ingredientesDto);
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
    public async Task<ActionResult<IngredientesDto>> Put(int id, [FromBody]IngredientesDto ingredientesaDto){
        if(ingredientesaDto == null)
            return NotFound();
        var Ingrediente = _mapper.Map<Ingredientes>(ingredientesaDto);
        _unitOfWork.Ingredientes.Update(Ingrediente);
        await _unitOfWork.SaveAsync();
        return ingredientesaDto;
        
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int  id){
        var ingredientes = await _unitOfWork.Ingredientes.GetByIdAsync(id.ToString());
        if(ingredientes == null){
            return NotFound();
        }
        _unitOfWork.Ingredientes.Remove(ingredientes);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}