using AutoMapper;
using Online_Learning_Platform.Core.Models;
using Online_Learning_Platform.DTO;

namespace Online_Learning_Platform.Helper
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, AddNewCourse>()
                .ForMember(dest => dest.Name , opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description , opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));

            CreateMap<Course, UpdateCourseDetails>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<Course , UpdateCourseInfoDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));

            CreateMap<AddNewCourse, Course>();
            CreateMap<UpdateCourseInfoDto, Course>();
            CreateMap<UpdateCourseDetails , Course>();


        }
    }
}
