//----------------------------------------------------------------------- 
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
using Energistics.DataAccess.WITSML200;
using PDS.Framework;


namespace PDS.Witsml.Server.Data.Attachments
{
    /// <summary>
    /// Provides validation for <see cref="Attachment" /> data objects.
    /// </summary>
    /// <seealso cref="PDS.Witsml.Server.Data.DataObjectValidator{Attachment}" />
    [Export(typeof(IDataObjectValidator<Attachment>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class Attachment200Validator : DataObjectValidator<Attachment>
    {
        private readonly IWitsmlDataAdapter<Attachment> _attachmentDataAdapter;

        /// <summary>
        /// Initializes a new instance of the <see cref="Attachment200Validator" /> class.
        /// </summary>
        /// <param name="container">The composition container.</param>
        /// <param name="attachmentDataAdapter">The attachment data adapter.</param>
        [ImportingConstructor]
        public Attachment200Validator(
            IContainer container,
            IWitsmlDataAdapter<Attachment> attachmentDataAdapter)
            : base(container)
        {
            _attachmentDataAdapter = attachmentDataAdapter;
        }
    }
}
