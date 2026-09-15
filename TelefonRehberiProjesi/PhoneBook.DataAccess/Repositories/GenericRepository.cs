using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Interfaces;
using PhoneBook.DataAccess.Context;

namespace PhoneBook.DataAccess.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly PhoneBookDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(PhoneBookDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public IQueryable<T> GetAll() => _dbSet.AsNoTracking();

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);
}