using AutoMapper;
using MuayThaiClub.Model.Dtos.Comment;
using MuayThaiClub.Model.Dtos.Post;
using MuayThaiClub.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Logic.Helpers
{
  public class DtoProvider
  {
    public Mapper mapper { get; set; }

    public DtoProvider()
    {
      this.mapper = new Mapper(new MapperConfiguration(cfg => 
      {
        cfg.CreateMap<PostCreateUpdateDto, Post>()
            .ForMember(dest => dest.Comments, opt => opt.Ignore());
        cfg.CreateMap<Post, PostViewDto>();

        cfg.CreateMap<CommentCreateUpdateDto, Comment>();
        cfg.CreateMap<Comment, CommentViewDto>();

      }));
    }
  }
}
