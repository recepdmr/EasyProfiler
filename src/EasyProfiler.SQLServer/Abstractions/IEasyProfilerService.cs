﻿using EasyProfiler.Entities;
using EasyProfiler.SQLServer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyProfiler.SQLServer.Abstractions
{
    /// <summary>
    /// This interface includes query log.
    /// </summary>
    public interface IEasyProfilerService
    {
        /// <summary>
        /// Insert Query Log.
        /// </summary>
        /// <param name="profiler">
        /// Profiler Entity.
        /// </param>
        /// <returns>
        /// NoContent.
        /// </returns>
        Task InsertLogAsync(Profiler profiler, CancellationToken cancellationToken = default);

        /// <summary>
        /// Advanced filter.
        /// </summary>
        /// <param name="filterModel">
        /// Filter object.
        /// </param>
        /// <returns>
        /// List of profiler.
        /// </returns>
        Task<List<Profiler>> AdvancedFilterAsync(AdvancedFilterModel filterModel, CancellationToken cancellationToken = default);
    }
}
