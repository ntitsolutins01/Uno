using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Books.Queries;

public class LanguageDto
{
    public required string Code { get; init; }
    public required string Language { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Book, LanguageDto>()
                .ForMember(dest => dest.Code,
                    opt => opt.MapFrom(src => src.Language.Code))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language.ToString()));
        }
    }
}
