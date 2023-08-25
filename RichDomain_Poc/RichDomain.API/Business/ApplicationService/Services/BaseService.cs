using RichDomain.API.Business.Domain.Handlers.NotificationHandler;
using RichDomain.API.Business.Domain.Handlers.ValidationHandler;
using RichDomain.API.Business.Domain.Interfaces.OthersContracts;

namespace RichDomain.API.Business.ApplicationService.Services;
public class BaseService
{
    protected readonly INotificationHandler _notification;

    protected BaseService(INotificationHandler notification)
    {
        _notification = notification;
    }

    protected bool EntityValidation(Dictionary<string, string> errors)
    {
        var validation = ValidationResponse.CreateResponse(errors);

        _notification.CreateNotifications(DomainNotification.CreateNotifications(validation.Errors));

        return validation.Valid;
    }

}

