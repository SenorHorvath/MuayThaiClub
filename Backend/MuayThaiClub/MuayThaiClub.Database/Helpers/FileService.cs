using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Database.Helpers
{
  public class FileService : IFileService
  {
    private readonly string storagePath = "wwwroot/uploads/profile-pictures";

    public async Task SaveFileAsync(Stream Content, string FileName)
    {
      if (!Directory.Exists(storagePath))
      {
        Directory.CreateDirectory(storagePath);
      }
      var FilePath = Path.Combine(storagePath, FileName);

      using var FileStream = new FileStream(FilePath,
        FileMode.Create);
      await Content.CopyToAsync(FileStream);
    }

    public void DeleteFile(string FileName)
    {
      var FilePath = Path.Combine(storagePath, FileName);
      if (File.Exists(FilePath))
      {
        File.Delete(FilePath);
      }
      

    }
  }
}
