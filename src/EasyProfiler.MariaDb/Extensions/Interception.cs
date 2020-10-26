﻿using System.Linq;
using EasyProfiler.MariaDb.Abstractions;
using EasyProfiler.MariaDb.Context;
using EasyProfiler.MariaDb.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace EasyProfiler.MariaDb.Extensions
{
    /// <summary>
    /// Interception extension method for dbcontext.
    /// </summary>
    public static class Interception
    {
        /// <summary>
        /// Add easy profiler for interceptions.
        /// </summary>
        /// <param name="optionsBuilder">
        /// DbContextOptionsBuilder
        /// </param>
        /// <returns>
        /// DbContextOptionsBuilder.
        /// </returns>
        public static DbContextOptionsBuilder AddEasyProfiler(this DbContextOptionsBuilder optionsBuilder, IServiceCollection services)
        {
            var interceptors = typeof(ProfilerDbContext).Assembly.GetTypes().Where(x => typeof(DbCommandInterceptor).IsAssignableFrom(x) && x != typeof(DbConnectionInterceptor) && x.IsClass).ToList();
            //foreach (var interceptor in interceptors)
            //{
            //    optionsBuilder.AddInterceptors(interceptor);
            //}
            optionsBuilder.AddInterceptors(new EasyProfilerInterceptors(services.BuildServiceProvider().GetService<IEasyProfilerService>()));
            
            return optionsBuilder;
        }
    }
}
