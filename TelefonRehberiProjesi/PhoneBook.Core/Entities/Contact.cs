namespace PhoneBook.Core.Entities;

public class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? Email { get; set; } // Opsiyonel (Boş bırakılabilir)
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;
}