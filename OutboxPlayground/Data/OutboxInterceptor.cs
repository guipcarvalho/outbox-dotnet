using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Ordering.Model.Entities;

namespace Ordering.Data;

internal sealed class OutboxInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var entitiesToPublish = eventData.Context!.ChangeTracker.Entries()
            .Where(x => x is { Entity: IAggregateRoot, State: EntityState.Added or EntityState.Modified or EntityState.Deleted })
            .Select(x =>
            {
                var changeType = x.State switch
                {
                    EntityState.Added => "Created",
                    EntityState.Modified => "Updated",
                    EntityState.Deleted => "Deleted",
                    _ => throw new ArgumentOutOfRangeException()
                };
                
                return new Outbox
                {
                    Id = ((IAggregateRoot)x.Entity).Id,
                    Type = x.Entity.GetType().Name,
                    Action = changeType,
                    Payload = JsonSerializer.Serialize(x.Entity) //we could map to a event model here
                };
            })
            .ToList();
        
        eventData.Context!.Set<Outbox>().AddRange(entitiesToPublish);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}