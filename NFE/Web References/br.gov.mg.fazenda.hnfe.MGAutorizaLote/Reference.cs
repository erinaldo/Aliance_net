﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.8009
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.8009.
// 
#pragma warning disable 1591

namespace srvNFE.br.gov.mg.fazenda.hnfe.MGAutorizaLote {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.7905")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="NfeAutorizacaoSoapBinding", Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NfeAutorizacao")]
    public partial class NfeAutorizacao : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private nfeCabecMsg nfeCabecMsgValueField;
        
        private System.Threading.SendOrPostCallback NfeAutorizacaoLoteOperationCompleted;
        
        private System.Threading.SendOrPostCallback NfeAutorizacaoLoteZipOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public NfeAutorizacao() {
            this.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            this.Url = global::srvNFE.Properties.Settings.Default.srvNFE_br_gov_mg_fazenda_hnfe_MGAutorizaLote_NfeAutorizacao;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public nfeCabecMsg nfeCabecMsgValue {
            get {
                return this.nfeCabecMsgValueField;
            }
            set {
                this.nfeCabecMsgValueField = value;
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
        public event NfeAutorizacaoLoteCompletedEventHandler NfeAutorizacaoLoteCompleted;
        
        /// <remarks/>
        public event NfeAutorizacaoLoteZipCompletedEventHandler NfeAutorizacaoLoteZipCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("nfeCabecMsgValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.InOut)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/nfe/wsdl/NfeAutorizacao/NfeAutorizacaoLote", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("nfeAutorizacaoLoteResult", Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NfeAutorizacao")]
        //[return: System.Xml.Serialization.XmlArrayItemAttribute("retEnviNFe", IsNullable=false)]
        public System.Xml.XmlNode NfeAutorizacaoLote([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NfeAutorizacao")] System.Xml.XmlNode nfeDadosMsg) {
            object[] results = this.Invoke("NfeAutorizacaoLote", new object[] {
                        nfeDadosMsg});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void NfeAutorizacaoLoteAsync(System.Xml.XmlNode nfeDadosMsg) {
            this.NfeAutorizacaoLoteAsync(nfeDadosMsg, null);
        }
        
        /// <remarks/>
        public void NfeAutorizacaoLoteAsync(System.Xml.XmlNode nfeDadosMsg, object userState) {
            if ((this.NfeAutorizacaoLoteOperationCompleted == null)) {
                this.NfeAutorizacaoLoteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNfeAutorizacaoLoteOperationCompleted);
            }
            this.InvokeAsync("NfeAutorizacaoLote", new object[] {
                        nfeDadosMsg}, this.NfeAutorizacaoLoteOperationCompleted, userState);
        }
        
        private void OnNfeAutorizacaoLoteOperationCompleted(object arg) {
            if ((this.NfeAutorizacaoLoteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NfeAutorizacaoLoteCompleted(this, new NfeAutorizacaoLoteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("nfeCabecMsgValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.InOut)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/nfe/wsdl/NfeAutorizacao/NfeAutorizacaoLoteZip", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("nfeAutorizacaoLoteResult", Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NfeAutorizacao")]
        //[return: System.Xml.Serialization.XmlArrayItemAttribute("retEnviNFe", IsNullable=false)]
        public System.Xml.XmlNode NfeAutorizacaoLoteZip([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NfeAutorizacao")] System.Xml.XmlNode nfeDadosMsgZip) {
            object[] results = this.Invoke("NfeAutorizacaoLoteZip", new object[] {
                        nfeDadosMsgZip});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void NfeAutorizacaoLoteZipAsync(System.Xml.XmlNode nfeDadosMsgZip) {
            this.NfeAutorizacaoLoteZipAsync(nfeDadosMsgZip, null);
        }
        
        /// <remarks/>
        public void NfeAutorizacaoLoteZipAsync(System.Xml.XmlNode nfeDadosMsgZip, object userState) {
            if ((this.NfeAutorizacaoLoteZipOperationCompleted == null)) {
                this.NfeAutorizacaoLoteZipOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNfeAutorizacaoLoteZipOperationCompleted);
            }
            this.InvokeAsync("NfeAutorizacaoLoteZip", new object[] {
                        nfeDadosMsgZip}, this.NfeAutorizacaoLoteZipOperationCompleted, userState);
        }
        
        private void OnNfeAutorizacaoLoteZipOperationCompleted(object arg) {
            if ((this.NfeAutorizacaoLoteZipCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NfeAutorizacaoLoteZipCompleted(this, new NfeAutorizacaoLoteZipCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NfeAutorizacao")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NfeAutorizacao", IsNullable=false)]
    public partial class nfeCabecMsg : System.Web.Services.Protocols.SoapHeader {
        
        private string cUFField;
        
        private string versaoDadosField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        public string cUF {
            get {
                return this.cUFField;
            }
            set {
                this.cUFField = value;
            }
        }
        
        /// <remarks/>
        public string versaoDados {
            get {
                return this.versaoDadosField;
            }
            set {
                this.versaoDadosField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NfeAutorizacao")]
    public partial class nfeDadosMsg {
        
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8009")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NfeAutorizacao")]
    public partial class nfeDadosMsgZip {
        
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.7905")]
    public delegate void NfeAutorizacaoLoteCompletedEventHandler(object sender, NfeAutorizacaoLoteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.7905")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class NfeAutorizacaoLoteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal NfeAutorizacaoLoteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public object[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((object[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.7905")]
    public delegate void NfeAutorizacaoLoteZipCompletedEventHandler(object sender, NfeAutorizacaoLoteZipCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.7905")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class NfeAutorizacaoLoteZipCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal NfeAutorizacaoLoteZipCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public object[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((object[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591