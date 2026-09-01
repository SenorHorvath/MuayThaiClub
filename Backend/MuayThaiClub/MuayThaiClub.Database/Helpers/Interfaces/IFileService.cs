using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Database.Helpers.Interfaces
{
  public interface IFileService
  {
    public Task SaveFileAsync(Stream Content, string FileName);
    public void DeleteFile(string FileName);
  }
}
