using System.ComponentModel;

namespace LibraryApi.Domain.ValueObjects;

public class Language(string code) : ValueObject
{
    public static Language From(string code)
    {
        var language = new Language(code);

        return !SupportedLanguages.Contains(language) ? throw new UnsupportedLanguageException(code) : language;
    }

    public static Language English => new("En");

    public static Language Portuguese => new("Pt");

    public string Code { get; private set; } = string.IsNullOrWhiteSpace(code)?"":code;

    public static implicit operator string(Language language)
    {
        return language.ToString();
    }

    public static explicit operator Language(string code)
    {
        return From(code);
    }

    public override string ToString()
    {
        return Code switch
        {
            "En" => "English",
            "Pt" => "Portuguese",
            _ => Code
        };
    }

    protected static IEnumerable<Language> SupportedLanguages
    {
        get
        {
            yield return English;
            yield return Portuguese;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}
