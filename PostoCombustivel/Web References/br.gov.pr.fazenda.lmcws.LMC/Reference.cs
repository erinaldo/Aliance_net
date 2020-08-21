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

namespace PostoCombustivel.br.gov.pr.fazenda.lmcws.LMC {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="LMCWSServiceSoapBinding", Namespace="http://www.fazenda.pr.gov.br/wsdl/sefaws")]
    public partial class LMCAutorizacao : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback lmcAutorizacaoOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public LMCAutorizacao() {
            this.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            this.Url = global::PostoCombustivel.Properties.Settings.Default.PostoCombustivel_br_gov_pr_fazenda_lmcws_LMC_LMCAutorizacao;
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
        public event lmcAutorizacaoCompletedEventHandler lmcAutorizacaoCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://www.fazenda.pr.gov.br/wsdl/sefaws", ResponseElementName="lmcAutorizacaoResult", ResponseNamespace="http://www.fazenda.pr.gov.br/wsdl/sefaws", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement lmcAutorizacao([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] System.Xml.XmlNode xmlDados) {
            object[] results = this.Invoke("lmcAutorizacao", new object[] {
                        xmlDados});
            return ((System.Xml.XmlElement)(results[0]));
        }
        
        /// <remarks/>
        public void lmcAutorizacaoAsync(System.Xml.XmlNode xmlDados) {
            this.lmcAutorizacaoAsync(xmlDados, null);
        }
        
        /// <remarks/>
        public void lmcAutorizacaoAsync(System.Xml.XmlNode xmlDados, object userState) {
            if ((this.lmcAutorizacaoOperationCompleted == null)) {
                this.lmcAutorizacaoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnlmcAutorizacaoOperationCompleted);
            }
            this.InvokeAsync("lmcAutorizacao", new object[] {
                        xmlDados}, this.lmcAutorizacaoOperationCompleted, userState);
        }
        
        private void OnlmcAutorizacaoOperationCompleted(object arg) {
            if ((this.lmcAutorizacaoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.lmcAutorizacaoCompleted(this, new lmcAutorizacaoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.7905")]
    public delegate void lmcAutorizacaoCompletedEventHandler(object sender, lmcAutorizacaoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.7905")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class lmcAutorizacaoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal lmcAutorizacaoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlElement Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlElement)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591