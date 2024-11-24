using System.Text.Json;
using MassTransit;
using Ordering.Data.Repositories.Contracts;

namespace Ordering.Events;

public class OutboxBackgroundService(
    IBus bus,
    IServiceProvider serviceProvider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Starting OutboxBackgroundService");
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = serviceProvider.CreateScope();
                var outboxRepository = scope.ServiceProvider.GetRequiredService<IOutboxRepository>();
                var messages = await outboxRepository.GetUnprocessedMessagesAsync(stoppingToken);
                foreach (var message in messages)
                {
                    Console.WriteLine($"Publishing message: {message.Id}");

                    var payload = JsonSerializer.Deserialize(message.Payload, Type.GetType($"Ordering.Model.Entities.{message.Type}")!);
                    await bus.Publish(payload!, stoppingToken);
                    await outboxRepository.DeleteMessageAsync(message.Id, message.EventDate, message.Action,
                        stoppingToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}