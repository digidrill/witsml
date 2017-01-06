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

using Energistics.DataAccess.WITSML200;
using Energistics.DataAccess.WITSML200.ComponentSchemas;
using Energistics.DataAccess.WITSML200.ReferenceData;
using Energistics.Datatypes;

namespace PDS.Witsml.Server.Data.Trajectories
{
    /// <summary>
    /// Data provider that implements support for ETP API functions for <see cref="Trajectory"/>.
    /// </summary>
    public partial class Trajectory200DataProvider
    {
        /// <summary>
        /// Sets the additional default values.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        /// <param name="uri">The URI.</param>
        partial void SetAdditionalDefaultValues(Trajectory dataObject, EtpUri uri)
        {
            dataObject.GrowingStatus = dataObject.GrowingStatus ?? ChannelStatus.inactive;

            if (dataObject.Wellbore == null)
            {
                var wellboreType = new Wellbore().GetUri().ContentType;
                var wellboreUri = uri.Parent;

                dataObject.Wellbore = new DataObjectReference
                {
                    ContentType = wellboreType,
                    Uuid = wellboreUri.ObjectId ?? string.Empty,
                    Title = wellboreUri.ObjectId ?? string.Empty
                };
            }
        }
    }
}
