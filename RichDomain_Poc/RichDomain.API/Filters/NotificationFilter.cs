using RichDomain.API.Business.Domain.Interfaces.OthersContracts;
using RichDomain.API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RichDomain.API.Filters;

public sealed class NotificationFilter : ActionFilterAttribute
{
    private readonly INotificationHandler _notificationHandler;

    public NotificationFilter(INotificationHandler notificationHandler)
    {
        _notificationHandler = notificationHandler;
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (!ExternalMethodExtension.IsMethodGet(context) && _notificationHandler.HasNotification())
            context.Result = new BadRequestObjectResult(_notificationHandler.GetNotifications());

        base.OnActionExecuted(context);
    }
}