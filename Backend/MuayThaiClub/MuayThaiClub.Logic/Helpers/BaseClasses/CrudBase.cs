using AutoMapper;
using MuayThaiClub.Database.Repositories;
using MuayThaiClub.Model;
using MuayThaiClub.Model.Dtos.Post;
using MuayThaiClub.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Logic.Helpers.BaseClasses
{
  public abstract class CrudBase<T, TCreateUpdateDto, TViewDto> where T : class, IIDentity, ICreatorID
  {
    protected Repository<T> repo;
    protected Mapper mapper;

    public CrudBase(Repository<T> repo, DtoProvider provider)
    {
      this.repo = repo;
      this.mapper = provider.mapper;
    }

    public TViewDto Get(string id)
    {
      var r = repo.GetByID(id);
      return mapper.Map<TViewDto>(r);
    }

    public virtual IEnumerable<TViewDto> GetAll()
    {
      return repo.GetAll().Select(x => mapper.Map<TViewDto>(x));
    }
    public async Task CreateAsync(TCreateUpdateDto e, string UserID)
    {
      var entity = mapper.Map<T>(e);
      entity.CreatorID = UserID;
      await repo.CreateAsync(entity);
    }
    public async Task UpdateAsync(string id, TCreateUpdateDto e, string UserID)
    {

      var ToUpdate = repo.GetByID(id);
      if (ToUpdate != null)
      {
        if (ToUpdate.CreatorID == UserID)
        {
          try
          {
            // <-- A HIBA ITT TÖRTÉNIK, amikor a Mapper hozzáér a proxyhoz!
            mapper.Map(e, ToUpdate);
            await repo.UpdateAsync(ToUpdate);
          }
          catch (Exception ex)
          {
            // Ássunk le a legalsó, eredeti SQL hibáig!
            Exception realError = ex;
            while (realError.InnerException != null)
            {
              realError = realError.InnerException;
            }

            // Dobunk egy új hibát, amit a Swagger egyből ki fog írni a képernyőre!
            throw new Exception(">>> PONTOS SQL HIBA: " + realError.Message);
          }
        }
        else
        {
          Type t = typeof(T);
          throw new UnauthorizedAccessException($"The {t.Name.ToLower()} cannot be modified " +
            "by other than the owner.");
        }
      }     
    }
    public async Task DeleteAsync(string id)
    {
      await repo.DeleteByIDAsync(id);
    }

  }
}
