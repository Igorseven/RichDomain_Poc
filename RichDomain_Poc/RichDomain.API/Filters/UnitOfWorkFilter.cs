﻿using RichDomain.API.Business.Domain.Interfaces.OthersContracts;
using RichDomain.API.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RichDomain.API.Filters;

public sealed class UnitOfWorkFilter : ActionFilterAttribute
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationHandler _notification;

    public UnitOfWorkFilter(IUnitOfWork unitOfWork, INotificationHandler notificationHandler)
    {
        _unitOfWork = unitOfWork;
        _notification = notificationHandler;
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (ExternalMethodExtension.IsMethodGet(context)) return;

        if (context.Exception is null && context.ModelState.IsValid && !_notification.HasNotification())
            _unitOfWork.CommitTransaction();
        else
            _unitOfWork.RolbackTransaction();

        base.OnActionExecuted(context);
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (ExternalMethodExtension.IsMethodGet(context)) return;

        _unitOfWork.BeginTransaction();

        base.OnActionExecuting(context);
    }
}

