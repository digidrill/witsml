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
using Energistics.DataAccess.WITSML131;
using PDS.Framework;


namespace PDS.Witsml.Server.Data.Wellbores
{
    /// <summary>
    /// Provides validation for <see cref="Wellbore" /> data objects.
    /// </summary>
    /// <seealso cref="PDS.Witsml.Server.Data.DataObjectValidator{Wellbore}" />
    [Export(typeof(IDataObjectValidator<Wellbore>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class Wellbore131Validator : DataObjectValidator<Wellbore>
    {
        private readonly IWitsmlDataAdapter<Well> _wellDataAdapter;
        private readonly IWitsmlDataAdapter<Wellbore> _wellboreDataAdapter;

        /// <summary>
        /// Initializes a new instance of the <see cref="Wellbore131Validator" /> class.
        /// </summary>
        /// <param name="container">The composition container.</param>
        /// <param name="wellDataAdapter">The well data adapter.</param>
        /// <param name="wellboreDataAdapter">The wellbore data adapter.</param>
        [ImportingConstructor]
        public Wellbore131Validator(
            IContainer container,
            IWitsmlDataAdapter<Well> wellDataAdapter,
            IWitsmlDataAdapter<Wellbore> wellboreDataAdapter)
            : base(container)
        {
            _wellDataAdapter = wellDataAdapter;
            _wellboreDataAdapter = wellboreDataAdapter;
        }
    }
}
