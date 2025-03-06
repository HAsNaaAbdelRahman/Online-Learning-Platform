using AutoMapper;
using Online_Learning_Platform.Core.Models;
using Online_Learning_Platform.DTO;

namespace Online_Learning_Platform.Helper
{
    public class EnrollmentsProfile:Profile
    {
        public EnrollmentsProfile()
        {
            CreateMap<Enrollment, EnrollmentRequest>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId)).ReverseMap();
        }
    }
}
