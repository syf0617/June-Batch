using Microsoft.EntityFrameworkCore;

namespace Generics;

public class GenericRepository<T>(DbContext context) : IRepository<T>
    where T : Entity, new()
{
    private DbSet<T> _dbSet = context.Set<T>();

    public void Add(T? item)
    {
        if (item != null) _dbSet.Add(item);
    }

    public void Remove(T item) {
        var existing = _dbSet.Find(item.Id);
        if (existing != null) {
            _dbSet.Remove(existing);
        }
    }

    public void Save() {
        context.SaveChanges();
    }

    public IEnumerable<T?> GetAll() {
        return _dbSet.AsNoTracking().ToList();
    }

    public T? GetById(int id) {
        return _dbSet.Find(id);
    }
}