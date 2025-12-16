using LibraryApi.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LibraryApi.Infrastructure.IntegrationTests.Book;

[TestFixture]
public class BookConfigurationTests
{
    // Helper method to create a test EntityTypeBuilder
    private static EntityTypeBuilder<T> GetEntityBuilder<T>() where T : class
    {
        // Suppress EF1001 warning for internal API usage in tests
#pragma warning disable EF1001
        var entityType = new EntityType(typeof(T).Name, typeof(T), new Model(), false, ConfigurationSource.Convention);
        var builder = new EntityTypeBuilder<T>(entityType);
        return builder;
#pragma warning restore EF1001
    }
    [Test]
    public void Configure_ShouldApplyCorrectConfiguration()
    {
        // Arrange
        var configuration = new BookConfiguration();
        var builder = GetEntityBuilder<Domain.Entities.Book>();

        // Act
        configuration.Configure(builder);

        // Assert
        var metadata = builder.Metadata;

        Assert.That(metadata.FindPrimaryKey()?.Properties[0].Name, Is.EqualTo(nameof(Domain.Entities.Book.Id)));
        Assert.That(metadata.FindProperty(nameof(Domain.Entities.Book.Title)) is { IsNullable: true }, Is.False);
        Assert.That(metadata.FindProperty(nameof(Domain.Entities.Book.ToString))?.GetMaxLength(), Is.EqualTo(200));
        Assert.That(metadata.GetTableName(), Is.EqualTo("Books"));
    }
}
