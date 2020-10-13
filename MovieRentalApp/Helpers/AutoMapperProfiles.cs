using AutoMapper;
using MovieRentalApp.Dtos;
using MovieRentalApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace MovieRentalApp.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TblMovie, MovieForListDto>().ReverseMap();
            CreateMap<TblMovie, MovieForDetailedDto>().ReverseMap();
            CreateMap<TblMovieActorMapping, ActorForMappingDto>();
            CreateMap<TblMovieDirectorMapping, DirectorForMappingDto>();
            CreateMap<TblActor, ActorNameDto>();
            CreateMap<TblDirector, DirectorNameDto>();
            CreateMap<TblUser, UserForListDto>()
                .ForMember(dest => dest.Age, opt =>
                      opt.MapFrom(src => src.ADob.CalculateAge()));
            CreateMap<TblUser, UserForDetailedDto>()
                .ForMember(dest => dest.Age, opt =>
                      opt.MapFrom(src => src.ADob.CalculateAge()));
            CreateMap<TblOrder, OrderForMappingDto>().ReverseMap();
            CreateMap<TblMovie, OrderToMovieDto>();
            CreateMap<UserForUpdateDto, TblUser>();
            CreateMap<UserForRegisterDto, TblUser>();
        }

    }
}
