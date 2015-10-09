using System;
using System.Linq;

namespace ParkingSpace.DataAccess.Core {
  public interface IRepository<T> : IRepository, IDisposable where T : class { // โดย T จะต้องมี Type เป็น Class

    IQueryable<T> Query(Func<T, bool> predicate);

    T Add(T item);

    T Remove(T item);

    int SaveChanges();

  }
}
