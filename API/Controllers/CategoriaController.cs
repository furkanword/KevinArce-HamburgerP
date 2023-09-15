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

public class CategoriaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoriaController(IUnitOfWork unitOfWork, IMapper mapper)
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
    public async  Task<ActionResult<IEnumerable<CategoriasDto>>> Get()
    {
        var categorias = await _unitOfWork.Categorias.GetAllAsync();
        return _mapper.Map<List<CategoriasDto>>(categorias);
    }
    
    
 
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CategoriasDto>>> Get11([FromQuery] Params categoriaParams)
    {
        var (totalRegistros, registros) = await _unitOfWork.Categorias.GetAllAsync(categoriaParams.PageIndex,categoriaParams.PageSize,categoriaParams.Search);
        var lstCategoriasDto = _mapper.Map<List<CategoriasDto>>(registros);
        return new Pager<CategoriasDto>(lstCategoriasDto,totalRegistros,categoriaParams.PageIndex,categoriaParams.PageSize,categoriaParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriasDto>> Get(int id)
    {
        var categorias = await _unitOfWork.Categorias.GetByIdAsync(id.ToString());
        if (categorias == null){
            return NotFound();
        }
        return _mapper.Map<CategoriasDto>(categorias);
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
    public async Task<ActionResult<Categorias>> Post(CategoriasDto categoriasDto){
        var categoria = _mapper.Map<Categorias>(categoriasDto);
        this._unitOfWork.Categorias.Add(categoria);
        await _unitOfWork.SaveAsync();
        if (categoria == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= categoria.Id}, categoriasDto);
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
    public async Task<ActionResult<CategoriasDto>> Put(int id, [FromBody]CategoriasDto categoriasDto){
        if(categoriasDto == null)
            return NotFound();
        var categorias = _mapper.Map<Categorias>(categoriasDto);
        _unitOfWork.Categorias.Update(categorias);
        await _unitOfWork.SaveAsync();
        return categoriasDto;
        
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int  id){
        var categoria = await _unitOfWork.Categorias.GetByIdAsync(id.ToString());
        if(categoria == null){
            return NotFound();
        }
        _unitOfWork.Categorias.Remove(categoria);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}