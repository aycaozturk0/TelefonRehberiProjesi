using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Business.Interfaces;
using PhoneBook.Core.Dtos;
using PhoneBook.Core.Entities;
using PhoneBook.Core.Interfaces;

namespace PhoneBook.Business.Services;

public class ContactService : IContactService
{
    private readonly IGenericRepository<Contact> _repository;
    private readonly IMapper _mapper;

    public ContactService(IGenericRepository<Contact> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ContactDto>> GetAllAsync()
    {
        var contacts = await _repository.GetAll().ToListAsync();
        return _mapper.Map<List<ContactDto>>(contacts);
    }

    public async Task<ContactDto?> GetByIdAsync(int id)
    {
        var contact = await _repository.GetByIdAsync(id);
        return _mapper.Map<ContactDto>(contact);
    }

    public async Task AddAsync(ContactDto contactDto)
    {
        var entity = _mapper.Map<Contact>(contactDto);
        await _repository.AddAsync(entity);
        // Not: Gerçek projede burada bir UnitOfWork.Save() gerekir 
        // ama şu an GenericRepository üzerinden ilerliyoruz.
    }

    public async Task UpdateAsync(ContactDto contactDto)
    {
        var entity = _mapper.Map<Contact>(contactDto);
        _repository.Update(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity != null)
        {
            _repository.Delete(entity);
        }
    }
}