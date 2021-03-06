//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace srvNFE.br.gov.ms.fazenda.nfe.MSAutorizaLote4 {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="nfeAutorizacaoSoap12Binding", Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4")]
    public partial class NFeAutorizacao4 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback nfeAutorizacaoLoteOperationCompleted;
        
        private System.Threading.SendOrPostCallback nfeAutorizacaoLoteZIPOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public NFeAutorizacao4() {
            this.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            this.Url = global::srvNFE.Properties.Settings.Default.srvNFE_br_gov_ms_fazenda_nfe_MSAutorizaLote4_NFeAutorizacao4;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event nfeAutorizacaoLoteCompletedEventHandler nfeAutorizacaoLoteCompleted;
        
        /// <remarks/>
        public event nfeAutorizacaoLoteZIPCompletedEventHandler nfeAutorizacaoLoteZIPCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4/nfeAutorizacaoLote", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("nfeResultMsg", Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4")]
        public nfeResultMsg1 nfeAutorizacaoLote([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4")] nfeResultMsg nfeDadosMsg) {
            object[] results = this.Invoke("nfeAutorizacaoLote", new object[] {
                        nfeDadosMsg});
            return ((nfeResultMsg1)(results[0]));
        }
        
        /// <remarks/>
        public void nfeAutorizacaoLoteAsync(nfeResultMsg nfeDadosMsg) {
            this.nfeAutorizacaoLoteAsync(nfeDadosMsg, null);
        }
        
        /// <remarks/>
        public void nfeAutorizacaoLoteAsync(nfeResultMsg nfeDadosMsg, object userState) {
            if ((this.nfeAutorizacaoLoteOperationCompleted == null)) {
                this.nfeAutorizacaoLoteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnnfeAutorizacaoLoteOperationCompleted);
            }
            this.InvokeAsync("nfeAutorizacaoLote", new object[] {
                        nfeDadosMsg}, this.nfeAutorizacaoLoteOperationCompleted, userState);
        }
        
        private void OnnfeAutorizacaoLoteOperationCompleted(object arg) {
            if ((this.nfeAutorizacaoLoteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.nfeAutorizacaoLoteCompleted(this, new nfeAutorizacaoLoteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4/nfeAutorizacaoLoteZIP", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("nfeResultMsg", Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4")]
        public nfeResultMsg1 nfeAutorizacaoLoteZIP([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4")] string nfeDadosMsgZip) {
            object[] results = this.Invoke("nfeAutorizacaoLoteZIP", new object[] {
                        nfeDadosMsgZip});
            return ((nfeResultMsg1)(results[0]));
        }
        
        /// <remarks/>
        public void nfeAutorizacaoLoteZIPAsync(string nfeDadosMsgZip) {
            this.nfeAutorizacaoLoteZIPAsync(nfeDadosMsgZip, null);
        }
        
        /// <remarks/>
        public void nfeAutorizacaoLoteZIPAsync(string nfeDadosMsgZip, object userState) {
            if ((this.nfeAutorizacaoLoteZIPOperationCompleted == null)) {
                this.nfeAutorizacaoLoteZIPOperationCompleted = new System.Threading.SendOrPostCallback(this.OnnfeAutorizacaoLoteZIPOperationCompleted);
            }
            this.InvokeAsync("nfeAutorizacaoLoteZIP", new object[] {
                        nfeDadosMsgZip}, this.nfeAutorizacaoLoteZIPOperationCompleted, userState);
        }
        
        private void OnnfeAutorizacaoLoteZIPOperationCompleted(object arg) {
            if ((this.nfeAutorizacaoLoteZIPCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.nfeAutorizacaoLoteZIPCompleted(this, new nfeAutorizacaoLoteZIPCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4")]
    public partial class nfeResultMsg {
        
        private System.Xml.XmlNode[] anyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlNode[] Any {
            get {
                return this.anyField;
            }
            set {
                this.anyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4")]
    public partial class nfeResultMsg1 {
        
        private System.Xml.XmlNode[] anyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlNode[] Any {
            get {
                return this.anyField;
            }
            set {
                this.anyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    public delegate void nfeAutorizacaoLoteCompletedEventHandler(object sender, nfeAutorizacaoLoteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class nfeAutorizacaoLoteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal nfeAutorizacaoLoteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public nfeResultMsg1 Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((nfeResultMsg1)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    public delegate void nfeAutorizacaoLoteZIPCompletedEventHandler(object sender, nfeAutorizacaoLoteZIPCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class nfeAutorizacaoLoteZIPCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal nfeAutorizacaoLoteZIPCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public nfeResultMsg1 Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((nfeResultMsg1)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591