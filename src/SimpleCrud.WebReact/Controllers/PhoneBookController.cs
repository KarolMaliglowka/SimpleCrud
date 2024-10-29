using Microsoft.AspNetCore.Mvc;
using SimpleCrud.Application.Dtos;
using SimpleCrud.Core.Entities;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.WebReact.Controllers;

[ApiController]
[Route("[controller]")]
public class PhoneBookController(IPhoneBookRepository phoneBookRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<PhoneDto?>?>> GetAll()
    {
        var getAllAsync = (await phoneBookRepository.GetAllAsync())
            .ToList();
        return Ok(getAllAsync.ToList());
    }

    [HttpGet("getById/{phoneId:guid}")]
    public async Task<ActionResult<PhoneDto>> GetById(Guid phoneId)
    {
        var phone = await phoneBookRepository
            .GetAsyncById(phoneId);
        if (phone == null)
        {
            throw new NullReferenceException("No record");
        }

        return new PhoneDto
        {
            Id = phone.Id,
            Name = phone.Name,
            PhoneNumber = phone.PhoneNumber
        };
    }

    [HttpPost("create")]
    public async Task<ActionResult> Create([FromBody] PhoneDto command)
    {
        var newPhone = new PhoneBook(command.PhoneNumber, command.Name);
        await phoneBookRepository
            .AddAsync(newPhone);
        return Created();
    }

    [HttpPut("update")]
    public async Task<ActionResult<PhoneDto>> Edit([FromBody] PhoneDto command)
    {
        var phone = await phoneBookRepository
            .GetAsyncById(command.Id);
        if (phone == null)
        {
            throw new NullReferenceException("No record");
        }

        phone.PhoneNumber = command.PhoneNumber;
        phone.Name = command.Name;
        await phoneBookRepository
            .Update(phone);
        return Ok();
    }

    [HttpDelete("delete/{phoneId:guid}")]
    public async Task<ActionResult> Delete(Guid phoneId)
    {
        var phone = await phoneBookRepository
            .GetAsyncById(phoneId);
        if (phone == null)
        {
            throw new NullReferenceException("No record");
        }

        await phoneBookRepository
            .Remove(phone);
        return Ok();
    }

    [HttpGet("getByPhoneNumber/{phoneNumber}")]
    public async Task<ActionResult<PhoneDto>> GetByPhoneNumber(string phoneNumber)
    {
        var phone = await phoneBookRepository
            .GetAsyncByPhoneNumber(phoneNumber);
        if (phone == null)
        {
            throw new NullReferenceException("No record");
        }

        return new PhoneDto
        {
            Id = phone.Id,
            Name = phone.Name,
            PhoneNumber = phone.PhoneNumber
        };
    }
}