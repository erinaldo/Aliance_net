﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Parametros.Diversos {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.8.0.0")]
    internal sealed partial class configIntegracao : global::System.Configuration.ApplicationSettingsBase {
        
        private static configIntegracao defaultInstance = ((configIntegracao)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new configIntegracao())));
        
        public static configIntegracao Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string cd_empresa {
            get {
                return ((string)(this["cd_empresa"]));
            }
            set {
                this["cd_empresa"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string nm_empresa {
            get {
                return ((string)(this["nm_empresa"]));
            }
            set {
                this["nm_empresa"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string cd_tabelapreco {
            get {
                return ((string)(this["cd_tabelapreco"]));
            }
            set {
                this["cd_tabelapreco"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ds_tabelapreco {
            get {
                return ((string)(this["ds_tabelapreco"]));
            }
            set {
                this["ds_tabelapreco"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string path_arquivo {
            get {
                return ((string)(this["path_arquivo"]));
            }
            set {
                this["path_arquivo"] = value;
            }
        }
    }
}