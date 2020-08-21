﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.8662
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.8662.
// 
#pragma warning disable 1591

namespace MDFe.br.gov.rs.svrs.mdfe.RetRec {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.8662")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MDFeRetRecepcaoSoap12", Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao")]
    public partial class MDFeRetRecepcao : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private mdfeCabecMsg mdfeCabecMsgValueField;
        
        private System.Threading.SendOrPostCallback mdfeRetRecepcaoOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MDFeRetRecepcao() {
            this.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            this.Url = global::MDFe.Properties.Settings.Default.MDFe_br_gov_rs_svrs_mdfe_RetRec_MDFeRetRecepcao;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public mdfeCabecMsg mdfeCabecMsgValue {
            get {
                return this.mdfeCabecMsgValueField;
            }
            set {
                this.mdfeCabecMsgValueField = value;
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
        public event mdfeRetRecepcaoCompletedEventHandler mdfeRetRecepcaoCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("mdfeCabecMsgValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.InOut)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao/mdfeRetRecepcao", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao")]
        public System.Xml.XmlNode mdfeRetRecepcao([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao")] System.Xml.XmlNode mdfeDadosMsg) {
            object[] results = this.Invoke("mdfeRetRecepcao", new object[] {
                        mdfeDadosMsg});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void mdfeRetRecepcaoAsync(System.Xml.XmlNode mdfeDadosMsg) {
            this.mdfeRetRecepcaoAsync(mdfeDadosMsg, null);
        }
        
        /// <remarks/>
        public void mdfeRetRecepcaoAsync(System.Xml.XmlNode mdfeDadosMsg, object userState) {
            if ((this.mdfeRetRecepcaoOperationCompleted == null)) {
                this.mdfeRetRecepcaoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnmdfeRetRecepcaoOperationCompleted);
            }
            this.InvokeAsync("mdfeRetRecepcao", new object[] {
                        mdfeDadosMsg}, this.mdfeRetRecepcaoOperationCompleted, userState);
        }
        
        private void OnmdfeRetRecepcaoOperationCompleted(object arg) {
            if ((this.mdfeRetRecepcaoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.mdfeRetRecepcaoCompleted(this, new mdfeRetRecepcaoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.8662")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao", IsNullable=false)]
    public partial class mdfeCabecMsg : System.Web.Services.Protocols.SoapHeader {
        
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.8662")]
    public delegate void mdfeRetRecepcaoCompletedEventHandler(object sender, mdfeRetRecepcaoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.8662")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class mdfeRetRecepcaoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal mdfeRetRecepcaoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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