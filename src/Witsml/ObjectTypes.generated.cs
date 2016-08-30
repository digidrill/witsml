//----------------------------------------------------------------------- 
// PDS.Witsml, 2016.1
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

namespace PDS.Witsml
{
    /// <summary>
    /// Defines constants that can be used to indicate a data object's type.
    /// </summary>
    public static partial class ObjectTypes
    {
        /// <summary>
        /// The data object type for a Attachment.
        /// </summary>
        public const string Attachment = "attachment";

        /// <summary>
        /// The data object type for a Channel.
        /// </summary>
        public const string Channel = "channel";

        /// <summary>
        /// The data object type for a ChannelSet.
        /// </summary>
        public const string ChannelSet = "channelSet";

        /// <summary>
        /// The data object type for a Log.
        /// </summary>
        public const string Log = "log";

        /// <summary>
        /// The data object type for a Message.
        /// </summary>
        public const string Message = "message";

        /// <summary>
        /// The data object type for a Rig.
        /// </summary>
        public const string Rig = "rig";

        /// <summary>
        /// The data object type for a Trajectory.
        /// </summary>
        public const string Trajectory = "trajectory";

        /// <summary>
        /// The data object type for a WbGeometry.
        /// </summary>
        public const string WbGeometry = "wbGeometry";

        /// <summary>
        /// The data object type for a Well.
        /// </summary>
        public const string Well = "well";

        /// <summary>
        /// The data object type for a Wellbore.
        /// </summary>
        public const string Wellbore = "wellbore";

    }
}