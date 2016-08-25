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

using System.ComponentModel.Composition;
using Energistics.DataAccess.WITSML141;

namespace PDS.Witsml.Server.Data.Trajectories
{
    /// <summary>
    /// Provides validation for <see cref="Trajectory" /> data objects.
    /// </summary>
    /// <seealso cref="PDS.Witsml.Server.Data.DataObjectValidator{Trajectory}" />
    [Export(typeof (IDataObjectValidator<Trajectory>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class Trajectory141Validator : DataObjectValidator<Trajectory, Wellbore, Well>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Trajectory141Validator"/> class.
        /// </summary>
        /// <param name="trajectoryDataAdapter">The trajectory data adapter.</param>
        /// <param name="wellboreDataAdapter">The wellbore data adapter.</param>
        /// <param name="wellDataAdapter">The well data adapter.</param>
        [ImportingConstructor]
        public Trajectory141Validator(IWitsmlDataAdapter<Trajectory> trajectoryDataAdapter, IWitsmlDataAdapter<Wellbore> wellboreDataAdapter, IWitsmlDataAdapter<Well> wellDataAdapter)
            : base(trajectoryDataAdapter, wellboreDataAdapter, wellDataAdapter)
        {
        }
    }
}