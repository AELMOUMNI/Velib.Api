using AutoMapper;
using Dtos = Velib.Api.Models;
using Entities = Velib.Core.Entities;

namespace Velib.Api.Profiles
{
    public class Configprofile : Profile
    {
        public Configprofile()
        {
            CreateMap<Entities.Parameters, Dtos.Parameters>()
                .ForMember(dest => dest.DataSet, opt => opt.MapFrom(src => src.DataSet))
                .ForMember(dest => dest.Format, opt => opt.MapFrom(src => src.Format))
                .ForMember(dest => dest.Rows, opt => opt.MapFrom(src => src.Rows))
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Start))
                .ForMember(dest => dest.Timezone, opt => opt.MapFrom(src => src.Timezone))
                .ReverseMap();

            CreateMap<Entities.VelibAvailableReelTime, Dtos.VelibAvailableReelTimeResponse>()
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Fields.Capacity))
                .ForMember(dest => dest.CoordonneesGeo, opt => opt.MapFrom(src => src.Fields.CoordonneesGeo))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.Fields.DueDate))
                .ForMember(dest => dest.Ebike, opt => opt.MapFrom(src => src.Fields.Ebike))
                .ForMember(dest => dest.IsInstalled, opt => opt.MapFrom(src => src.Fields.IsInstalled))
                .ForMember(dest => dest.IsRenting, opt => opt.MapFrom(src => src.Fields.IsRenting))
                .ForMember(dest => dest.IsReturning, opt => opt.MapFrom(src => src.Fields.IsReturning))
                .ForMember(dest => dest.Mechanical, opt => opt.MapFrom(src => src.Fields.Mechanical))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Fields.Name))
                .ForMember(dest => dest.NomArrondissementCommunes, opt => opt.MapFrom(src => src.Fields.NomArrondissementCommunes))
                .ForMember(dest => dest.Numbikesavailable, opt => opt.MapFrom(src => src.Fields.Numbikesavailable))
                .ForMember(dest => dest.Numdocksavailable, opt => opt.MapFrom(src => src.Fields.Numdocksavailable))
                .ForMember(dest => dest.StationCode, opt => opt.MapFrom(src => src.Fields.Stationcode));
        }
    }
}
