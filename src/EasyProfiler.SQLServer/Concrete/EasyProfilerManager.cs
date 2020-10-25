﻿using AutoFilterer.Extensions;
using EasyProfiler.Entities;
using EasyProfiler.SQLServer.Abstractions;
using EasyProfiler.SQLServer.Context;
using EasyProfiler.SQLServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyProfiler.SQLServer.Concrete
{
    /// <summary>
    /// This class includes query log.
    /// </summary>
    public class EasyProfilerManager : IEasyProfilerService
    {
        private readonly ProfilerDbContext profilerDbContext;

        public EasyProfilerManager(ProfilerDbContext profilerDbContext)
        {
            this.profilerDbContext = profilerDbContext;
        }

        /// <summary>
        /// Advanced filter.
        /// </summary>
        /// <param name="filterModel">
        /// Filter object.
        /// </param>
        /// <returns>
        /// List of profiler.
        /// </returns>
        public async Task<List<Profiler>> AdvancedFilterAsync(AdvancedFilterModel filterModel, CancellationToken cancellationToken = default)
        {
            return await profilerDbContext.Profilers.ApplyFilter(filterModel).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Insert Query Log.
        /// </summary>
        /// <param name="profiler">
        /// Profiler Entity.
        /// </param>
        /// <returns>
        /// NoContent.
        /// </returns>
        public async Task InsertLogAsync(Profiler profiler, CancellationToken cancellationToken = default)
        {
            profiler.Id = Guid.NewGuid();
            await profilerDbContext.Profilers.AddAsync(profiler, cancellationToken);
            await profilerDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
