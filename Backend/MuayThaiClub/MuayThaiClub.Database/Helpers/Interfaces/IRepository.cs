using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Database.Helpers.Interfaces
{
  public interface IRepository<T>
  {
    //public void Create(T entity);

    public Task CreateAsync(T entity);

    public Task UpdateAsync(T entity);
    //public void Update(T entity);

    //public void Delete(T entity);

    public Task DeleteAsync(T entity);

    public T GetByID(string id);

    public IEnumerable<T> GetAll();

    //public void DeleteByID(string id);

    public Task DeleteByIDAsync(string id);
  }
}
