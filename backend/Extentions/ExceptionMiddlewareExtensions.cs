﻿using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using web_api.Middlewares;

namespace web_api.Extentions
{
    public static class ExceptionMiddlewareExtensions
    {

        public static void ConfigureExceptionHandler(this ApplicationBuilder app, IWebHostEnvironment env   )
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
        public static void ConfigureBuiltingExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler(options =>
                {
                    options.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            var ex = context.Features.Get<IExceptionHandlerFeature>();
                            if (ex != null)
                            {
                                context.Response.WriteAsync(ex.Error.Message);
                            }
                        });
                });
            }
        }
    }
}
