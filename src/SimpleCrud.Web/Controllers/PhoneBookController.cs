using Microsoft.AspNetCore.Mvc;
using SimpleCrud.Application.Abstractions.Dispatchers;
using SimpleCrud.Application.Dtos;
using SimpleCrud.Application.Queries;
using SimpleCrud.Core.Entities;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class PhoneBookController(IPhoneBookRepository phoneBookRepository, IDispatcher dispatcher)
    : ControllerBase
{
    [HttpGet]   
    public async Task<ActionResult<List<PhoneDto>>> GetAll()
    {
        var test = await dispatcher.QueryAsync(new GetPhonesNumbers());
        return Ok(test);
    }
    
    [HttpGet("getById/{phoneId:guid}")]
    public async Task<ActionResult<PhoneDto>> GetById(Guid phoneId)
    {
        
        var phone = await phoneBookRepository.GetAsyncById(phoneId);
        return new PhoneDto(phone.Id, phone.Name, phone.PhoneNumber);
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> Create([FromBody] PhoneDto command)
    {
        var newPhone = new PhoneBook(command.PhoneNumber, command.Name);
        await phoneBookRepository.AddAsync(newPhone);
        return Ok();
    }
    
    [HttpPut("update/{phoneId:guid}")]
    public async Task<ActionResult<PhoneDto>> Edit(Guid phoneId, [FromBody] PhoneDto command)
    {
        var phone = await phoneBookRepository.GetAsyncById(phoneId);
        phone.PhoneNumber = command.PhoneNumber;
        phone.Name = command.PhoneNumber;
        await phoneBookRepository.UpdateAsync(phone);
        return Ok();
    }
    
    [HttpDelete("delete/{phoneId:guid}")]
    public async Task<ActionResult> Delete(Guid phoneId)
    {
        var phone = await phoneBookRepository.GetAsyncById(phoneId);
        await phoneBookRepository.Remove(phone);
        return Ok();
    }
    
    [HttpGet("getByPhoneNumber/{phoneNumber}")]
    public async Task<ActionResult<PhoneDto>> GetByPhoneNumber(string phoneNumber)
    {
        var phone = await phoneBookRepository.GetAsyncByPhoneNumber(phoneNumber);
        return new PhoneDto(phone.Id, phone.Name, phone.PhoneNumber);
    }
}