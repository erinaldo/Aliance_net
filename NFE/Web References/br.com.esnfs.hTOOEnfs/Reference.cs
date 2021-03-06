//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4952
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.4952.
// 
#pragma warning disable 1591

namespace srvNFE.br.com.esnfs.hTOOEnfs {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="EnfsSoap11Binding", Namespace="http://services.enfsws.es")]
    public partial class Enfs : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback esRecepcionarLoteRpsOperationCompleted;
        
        private System.Threading.SendOrPostCallback esCancelarNfseOperationCompleted;
        
        private System.Threading.SendOrPostCallback esConsultarNfseOperationCompleted;
        
        private System.Threading.SendOrPostCallback esConsultarLoteRpsOperationCompleted;
        
        private System.Threading.SendOrPostCallback esConsultarSituacaoLoteRpsOperationCompleted;
        
        private System.Threading.SendOrPostCallback esConsultarNfsePorRpsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Enfs() {
            this.Url = global::srvNFE.Properties.Settings.Default.srvNFE_br_com_esnfs_hTOOEnfs_Enfs;
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
        public event esRecepcionarLoteRpsCompletedEventHandler esRecepcionarLoteRpsCompleted;
        
        /// <remarks/>
        public event esCancelarNfseCompletedEventHandler esCancelarNfseCompleted;
        
        /// <remarks/>
        public event esConsultarNfseCompletedEventHandler esConsultarNfseCompleted;
        
        /// <remarks/>
        public event esConsultarLoteRpsCompletedEventHandler esConsultarLoteRpsCompleted;
        
        /// <remarks/>
        public event esConsultarSituacaoLoteRpsCompletedEventHandler esConsultarSituacaoLoteRpsCompleted;
        
        /// <remarks/>
        public event esConsultarNfsePorRpsCompletedEventHandler esConsultarNfsePorRpsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:esRecepcionarLoteRps", RequestNamespace="http://services.enfsws.es", ResponseNamespace="http://services.enfsws.es", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable=true)]
        public string esRecepcionarLoteRps([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string nrVersaoXml, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string xml) {
            object[] results = this.Invoke("esRecepcionarLoteRps", new object[] {
                        nrVersaoXml,
                        xml});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void esRecepcionarLoteRpsAsync(string nrVersaoXml, string xml) {
            this.esRecepcionarLoteRpsAsync(nrVersaoXml, xml, null);
        }
        
        /// <remarks/>
        public void esRecepcionarLoteRpsAsync(string nrVersaoXml, string xml, object userState) {
            if ((this.esRecepcionarLoteRpsOperationCompleted == null)) {
                this.esRecepcionarLoteRpsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnesRecepcionarLoteRpsOperationCompleted);
            }
            this.InvokeAsync("esRecepcionarLoteRps", new object[] {
                        nrVersaoXml,
                        xml}, this.esRecepcionarLoteRpsOperationCompleted, userState);
        }
        
        private void OnesRecepcionarLoteRpsOperationCompleted(object arg) {
            if ((this.esRecepcionarLoteRpsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.esRecepcionarLoteRpsCompleted(this, new esRecepcionarLoteRpsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:esCancelarNfse", RequestNamespace="http://services.enfsws.es", ResponseNamespace="http://services.enfsws.es", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable=true)]
        public string esCancelarNfse([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string nrVersaoXml, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string xml) {
            object[] results = this.Invoke("esCancelarNfse", new object[] {
                        nrVersaoXml,
                        xml});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void esCancelarNfseAsync(string nrVersaoXml, string xml) {
            this.esCancelarNfseAsync(nrVersaoXml, xml, null);
        }
        
        /// <remarks/>
        public void esCancelarNfseAsync(string nrVersaoXml, string xml, object userState) {
            if ((this.esCancelarNfseOperationCompleted == null)) {
                this.esCancelarNfseOperationCompleted = new System.Threading.SendOrPostCallback(this.OnesCancelarNfseOperationCompleted);
            }
            this.InvokeAsync("esCancelarNfse", new object[] {
                        nrVersaoXml,
                        xml}, this.esCancelarNfseOperationCompleted, userState);
        }
        
        private void OnesCancelarNfseOperationCompleted(object arg) {
            if ((this.esCancelarNfseCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.esCancelarNfseCompleted(this, new esCancelarNfseCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:esConsultarNfse", RequestNamespace="http://services.enfsws.es", ResponseNamespace="http://services.enfsws.es", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable=true)]
        public string esConsultarNfse([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string nrVersaoXml, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string xml) {
            object[] results = this.Invoke("esConsultarNfse", new object[] {
                        nrVersaoXml,
                        xml});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void esConsultarNfseAsync(string nrVersaoXml, string xml) {
            this.esConsultarNfseAsync(nrVersaoXml, xml, null);
        }
        
        /// <remarks/>
        public void esConsultarNfseAsync(string nrVersaoXml, string xml, object userState) {
            if ((this.esConsultarNfseOperationCompleted == null)) {
                this.esConsultarNfseOperationCompleted = new System.Threading.SendOrPostCallback(this.OnesConsultarNfseOperationCompleted);
            }
            this.InvokeAsync("esConsultarNfse", new object[] {
                        nrVersaoXml,
                        xml}, this.esConsultarNfseOperationCompleted, userState);
        }
        
        private void OnesConsultarNfseOperationCompleted(object arg) {
            if ((this.esConsultarNfseCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.esConsultarNfseCompleted(this, new esConsultarNfseCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:esConsultarLoteRps", RequestNamespace="http://services.enfsws.es", ResponseNamespace="http://services.enfsws.es", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable=true)]
        public string esConsultarLoteRps([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string nrVersaoXml, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string xml) {
            object[] results = this.Invoke("esConsultarLoteRps", new object[] {
                        nrVersaoXml,
                        xml});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void esConsultarLoteRpsAsync(string nrVersaoXml, string xml) {
            this.esConsultarLoteRpsAsync(nrVersaoXml, xml, null);
        }
        
        /// <remarks/>
        public void esConsultarLoteRpsAsync(string nrVersaoXml, string xml, object userState) {
            if ((this.esConsultarLoteRpsOperationCompleted == null)) {
                this.esConsultarLoteRpsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnesConsultarLoteRpsOperationCompleted);
            }
            this.InvokeAsync("esConsultarLoteRps", new object[] {
                        nrVersaoXml,
                        xml}, this.esConsultarLoteRpsOperationCompleted, userState);
        }
        
        private void OnesConsultarLoteRpsOperationCompleted(object arg) {
            if ((this.esConsultarLoteRpsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.esConsultarLoteRpsCompleted(this, new esConsultarLoteRpsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:esConsultarSituacaoLoteRps", RequestNamespace="http://services.enfsws.es", ResponseNamespace="http://services.enfsws.es", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable=true)]
        public string esConsultarSituacaoLoteRps([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string nrVersaoXml, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string xml) {
            object[] results = this.Invoke("esConsultarSituacaoLoteRps", new object[] {
                        nrVersaoXml,
                        xml});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void esConsultarSituacaoLoteRpsAsync(string nrVersaoXml, string xml) {
            this.esConsultarSituacaoLoteRpsAsync(nrVersaoXml, xml, null);
        }
        
        /// <remarks/>
        public void esConsultarSituacaoLoteRpsAsync(string nrVersaoXml, string xml, object userState) {
            if ((this.esConsultarSituacaoLoteRpsOperationCompleted == null)) {
                this.esConsultarSituacaoLoteRpsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnesConsultarSituacaoLoteRpsOperationCompleted);
            }
            this.InvokeAsync("esConsultarSituacaoLoteRps", new object[] {
                        nrVersaoXml,
                        xml}, this.esConsultarSituacaoLoteRpsOperationCompleted, userState);
        }
        
        private void OnesConsultarSituacaoLoteRpsOperationCompleted(object arg) {
            if ((this.esConsultarSituacaoLoteRpsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.esConsultarSituacaoLoteRpsCompleted(this, new esConsultarSituacaoLoteRpsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:esConsultarNfsePorRps", RequestNamespace="http://services.enfsws.es", ResponseNamespace="http://services.enfsws.es", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable=true)]
        public string esConsultarNfsePorRps([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string nrVersaoXml, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string xml) {
            object[] results = this.Invoke("esConsultarNfsePorRps", new object[] {
                        nrVersaoXml,
                        xml});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void esConsultarNfsePorRpsAsync(string nrVersaoXml, string xml) {
            this.esConsultarNfsePorRpsAsync(nrVersaoXml, xml, null);
        }
        
        /// <remarks/>
        public void esConsultarNfsePorRpsAsync(string nrVersaoXml, string xml, object userState) {
            if ((this.esConsultarNfsePorRpsOperationCompleted == null)) {
                this.esConsultarNfsePorRpsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnesConsultarNfsePorRpsOperationCompleted);
            }
            this.InvokeAsync("esConsultarNfsePorRps", new object[] {
                        nrVersaoXml,
                        xml}, this.esConsultarNfsePorRpsOperationCompleted, userState);
        }
        
        private void OnesConsultarNfsePorRpsOperationCompleted(object arg) {
            if ((this.esConsultarNfsePorRpsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.esConsultarNfsePorRpsCompleted(this, new esConsultarNfsePorRpsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void esRecepcionarLoteRpsCompletedEventHandler(object sender, esRecepcionarLoteRpsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class esRecepcionarLoteRpsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal esRecepcionarLoteRpsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void esCancelarNfseCompletedEventHandler(object sender, esCancelarNfseCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class esCancelarNfseCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal esCancelarNfseCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void esConsultarNfseCompletedEventHandler(object sender, esConsultarNfseCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class esConsultarNfseCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal esConsultarNfseCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void esConsultarLoteRpsCompletedEventHandler(object sender, esConsultarLoteRpsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class esConsultarLoteRpsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal esConsultarLoteRpsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void esConsultarSituacaoLoteRpsCompletedEventHandler(object sender, esConsultarSituacaoLoteRpsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class esConsultarSituacaoLoteRpsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal esConsultarSituacaoLoteRpsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void esConsultarNfsePorRpsCompletedEventHandler(object sender, esConsultarNfsePorRpsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class esConsultarNfsePorRpsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal esConsultarNfsePorRpsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591