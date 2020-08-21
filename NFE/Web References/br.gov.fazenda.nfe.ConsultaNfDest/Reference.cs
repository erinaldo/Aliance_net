﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.4927.
// 
#pragma warning disable 1591

namespace srvNFE.br.gov.fazenda.nfe.ConsultaNfDest {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="NFeConsultaDestSoap", Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NfeConsultaDest")]
    public partial class NFeConsultaDest : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private nfeCabecMsg nfeCabecMsgValueField;
        
        private System.Threading.SendOrPostCallback nfeConsultaNFDestOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public NFeConsultaDest() {
            this.Url = global::srvNFE.Properties.Settings.Default.srvNFE_br_gov_fazenda_nfe_ConsultaNfDest_NFeConsultaDest;
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
        public event nfeConsultaNFDestCompletedEventHandler nfeConsultaNFDestCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("nfeCabecMsgValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/nfe/wsdl/NfeConsultaDest/nfeConsultaNFDest", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NfeConsultaDest")]
        public System.Xml.XmlNode nfeConsultaNFDest([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NfeConsultaDest")] System.Xml.XmlNode nfeDadosMsg) {
            object[] results = this.Invoke("nfeConsultaNFDest", new object[] {
                        nfeDadosMsg});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void nfeConsultaNFDestAsync(System.Xml.XmlNode nfeDadosMsg) {
            this.nfeConsultaNFDestAsync(nfeDadosMsg, null);
        }
        
        /// <remarks/>
        public void nfeConsultaNFDestAsync(System.Xml.XmlNode nfeDadosMsg, object userState) {
            if ((this.nfeConsultaNFDestOperationCompleted == null)) {
                this.nfeConsultaNFDestOperationCompleted = new System.Threading.SendOrPostCallback(this.OnnfeConsultaNFDestOperationCompleted);
            }
            this.InvokeAsync("nfeConsultaNFDest", new object[] {
                        nfeDadosMsg}, this.nfeConsultaNFDestOperationCompleted, userState);
        }
        
        private void OnnfeConsultaNFDestOperationCompleted(object arg) {
            if ((this.nfeConsultaNFDestCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.nfeConsultaNFDestCompleted(this, new nfeConsultaNFDestCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.4927")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NfeConsultaDest")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NfeConsultaDest", IsNullable=false)]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void nfeConsultaNFDestCompletedEventHandler(object sender, nfeConsultaNFDestCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class nfeConsultaNFDestCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal nfeConsultaNFDestCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591