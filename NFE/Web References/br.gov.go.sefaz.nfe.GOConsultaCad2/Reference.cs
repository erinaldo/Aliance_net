//------------------------------------------------------------------------------
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

namespace srvNFE.br.gov.go.sefaz.nfe.GOConsultaCad2 {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="CadConsultaCadastro2ServiceBinding", Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro2")]
    public partial class CadConsultaCadastro2 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private nfeCabecMsg nfeCabecMsgValueField;
        
        private System.Threading.SendOrPostCallback cadConsultaCadastro2OperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public CadConsultaCadastro2() {
            this.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            this.Url = global::srvNFE.Properties.Settings.Default.srvNFE_br_gov_go_sefaz_nfe_GOConsultaCad2_CadConsultaCadastro2;
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
        public event cadConsultaCadastro2CompletedEventHandler cadConsultaCadastro2Completed;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("nfeCabecMsgValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro2/cadConsultaCadastro2" +
            "", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro2")]
        public System.Xml.XmlNode cadConsultaCadastro2([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro2")] System.Xml.XmlNode nfeDadosMsg) {
            object[] results = this.Invoke("cadConsultaCadastro2", new object[] {
                        nfeDadosMsg});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void cadConsultaCadastro2Async(System.Xml.XmlNode nfeDadosMsg) {
            this.cadConsultaCadastro2Async(nfeDadosMsg, null);
        }
        
        /// <remarks/>
        public void cadConsultaCadastro2Async(System.Xml.XmlNode nfeDadosMsg, object userState) {
            if ((this.cadConsultaCadastro2OperationCompleted == null)) {
                this.cadConsultaCadastro2OperationCompleted = new System.Threading.SendOrPostCallback(this.OncadConsultaCadastro2OperationCompleted);
            }
            this.InvokeAsync("cadConsultaCadastro2", new object[] {
                        nfeDadosMsg}, this.cadConsultaCadastro2OperationCompleted, userState);
        }
        
        private void OncadConsultaCadastro2OperationCompleted(object arg) {
            if ((this.cadConsultaCadastro2Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.cadConsultaCadastro2Completed(this, new cadConsultaCadastro2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro2", IsNullable=false)]
    public partial class nfeCabecMsg : System.Web.Services.Protocols.SoapHeader {
        
        private string cUFField;
        
        private string versaoDadosField;
        
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
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void cadConsultaCadastro2CompletedEventHandler(object sender, cadConsultaCadastro2CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class cadConsultaCadastro2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal cadConsultaCadastro2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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