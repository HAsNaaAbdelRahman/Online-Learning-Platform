using AutoMapper;
using Online_Learning_Platform.Core.Models;
using Online_Learning_Platform.DTO;

namespace Online_Learning_Platform.Helper
{
    public class ModuleProfile : Profile
    {
        public ModuleProfile()
        {
            CreateMap<Module, AddModulesInToCourse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId));
            CreateMap<AddModulesInToCourse, Module>();

        }
    }
}
