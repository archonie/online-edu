using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;

namespace OnlineEdu.DataAccess.Repositories;

public class GenericRepository<T> : IRepository<T> where T : class
{
	protected readonly OnlineEduContext _context;
    public GenericRepository(OnlineEduContext context)
    {
		_context = context;
    }
    public DbSet<T> Table
	{
		get => _context.Set<T>();
	}

	public List<T> GetList()
	{
		return Table.ToList();
	}

	public T GetById(int id)
	{
		return Table.Find(id);
	}

	public T GetByFilter(Expression<Func<T, bool>> predicate)
	{
		return Table.Where(predicate).FirstOrDefault();
	}

	public void Create(T entity)
	{
		Table.Add(entity);
		_context.SaveChanges();
	}

	public void Update(T entity)
	{
		Table.Update(entity);
		_context.SaveChanges();
	}

	public void Delete(int id)
	{
		var entity = GetById(id);
		Table.Remove(entity);
		_context.SaveChanges();
	}

	public int Count()
	{
		return Table.Count();
	}

	public int FilteredCount(Expression<Func<T, bool>> predicate)
	{
		return Table.Where(predicate).Count();
	}

	public List<T> GetFilteredList(Expression<Func<T, bool>> predicate)
	{
		return Table.Where(predicate).ToList();
	}
}