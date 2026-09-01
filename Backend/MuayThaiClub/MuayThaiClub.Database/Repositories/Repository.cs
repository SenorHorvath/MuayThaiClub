using Microsoft.EntityFrameworkCore;
using MuayThaiClub.Database.Helpers.Interfaces;
using MuayThaiClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Database.Repositories
{
  public class Repository<T> : IRepository<T> where T : class, IIDentity
  {
    protected MuayThaiContext ctx;

    public Repository(MuayThaiContext ctx)
    {
      this.ctx = ctx;
    }

    public void Create(T entity) 
    { 
      ctx.Set<T>().Add(entity);
      ctx.SaveChanges();
    }

    public async Task CreateAsync(T entity)
    {

      ctx.Set<T>().Add(entity);
      await ctx.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
      var old = GetByID(entity.ID);
      foreach (var prop in typeof(T).GetProperties())
      {
        prop.SetValue(old, prop.GetValue(entity));
      }
      ctx.Set<T>().Update(old);
      await ctx.SaveChangesAsync();
    }
    public void Update(T entity) 
    {
      var old = GetByID(entity.ID);
      foreach (var prop in typeof(T).GetProperties()) 
      { 
        prop.SetValue(old, prop.GetValue(entity));
      }
      ctx.Set<T>().Update(old);
      ctx.SaveChanges();

    }

    public void Delete(T entity) 
    {
      ctx.Set<T>().Remove(entity);
      ctx.SaveChanges();
    }

    public async Task DeleteAsync(T entity)
    {
      ctx.Set<T>().Remove(entity);
      await ctx.SaveChangesAsync();
    }

    public T GetByID(string id)
    {
      try
      {

      return GetAll().First(t => t.ID == id);
      }
      catch (Exception sqlEx)
      {
        throw new Exception("A hiba: " + sqlEx.Message);
      }
    }

    public IEnumerable<T> GetAll() 
    {
      return ctx.Set<T>();
    }

    public void DeleteByID(string id) 
    {
      var entity = GetByID(id);
      Delete(entity);
    }

    public async Task DeleteByIDAsync(string id)
    {
      var entity = GetByID(id);
      await DeleteAsync(entity);
    }
  }
}
