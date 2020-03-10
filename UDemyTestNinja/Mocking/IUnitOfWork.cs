using System.Linq;

namespace UDemyTestNinja.Mocking
{
    public interface IUnitOfWork
    {
        IQueryable<T> Query<T>();
    }
}