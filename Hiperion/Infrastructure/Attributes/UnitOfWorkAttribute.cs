﻿namespace Hiperion.Infrastructure.Attributes
{
    using System;
    using System.Web.Http.Filters;
    using EF;
    using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class UnitOfWorkAttribute : ActionFilterAttribute
	{ 
		public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
		{
			if (actionExecutedContext.Exception != null) return;

			var container = actionExecutedContext.ActionContext.ControllerContext.Configuration.DependencyResolver;
			var context = container.GetService(typeof (IDbContext)) as IDbContext;
			context.SaveChanges();
		}
	}
}