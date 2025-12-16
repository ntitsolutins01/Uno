namespace LibraryApi.Domain.Entities;

public class Genre : BaseAuditableEntity
{
    public required string Name { get; set; }
}
