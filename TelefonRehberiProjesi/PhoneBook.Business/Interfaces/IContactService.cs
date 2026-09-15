using PhoneBook.Core.Dtos;

namespace PhoneBook.Business.Interfaces;

public interface IContactService
{
    Task<List<ContactDto>> GetAllAsync();
    Task<ContactDto?> GetByIdAsync(int id);
    Task AddAsync(ContactDto contactDto);
    Task UpdateAsync(ContactDto contactDto);
    Task DeleteAsync(int id);
}