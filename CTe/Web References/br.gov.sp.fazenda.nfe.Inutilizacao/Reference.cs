//------------------------------------------------------------------------------
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

namespace CTe.br.gov.sp.fazenda.nfe.Inutilizacao {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="CteInutilizacaoSoap12", Namespace="http://www.portalfiscal.inf.br/cte/wsdl/CteInutilizacao")]
    public partial class CteInutilizacao : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private cteCabecMsg cteCabecMsgValueField;
        
        private System.Threading.SendOrPostCallback cteInutilizacaoCTOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public CteInutilizacao() {
            this.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            this.Url = global::CTe.Properties.Settings.Default.CTe_br_gov_sp_fazenda_nfe_Inutilizacao_CteInutilizacao;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public cteCabecMsg cteCabecMsgValue {
            get {
                return this.cteCabecMsgValueField;
            }
            set {
                this.cteCabecMsgValueField = value;
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
        public event cteInutilizacaoCTCompletedEventHandler cteInutilizacaoCTCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("cteCabecMsgValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.InOut)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/cte/wsdl/CteInutilizacao/cteInutilizacaoCT", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/cte/wsdl/CteInutilizacao")]
        public System.Xml.XmlNode cteInutilizacaoCT([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/cte/wsdl/CteInutilizacao")] System.Xml.XmlNode cteDadosMsg) {
            object[] results = this.Invoke("cteInutilizacaoCT", new object[] {
                        cteDadosMsg});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void cteInutilizacaoCTAsync(System.Xml.XmlNode cteDadosMsg) {
            this.cteInutilizacaoCTAsync(cteDadosMsg, null);
        }
        
        /// <remarks/>
        public void cteInutilizacaoCTAsync(System.Xml.XmlNode cteDadosMsg, object userState) {
            if ((this.cteInutilizacaoCTOperationCompleted == null)) {
                this.cteInutilizacaoCTOperationCompleted = new System.Threading.SendOrPostCallback(this.OncteInutilizacaoCTOperationCompleted);
            }
            this.InvokeAsync("cteInutilizacaoCT", new object[] {
                        cteDadosMsg}, this.cteInutilizacaoCTOperationCompleted, userState);
        }
        
        private void OncteInutilizacaoCTOperationCompleted(object arg) {
            if ((this.cteInutilizacaoCTCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.cteInutilizacaoCTCompleted(this, new cteInutilizacaoCTCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.portalfiscal.inf.br/cte/wsdl/CteInutilizacao")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.portalfiscal.inf.br/cte/wsdl/CteInutilizacao", IsNullable=false)]
    public partial class cteCabecMsg : System.Web.Services.Protocols.SoapHeader {
        
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.7905")]
    public delegate void cteInutilizacaoCTCompletedEventHandler(object sender, cteInutilizacaoCTCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.7905")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class cteInutilizacaoCTCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal cteInutilizacaoCTCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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