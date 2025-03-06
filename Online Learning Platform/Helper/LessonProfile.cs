using AutoMapper;
using Online_Learning_Platform.Core.Models;
using Online_Learning_Platform.DTO;

namespace Online_Learning_Platform.Helper
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            CreateMap<Lesson, AddLessonsIntoModules>()
    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
    .ForMember(dest => dest.ModuleId, opt => opt.MapFrom(src => src.ModuleId));
            CreateMap<AddLessonsIntoModules, Lesson>();

        }
    }
}
