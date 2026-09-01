using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MuayThaiClub.Database.Helpers;
using MuayThaiClub.Database.Helpers.Interfaces;
using MuayThaiClub.Logic.Helpers;
using MuayThaiClub.Logic.Helpers.Interfaces;
using MuayThaiClub.Model.Dtos.User;
using MuayThaiClub.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Logic
{
  public class UserLogic : IUserLogic
  {
    private IRepository<User> repo;
    private UserManager<AppUser> userManager;
    private readonly IFileService fileService;
    private Mapper mapper;

    public UserLogic(IRepository<User> repo, UserManager<AppUser> userManager,
      IFileService fileService, DtoProvider dto)
    {
      this.repo = repo;
      this.userManager = userManager;
      this.fileService = fileService;
      this.mapper = dto.mapper;
    }

    public async Task ChangeProfilePicture(UserFileUploadDto file, string UserID)
    {
      var AllowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

      if (!AllowedExtensions.Contains(file.Extension))
      {

        throw new ArgumentException("Invalid file extension" + file.Extension);
      }

      string FileName = Guid.NewGuid().ToString() + file.Extension;
      var User = repo.GetByID(UserID);

      await fileService.SaveFileAsync(file.Content, FileName);

      if (!string.IsNullOrEmpty(User.PhotoUrl))
      {
        fileService.DeleteFile(User.PhotoUrl);
      }

      User.PhotoUrl = FileName;
      await repo.UpdateAsync(User);

    }

  }
}
