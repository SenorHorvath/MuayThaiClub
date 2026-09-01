using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Model.Objects
{
  public class User : IIDentity
  {
    [Key]
    public string AppUserID { get; set; } = "";
    public string UserName { get; set; } = "";
    public string EmailAddress { get; set; } = "";
    public string PhotoUrl { get; set; } = "";
    public DateTime DateOfBirth { get; set; } = new DateTime();
    [NotMapped]
    public string ID 
    { 
      get => AppUserID;
      set => AppUserID = value;
    }
  }
}
