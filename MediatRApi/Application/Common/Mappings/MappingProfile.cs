using AutoMapper;
using MediatRApi.Application.Common.Models;
using MediatRApi.Entities;

namespace MediatRApi.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Add your mappings here
        // Example:
        // CreateMap<SourceModel, DestinationModel>();
        CreateMap<DemoEntity, DemoEntityResponse>();
    }
} 