using LibraryApi.Domain.Exceptions;
using LibraryApi.Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace LibraryApi.Domain.UnitTests.ValueObjects;

public class LanguageTests
{
    [Test]
    public void ShouldReturnCorrectLanguageCode()
    {
        var code = "En";

        var language = Language.From(code);

        language.Code.Should().Be(code);
    }

    [Test]
    public void ToStringReturnsCode()
    {
        var language = Language.Portuguese;

        language.ToString().Should().NotBe(language.Code);
    }

    [Test]
    public void ShouldPerformImplicitConversionToLanguageCodeString()
    {
        string code = Language.English;

        code.Should().Be("En");
    }

    [Test]
    public void ShouldPerformExplicitConversionGivenSupportedLanguageCode()
    {
        var language = (Language)"En";

        language.Should().Be(Language.English);
    }

    [Test]
    public void ShouldThrowUnsupportedLanguageExceptionGivenNotSupportedLanguageCode()
    {
        FluentActions.Invoking(() => Language.From("Es"))
            .Should().Throw<UnsupportedLanguageException>();
    }
}
