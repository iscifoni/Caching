// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.Caching.SqlServer
{
    /// <summary>
    /// Configuration options for <see cref="SqlServerCache"/>.
    /// </summary>
    public class SqlServerCacheOptions : IOptions<SqlServerCacheOptions>
    {
        public SqlServerCacheOptions()
        {
            DefaultCacheEntryOptions = new DistributedCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromMinutes(20)
            };
        }

        /// <summary>
        /// An abstraction to represent the clock of a machine in order to enable unit testing.
        /// </summary>
        public ISystemClock SystemClock { get; set; }

        /// <summary>
        /// The periodic interval to scan and delete expired items in the cache. Default is 30 minutes.
        /// </summary>
        public TimeSpan? ExpiredItemsDeletionInterval { get; set; }

        /// <summary>
        /// The connection string to the database.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// The schema name of the table.
        /// </summary>
        public string SchemaName { get; set; }

        /// <summary>
        /// Name of the table where the cache items are stored.
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// The default options for a new cache entry. It has SlidingExpiration set for 20 minutes by default.
        /// </summary>
        public DistributedCacheEntryOptions DefaultCacheEntryOptions { get; set; }

        SqlServerCacheOptions IOptions<SqlServerCacheOptions>.Value
        {
            get
            {
                return this;
            }
        }
    }
}