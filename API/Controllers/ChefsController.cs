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

public class ChefsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ChefsController(IUnitOfWork unitOfWork, IMapper mapper)
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
    public async  Task<ActionResult<IEnumerable<ChefsDto>>> Get()
    {
        var Chefs = await _unitOfWork.Chefs.GetAllAsync();
        return _mapper.Map<List<ChefsDto>>(Chefs);
    }
    
    
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ChefsDto>>> Get11([FromQuery] Params ChefsParams)
    {
        var (totalRegistros, registros) = await _unitOfWork.Chefs.GetAllAsync(ChefsParams.PageIndex,ChefsParams.PageSize,ChefsParams.Search);
        var lstChefsDto = _mapper.Map<List<ChefsDto>>(registros);
        return new Pager<ChefsDto>(lstChefsDto,totalRegistros,ChefsParams.PageIndex,ChefsParams.PageSize,ChefsParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ChefsDto>> Get(int id)
    {
        var chefs = await _unitOfWork.Chefs.GetByIdAsync(id.ToString());
        if (chefs == null){
            return NotFound();
        }
        return _mapper.Map<ChefsDto>(chefs);
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
    public async Task<ActionResult<ChefsDto>> Post(ChefsDto chefsDto){
        var chefs = _mapper.Map<Chefs>(chefsDto);
        this._unitOfWork.Chefs.Add(chefs);
        await _unitOfWork.SaveAsync();
        if (chefs == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= chefs.Id}, chefsDto);
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
    public async Task<ActionResult<ChefsDto>> Put(int id, [FromBody]ChefsDto chefsDto){
        if(chefsDto == null)
            return NotFound();
        var chefs = _mapper.Map<Chefs>(chefsDto);
        _unitOfWork.Chefs.Update(chefs);
        await _unitOfWork.SaveAsync();
        return chefsDto;
        
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int  id){
        var chefs = await _unitOfWork.Chefs.GetByIdAsync(id.ToString());
        if(chefs == null){
            return NotFound();
        }
        _unitOfWork.Chefs.Remove(chefs);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}