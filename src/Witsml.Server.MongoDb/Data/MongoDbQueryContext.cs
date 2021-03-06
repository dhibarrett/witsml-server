﻿//----------------------------------------------------------------------- 
// PDS.Witsml.Server, 2016.1
//
// Copyright 2016 Petrotechnical Data Systems
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using MongoDB.Driver;
using PDS.Witsml.Data;

namespace PDS.Witsml.Server.Data
{
    /// <summary>
    /// Encapsulates common properties used for querying the data store.
    /// </summary>
    /// <typeparam name="T">The data object type.</typeparam>
    /// <seealso cref="PDS.Witsml.Data.DataObjectNavigationContext" />
    public class MongoDbQueryContext<T> : DataObjectNavigationContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbQueryContext{T}"/> class.
        /// </summary>
        public MongoDbQueryContext()
        {
            DataObjectType = typeof(T);
            Function = Functions.GetFromStore;
            Filters = new List<FilterDefinition<T>>();
            ParentFilters = new Dictionary<string, List<FilterDefinition<T>>>();
        }

        /// <summary>
        /// Gets the type of the data object.
        /// </summary>
        /// <value>The type of the data object.</value>
        public override Type DataObjectType { get; }

        /// <summary>
        /// Gets or sets the list of filters.
        /// </summary>
        /// <value>The list of filters.</value>
        public List<FilterDefinition<T>> Filters { get; set; }

        /// <summary>
        /// Gets the collection of parent filters.
        /// </summary>
        /// <value>The parent filters.</value>
        public Dictionary<string, List<FilterDefinition<T>>> ParentFilters { get; }

        /// <summary>
        /// Gets or sets the list of fields.
        /// </summary>
        /// <value>The list of fields.</value>
        public List<string> Fields { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the query is a projection.
        /// </summary>
        /// <value>
        /// <c>true</c> if the query is a projection; otherwise, <c>false</c>.
        /// </value>
        public bool IsProjection { get; set; }
    }
}
