using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using DatingApp.API.Helpers;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Users, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, 
                    opt => opt.MapFrom(src =>src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.Age, 
                    opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge() ));
            CreateMap<Users, UserForDetailedDto>()
                .ForMember(dest => dest.Age, 
                opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge() ));
            CreateMap<Photo, PhotosForDetailedDto>();
        }
    }
}