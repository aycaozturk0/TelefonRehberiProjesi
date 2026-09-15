using Microsoft.AspNetCore.Mvc;
using PhoneBook.Business.Interfaces;
using PhoneBook.Core.Dtos;

namespace PhoneBook.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _contactService.GetAllAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ContactDto dto)
    {
        await _contactService.AddAsync(dto);
        return Ok(new { message = "Kişi başarıyla eklendi." });
    }
}