using Application.Models;
using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employee.EventHandlers
{

    public class EmployeeCompletedEventHandler : INotificationHandler<DomainEventNotification<EmployeeCompletedEvent>>
    {
        private readonly ILogger<EmployeeCompletedEventHandler> _logger;

        public EmployeeCompletedEventHandler(ILogger<EmployeeCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<EmployeeCompletedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
