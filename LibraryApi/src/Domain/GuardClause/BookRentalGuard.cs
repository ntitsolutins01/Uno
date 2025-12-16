using Ardalis.GuardClauses;

namespace LibraryApi.Domain.GuardClause;
public static class BookRentalGuard
{
    public static void BookRent(this IGuardClause guardClause, bool input)
    {
        if (input)
        {
            throw new ArgumentException("This book is rented");
        }
    }
}
