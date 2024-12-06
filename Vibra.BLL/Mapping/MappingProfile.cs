using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Vibra.BLL.DTOs;
using Vibra.Domain.Artist;
using Vibra.Domain.User;

namespace Vibra.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StandardUserEntity, AddStandardUserDto>();
            CreateMap<AddStandardUserDto, StandardUserEntity>();

            CreateMap<StandardUserEntity, StandardUserDto>();
            CreateMap<StandardUserDto, StandardUserEntity>();

            CreateMap<StandardUserLoginDto, StandardUserDto>();

            CreateMap<ArtistEntity, AddArtistProfileDto>();
            CreateMap<AddArtistProfileDto, ArtistEntity>();
        }
    }
}
