using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;

namespace WebAPI.Data;

public class DataAccess : IDataAccess
{
    private ToyContext _context;

    public DataAccess(ToyContext context)
    {
        _context = context;
    }

    public async Task<Child> AddChildAsync(Child child)
    {
        EntityEntry<Child> added = await _context.AddAsync(child);
        await _context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<ICollection<string>> GetAllChildren()
    {
        return await _context.Child.Select(c => c.Name).ToListAsync();
    }

    public async Task<Toy> CreateToyAsync(Toy toy,string ChildName)
    {
        var child = _context.Child.FirstOrDefault(c => c.Name.Equals(ChildName));
        toy.child = child;
        
        EntityEntry<Toy> added = await _context.AddAsync(toy);
        await _context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<ICollection<Toy>> GetAllToys(bool? favourite, string? gender)
    {
        IQueryable<Toy> toys = _context.Toy.Include(toy => toy.child).AsQueryable();
        
        if (favourite != null && string.IsNullOrEmpty(gender)) {
            toys = toys.Where(t => t.IsFavourite == favourite);
        }
        else if(favourite == null && !string.IsNullOrEmpty(gender)) {
            toys =  toys.Where(t => t.child.Gender == gender);
        }
        else if (favourite != null && !string.IsNullOrEmpty(gender))
        {
            toys = toys.Where(t => t.child.Gender == gender && t.IsFavourite == favourite);
        }
        return await toys.ToListAsync();
    }

    public async Task DeleteToy(string toyName)
    {
        Toy? toy = _context.Toy.FirstOrDefault(t => t.Name.Equals(toyName));
        _context.Toy.Remove(toy);
        await _context.SaveChangesAsync();
    }
}