using Microsoft.AspNetCore.Mvc;
using SimpleCrud.Application.Dtos;
using SimpleCrud.Core.Entities;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class PhoneBookController : ControllerBase
{
    public readonly IPhoneBookRepository PhoneBookRepository;

    public PhoneBookController(IPhoneBookRepository phoneBookRepository)
    {
        PhoneBookRepository = phoneBookRepository;
    }

    [HttpGet]   
    public async Task<ActionResult<IEnumerable<PhoneDto>>> GetAll()
    {
        return null;
    }
    
    [HttpGet("getById/{phoneId:guid}")]
    public async Task<ActionResult<PhoneDto>> GetById(Guid phoneId)
    {
        var phone = await PhoneBookRepository.GetAsyncById(phoneId);
        return new PhoneDto(phone.Id, phone.Name, phone.PhoneNumber);
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> Create([FromBody] PhoneDto command)
    {
        var newPhone = new PhoneBook(command.PhoneNumber, command.Name);
        await PhoneBookRepository.AddAsync(newPhone);
        return Ok();
    }
    
    [HttpPut("update/{phoneId:guid}")]
    public async Task<ActionResult<PhoneDto>> Edit(Guid phoneId, [FromBody] PhoneDto command)
    {
        var phone = await PhoneBookRepository.GetAsyncById(phoneId);
        phone.PhoneNumber = command.PhoneNumber;
        phone.Name = command.PhoneNumber;
        await PhoneBookRepository.UpdateAsync(phone);
        return Ok();
    }
    
    [HttpDelete("delete/{phoneId:guid}")]
    public async Task<ActionResult> Delete(Guid phoneId)
    {
        var phone = await PhoneBookRepository.GetAsyncById(phoneId);
        await PhoneBookRepository.Remove(phone);
        return Ok();
    }
    
    [HttpGet("getByPhoneNumber/{phoneNumber}")]
    public async Task<ActionResult<PhoneDto>> GetByPhoneNumber(string phoneNumber)
    {
        var phone = await PhoneBookRepository.GetAsyncByPhoneNumber(phoneNumber);
        return new PhoneDto(phone.Id, phone.Name, phone.PhoneNumber);
    }
}