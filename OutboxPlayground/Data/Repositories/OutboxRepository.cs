// OutboxRepository.cs
using Microsoft.EntityFrameworkCore;
using Ordering.Data.Repositories.Contracts;
using Ordering.Model.Entities;

namespace Ordering.Data.Repositories
{
    public class OutboxRepository : IOutboxRepository
    {
        private readonly ApplicationContext _context;

        public OutboxRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Outbox>> GetUnprocessedMessagesAsync(CancellationToken cancellationToken)
        {
            return await _context.Outbox
                .ToListAsync(cancellationToken);
        }

        public async Task DeleteMessageAsync(Guid id, DateTime dateTime, string action, CancellationToken cancellationToken)
        {
            var message = await _context.Outbox
                .FirstOrDefaultAsync(m => m.Id == id && dateTime == m.EventDate && action == m.Action, cancellationToken);
            if (message != null)
            {
                _context.Outbox.Remove(message);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}