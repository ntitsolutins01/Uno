namespace LibraryApi.Domain.Entities;

public class BookRental : BaseAuditableEntity
{
    public required Book Book { get; set; }
    public required string UserId { get; set; }
    public DateTime? RentalDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
