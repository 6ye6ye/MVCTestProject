namespace BLL.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LostAnimal, LostAnimalDtoAdd>().ReverseMap();
        CreateMap<LostAnimal, LostAnimalDtoGetShort>().ReverseMap();
        CreateMap<LostAnimal, LostAnimalDtoGetFull>().ReverseMap();
        CreateMap<LostAnimal, LostAnimalViewModelAdd>()
             .ForMember(dest => dest.LostAnimal, opt => opt.MapFrom(src => src))
             .ReverseMap();

        CreateMap<District, DistrictDtoGet>().ReverseMap();
        CreateMap<District, DistrictViewModel>().ReverseMap();
        CreateMap<User, RegisterViewModel>().ReverseMap();
        CreateMap<User, LoginViewModel>().ReverseMap();
    }
}
