using Ordering.Model.Entities;

namespace Ordering.Data.Repositories.Contracts;

public interface IOutboxRepository
{
    Task<IEnumerable<Outbox>> GetUnprocessedMessagesAsync(CancellationToken cancellationToken);
    Task DeleteMessageAsync(Guid id, DateTime dateTime, string action, CancellationToken cancellationToken);
}