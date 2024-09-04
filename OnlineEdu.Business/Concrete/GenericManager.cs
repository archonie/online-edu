using System.Linq.Expressions;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;

namespace OnlineEdu.Business.Concrete;

public class GenericManager<T>(IRepository<T> _repository) : IGenericService<T> where T : class
{
    
    public List<T> TGetList()
    {
        return _repository.GetList();
    }

    public T TGetById(int id)
    {
        return _repository.GetById(id);
    }

    public T TGetByFilter(Expression<Func<T, bool>> predicate)
    {
        return _repository.GetByFilter(predicate);
    }

    public void TCreate(T entity)
    {
        _repository.Create(entity);
    }

    public void TUpdate(T entity)
    {
        _repository.Update(entity);
    }

    public void TDelete(int id)
    {
        _repository.Delete(id);
    }

    public int TCount()
    {
        return _repository.Count();
    }

    public int TFilteredCount(Expression<Func<T, bool>> predicate)
    {
        return _repository.FilteredCount(predicate);
    }

    public List<T> TGetFilteredList(Expression<Func<T, bool>> predicate)
    {
        return _repository.GetFilteredList(predicate);
    }
    
}