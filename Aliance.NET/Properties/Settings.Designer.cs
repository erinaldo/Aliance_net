//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aliance.NET.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.DateTime DT_SERVIDOR {
            get {
                return ((global::System.DateTime)(this["DT_SERVIDOR"]));
            }
            set {
                this["DT_SERVIDOR"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost/ws_licenca/WS_Licenca.asmx")]
        public string Aliance_NET_WS_Licenca_WS_Licenca {
            get {
                return ((string)(this["Aliance_NET_WS_Licenca_WS_Licenca"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("pt-BR")]
        public string CULTURA {
            get {
                return ((string)(this["CULTURA"]));
            }
            set {
                this["CULTURA"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SERVIDOR_BD {
            get {
                return ((string)(this["SERVIDOR_BD"]));
            }
            set {
                this["SERVIDOR_BD"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string BANCO_DADOS {
            get {
                return ((string)(this["BANCO_DADOS"]));
            }
            set {
                this["BANCO_DADOS"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string PATH_ARQ {
            get {
                return ((string)(this["PATH_ARQ"]));
            }
            set {
                this["PATH_ARQ"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://192.9.100.254/ws_helpdesk/WS_HelpDesk.asmx")]
        public string Aliance_NET_WS_HelpDesk_WS_HelpDesk {
            get {
                return ((string)(this["Aliance_NET_WS_HelpDesk_WS_HelpDesk"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string EmailContador {
            get {
                return ((string)(this["EmailContador"]));
            }
            set {
                this["EmailContador"] = value;
            }
        }
    }
}
