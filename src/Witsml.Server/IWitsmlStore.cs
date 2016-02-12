﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PDS.Witsml.Server
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.witsml.org/wsdl/120", ConfigurationName="PDS.Witsml.Server.IWitsmlStore")]
    public interface IWitsmlStore
    {
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.witsml.org/action/120/Store.WMLS_AddToStore")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        PDS.Witsml.Server.WMLS_AddToStoreResponse WMLS_AddToStore(PDS.Witsml.Server.WMLS_AddToStoreRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.witsml.org/action/120/Store.WMLS_DeleteFromStore")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        PDS.Witsml.Server.WMLS_DeleteFromStoreResponse WMLS_DeleteFromStore(PDS.Witsml.Server.WMLS_DeleteFromStoreRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://www.witsml.org/message/120) of message WMLS_GetBaseMsgRequest does not match the default value (http://www.witsml.org/wsdl/120)
        [System.ServiceModel.OperationContractAttribute(Action="http://www.witsml.org/action/120/Store.WMLS_GetBaseMsg")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        PDS.Witsml.Server.WMLS_GetBaseMsgResponse WMLS_GetBaseMsg(PDS.Witsml.Server.WMLS_GetBaseMsgRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.witsml.org/action/120/Store.WMLS_GetCap")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        PDS.Witsml.Server.WMLS_GetCapResponse WMLS_GetCap(PDS.Witsml.Server.WMLS_GetCapRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.witsml.org/action/120/Store.WMLS_GetFromStore")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        PDS.Witsml.Server.WMLS_GetFromStoreResponse WMLS_GetFromStore(PDS.Witsml.Server.WMLS_GetFromStoreRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://www.witsml.org/message/120) of message WMLS_GetVersionRequest does not match the default value (http://www.witsml.org/wsdl/120)
        [System.ServiceModel.OperationContractAttribute(Action="http://www.witsml.org/action/120/Store.WMLS_GetVersion")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        PDS.Witsml.Server.WMLS_GetVersionResponse WMLS_GetVersion(PDS.Witsml.Server.WMLS_GetVersionRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.witsml.org/action/120/Store.WMLS_UpdateInStore")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        PDS.Witsml.Server.WMLS_UpdateInStoreResponse WMLS_UpdateInStore(PDS.Witsml.Server.WMLS_UpdateInStoreRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WMLS_AddToStore", WrapperNamespace="http://www.witsml.org/message/120", IsWrapped=true)]
    public partial class WMLS_AddToStoreRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string WMLtypeIn;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string XMLin;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=2)]
        public string OptionsIn;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=3)]
        public string CapabilitiesIn;
        
        public WMLS_AddToStoreRequest()
        {
        }
        
        public WMLS_AddToStoreRequest(string WMLtypeIn, string XMLin, string OptionsIn, string CapabilitiesIn)
        {
            this.WMLtypeIn = WMLtypeIn;
            this.XMLin = XMLin;
            this.OptionsIn = OptionsIn;
            this.CapabilitiesIn = CapabilitiesIn;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WMLS_AddToStoreResponse", WrapperNamespace="http://www.witsml.org/message/120", IsWrapped=true)]
    public partial class WMLS_AddToStoreResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public short Result;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string SuppMsgOut;
        
        public WMLS_AddToStoreResponse()
        {
        }
        
        public WMLS_AddToStoreResponse(short Result, string SuppMsgOut)
        {
            this.Result = Result;
            this.SuppMsgOut = SuppMsgOut;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WMLS_DeleteFromStore", WrapperNamespace="http://www.witsml.org/message/120", IsWrapped=true)]
    public partial class WMLS_DeleteFromStoreRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string WMLtypeIn;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string QueryIn;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=2)]
        public string OptionsIn;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=3)]
        public string CapabilitiesIn;
        
        public WMLS_DeleteFromStoreRequest()
        {
        }
        
        public WMLS_DeleteFromStoreRequest(string WMLtypeIn, string QueryIn, string OptionsIn, string CapabilitiesIn)
        {
            this.WMLtypeIn = WMLtypeIn;
            this.QueryIn = QueryIn;
            this.OptionsIn = OptionsIn;
            this.CapabilitiesIn = CapabilitiesIn;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WMLS_DeleteFromStoreResponse", WrapperNamespace="http://www.witsml.org/message/120", IsWrapped=true)]
    public partial class WMLS_DeleteFromStoreResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public short Result;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string SuppMsgOut;
        
        public WMLS_DeleteFromStoreResponse()
        {
        }
        
        public WMLS_DeleteFromStoreResponse(short Result, string SuppMsgOut)
        {
            this.Result = Result;
            this.SuppMsgOut = SuppMsgOut;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WMLS_GetBaseMsg", WrapperNamespace="http://www.witsml.org/message/120", IsWrapped=true)]
    public partial class WMLS_GetBaseMsgRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public short ReturnValueIn;
        
        public WMLS_GetBaseMsgRequest()
        {
        }
        
        public WMLS_GetBaseMsgRequest(short ReturnValueIn)
        {
            this.ReturnValueIn = ReturnValueIn;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WMLS_GetBaseMsgResponse", WrapperNamespace="http://www.witsml.org/message/120", IsWrapped=true)]
    public partial class WMLS_GetBaseMsgResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string Result;
        
        public WMLS_GetBaseMsgResponse()
        {
        }
        
        public WMLS_GetBaseMsgResponse(string Result)
        {
            this.Result = Result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WMLS_GetCap", WrapperNamespace="http://www.witsml.org/message/120", IsWrapped=true)]
    public partial class WMLS_GetCapRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string OptionsIn;
        
        public WMLS_GetCapRequest()
        {
        }
        
        public WMLS_GetCapRequest(string OptionsIn)
        {
            this.OptionsIn = OptionsIn;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WMLS_GetCapResponse", WrapperNamespace="http://www.witsml.org/message/120", IsWrapped=true)]
    public partial class WMLS_GetCapResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public short Result;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string CapabilitiesOut;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=2)]
        public string SuppMsgOut;
        
        public WMLS_GetCapResponse()
        {
        }
        
        public WMLS_GetCapResponse(short Result, string CapabilitiesOut, string SuppMsgOut)
        {
            this.Result = Result;
            this.CapabilitiesOut = CapabilitiesOut;
            this.SuppMsgOut = SuppMsgOut;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WMLS_GetFromStore", WrapperNamespace="http://www.witsml.org/message/120", IsWrapped=true)]
    public partial class WMLS_GetFromStoreRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string WMLtypeIn;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string QueryIn;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=2)]
        public string OptionsIn;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=3)]
        public string CapabilitiesIn;
        
        public WMLS_GetFromStoreRequest()
        {
        }
        
        public WMLS_GetFromStoreRequest(string WMLtypeIn, string QueryIn, string OptionsIn, string CapabilitiesIn)
        {
            this.WMLtypeIn = WMLtypeIn;
            this.QueryIn = QueryIn;
            this.OptionsIn = OptionsIn;
            this.CapabilitiesIn = CapabilitiesIn;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WMLS_GetFromStoreResponse", WrapperNamespace="http://www.witsml.org/message/120", IsWrapped=true)]
    public partial class WMLS_GetFromStoreResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public short Result;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string XMLout;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=2)]
        public string SuppMsgOut;
        
        public WMLS_GetFromStoreResponse()
        {
        }
        
        public WMLS_GetFromStoreResponse(short Result, string XMLout, string SuppMsgOut)
        {
            this.Result = Result;
            this.XMLout = XMLout;
            this.SuppMsgOut = SuppMsgOut;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WMLS_GetVersion", WrapperNamespace="http://www.witsml.org/message/120", IsWrapped=true)]
    public partial class WMLS_GetVersionRequest
    {
        
        public WMLS_GetVersionRequest()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WMLS_GetVersionResponse", WrapperNamespace="http://www.witsml.org/message/120", IsWrapped=true)]
    public partial class WMLS_GetVersionResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string Result;
        
        public WMLS_GetVersionResponse()
        {
        }
        
        public WMLS_GetVersionResponse(string Result)
        {
            this.Result = Result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WMLS_UpdateInStore", WrapperNamespace="http://www.witsml.org/message/120", IsWrapped=true)]
    public partial class WMLS_UpdateInStoreRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string WMLtypeIn;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string XMLin;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=2)]
        public string OptionsIn;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=3)]
        public string CapabilitiesIn;
        
        public WMLS_UpdateInStoreRequest()
        {
        }
        
        public WMLS_UpdateInStoreRequest(string WMLtypeIn, string XMLin, string OptionsIn, string CapabilitiesIn)
        {
            this.WMLtypeIn = WMLtypeIn;
            this.XMLin = XMLin;
            this.OptionsIn = OptionsIn;
            this.CapabilitiesIn = CapabilitiesIn;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WMLS_UpdateInStoreResponse", WrapperNamespace="http://www.witsml.org/message/120", IsWrapped=true)]
    public partial class WMLS_UpdateInStoreResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public short Result;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string SuppMsgOut;
        
        public WMLS_UpdateInStoreResponse()
        {
        }
        
        public WMLS_UpdateInStoreResponse(short Result, string SuppMsgOut)
        {
            this.Result = Result;
            this.SuppMsgOut = SuppMsgOut;
        }
    }
}
