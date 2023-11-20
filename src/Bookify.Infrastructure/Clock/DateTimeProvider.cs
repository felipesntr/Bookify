using Bookify.Application.Abstractions.Clock;

namespace Bookify.Infrastructure.Clock;
internal class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

